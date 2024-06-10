using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    public static GamePanel instance;

    public Light light;
    public Text txtName;

    public Button btnAtk;
    public Button btnChangeName;
    public Button btnBag;

    public PlayerObj player;
    public Toggle togSoundOn;
    public Toggle togSoundoff;
    public ToggleGroup togGroup;

    public Slider sliderSound;
    public Dropdown ddChange;

    public LongPress LongPress;

    public GameObject imgRoot; // 进度条根对象 用于控制显隐
    public RectTransform imgBk; // 进度条对象 用于控制进度


    private bool isDown;
    private float nowTime;
    public float addSpeed = 10f;
    private int hp = 10;

    public RectTransform imgJoy; // 摇杆位置
    public EventTrigger et; // 摇杆事件相关
    private void Awake()
    {
        instance = this;
        imgRoot.gameObject.SetActive(false); // 一开始蓄能条隐藏
    }

    // Start is called before the first frame update
    void Start()
    {
        btnAtk.onClick.AddListener(() =>
        {
            // 得到玩家 进行开火
            player.Fire();
        });
        btnChangeName.onClick.AddListener(() =>
        {
            // 显示改名面板
            ChangeNamePanel.instance.gameObject.SetActive(true);
            HideMe();
        });
        togSoundOn.onValueChanged.AddListener(TogChangeValue);
        togSoundoff.onValueChanged.AddListener(TogChangeValue);

        // 初始化Slider的值
        sliderSound.value = MusicData.Instance.soundValue;
        // 监听滑动条的改变
        sliderSound.onValueChanged.AddListener((f) =>
        {
            // 处理音效大小
            MusicData.Instance.soundValue = f;
        });


        btnBag.onClick.AddListener(() =>
        {
            // 打开背包面版
            BagPanel.instance.gameObject.SetActive(true);
            HideMe();
        });

        ddChange.onValueChanged.AddListener((value) =>
        {
            switch (value)
            {
                case 0:
                    light.intensity = 1f;
                    break;
                case 1:
                    light.intensity = 0.1f;
                    break;
                default:
                    break;
            }
        });
        LongPress.downEvent += BtnDown;
        LongPress.upEvent += BtnUp;
    }
    private void TogChangeValue(bool v)
    {
        // 得到当前激活的toggle
        foreach (var item in togGroup.ActiveToggles())
        {
            if (item == togSoundOn)
            {
                MusicData.Instance.SoundIsOpen = true;
            }
            else if (item == togSoundoff)
            {
                MusicData.Instance.SoundIsOpen = false;
            }
        }
    }

    private void BtnDown()
    {
        isDown = true;
        imgBk.sizeDelta = new Vector2(0, 100);
    }

    private void BtnUp()
    {
        isDown = false;
        imgRoot.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isDown)
        {
            // 计时
            nowTime += Time.deltaTime;
            if (nowTime >= 0.2f)
            {
                imgRoot.gameObject.SetActive(true);
                //蓄能条增加
                imgBk.sizeDelta += new Vector2(addSpeed * Time.deltaTime, 0);
                if (imgBk.sizeDelta.x >= 800f)
                {
                    // HP增加 条清空
                    hp += 10;
                    print("当前HP" + hp);
                    imgBk.sizeDelta = new Vector2(0, 100);
                }
            }
        }

        // 为摇杆注册事件
        // 拖动中
        EventTrigger.Entry dragEntry = new EventTrigger.Entry();
        dragEntry.eventID = EventTriggerType.Drag;
        dragEntry.callback.AddListener(JoyDrag);
        et.triggers.Add(dragEntry);

        // 结束拖动
        EventTrigger.Entry endDragEntry = new EventTrigger.Entry();
        endDragEntry.eventID = EventTriggerType.EndDrag;
        endDragEntry.callback.AddListener(EndJoyDrag);
        et.triggers.Add(endDragEntry);
    }

    public void ShowMe()
    {
        this.gameObject.SetActive(true);
    }

    public void HideMe()
    {
        this.gameObject.SetActive(false);
    }

    private void JoyDrag(BaseEventData data)
    {
        PointerEventData eventData = data as PointerEventData;

        // 以前的知识 是通过加上 鼠标偏移的位置 让图标动起来
        //imgJoy.localPosition += new Vector3(eventData.delta.x , eventData.delta.y, 0);

        // 用新知识点制作
        Vector2 nowPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imgJoy.parent as RectTransform,
            eventData.position,
            eventData.enterEventCamera,
            out nowPos);
        imgJoy.localPosition = nowPos;

        //我们有专门的参数 得到相对于锚点的点
        if (imgJoy.anchoredPosition.magnitude > 90)
        {
            //拉回来
            //单位向量 乘以 长度 = 临界位置
            imgJoy.anchoredPosition = imgJoy.anchoredPosition.normalized * 90;
        }

        //让玩家移动
        player.Move(imgJoy.anchoredPosition);

    }
    private void EndJoyDrag(BaseEventData data)
    {
        // 回归中心点
        imgJoy.anchoredPosition = Vector2.zero;
        player.Move(Vector2.zero);
    }
}
