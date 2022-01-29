using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class EDS_QnA
{
    public string Question;
    public GameObject CurrentView;
    public Sprite QuestionImage;
    public Sprite[] Answers;
    public int CorrectAnswers;
}
