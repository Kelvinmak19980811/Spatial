using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDS_Test : MonoBehaviour
{
    public GameObject CharCam;
    public GameObject ChooseChar;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharCamMove()
    {
        Vector3 Choose = new Vector3(ChooseChar.transform.position.x, 1.5f, ChooseChar.transform.position.z);
        CharCam.transform.position = Vector3.Lerp(CharCam.transform.position, Choose, Time.deltaTime);

        Vector3 currentAngle = new Vector3(
        Mathf.LerpAngle(CharCam.transform.rotation.eulerAngles.x, ChooseChar.transform.rotation.eulerAngles.x, Time.deltaTime),
        Mathf.LerpAngle(CharCam.transform.rotation.eulerAngles.y, ChooseChar.transform.rotation.eulerAngles.y, Time.deltaTime),
        Mathf.LerpAngle(CharCam.transform.rotation.eulerAngles.z, ChooseChar.transform.rotation.eulerAngles.z, Time.deltaTime));

        CharCam.transform.eulerAngles = currentAngle;
    }
}
