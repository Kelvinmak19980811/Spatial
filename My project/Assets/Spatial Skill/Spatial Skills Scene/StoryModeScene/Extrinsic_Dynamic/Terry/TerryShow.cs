using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerryShow : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Q1, Q2, Q3, Q4, Q5;
    public GameObject Q1C1, Q1C2, Q1C3, Q1C4;
    public GameObject Q2C1, Q2C2, Q2C3, Q2C4;
    public GameObject Q3C1, Q3C2, Q3C3, Q3C4;
    public GameObject Q4C1, Q4C2, Q4C3, Q4C4;
    public GameObject Q5C1, Q5C2, Q5C3, Q5C4;

    public Sprite Q1Pic, Q2Pic, Q3Pic, Q4Pic, Q5Pic;

    public GameObject pic;
    public GameObject pictarget;

    public TerryAnimation CharacterAnimation = new TerryAnimation();

    public bool QuestionCompleted = true;
    void Start()
    {
        QuestionSet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuestionSet()//remember is purple, corrects
    {
        Q1.SetActive(true);
        Q2.SetActive(false);
        Q3.SetActive(false);
        Q4.SetActive(false);
        Q5.SetActive(false);


        pic.GetComponent<Image>().GetComponent<SpriteRenderer>().sprite = Q1Pic;

        MainCamera.transform.position = new Vector3(Q1.transform.position.x, 60, Q1.transform.position.z);

        CharacterAnimation.Target.transform.position = Q1C1.transform.position;//set character animation target as choice 1 position, purple

        CharacterAnimation.Area.transform.position = Q1.transform.position;// set character look area as question 1

    }
    //purple c1 correct q1
    //green c3 correct q2
    //yellow c4 wrong q3
    //purple c1 correct q4
    //yellow c4 wrong q5
    public void ClickQuestionOne()
    {
        CharacterAnimation.Answer = true;

        CharacterAnimation.SpawnCharacter();

        do
        {
            Debug.Log("Click One");
        } while (CharacterAnimation.NextQuestion == true);
        QuestionTwo();
        CharacterAnimation.NextQuestion = false;
    }

    public void QuestionTwo()  //remember is green, correct
    {
        
        Q1.SetActive(false);
        Q2.SetActive(true);
        Q3.SetActive(false);
        Q4.SetActive(false);
        Q5.SetActive(false);

        pic.GetComponent<SpriteRenderer>().sprite = Q2Pic;

        MainCamera.transform.position = new Vector3(Q2.transform.position.x, 60, Q2.transform.position.z);

        CharacterAnimation.Target.transform.position = Q2C3.transform.position;//set character animation target as choice 1 position

        CharacterAnimation.Area.transform.position = Q2.transform.position;// set character look area as question 1

    }

    public void ClickQuestionTwo()
    {
        CharacterAnimation.Answer = true;

        CharacterAnimation.SpawnCharacter();
        if(CharacterAnimation.NextQuestion == true)
        {
            QuestionThree();
            do
            {
                Debug.Log("Click One");
            } while (CharacterAnimation.NextQuestion == true);
            CharacterAnimation.SpawnCharacter();
        }
    }

    public void QuestionThree()  //remember is yellow, wrong
    {

        Q1.SetActive(false);
        Q2.SetActive(false);
        Q3.SetActive(true);
        Q4.SetActive(false);
        Q5.SetActive(false);

        pic.GetComponent<SpriteRenderer>().sprite = Q3Pic;

        CharacterAnimation.Answer = false;

        MainCamera.transform.position = new Vector3(Q3.transform.position.x, 60, Q3.transform.position.z);

        CharacterAnimation.Target.transform.position = Q3C4.transform.position;//set character animation target as choice 1 position

        CharacterAnimation.Area.transform.position = Q3.transform.position;// set character look area as question area
    }

    public void ClickQuestionThree()
    {
        CharacterAnimation.Answer = false;

        CharacterAnimation.SpawnCharacter();
        do
        {
            Debug.Log("Click One");
        } while (CharacterAnimation.NextQuestion == true);
        QuestionFour();
    }

    public void QuestionFour()//remember is purple, correct
    {
        Q1.SetActive(false);
        Q2.SetActive(false);
        Q3.SetActive(false);
        Q4.SetActive(true);
        Q5.SetActive(false);

        pic.GetComponent<SpriteRenderer>().sprite = Q4Pic;

        MainCamera.transform.position = new Vector3(Q4.transform.position.x, 60, Q4.transform.position.z);

        CharacterAnimation.Target.transform.position = Q4C1.transform.position;// set character animation as choice 1 position

        CharacterAnimation.Area.transform.position = Q4.transform.position; // set character area as question area
    }

    public void ClickQuestionFour()
    {
        CharacterAnimation.Answer = true;

        CharacterAnimation.SpawnCharacter();
        do
        {
            Debug.Log("Click One");
        } while (CharacterAnimation.NextQuestion == true);
        QuestionFive();
    }

    public void QuestionFive()
    {
        Q1.SetActive(false);
        Q2.SetActive(false);
        Q3.SetActive(false);
        Q4.SetActive(false);
        Q5.SetActive(true);

        pic.GetComponent<SpriteRenderer>().sprite = Q5Pic;

        MainCamera.transform.position = new Vector3(Q5.transform.position.x, 60, Q5.transform.position.z);

        CharacterAnimation.Target.transform.position = Q5C4.transform.position;// set character animation as choice 4 position

        CharacterAnimation.Area.transform.position = Q4.transform.position; // set character area as question area
    }

    public void ClickQuestionFive()
    {
        CharacterAnimation.Answer = false;
        CharacterAnimation.SpawnCharacter();
        do
        {
            Debug.Log("Click One");
        } while (CharacterAnimation.NextQuestion == true);

        QuestionCompleted = true;
    }
}
