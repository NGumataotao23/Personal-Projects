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
    private double result;
    private void Start()
    {
        
        globaltime = 0f;
    }

    void Update()
    {
        
        globaltime += Time.deltaTime;
        result = Math.Round(globaltime,2);
        if (Input.GetKeyDown(KeyCode.G)) {
            Debug.Log(captureTime());
        }
        
    }
    public double captureTime()
    {
        double currentTime = result;
        globaltime = 0f;
        return currentTime;
    }
}
