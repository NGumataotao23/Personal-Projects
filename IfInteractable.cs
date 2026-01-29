using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class IfInteractable : MonoBehaviour
{
    public Interactor interact;

    public GameObject cleaver;
    public GameObject scissors;
    public GameObject knife;
    public GameObject saw;

    [SerializeField] textFadeIn fade;
    [SerializeField] textFadeIn fade2;

    bool hintChecked = false;

    [SerializeField]  GameObject C;
    [SerializeField]  GameObject S;
    [SerializeField]  GameObject K;
    [SerializeField]  GameObject SA;

    [SerializeField] MeshRenderer cl;
    [SerializeField] MeshRenderer sw;
    [SerializeField] MeshRenderer kn;
    [SerializeField] MeshRenderer sc;

    
   
    public int isHolding = 0;

    [SerializeField] LayerMask interactable;

    private void Awake()
    {

    }
    void Update()
    {
        outline();
        if (isHolding == 0)
        {
            getTool();
        }
        else if (isHolding > 0)
        {
            returnTool();
        }

        hintDisplay();
        
        
    }
    public string whatwasHit()
    {
        string whatWas;
        if(interact.hit.collider == null)
        {
            return null;
        }
        whatWas = interact.hit.transform.gameObject.name;
        Debug.Log(whatWas);
        return whatWas;

    }
    private void outline()
    {
        
        switch (whatwasHit())
        {
            case "Cleaver":
                cl.enabled = true;
                fade.getHighlightedObject(0.5f, true);
                break;
            case "Butcehr Knife":
                kn.enabled = true;
                fade.getHighlightedObject(0.5f,true);
                break;
            case "Bone Saw":
                fade.getHighlightedObject(0.5f, true);
                sw.enabled = true;
                break;
            case "Cylinder":
                fade.getHighlightedObject(0.5f,true);
                sc.enabled = true;
                break;
            default:
                fade.getHighlightedObject(0.5f, false);
                cl.enabled = false;
                kn.enabled = false;
                sw.enabled = false;
                sc.enabled = false;
                break;

        }


    }
    private void hintDisplay()
    {
        
        if(!hintChecked && isHolding > 0)
        {
            fade2.getHighlightedObject(0.5f, true);
            hintChecked = true;
        }
        if (hintChecked && Input.GetKeyDown(KeyCode.Mouse0))
        {
            fade2.getHighlightedObject(0.5f, false);
        }

        
    }
    public void disableTool(int x)
    {
        switch (x)
        {
            case 1:
                cleaver.SetActive(false);
                break;
            case 2:
                knife.SetActive(false);
                break;
            case 3:
                saw.SetActive(false);
                break;
            case 4:
                scissors.SetActive(false);
                break;
        }
        
    }
    public void enableTool(int holding)
    {
        switch (holding)
        {
            case 1:
                cleaver.SetActive(true);
                break;
            case 2:
                knife.SetActive(true);
                break;
            case 3:
                saw.SetActive(true);
                break;
            case 4:
                scissors.SetActive(true);
                break;

        }
    }
    
    void getTool()
    {
        if (Input.GetKeyDown(KeyCode.E) && (interact.isInteractable == true) && (1<<interactable)!=0)
        {
            Debug.Log("Pressed");
            Debug.Log(whatwasHit());

            switch (whatwasHit())
            {
                
                case "Cleaver":
                    cleaver.SetActive(true);
                    
                    C.SetActive(false);
                    isHolding = 1;
                    break;
                case "Butcehr Knife":
                    knife.SetActive(true);
                    
                    K.SetActive(false);
                    isHolding = 2;
                    break;
                case "Bone Saw":
                    saw.SetActive(true);
                    
                    SA.SetActive(false);
                    isHolding = 3;
                    break;
                case "Cylinder":
                    scissors.SetActive(true);

                    S.SetActive(false);
                    isHolding = 4;
                    break;
                default:
                    break;
            }
        }
    }
    void returnTool()
    {
        if (Input.GetKeyDown(KeyCode.E) && (interact.isInteractable == true) && (whatwasHit() == "Rack"))
        {
            switch (isHolding)
            {

                case 1:
                    cleaver.SetActive(false);
                    C.SetActive(true);
                    isHolding = 0;
                    break;
                case 2:
                    knife.SetActive(false);
                    K.SetActive(true);
                    isHolding = 0;
                    break;
                case 3:
                    saw.SetActive(false);
                    SA.SetActive(true);
                    isHolding = 0;
                    break;
                case 4:
                    scissors.SetActive(false);
                    S.SetActive(true);
                    isHolding = 0;
                    break;
                default:
                    break;
            }
        }





    }
    
    
}
