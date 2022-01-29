using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Target;
    public GameObject Area;
    // Start is called before the first frame update
    void Start()
    {
        Target.transform.LookAt(Area.transform.position);
        Camera();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Camera()
    {
        Debug.Log("Camera");
        Vector3 MCPos = MainCamera.transform.position;

        Vector3 MCPosEnd = new Vector3(Target.transform.position.x, 2, Target.transform.position.z);

        MainCamera.transform.position = Vector3.Lerp(MCPos, MCPosEnd, 1 * Time.deltaTime);

        MainCamera.transform.LookAt(Area.transform.position);
    }
}
