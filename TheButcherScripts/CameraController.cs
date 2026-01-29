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

    [SerializeField] textFadeIn fade1;
    [SerializeField] textFadeIn fade2;
    [SerializeField] textFadeIn fade3;

    [SerializeField] RawImage crosshair;
    
    [SerializeField] Interactor camDetector;
    [SerializeField] IfInteractable whatisCamera;
    public Transform cam1;
    public Transform cam2;

    Quaternion toRot;
    Vector3 toPos;

    

    public bool atComputer = false;

    public int manager;

    public void Start()
    {
        
        deskCam.enabled = false;
        
    }
    
    public void Update()
    {
        deskTextPopUp();
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
    
    public Vector3 getPlayerPos()
    {
        Vector3 fromPlayerPos = playerCam.transform.position;
        return fromPlayerPos;
    }
    public Quaternion getPlayerRot()
    {
        Quaternion fromPlayRot = playerCam.transform.rotation;
        return fromPlayRot;
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
