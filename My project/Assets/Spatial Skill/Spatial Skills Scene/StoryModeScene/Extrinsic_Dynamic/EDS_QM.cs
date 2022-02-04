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
    public GameObject Life;

    int totalLife = 1;
    int totalQuestions = 0;
    public int CorrectCount;
    public Text CorrectText;
    public int WrongCount;
    public Text WrongText;

    public Image LikeBar;
    public float CurrentHealth;
    private float MaxHealth = 5f;

    public int score;

    public GameObject Quizpanel;
    public GameObject ResultPanel;

    public Text ResultScore;

    public GameObject Star1, Star2, Star3, StarOff1, StarOff2, StarOff3;


    private void Start()
    {
        CorrectCount = 0;

        totalQuestions = QnA.Count;

        Life.SetActive(true);
        ResultPanel.SetActive(false);

        generateQuestion();

        StarOff1.SetActive(true);
        StarOff2.SetActive(true);
        StarOff3.SetActive(true);

        Star1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false);
    }

    private void Update()
    {
        CurrentHealth = CorrectCount/1000;
        LikeBar.fillAmount = (CurrentHealth) / MaxHealth;
        ResultScore = CorrectText;

        if (CorrectCount == 0)
        {
             NoStar();
        }
        else if (CorrectCount <= 2000)
        {
            OneStar(); 
        }
        else if (CorrectCount == 3000)
        {
            TwoStar();
        }
        else if (CorrectCount >= 4000)
        {
            ThreeStar();
        }
    }

    public void Result()
    {
        Quizpanel.SetActive(false);
        ResultPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void correct()
    {
        //when you are right
        CorrectCount += 1000;
        CorrectText.text = CorrectCount.ToString();
        QnA.RemoveAt(currentQuestion);
        QuestionGmObj.SetActive(false);

        generateQuestion();
    }

    public void wrong()
    {
        //when you answer wrong
        WrongCount += 1000;
        WrongText.text = WrongCount.ToString();
        QnA.RemoveAt(currentQuestion);
        QuestionGmObj.SetActive(false);
        generateQuestion();
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
            Result();
        }
    }

    void OneStar()
    {
        Star1.SetActive(true);
        StarOff2.SetActive(true);
        StarOff3.SetActive(true);

        StarOff1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false);
    }

    void TwoStar()
    {
        Star1.SetActive(true);
        Star2.SetActive(true);
        StarOff3.SetActive(true);

        StarOff1.SetActive(false);
        StarOff2.SetActive(false);
        Star3.SetActive(false);
    }

    void ThreeStar()
    {
        Star1.SetActive(true);
        Star2.SetActive(true);
        Star3.SetActive(true);

        StarOff1.SetActive(false);
        StarOff2.SetActive(false);
        StarOff3.SetActive(false);
    }

    void NoStar()
    {
        StarOff1.SetActive(true);
        StarOff2.SetActive(true);
        StarOff3.SetActive(true);

        Star1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false);
    }
}

