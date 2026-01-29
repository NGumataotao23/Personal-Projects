using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionsMenu : MonoBehaviour
{
    public int targetFPS = 144;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFPS;
    }
}
