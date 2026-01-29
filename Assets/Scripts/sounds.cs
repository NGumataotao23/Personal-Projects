using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{

    [SerializeField] AudioSource r1;
    [SerializeField] AudioSource r2;
    [SerializeField] AudioSource r3;
    [SerializeField] AudioSource r4;
  //  [SerializeField] AudioSource r5;
   // [SerializeField] AudioSource r6;
    public AudioSource[] rNoises;

    private bool timerOn;

    private void Start()
    {
       
    }
    void Update()
    {
        if (!timerOn)
        {
            StartCoroutine(Timer());
        }
    }
    private void randomNoise()
    {
        rNoises[Random.Range(0, rNoises.Length)].Play();
    }
    private IEnumerator Timer()
    {
        timerOn = true;
        float wait = Random.Range(20f, 30f);
        yield return new WaitForSeconds(wait);
        randomNoise();

        timerOn = false;
    }
    

}
