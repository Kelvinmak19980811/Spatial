using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class JsonLoad : MonoBehaviour
{

    string LoadData;
    CharData MyData;
    CharPos CharPosData;
    SpawnAreaData SpawnData;
    void Start()
    {

        LoadData = File.ReadAllText("C:/Users/qefml/Desktop/My project/Assets");

        MyData = JsonUtility.FromJson<CharData>(LoadData);
        CharPosData = JsonUtility.FromJson<CharPos>(LoadData);
        SpawnData = JsonUtility.FromJson<SpawnAreaData>(LoadData);

        Debug.Log("Current level is " + MyData.level);
        Debug.Log("Current Question is " + MyData.question);
        Debug.Log("Current Question Complicated is " + MyData.questioncomplicated);
        Debug.Log("Question have " + MyData.questionchoice + "choice");

    }
}