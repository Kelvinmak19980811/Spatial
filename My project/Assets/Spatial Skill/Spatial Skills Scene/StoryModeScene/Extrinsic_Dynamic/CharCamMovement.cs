using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCamMovement : MonoBehaviour
{
    public GameObject CharCam;
    public GameObject[] CurrentQuestion;
    public int Count;
    EDS_QM CQ;
    // Start is called before the first frame update
    void Start()
    {
        Count = CQ.currentQuestion;
        Debug.Log(Count);
        //CharCam.transform.position = CurrentQuestion[CQ.currentQuestion].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //CharCam.transform.position = CurrentQuestion[CQ.currentQuestion].transform.position;
        //Debug.Log(CQ.currentQuestion);
    }
}
