using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows.WebCam;

public class PigCutter : MonoBehaviour
{
    [SerializeField] IfInteractable ifInter;
    [SerializeField] Interactor interactor;

    [SerializeField] bleeding playBleed;

    [SerializeField] textFadeIn fade;
    [SerializeField] textFadeIn fade2;

    public GameObject pig1;
    public GameObject carryPig;
    public GameObject pig2;
    public GameObject pig3;
    public GameObject pig4;
    public GameObject pig5;
    public GameObject pig6;
    public GameObject pig7;

    [SerializeField] GameObject boardTrigger;
    [SerializeField] GameObject lockTrigger;

    [SerializeField] bool hangPigDone = false;
    public bool isBled = false;
    private bool msgDis = false;
    [SerializeField] bool carrying = false;
    [SerializeField] bool beheaded = false;

    
    
    void Update()
    {
        cutPig();
        hangPig();
        putBack();
    }
    private void cutPig()
    {
        textPopup();
        if (interactor.isInteractable)
        {
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

               
                switch (ifInter.whatwasHit())
                {

                    case "Pig1":
                        if (isBled && !hangPigDone )
                        {
                            
                            pig1.SetActive(false);
                            carryPig.SetActive(true);
                            lockTrigger.SetActive(true);
                            carrying = true;
                            break;
                        }
                        else if (hangPigDone && (ifInter.isHolding == 2))
                        {
                            pig1.SetActive(false);
                            pig2.SetActive(true);
                            boardTrigger.SetActive(false);
                            break;
                        }
                        else if((ifInter.isHolding == 2))
                        {
                            StartCoroutine(playBleed.PlayBlood(1));
                        }
                        break;
                    
                }
            }
            if (ifInter.isHolding == 3 && Input.GetKeyDown(KeyCode.Mouse0))
            {
                switch (ifInter.whatwasHit())
                {
                    case "Pig2":
                        beheaded = true;
                        pig2.SetActive(false);
                        pig3.SetActive(true);
                        break;
                    case "Pig4":
                        pig4.SetActive(false);
                        pig5.SetActive(true);
                        break;
                    case "Pig5":
                        pig5.SetActive(false);
                        pig6.SetActive(true);
                        break;

                }

            }
            if(ifInter.isHolding == 4 && Input.GetKeyDown(KeyCode.Mouse0) && ifInter.whatwasHit() == "Pig3"){
                if (beheaded)
                {
                    pig3.SetActive(false);
                    pig4.SetActive(true);
                }
            }
            
        }
    }
    private void hangPig()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (interactor.isInteractable && ifInter.whatwasHit() == "lockTrigger" && !hangPigDone)
            {
                carryPig.SetActive(false);
                if (ifInter.isHolding != 0)
                {
                    ifInter.enableTool(ifInter.isHolding);
                }
                pig7.SetActive(true);
                playBleed.blood3.SetActive(true);
                msgDis = true;
                StartCoroutine(hangPigWait(4f));
            }
            else if (interactor.isInteractable && ifInter.whatwasHit() == "lockTrigger" && hangPigDone)
            {
                carryPig.SetActive(true);
                
                ifInter.disableTool(ifInter.isHolding);
                pig7.SetActive(false);
                lockTrigger.SetActive(false);
                boardTrigger.SetActive(true);
            }
        }
    }
    private void putBack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (interactor.isInteractable && ifInter.whatwasHit() == "BoardTrigger")
            {
                pig1.SetActive(true);
                carryPig.SetActive(false);
                ifInter.enableTool(ifInter.isHolding);
                boardTrigger.SetActive(false);
                carrying = false;
                isBled = true;
            }
        }
    }
    private void textPopup()
    {
        
        //If the player is carrying the pig and is looking at the locker 
        if(carrying && !msgDis)
        {
            if (ifInter.whatwasHit() == "lockTrigger") { fade.getHighlightedObject(0.5f, true); }
            
        }
        if (msgDis && carrying)
        {
            if (ifInter.whatwasHit() != "lockTrigger") { fade.getHighlightedObject(0.5f, false); }
        }
        if (isBled && !hangPigDone)
        {
            if (ifInter.whatwasHit() == "Pig1") { fade2.getHighlightedObject(0.5f, true); }
            else if (ifInter.whatwasHit() != "Pig1") { fade2.getHighlightedObject(0.5f, false); }
        }
    }
    private IEnumerator hangPigWait(float i)
    {
        
        
        yield return new WaitForSeconds(i);
        hangPigDone = true;
        yield return null;
    }
}
