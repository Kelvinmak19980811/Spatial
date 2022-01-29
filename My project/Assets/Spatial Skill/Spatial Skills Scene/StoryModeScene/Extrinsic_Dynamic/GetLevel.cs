using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLevel : MonoBehaviour
{
    public int section;
    public int Question, QuestionChoice, QuestionComplicated, TimeCount;

    public int LevelData(int level)
    {
        if (level == 1 && level <= 4)
        {
            Question = 1;
            QuestionChoice = 2;
            QuestionComplicated = 1;
            TimeCount = 180;

        }else if(level >= 5 && level <= 8 )
        {
            Question = 2;
            QuestionChoice = 4;
            QuestionComplicated = 2;
            TimeCount = 150;

        }
        else if (level >= 9 && level <= 13)
        {
            Question = 3;
            QuestionChoice = 6;
            QuestionComplicated = 3;
            TimeCount = 120;

        }
        else if (level >= 14 && level <= 17)
        {
            Question = 4;
            QuestionChoice = 8;
            QuestionComplicated = 4;
            TimeCount = 80;

        }
        else if (level >= 18 && level <= 21)
        {
            Question = 5;
            QuestionChoice = 12;
            QuestionComplicated = 5;
            TimeCount = 60;
        }else if(level > 21)
        {
            level = 1;
            section = section++;
        }

        return level;
    }

    public int EDS_Level(int level)
    {
        if (level == 1 && level <= 4)
        {
            Question = 1;
            QuestionChoice = 4;
            QuestionComplicated = 1;
            TimeCount = 180;

        }
        else if (level >= 5 && level <= 8)
        {
            Question = 2;
            QuestionChoice = 4;
            QuestionComplicated = 2;
            TimeCount = 150;

        }
        else if (level >= 9 && level <= 13)
        {
            Question = 3;
            QuestionChoice = 4;
            QuestionComplicated = 3;
            TimeCount = 120;

        }
        else if (level >= 14 && level <= 17)
        {
            Question = 4;
            QuestionChoice = 4;
            QuestionComplicated = 4;
            TimeCount = 80;

        }
        else if (level >= 18 && level <= 21)
        {
            Question = 5;
            QuestionChoice = 4;
            QuestionComplicated = 5;
            TimeCount = 60;
        }
        else if (level > 21)
        {
            level = 1;
            section = section++;
        }

        return level;
    }
}
