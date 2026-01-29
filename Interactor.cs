using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    //Code From:https://www.youtube.com/watch?v=Bfdvbfk89IY

    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private Transform looking;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[1];
    [SerializeField] public int _numFound; 
    [SerializeField] public bool isInteractable;

    public RaycastHit hit;
    public void Update()
    {
        
            Ray intRay = new Ray(_interactionPoint.position, looking.forward);
            Vector3 interactionEnd = (_interactionPoint.position) * 5.0f;
            Debug.DrawLine(_interactionPoint.position, interactionEnd);
            isInteractable = Physics.Raycast(intRay, out hit, 5.0f, _interactableMask);
        
        
        

        
    }
   
}
