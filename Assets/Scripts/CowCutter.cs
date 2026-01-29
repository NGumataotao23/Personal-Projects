using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CowCutter : MonoBehaviour
{

    //Script to control phase 1 of Cow Cutting
    [SerializeField] public IfInteractable ifInter;
    [SerializeField] public Interactor interactor;
    [SerializeField] MeatCutterCow meat;
    public GameObject cow1;
    public GameObject cow2;
    public GameObject cow3;
    public GameObject cow4;
    public GameObject cow5;
    public GameObject cow6;

    [SerializeField] bleeding playBleed;

    //trakcs whether the cow has had bleed animation played or not
    public bool isBled = false;
    void Update()
    {
        cutcow();
    }
    private void cutcow()
    {
        // Couple of checks to make sure that not only is the object hit interactable via the interactable layer, also checks to make sure the tool is correct
        //via the number 
        if (interactor.isInteractable)
        {
            if ((ifInter.isHolding == 1) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                switch (ifInter.whatwasHit())
                {
                    case "Cow5":
                        cow5.SetActive(false);
                        cow6.SetActive(true);
                        break;
                    
                }
              }
            if ((ifInter.isHolding == 2) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                switch (ifInter.whatwasHit())
                {

                    case "Cow":
                        if (isBled)
                        {
                            cow1.SetActive(false);
                            cow2.SetActive(true);
                            break;
                        }
                        //plays bleed animation if cow has not been bled, otherwise will transition to next stage
                        StartCoroutine(playBleed.PlayBlood(2));
                        Debug.Log("Cow is Bled");
                        isBled = true;
                        ifInter.enableTool(ifInter.isHolding);
                        break;
                }
            }
            if (ifInter.isHolding == 3 && Input.GetKeyDown(KeyCode.Mouse0))
            {
                switch (ifInter.whatwasHit())
                {
                    
                    case "Cow3":
                        cow3.SetActive(false);
                        cow4.SetActive(true);
                        break;
                    case "Cow4":
                        cow4.SetActive(false);
                        cow5.SetActive(true);
                        break;
                }

            }
            if (ifInter.isHolding == 4 && Input.GetKeyDown(KeyCode.Mouse0))
            {

                switch (ifInter.whatwasHit())
                {
                    case "Cow2":
                        cow2.SetActive(false);
                        cow3.SetActive(true);
                        break;


                }
             }

        }
    }
    

}
