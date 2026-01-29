using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class eventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] CameraController camControl;
    [SerializeField] Camera compCam;
    [SerializeField] Camera deskCam;
    [SerializeField] textFadeIn fade;
    [SerializeField] textFadeIn fade3;

    bool clickHappened;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData);
        compCam.enabled = true;
        deskCam.enabled = false;
        if(compCam.isActiveAndEnabled)
        {
            fade.getHighlightedObject(0.1f, false);
            fade3.getHighlightedObject(0.1f, true);
        }

    }
    public void OnPointerUp(PointerEventData eventData)
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
       
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
