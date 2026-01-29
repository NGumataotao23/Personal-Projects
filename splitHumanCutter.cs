using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splitHumanCutter : MonoBehaviour
{
    [SerializeField] IfInteractable ifInter;
    [SerializeField] Interactor interactor;
    [SerializeField] MeatCutterHuman meat;

    [SerializeField] GameObject shoulder;
    [SerializeField] GameObject breast;
    [SerializeField] GameObject ribs;
    [SerializeField] GameObject maximus;
    [SerializeField] GameObject medius;
    [SerializeField] GameObject upperthigh;
    [SerializeField] GameObject lowerthigh;
    



    void Update()
    {
        shumanController();
    }

    void shumanController()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactor.isInteractable)
        {
            switch (ifInter.isHolding)
            {
                //Cleaver
                case 1:
                    if (ifInter.whatwasHit() == "UPPERTHIGH")
                    {
                        upperthigh.SetActive(false);
                        meat.meatSelector(6);
                        break;
                    }
                    if (ifInter.whatwasHit() == "LOWERTHIGH")
                    {
                        lowerthigh.SetActive(false);
                        meat.meatSelector(7);
                        break;
                    }
                    
                    break;
                //Knife 
                case 2:
                    if (ifInter.whatwasHit() == "CUTSHOULDER")
                    {
                        shoulder.SetActive(false);
                        meat.meatSelector(2);
                        break;
                    }
                    else if (ifInter.whatwasHit() == "CUTCHUCK")
                    {
                        breast.SetActive(false);
                        meat.meatSelector(1);
                        break;
                    }
                    else if (ifInter.whatwasHit() == "CUTABDOMEN")
                    {
                        medius.SetActive(false);
                        meat.meatSelector(4);
                        break;
                    }
                    else if (ifInter.whatwasHit() == "CUTGLUTE")
                    {
                        maximus.SetActive(false);
                        meat.meatSelector(5);
                        break;
                    }
                    break;
                //Saw
                case 3:
                    if (ifInter.whatwasHit() == "CUTRIBS")
                    {
                        ribs.SetActive(false);
                        meat.meatSelector(3);
                        break;
                    }
                    break;
                //Scissors
                case 4:
                    break;
            }
        }
    }
}

