using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class openbookHighlight : MonoBehaviour
{
    
    [SerializeField] IfInteractable isInt;
    [SerializeField] Interactor interact;

    [SerializeField] textFadeIn textFade;
    [SerializeField] textFadeIn textFade2;

    [SerializeField] MeshRenderer bookA;
    [SerializeField] GameObject viewBook;
    [SerializeField] MeshCollider book;
    [SerializeField] GameObject ch;

    [SerializeField] GameObject boutline;
    [SerializeField] MeshRenderer boutlineMesh;


    [SerializeField] bool holding = false;
    public bool canGrab = false;
    [SerializeField] bool hasBook = false;


    [SerializeField] GameObject bookPickUp;
   


    void Awake()
    {
        
    }
    public void Update()
    {
        bookView();
        if (interact.isInteractable)
        {
            if(isInt.whatwasHit() == "OpenBook")
            {
                outline(true);
                canGrab = true;
            }
       
       
        }else if (interact.hit.collider != book)
            {
                outline(false);
                canGrab = false;
            }
    }
    public void outline(bool show)
    {
        if (show && !hasBook)
        {
            boutline.SetActive(true);
            
            textFade.getHighlightedObject(0.5f, true);
        }
        else if (!show && !hasBook)
        {
            boutline.SetActive(false);
            
            textFade.getHighlightedObject(0.5f,false);
        }

    }
    public void bookView()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(canGrab)
            {
                bookA.enabled = false;
                boutlineMesh.enabled = false;
                book.enabled = false;
                canGrab = false;
                hasBook = true;
                textFade.getHighlightedObject(0.5f, false);
                textFade2.getHighlightedObject(0.5f, true);
            }
            else if(hasBook)
            {
                textFade2.getHighlightedObject(0.5f, false);
                if (holding)
                {
                    viewBook.SetActive(false);
                    ch.SetActive(true);
                    holding = false;
                }
                else if (!holding)
                {
                    viewBook.SetActive(true);
                    ch.SetActive(false);
                    holding = true;
                }
                
            }
        }
    }
}
