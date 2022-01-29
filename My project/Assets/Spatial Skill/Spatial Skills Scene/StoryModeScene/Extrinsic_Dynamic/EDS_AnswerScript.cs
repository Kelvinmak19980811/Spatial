using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EDS_AnswerScript : MonoBehaviour
{

    public bool isCorrect = false;

    public EDS_QM quizManager;

    public Color startColor;

    public Color greenColor;

    private void Start()
    {
        startColor = GetComponent<Image>().color;
        greenColor = GetComponent<Image>().color;
    }
    public void Answer()
    {
        if(isCorrect)
        {
            //GetComponent<Image>().color = Color.green;
            Debug.Log("Correct");
            quizManager.correct();
        }
        else
        {
            //GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");
            quizManager.wrong();
        }
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
