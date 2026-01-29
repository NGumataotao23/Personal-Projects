using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class MeatCutterPig : MonoBehaviour
{
    public GameObject pChops;
    public GameObject sRibs;
    public GameObject pBelly;
    public GameObject pLoin;
    public GameObject sirloin;
    public GameObject ham;
    public GameObject pCutlets;

    public GameObject trayBox;

    [SerializeField] textFadeIn completeFade;
    [SerializeField] trayController controller;
    private bool notifyPlayed;
    private int meatCounter = 0;
    [SerializeField] int trayCount = 0;

    void Update()
    {
        meatSelector(meatCounter);
        if(trayCount  ==  7 && !controller.trayPicked)
        {
            trayBox.SetActive(true);
            controller.whatTray = 1;
            if (!notifyPlayed)
            {
                StartCoroutine(Complete());
            }
            
        }
    }
    public void meatSelector(int meatCounter)
    {
        switch (meatCounter)
        {
            case 1: pChops.SetActive(true); trayCount++; break;
            case 2: sRibs.SetActive(true); trayCount++; break;
            case 3: pBelly.SetActive(true); trayCount++; break;
            case 4: pLoin.SetActive(true); trayCount++; break;
            case 5: sirloin.SetActive(true); trayCount++; break;
            case 6: ham.SetActive(true); trayCount++; break;
            case 7: pCutlets.SetActive(true); trayCount++; break;
        }
    }
    private IEnumerator Complete()
    {
        notifyPlayed = true;
        completeFade.getHighlightedObject(0.5f, true);
        yield return new WaitForSeconds(5f);
        completeFade.getHighlightedObject(0.5f, false);
        yield return new WaitForSeconds(5f);
        yield return null;
    }
}
