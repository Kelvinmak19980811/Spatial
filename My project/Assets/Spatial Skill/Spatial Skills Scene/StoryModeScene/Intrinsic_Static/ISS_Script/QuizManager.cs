using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionTxt;
    public Image QuestionImage;
    public Text ScoreTxt;
    public Text LifeTxt;

    int totalLife = 1;
    int totalQuestions = 0;
    public int CorrectCount;
    [SerializeField]
    public int score;

    public GameObject Quizpanel;
    public GameObject GoPanel;
    public GameObject GwPanel;


    public RestaurantController TimeCount;


    private void Start()
    {
        CorrectCount = 0;

        LifeTxt.text = "Life : " + totalLife + "/" + "1";
        ScoreTxt.text = "Question Remaining : " + CorrectCount + "/" + score;

        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        GwPanel.SetActive(false);

        
        generateQuestion();
    }

    public void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        TimeCount.timeValue = 0;
    }

    public void GameWin()
    {
        Quizpanel.SetActive(false);
        GwPanel.SetActive(true);
    }

    public void correct()
    {
        //when you are right
        CorrectCount += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();

        ScoreTxt.text = "Question Remaining : " + CorrectCount + "/" + score;

        if (CorrectCount == score)
        {
            GameWin();
        }

    }

    public void wrong()
    {
        //when you answer wrong
        QnA.RemoveAt(currentQuestion);
        generateQuestion();

        ScoreTxt.text = "Question Remaining : " + CorrectCount + "/" + score;

        LifeCount();
    }


    void SetAnswer()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Image>().sprite = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswers == i+1)
            {
                options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().greenColor;
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }        
        }
    }
    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            QuestionImage.sprite = QnA[currentQuestion].QuestionImage;

            SetAnswer();

        }
        else
        {
            Debug.Log("Out of Question");
            GameOver();
        }

    }

    void LifeCount()
    {
            if (CorrectCount == 0)
            {
                GameOver();
                Debug.Log("You Lose");
            }
            else if (CorrectCount > 0 && totalLife == 1)
            {
            totalLife = 0;
                CorrectCount = 0;

                LifeTxt.text = "Life : " + totalLife + "/" + "1";
                ScoreTxt.text = "Question Remaining : " + CorrectCount + "/" + score;
                Debug.Log("Life is 0");

            }
            else if (totalLife == 0)
            {
            GameOver();
            Debug.Log("Life 0 and lose");
            }
    }
}
