using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMove : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Target;
    public GameObject Area;
    // Start is called before the first frame update
    void Start()
    {
        Target.transform.LookAt(Area.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Camera();
    }

    public void Camera()
    {
        Debug.Log("Camera");
        Vector3 MCPos = MainCamera.transform.position;

        Vector3 MCPosEnd = new Vector3(Target.transform.position.x, 2, Target.transform.position.z);

        MainCamera.transform.position = Vector3.Lerp(MCPos, MCPosEnd, 1 * Time.deltaTime);

        Transform AreaRotate = Area.transform;

        MainCamera.transform.rotation = Quaternion.Lerp(MainCamera.transform.rotation, Quaternion.LookRotation(Area.transform.position), 1 * Time.deltaTime);   
    }

    
}
