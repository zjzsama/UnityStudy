using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Lesson_ExecuteAlways : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake");
    }
    private void OnGUI()
    {
        Debug.Log("OnGUI");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }
    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }
    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }
}
