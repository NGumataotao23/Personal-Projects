using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class HumanCutter : MonoBehaviour
{


    [SerializeField] IfInteractable ifInter;
    [SerializeField] Interactor interactor;
    [SerializeField] MeatCutterHuman meat;
    [SerializeField] GameObject human1;
    [SerializeField] GameObject human2;
    [SerializeField] GameObject human3;
    [SerializeField] GameObject human4;
    [SerializeField] GameObject human5;
    

    [SerializeField] GameObject HUMAN;



    [SerializeField] bool isBled = false;
    void Update()
    {
        cuthuman();
    }
    private void cuthuman()
    {

        if (interactor.isInteractable)
        {
            if ((ifInter.isHolding == 1) && Input.GetKeyDown(KeyCode.E))
            {
                switch (ifInter.whatwasHit())
                {
                    case "Human1":
                        if (isBled)
                        {
                            human1.SetActive(false);
                            human2.SetActive(true);
                            break;
                        }
                        ifInter.disableTool(ifInter.isHolding);
                        Task.Delay(5000);
                        Debug.Log("Human is Bled");
                        isBled = true;
                        ifInter.enableTool(ifInter.isHolding);
                        break;
                }
              }
            if ((ifInter.isHolding == 2) && Input.GetKeyDown(KeyCode.E))
            {
                switch (ifInter.whatwasHit())
                {
                    case "Human2":
                        
                        human2.SetActive(false);
                        human3.SetActive(true);
                        break;
                    case "Human4":
                       
                        human4.SetActive(false);
                        human5.SetActive(true);
                        break;
                  
                   
                    
                }
            }
            if (ifInter.isHolding == 3 && Input.GetKeyDown(KeyCode.E))
            {
                switch (ifInter.whatwasHit())
                {

                    case "Human5":
                        
                        human5.SetActive(false);
                        HUMAN.SetActive(true);
                        break;
                }

            }
            if (ifInter.isHolding == 4 && Input.GetKeyDown(KeyCode.E))
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
