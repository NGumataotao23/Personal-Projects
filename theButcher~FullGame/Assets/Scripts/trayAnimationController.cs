using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class trayAnimationController : MonoBehaviour
{
    [SerializeField] Animator trayAnimator;
    [SerializeField] trayController controller;
    
    [SerializeField] AudioSource doorSFX;
    [SerializeField] AudioClip doorSFXA;
    [SerializeField] AudioClip doorSFXB;

    private bool triggered = false;
    
    private void Start()
    {
        
    }
    public void trayPlace()
    {
        controller.inputTray.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            Debug.Log("in");
            
            trayAnimator.SetBool("playOpen", true);
            doorSFX.clip = doorSFXA;
            doorSFX.Play();
            trayAnimator.SetBool("isOpen", true);
            triggered = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !controller.trayPicked)
        {
            trayAnimator.SetBool("playClose", true);
            doorSFX.clip = doorSFXB;
            doorSFX.Play();
            trayAnimator.SetBool("isClose", true);
            trayAnimator.SetBool("playOpen", false);
            controller.startTextPop();
            this.gameObject.SetActive(false);


        }
    }

    
}
