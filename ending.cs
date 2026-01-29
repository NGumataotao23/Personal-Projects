using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending : MonoBehaviour
{

    [SerializeField] bool canExit;
    [SerializeField] textFadeIn endQuote;
    [SerializeField] textFadeIn gameBy;
    [SerializeField] textFadeIn association;
    [SerializeField] textFadeIn musicBy;
    [SerializeField] textFadeIn exitPrompt;
    void Update()
    {
        endingSequence();
        if (Input.GetKeyDown(KeyCode.Escape) && canExit)
        {
            Application.Quit();
            Debug.Log("Application Exited");
        }
        
    }
    private void endingSequence()
    {
        StartCoroutine(EndingWords());
    }
    private IEnumerator EndingWords()
    {
        yield return new WaitForSeconds(2f);
        endQuote.getHighlightedObject(0.5f, true);
        yield return new WaitForSeconds(3f);
        gameBy.getHighlightedObject(0.5f, true);
        yield return new WaitForSeconds(3f);
        association.getHighlightedObject(0.5f, true);
        yield return new WaitForSeconds(3f);
        musicBy.getHighlightedObject(0.5f, true);
        yield return new WaitForSeconds(3f);
        exitPrompt.getHighlightedObject(0.5f, true);
        canExit = true;

        yield return null;
    }
}
