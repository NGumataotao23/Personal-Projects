using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using static System.Net.WebRequestMethods;

public class optionsMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject socialsMenu;

    [SerializeField] TextMeshProUGUI valueText1;
    [SerializeField] TextMeshProUGUI valueText2;

    [SerializeField] GameObject hintCheck;
    [SerializeField] public bool hintsActive = false;

    [SerializeField] AudioMixer Mixer;
    

    private void Start()
    {
        Resolution currentRes = Screen.currentResolution;

        int width = currentRes.width;
        int height = currentRes.height;

        PlayerPrefs.DeleteAll();

        double refreshRate = currentRes.refreshRateRatio.value;

        QualitySettings.vSyncCount = 0;
        Debug.Log($"Detected Resolution: {width}x{height} @ {refreshRate:F2} Hz");
        Screen.SetResolution(width,height,true);
        Application.targetFrameRate = ((int)refreshRate);
    }
    public void showOptions()
    {
        settingsMenu.SetActive(true);
    }
    public void hideOptions()
    {
        settingsMenu.SetActive(false);
    }
    public void hintsON()
    {
        if (hintsActive)
        {
            hintCheck.SetActive(false);
            hintsActive = false;
            PlayerPrefs.SetInt("hint", 0);
            PlayerPrefs.Save();
        }
        else if (!hintsActive)
        {
            hintCheck.SetActive(true);
            hintsActive = true;
            PlayerPrefs.SetInt("hint", 1);
            PlayerPrefs.Save();
        }
    }
    
    public void quitGame(){
    
        Application.Quit();
    
    }
    public void socialHypers(int x)
    {

        switch (x)
        {
            case 1:
                Application.OpenURL("https://dave-winters.itch.io");
                break;
            case 2:
                Application.OpenURL("https://www.youtube.com/@DaveWintersDev");
                break;
            case 3:
                Application.OpenURL("https://x.com/DaveWintersDev");
                break;
            case 4:
                socialsMenu.SetActive(true);
                break;
            case 5:
                socialsMenu.SetActive(false);
                break;
        }
         
    }

    public void audioController1(float value)
    {
        valueText1.SetText($"{(value * 100).ToString("N0")}");
        Mixer.SetFloat("sfx", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("sfxVolume", value);
        PlayerPrefs.Save();

    }
    public void audioController2(float value)
    {
        valueText2.SetText($"{(value * 100).ToString("N0")}");

        //Logarithmic Scale in which Humans percieve sounds
        Mixer.SetFloat("music", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("musicVolume", value);
        PlayerPrefs.Save();
    }

}
