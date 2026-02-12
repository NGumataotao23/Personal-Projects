using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class splitpigCutter : MonoBehaviour
{
    
    [SerializeField] IfInteractable ifInter;
    [SerializeField] Interactor interactor;
    [SerializeField] MeatCutterPig meat;

    [SerializeField] GameObject pChops;
    [SerializeField] GameObject sRibs;
    [SerializeField] GameObject pBelly;
    [SerializeField] GameObject pLoin;
    [SerializeField] GameObject sirloin;
    [SerializeField] GameObject ham;
    [SerializeField] GameObject cutlets;
    [SerializeField] GameObject cutletsRe;
    [SerializeField] GameObject sRibRe;
    [SerializeField] GameObject hamRe;

    
    void Update()
    {
        spigController();
        
    }
    void spigController()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && interactor.isInteractable){
            switch (ifInter.isHolding)
            {
                //Cleaver
                case 1:
                    if (ifInter.whatwasHit() == "CUTRIGHTLEGDEFAULT")
                    {
                        sirloin.SetActive(false);
                        ham.SetActive(true);
                        meat.meatSelector(5);
                    }
                break;
                //Knife 
                case 2:
                    if (ifInter.whatwasHit() == "LEFTCUT"){
                        pChops.SetActive(false);
                        meat.meatSelector(1);
                    }
                    else if (ifInter.whatwasHit() == "MIDDLECUT"){
                        pLoin.SetActive(false);
                        meat.meatSelector(4);
                    }
                    else if (ifInter.whatwasHit() == "CUTLEFTLEGDEFAULT")
                    {
                        sRibs.SetActive(false);
                        sRibRe.SetActive(true);
                        meat.meatSelector(2);
                    }
                    else if(ifInter.whatwasHit() == "CUTHAM")
                    {
                        hamRe.SetActive(false);
                        meat.meatSelector(6);
                    }
                    else if (ifInter.whatwasHit() == "BOTTOMCUT")
                    {
                        pBelly.SetActive(false);
                        meat.meatSelector(3);
                    }
                    else if (ifInter.whatwasHit() == "CUTUPPERDEFAULT")
                    {
                        cutlets.SetActive(false);
                        cutletsRe.SetActive(true);
                        meat.meatSelector(7);
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
