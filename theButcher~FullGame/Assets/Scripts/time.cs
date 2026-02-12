using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class time : MonoBehaviour
{
    [SerializeField] static float globaltime = 0.00f;
    private float result;
    private void Start()
    {
        
        globaltime = 0f;
    }

    void Update()
    {
        
        globaltime += Time.deltaTime;
        result = MathF.Round(globaltime,2);
        if (Input.GetKeyDown(KeyCode.G)) {
            Debug.Log(captureTime());
        }
        
    }
    public float captureTime()
    {
        float currentTime = result;
        globaltime = 0f;
        return currentTime;
    }
}
