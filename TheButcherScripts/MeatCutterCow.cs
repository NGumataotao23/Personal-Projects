using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MeatCutterCow : MonoBehaviour
{
    public GameObject sTip;
    public GameObject brrBeef;
    public GameObject tTip;
    public GameObject tSirloin;
    public GameObject fMignon;
    public GameObject sRibsCow;
    public GameObject ribeye;
    public GameObject brisket;

    public GameObject trayBox;

    [SerializeField] textFadeIn completeFade;
    [SerializeField] trayController controller;
    private bool notifyPlayed;
    

    public int meatCounter = 0;
    private int trayCount = 0;

    void Update()
    {
       
        meatSelector(meatCounter);
        if (trayCount == 7)
        {
            trayBox.SetActive(true);
        }
    }
    public void meatSelector(int meatCounter)
    {
        switch (meatCounter)
        {
           
            case 1: sTip.SetActive(true); trayCount++; break;
            case 2: brrBeef.SetActive(true); trayCount++; break;
            case 3: tTip.SetActive(true); trayCount++; break;
            case 4: tSirloin.SetActive(true); trayCount++; break;
            case 5: fMignon.SetActive(true); trayCount++; break;
            case 6: sRibsCow.SetActive(true); trayCount++; break;
            case 7: ribeye.SetActive(true); trayCount++; break;
            case 8: brisket.SetActive(true); trayCount++; break;

        }
    }
}
