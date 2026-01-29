using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class MeatCutterHuman : MonoBehaviour
{
    public GameObject chuck;
    public GameObject shoulder;
    public GameObject rib;
    public GameObject abdomen;
    public GameObject butt;
    public GameObject round;
    public GameObject shank;

    [SerializeField] GameObject trayBox;


    public int meatCounter = 0;
    private int trayCount;

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
            case 1: chuck.SetActive(true); trayCount++; break;
            case 2: shoulder.SetActive(true); trayCount++; break;
            case 3: rib.SetActive(true); trayCount++; break;
            case 4: abdomen.SetActive(true); trayCount++; break;
            case 5: butt.SetActive(true); trayCount++; break;
            case 6: round.SetActive(true); trayCount++; break;
            case 7: shank.SetActive(true); trayCount++; break;
        }
    }
}
