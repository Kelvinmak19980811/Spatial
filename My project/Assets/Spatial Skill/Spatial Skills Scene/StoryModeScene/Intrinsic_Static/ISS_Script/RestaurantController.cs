using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class RestaurantController : MonoBehaviour
{    
    [SerializeField]
    GameObject ConfirmButton;

    public GameObject QuizSystem;

    public GameObject ControlSystem;

    public GameObject MinimapSystem;

    public GameObject MinimapOn;

    public GameObject MinimapOff;

    [SerializeField]
    public float timeSet;
    
    public float timeValue;

    public Text timeText;

    public GameObject TimeSystem;

    // Start is called before the first frame update
    void Start()
    {
        timeValue = float.PositiveInfinity;

        ConfirmButton.SetActive(false);
        QuizSystem.SetActive(false);
        MinimapOn.SetActive(false);
        MinimapOff.SetActive(true);

        TimeSystem.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }

        if(TimeSystem.activeSelf == true)
        {
            timeValue = timeSet;
        }
        else if (TimeSystem.activeSelf == false)
        {
            timeValue = float.PositiveInfinity;
        }

        DisplayTime(timeValue);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Restaurant"))
        {
            ConfirmButton.SetActive(true);
        }
        else
        {
            ConfirmButton.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Restaurant"))
        {
            ConfirmButton.SetActive(false);
        }
    }

    public void TurnOnQuizSystem()
    {
        QuizSystem.SetActive(true);

        ControlSystem.SetActive(false);

        MinimapSystem.SetActive(false);

        MinimapOff.SetActive(false);

        MinimapOn.SetActive(false);

        TimeSystem.SetActive(true);

        ConfirmButton.SetActive(false);


    }

    public void TurnOnMinimap()
    {
        MinimapSystem.SetActive(true);
        MinimapOff.SetActive(true);
        MinimapOn.SetActive(false);
    }

    public void TurnOffMinimap()
    {
        MinimapSystem.SetActive(false);
        MinimapOff.SetActive(false);
        MinimapOn.SetActive(true);

    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("Time Remaining : " + "{0:00}:{01:00}", minutes, seconds);

    }

}
