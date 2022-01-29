using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EDS_QM : MonoBehaviour
{
    public List<EDS_QnA> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Image QuestionImage;
    public GameObject QuestionGmObj;
    public Text ScoreTxt;
    public GameObject Life;
    public GameObject LifeEmpty;

    int totalLife = 1;
    int totalQuestions = 0;
    public int CorrectCount;

    public Image LikeBar;
    public float CurrentHealth;
    private float MaxHealth = 100f;

    public int score;

    public GameObject Quizpanel;
    public GameObject GoPanel;
    public GameObject GwPanel;

    private void Start()
    {
        CorrectCount = 0;

        ScoreTxt.text = "Question Remaining : " + CorrectCount + "/" + score;

        totalQuestions = QnA.Count;

        Life.SetActive(true);
        LifeEmpty.SetActive(false);
        GoPanel.SetActive(false);
        GwPanel.SetActive(false);

        generateQuestion();
    }

    private void Update()
    {
        CurrentHealth = CorrectCount;
        LikeBar.fillAmount = (CurrentHealth * 20) / MaxHealth;
    }

    public void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
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
        QuestionGmObj.SetActive(false);

        generateQuestion();

        ScoreTxt.text = "Question Remaining : " + CorrectCount + "/" + totalQuestions;

        if (CorrectCount == score)
        {
        GameWin();
        }
    }

    public void wrong()
    {
        //when you answer wrong

        QnA.RemoveAt(currentQuestion);
        QuestionGmObj.SetActive(false);
        generateQuestion();

        ScoreTxt.text = "Question Remaining : " + CorrectCount + "/" + totalQuestions;

        LifeCount();

        
    }


    void SetAnswer()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<EDS_AnswerScript>().startColor;
            options[i].GetComponent<EDS_AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Image>().sprite = QnA[currentQuestion].Answers[i];
            
            
            

            if (QnA[currentQuestion].CorrectAnswers == i+1)
            {
                options[i].GetComponent<Image>().color = options[i].GetComponent<EDS_AnswerScript>().greenColor;
                options[i].GetComponent<EDS_AnswerScript>().isCorrect = true;
            }        
        }
    }

    void generateQuestion()
    {
        
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionImage.sprite = QnA[currentQuestion].QuestionImage;
            QuestionGmObj = QnA[currentQuestion].CurrentView;
            QuestionGmObj.SetActive(true);
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
                Life.SetActive(false);
                LifeEmpty.SetActive(true);

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

