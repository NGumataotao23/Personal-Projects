using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class textFadeIn : MonoBehaviour
{


    public GameObject textObject;
    TextMeshProUGUI text;
    bool visible;
    private Coroutine fadeRoutine;


    private void Awake()
    {
        text = textObject.GetComponent<TextMeshProUGUI>();
        visible = text.color.a > 0.01f;
    }
    public void getHighlightedObject(float time, bool canGrab)
    {
        
        if (canGrab == visible)
        {
            return;
        }
        visible = canGrab;
        if (fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }
        fadeRoutine = StartCoroutine(canGrab ? textFadein(time, text) : textFadeOut(time,text));

    }
    public IEnumerator textFadein(float time, TextMeshProUGUI text){
        
        Color c = text.color;
        
        c.a = 0;
        text.color = c;
        
        while(c.a < time)
        {
            c.a += Time.deltaTime / time;
            text.color = c;
            yield return null;
        }

        c.a = 1f;
        text.color = c;
        
    }
    public IEnumerator textFadeOut(float time, TextMeshProUGUI text)
    {

        Color c = text.color;
        text.color = c;

        while (c.a > 0f)
        {
            c.a -= Time.deltaTime / time;
            text.color = c;
            yield return null;
        }

        c.a = 0f;
        text.color = c;
        
    }
}
