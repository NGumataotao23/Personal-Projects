using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  
    [Header("Movement")]
    public float moveSpeed;
    
    [SerializeField]  bool grounded;
    [SerializeField]  float playerHeight;
    [SerializeField]  LayerMask whatisGround;
    [SerializeField]  float groundDrag;

    [SerializeField]  Transform orientation;

    

    private float defaultVolume = 0.2f;

    [SerializeField] AudioSource footstep_source; 

    float horizontalInput;
    float verticalInput;

    Vector3 movementDirection;

    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        footstep_source = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        movePlayer();
    }
    private void Update()
    {

        
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatisGround);
        InputGet();
        footSteps();
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        
        
    }
    private void InputGet()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
            

    }
    private bool IsMoving()
    {
        if(Input.GetKey(KeyCode.W) ||  Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            return true;
        }
        else { return false; }
    }
    public static IEnumerator FadeOut(AudioSource source)
    {
        float finishVolume = source.volume;
        
        while(source.volume > 0)
        {
            source.volume -= finishVolume * Time.deltaTime / 0.5f;
            yield return null;
        }
        source.Pause();
        source.volume = finishVolume;
    }
    private void movePlayer()
    {
        movementDirection = orientation.forward *verticalInput +orientation.right *horizontalInput;
        
        rb.AddForce(movementDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        
    }
    private void footSteps()
    {
       bool firstMove = false;
       if (IsMoving())
       {
            footstep_source.volume = defaultVolume;
            if (!footstep_source.isPlaying)
            {
               footstep_source.Play();
               firstMove = true;
            }
            if (!footstep_source.isPlaying || firstMove)
            {
                footstep_source.UnPause();
                
            }
       }
       if(footstep_source.isPlaying && !IsMoving())
       {
            StartCoroutine(FadeOut(footstep_source));
            
       }
       
       
    }
    
}
