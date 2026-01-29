//Script for Player movement
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.TimeZoneInfo;

public class CameraController : MonoBehaviour
{
    public Camera deskCam;
    public Camera playerCam;
    public PlayerMovement player;
    public PlayerCam playCam;

    //Any textFadeIn components are used to fade in certain text elements
    [SerializeField] textFadeIn fade1;
    [SerializeField] textFadeIn fade2;
    [SerializeField] textFadeIn fade3;

    [SerializeField] RawImage crosshair;
    
    [SerializeField] Interactor camDetector;
    [SerializeField] IfInteractable whatisCamera;
    public Transform cam1;
    public Transform cam2;

    public bool atComputer = false;

    public int manager;

    public void Start()
    {
        
        deskCam.enabled = false;
        
    }
    
    public void Update()
    {
        deskTextPopUp();
        //checks if player is looking a the desk and also checks for pressing of 'E' key
        if (Input.GetKeyDown(KeyCode.E) && camDetector.isInteractable && whatisCamera.whatwasHit() == "Computer" && !atComputer)
        {
            atDesk();
            
        }
        else if (Input.GetKeyDown(KeyCode.E) && atComputer) { 

            awayDesk();
            
        }
        
    }
    private void deskTextPopUp()
    {
        switch (whatisCamera.whatwasHit())
        {
            //Fades text in if player is currently looking at the computer if not fade the text out
            case "Computer":
                fade1.getHighlightedObject(0.1f, true);
                break;
            default:
                fade1.getHighlightedObject(0.1f, false);
                break;
        }
        if (atComputer)
        {
            fade1.getHighlightedObject(0.1f, false);
            
        }
        else
        {
            fade3.getHighlightedObject(0.5f, false);
        }

    }


    public void atDesk()
    {

        lockMovement();
        playerCam.enabled = false;
        deskCam.enabled = true;
        atComputer = true;
        fade2.getHighlightedObject(0.1f, true);
        

    }
    public void awayDesk()
    {

        unLockMov();
        playerCam.enabled = true;
        deskCam.enabled = false;
        atComputer = false;
        
    }

    public void lockMovement()
    {
        crosshair.enabled = false;
        player.moveSpeed = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void unLockMov()
    {
        
        crosshair.enabled = true;
        player.moveSpeed = 5f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
