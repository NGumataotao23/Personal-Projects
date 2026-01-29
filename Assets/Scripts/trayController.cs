using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class trayController : MonoBehaviour
{
    [SerializeField] GameObject trayHeld;
    public GameObject inputTray;
    [SerializeField] GameObject outputTray;

    [SerializeField] GameObject animationCollider;

    [SerializeField] textFadeIn trayFade;
    [SerializeField] textFadeIn hatchFade;
    [SerializeField] textFadeIn endFade;

    [SerializeField] MeatCutterPig pigCut;
    [SerializeField] MeatCutterCow cowCut;
    [SerializeField] IfInteractable ifInter;
    [SerializeField] Interactor interactor;

    [SerializeField] GameObject door;
    public bool trayPicked = false;
    public static bool doorOpenB = true;

    public int whatTray = 0;
    void Update()
    {
        trayControl();
    }
    private void trayControl()
    {
        textPopups();
        if (Input.GetKeyDown(KeyCode.E) && interactor.isInteractable)
        {
            if(ifInter.whatwasHit() == "trayDetector")
            {
                trayHeld.SetActive(true);
                animationCollider.SetActive(true);
                trayPickup(whatTray);
                
                trayPicked = true;

            }
            else if(ifInter.whatwasHit() == "trayTrigger")
            {
                inputTray.SetActive(false);
                trayHeld.SetActive(false);
                outputTray.SetActive(true);
                
            }
            
        }
    }
    private void doorOpen(){door.SetActive(true); doorOpenB = true; }
    public void startTextPop() {StartCoroutine(textPop());}
    private IEnumerator textPop()
    {
        yield return new WaitForSeconds(2f);
        endFade.getHighlightedObject(0.5f, true);
        yield return new WaitForSeconds(5f);
        endFade.getHighlightedObject(0.5f, false);
        yield return new WaitForSeconds(5f);
        doorOpen();
        yield return null;

    }
    private void textPopups()
    {
        if (ifInter.whatwasHit() == "trayDetector")
        {
            trayFade.getHighlightedObject(0.5f, true);
        }
        else if(ifInter.whatwasHit() != "trayDetector")
        {
            trayFade.getHighlightedObject(0.5f, false);
        }
        if (ifInter.whatwasHit() == "trayTrigger")
        {
            hatchFade.getHighlightedObject(0.5f, true);
        }
        else if (ifInter.whatwasHit() != "trayTrigger")
        {
            hatchFade.getHighlightedObject(0.5f, false);
        }
    }
    private void trayPickup(int tray)
    {
        switch (tray)
        {
            case 1:
                pigCut.trayBox.SetActive(false);
                pigCut.pChops.SetActive(false);
                pigCut.sRibs.SetActive(false);
                pigCut.pBelly.SetActive(false);
                pigCut.pLoin.SetActive(false);
                pigCut.sirloin.SetActive(false);
                pigCut.ham.SetActive(false);
                pigCut.pCutlets.SetActive(false);
                break;
            case 2:
                cowCut.trayBox.SetActive(false);
                cowCut.sTip.SetActive(false);
                cowCut.brrBeef.SetActive(false);
                cowCut.tTip.SetActive(false);
                cowCut.tSirloin.SetActive(false);
                cowCut.fMignon.SetActive(false);
                cowCut.sRibsCow.SetActive(false);
                cowCut.ribeye.SetActive(false);
                cowCut.brisket.SetActive(false);
                break;

        }


    }
  
}
