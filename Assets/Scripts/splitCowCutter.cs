using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splitCowCutter : MonoBehaviour
{

    [SerializeField] IfInteractable ifInter;
    [SerializeField] Interactor interactor;
    [SerializeField] MeatCutterCow meat;

    [SerializeField] GameObject sTip;
    [SerializeField] GameObject brRoast;
    [SerializeField] GameObject tTip;
    [SerializeField] GameObject tSirloin;
    [SerializeField] GameObject filet;
    [SerializeField] GameObject shortRib;
    [SerializeField] GameObject ribeye;
    [SerializeField] GameObject brisket;

    [SerializeField] GameObject filetRe;
    [SerializeField] GameObject brisketRe;


    void Update()
    {
        scowController();

    }
    void scowController()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactor.isInteractable)
        {
            switch (ifInter.isHolding)
            {
                //Cleaver
                case 1:
                    if (ifInter.whatwasHit() == "CUTSIRLOINTIP")
                    {
                        sTip.SetActive(false);
                        meat.meatSelector(1);
                        break;
                    }
                    if (ifInter.whatwasHit() == "CUTROASTBEEF")
                    {
                        brRoast.SetActive(false);
                        meat.meatSelector(2);
                        break;
                    }
                    else if (ifInter.whatwasHit() == "CUTSHORTRRIB")
                    {
                        shortRib.SetActive(false);
                        meat.meatSelector(6);
                        break;
                    }
                    break;
                //Knife 
                case 2:
                    if (ifInter.whatwasHit() == "CUTRIBEYE")
                    {
                        ribeye.SetActive(false);
                        meat.meatSelector(7);
                        break;
                    }
                    else if (ifInter.whatwasHit() == "CUTTRITIP")
                    {
                        tTip.SetActive(false);
                        meat.meatSelector(3);
                        break;
                    }
                    else if (ifInter.whatwasHit() == "CUTSIRLOIN")
                    {
                        tSirloin.SetActive(false);
                        meat.meatSelector(4);
                        break;
                    }
                    else if (ifInter.whatwasHit() == "CUTFILETDEFAULT")
                    {
                        filet.SetActive(false);
                        filetRe.SetActive(true);
                        meat.meatSelector(5);
                        break;
                    }
                    else if (ifInter.whatwasHit() == "CUTBRISKETCUT")
                    {
                        brisket.SetActive(false);
                        brisketRe.SetActive(true);
                        meat.meatSelector(8);
                        break;
                    }
                    break;
                //Saw
                case 3:
                    break;
                //Scissors
                case 4:
                    break;
            }
        }
    }
}
