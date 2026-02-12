using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CowCutter : MonoBehaviour
{


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

    [SerializeField] GameObject hints;

    public bool isBled = false;

    private void Start()
    {
        int hintOn = PlayerPrefs.GetInt("hint", 0);
        if (hintOn == 0)
        {
            hints.SetActive(false);
        }
        
    }
    void Update()
    {
        cutcow();
    }
    private void cutcow()
    {

        if (interactor.isInteractable)
        {
            if ((ifInter.isHolding == 1) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                
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
                        StartCoroutine(playBleed.PlayBlood(2));
                        Debug.Log("Cow is Bled");
                        
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
                    case "Cow5":
                        cow5.SetActive(false);
                        cow6.SetActive(true);
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
