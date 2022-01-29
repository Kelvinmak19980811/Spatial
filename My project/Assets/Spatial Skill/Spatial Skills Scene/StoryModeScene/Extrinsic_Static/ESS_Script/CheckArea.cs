using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckArea : MonoBehaviour
{
    public bool PlayerCorrect;

    public GameObject GOPanel;
    public GameObject GWPanel;

    [SerializeField]
    public float timeValue;

    public Text timeText;


    // Start is called before the first frame update
    void Start()
    {
        PlayerCorrect = false; // set the player correct value to wrong

        Time.timeScale = 1f; // start the timer

        GOPanel.SetActive(false); // turn off the game over panel
        GWPanel.SetActive(false); // turn off the game win panel
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ExtrinsicStatic")) //check if player enter the correct area
        {
            PlayerCorrect = true;
            Debug.Log("Player Enter Correct Area?");
        }
        return;
    }

    private void OnTriggerExit(Collider other) // check if player leave the correct area
    {
        if (other.gameObject.CompareTag("ExtrinsicStatic"))
        {
            PlayerCorrect = false;
            Debug.Log("Player leave the Correct Area!");
        }
        return;
    }

    public void CheckCorrect() // on click button check
    {
        if(PlayerCorrect)
        {
            GWPanel.SetActive(true);
        }
        else
        {
            GOPanel.SetActive(true);
        }
    }

    public void retry() // set retry button on click function
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update() // keep update the timer
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }

        DisplayTime(timeValue);

        if (timeValue == 0)
        {

        }
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

        if(GOPanel.activeSelf == true || GWPanel.activeSelf == true)
        {
            Time.timeScale = 0f;
            Debug.Log("Hello Peter");
        }else if(GOPanel.activeSelf == false || GWPanel.activeSelf == false)
        {
            Time.timeScale = 1f;
            Debug.Log("You're not Peter");
        }
    }
}
