using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resultsScreen : MonoBehaviour
{
    Menu results;
    Time getTime;
    sceneFade fade;

    private float timeGiven;
    
    [SerializeField] GameObject pigImage;
    [SerializeField] GameObject cowImage;
    [SerializeField] GameObject humanImage;

    [SerializeField] GameObject pigText;
    [SerializeField] GameObject humanText;
    [SerializeField] GameObject cowText;

 
    private TextMeshProUGUI timeTextF;
    [SerializeField] GameObject timeText;

    private void Start()
    {
        timeTextF = timeText.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        
        switch (Menu.sceneBefore)
        {
            case 1:
                pigImage.SetActive(true);
                pigText.SetActive(true);
                timeTextF.text = Menu.getTime.ToString();
                break;
            case 2:
                cowImage.SetActive(true);
                cowText.SetActive(true);
                timeTextF.text = Menu.getTime.ToString();
                break;
            case 3:
                humanImage.SetActive(true);
                humanText.SetActive(true);
                break;
            default:
                Debug.Log("Scene Before is Null");
                break;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            int nextScene = Menu.sceneBefore + 1;
            SceneManager.LoadScene(nextScene);
        }
        
    }
    
}

