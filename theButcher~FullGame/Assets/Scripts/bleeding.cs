using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bleeding : MonoBehaviour
{
    [SerializeField] GameObject blood1;
    [SerializeField] GameObject blood2;
    public GameObject blood3;
    [SerializeField] GameObject bloodDrain;

    public MeshCollider pigMesh;
    public MeshCollider cowMesh;
    public MeshCollider humanMesh;

    public PigCutter pig;
    public CowCutter cow;
    public HumanCutter human;
    public ParticleSystem bleed1;
    public ParticleSystem bleed2;
    
    void Start()
    {
        bleed1 = blood1.GetComponent<ParticleSystem>();
        bleed2 = blood2.GetComponent<ParticleSystem>();
        
    }

    
    void Update()
    {
        
    }
    public IEnumerator PlayBlood(int whichOne)
    {
        switch (whichOne)
        {
            case 1:
                bleed1.Play();
                bleed2.Play();
                yield return new WaitForSeconds(1f);
                bloodDrain.SetActive(true);

                pigMesh.enabled = false;

                while (bleed1.isEmitting)
                {
                    yield return null;
                }
                pigMesh.enabled = true;
                pig.isBled = true;
                break;
            case 2:
                bleed1.Play();
                bleed2.Play();
                yield return new WaitForSeconds(1f);
                bloodDrain.SetActive(true);

                cowMesh.enabled = false;

                while (bleed1.isEmitting)
                {
                    yield return null;
                }
                cowMesh.enabled = true;
                cow.isBled = true;
                break;
            case 3:
                bleed1.Play();
                bleed2.Play();
                yield return new WaitForSeconds(1f);
                bloodDrain.SetActive(true);

                humanMesh.enabled = false;

                while (bleed1.isEmitting)
                {
                    yield return null;
                }
                humanMesh.enabled = true;
                human.isBled = true;
                break;
        }
        

    }

}
