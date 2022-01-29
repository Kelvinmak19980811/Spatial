using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonDemo : MonoBehaviour
{
    GetLevel leveldata;
    int i;
    void Start()
    {

    }

    public void SaveData()
    {
        CharData newData = new CharData
        {
            level = leveldata.LevelData(1),
            questionchoice = leveldata.QuestionChoice,
            question = leveldata.Question,
            questioncomplicated = leveldata.QuestionComplicated,
            timeCount = leveldata.TimeCount,
        };

        string jsonInfo = JsonUtility.ToJson(newData, true);
        File.WriteAllText("C:/Users/qefml/Desktop/My project/Assets/Spatial Skill/EDS_QuestionBank", jsonInfo);
        
        Debug.Log("Saved");
    }
    
}
[System.Serializable]
public class CharData
{
    public List<GameObject> Prefabs;
    public int level;
    public int question;
    public int questionchoice;
    public int questioncomplicated;
    public int answer;
    public int timeCount;
}

public class CharPos
{
    public float xPos;
    public float yPos;
    public float zPos;
    public CharPos(Vector3 pos)
    {
        xPos = pos.x;
        yPos = pos.y;
        zPos = pos.z;
    }
}

public class SpawnAreaData
{
    

}