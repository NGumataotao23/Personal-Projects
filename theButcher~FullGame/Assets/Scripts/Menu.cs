using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    

    [SerializeField] IfInteractable If;
    [SerializeField] trayController tray;
    [SerializeField] time timer;
    [SerializeField]
    private float sceneFadeDuration;
    [SerializeField] sceneFade sceneFade1;


    public static int sceneBefore;
    public static string getTime;
    private void Awake()
    {
        sceneFade1 = FindObjectOfType<sceneFade>();
    }
    private IEnumerator Start()
    {
        yield return sceneFade1.fadeIn(sceneFadeDuration);
    }
    
    public void play()
    {
        StartCoroutine(FadeoutDoor());
        SceneManager.LoadSceneAsync(1);

    }
    public void Update()
    {
        
            sceneChange();

    } 
    public void sceneChange()
    {
        if (trayController.doorOpenB == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && If.whatwasHit() == "Door1" && If.interact.isInteractable)
            {
                trayController.doorOpenB = false;
                sceneBefore = 1;
                
                getTime = calcMins(timer.captureTime());
                
                StartCoroutine(FadeoutDoor());
                
            }
            else if (Input.GetKeyDown(KeyCode.E) && If.whatwasHit() == "Door2" && If.interact.isInteractable)
            {
                trayController.doorOpenB = false;
                sceneBefore = 2;
                getTime = calcMins(timer.captureTime());
                StartCoroutine(FadeoutDoor());

            }
            else if (Input.GetKeyDown(KeyCode.E) && If.whatwasHit() == "Door3" && If.interact.isInteractable)
            {
                trayController.doorOpenB = false;
                sceneBefore = 3;
                
                getTime = calcMins(timer.captureTime());
                StartCoroutine(FadeoutDoor());

            }
        }
    }
    private IEnumerator FadeoutDoor()
    {
        yield return sceneFade1.fadeOut(sceneFadeDuration);
        Debug.Log("fadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(5);
    }
    private string calcMins(float time)
    {
        
        float mins = (time / 60);
        if(mins < 0) mins = 0;
        mins = MathF.Round(mins, 0);
        float secs = (time % 60);
        secs = MathF.Round(secs, 0);
        string total =  mins.ToString() + ":" + secs.ToString();
        Debug.Log(total);
        return total;
    }


}

