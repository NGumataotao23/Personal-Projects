using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class HumanCutter : MonoBehaviour
{

    [SerializeField] bleeding playBleed;

    [SerializeField] IfInteractable ifInter;
    [SerializeField] Interactor interactor;
    [SerializeField] MeatCutterHuman meat;
    [SerializeField] GameObject human1;
    [SerializeField] GameObject human2;
    [SerializeField] GameObject human3;
    [SerializeField] GameObject human4;
    [SerializeField] GameObject human5;
    

    [SerializeField] GameObject HUMAN;

    [SerializeField] GameObject hints;

    [SerializeField] public bool isBled = false;

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
        cuthuman();
    }
    private void cuthuman()
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
                    case "Human2":
                        if (isBled)
                        {
                            human2.SetActive(false);
                            human3.SetActive(true);
                            break;
                        }
                        StartCoroutine(playBleed.PlayBlood(3));
                        Debug.Log("Human is Bled");
                        break;
                    
                  
                   
                    
                }
            }
            if (ifInter.isHolding == 3 && Input.GetKeyDown(KeyCode.Mouse0))
            {
                switch (ifInter.whatwasHit())
                {
                    case "Human1":
                        human1.SetActive(false);
                        human2.SetActive(true);
                        break;
                    case "Human4":

                        human4.SetActive(false);
                        human5.SetActive(true);
                        break;

                    case "Human5":
                        
                        human5.SetActive(false);
                        HUMAN.SetActive(true);
                        break;
                }

            }
            if (ifInter.isHolding == 4 && Input.GetKeyDown(KeyCode.Mouse0))
            {

                switch (ifInter.whatwasHit())
                {
                    case "Human3":
                        
                        human3.SetActive(false);
                        human4.SetActive(true);
                        break;


                }
             }

        }
    }
    

}
