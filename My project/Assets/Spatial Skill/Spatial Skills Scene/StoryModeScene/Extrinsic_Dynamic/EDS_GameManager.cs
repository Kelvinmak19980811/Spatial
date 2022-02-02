using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EDS_GameManager : MonoBehaviour
{
    public GameObject PicFrame;
    public GameObject PicBtnOn;
    public GameObject PicBtnOff;
    //public GameObject PauseBtn;

    public GameObject ChoicePanel;
    public GameObject ChoiceBtnOn;
    public GameObject ChoiceBtnOff;

    public GameObject LikeBar;
    public GameObject LikeBarBtnOn;
    public GameObject LikeBarBtnOff;

    public GameObject PauseMenu;

    public GameObject ResultMenu;

    public float timeValue;
    public Text Clock;
    public float CurrentTime;
    public float MaxTime;

    // Start is called before the first frame update
    void Start()
    {
        //picture panel
        PicFrame.SetActive(true);
        PicBtnOn.SetActive(false);
        PicBtnOff.SetActive(true);

        //choice panel
        ChoicePanel.SetActive(true);
        ChoiceBtnOn.SetActive(false);
        ChoiceBtnOff.SetActive(true);

        //choice likebar show
        LikeBar.SetActive(true);
        LikeBarBtnOn.SetActive(false);
        LikeBarBtnOff.SetActive(true);

        PauseMenu.SetActive(false);
        ResultMenu.SetActive(false);

        MaxTime = timeValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= (int)Time.deltaTime;
            CurrentTime = timeValue;
            Clock.text = timeValue.ToString();
        }


        if (timeValue == 0)
        {
            EDS_QM Time = new EDS_QM();
            Time.Result();
        }
    }

    public void PictureBtnControllerOn()
    {
        PicBtnOn.SetActive(false);
        PicFrame.SetActive(true);
        PicBtnOff.SetActive(true);
    }

    public void PictureBtnControllerOff()
    {
        PicBtnOn.SetActive(true);
        PicFrame.SetActive(false);
        PicBtnOff.SetActive(false);
    }

    public void LikeBarBtnControllerOn()
    {
        LikeBarBtnOn.SetActive(false);
        LikeBar.SetActive(true);
        LikeBarBtnOff.SetActive(true);
    }

    public void LikeBarBtnControllerOff()
    {
        LikeBarBtnOn.SetActive(true);
        LikeBar.SetActive(false);
        LikeBarBtnOff.SetActive(false);
    }

    public void ChoiceBtnControllerOn()
    {
        ChoiceBtnOn.SetActive(false);
        ChoicePanel.SetActive(true);
        ChoiceBtnOff.SetActive(true);
    }

    public void ChoiceBtnControllerOff()
    {
        ChoiceBtnOn.SetActive(true);
        ChoicePanel.SetActive(false);
        ChoiceBtnOff.SetActive(false);
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Kato");
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }

    public void Result()
    {
        ResultMenu.SetActive(true);
    }

    
}
