using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sceneFade : MonoBehaviour
{

    [SerializeField] Image sceneFadeImage;

    private void Awake()
    {
        sceneFadeImage = GetComponent<Image>();
    }

    public IEnumerator fadeIn(float duration)
    {
        Color startColor = new Color(sceneFadeImage.color.r, sceneFadeImage.color.g, sceneFadeImage.color.b, 1);
        Color endColor = new Color(sceneFadeImage.color.r, sceneFadeImage.color.g, sceneFadeImage.color.b, 0);

        yield return FadeRoutine(startColor, endColor, duration);
        gameObject.SetActive(false);
    }
    public IEnumerator fadeOut(float duration)
    {
        Color startColor = new Color(sceneFadeImage.color.r, sceneFadeImage.color.g, sceneFadeImage.color.b, 0);
        Color endColor = new Color(sceneFadeImage.color.r, sceneFadeImage.color.g, sceneFadeImage.color.b, 1);

        gameObject.SetActive(true);
        yield return FadeRoutine(startColor, endColor, duration);
        
    }
    private IEnumerator FadeRoutine(Color start, Color end, float duration)
    {
        float eTime = 0;
        float ePercent = 0;

        while(ePercent < 1)
        {
            ePercent = eTime / duration;
            sceneFadeImage.color = Color.Lerp(start, end, ePercent);

            yield return null;
            eTime += Time.deltaTime;
        }
    }
}
