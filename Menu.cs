using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
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
    public static double getTime;
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
                getTime = timer.captureTime();
                Debug.Log(getTime);
                StartCoroutine(FadeoutDoor());
                
            }
            else if (Input.GetKeyDown(KeyCode.E) && If.whatwasHit() == "Door2" && If.interact.isInteractable)
            {
                trayController.doorOpenB = false;
                sceneBefore = 2;
                getTime = timer.captureTime();
                StartCoroutine(FadeoutDoor());

            }
            else if (Input.GetKeyDown(KeyCode.E) && If.whatwasHit() == "Door3" && If.interact.isInteractable)
            {
                trayController.doorOpenB = false;
                sceneBefore = 3;
                getTime = timer.captureTime();
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


}

