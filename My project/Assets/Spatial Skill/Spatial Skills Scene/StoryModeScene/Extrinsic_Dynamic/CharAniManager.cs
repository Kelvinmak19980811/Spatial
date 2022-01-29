using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAniManager : MonoBehaviour
{
    public GameObject[] Char;
    public GameObject Area;
    private GameObject Character;
    protected Vector3 CharPos;
    private float charspeed = 0.1f;
    protected static Animator animator;
    [SerializeField] protected RuntimeAnimatorController idle;
    [SerializeField] protected RuntimeAnimatorController running;

    public GameObject Target;
    public Vector3 CharPosition = new Vector3(100, 1 , 100);

    public GameObject MainCamera;

    public GameObject MCam;

    public LayerMask _CullingLayer;

    private Vector3 SpawnCharPos;
    // Start is called before the first frame update
    void Start()
    {
        float RandX, RandZ;
        RandX = Area.transform.position.x + Random.Range(Area.transform.localScale.x / 2, -Area.transform.localScale.x / 2);
        RandZ = Area.transform.position.z + Random.Range(Area.transform.localScale.z / 2, -Area.transform.localScale.z / 2);
        SpawnCharPos = new Vector3(RandX, 1, RandZ);
        Character = Instantiate(Char[Random.Range(0, Char.Length)], CharPosition, Quaternion.identity);
        Character.transform.localScale = new Vector3 (2, 2, 2);
        Character.layer = 10;
        foreach (Transform T in Character.transform) //set character child object tag and layer
        {
            T.gameObject.tag = Character.tag; // set character child obj tag
            T.gameObject.layer = Character.layer; // set character child obj layer
        }
        Character.transform.LookAt(Area.transform.position);
        animator = Character.GetComponent<Animator>();
    }

    private void Update()
    {
        CharMovement();
    }

    public void CharMovement()
    {
        CharPos = new Vector3(Character.transform.position.x , 1, Character.transform.position.z);
        animator.runtimeAnimatorController = running;
        Character.transform.position = Vector3.Lerp(CharPos, Area.transform.position, charspeed * Time.deltaTime);

        if(Vector3.Distance(CharPos, Area.transform.position) < 1f)
        {
            Debug.Log("Arrive");
            animator.runtimeAnimatorController = idle;
            Character.transform.rotation = Quaternion.Lerp(Character.transform.rotation, Quaternion.LookRotation(Target.transform.position), 1 * Time.deltaTime);
            CameraMove();
        }
    }

    void CameraMove()
    {
        Debug.Log("Camera");
        Vector3 MCPos = MainCamera.transform.position;

        Vector3 MCPosEnd = new Vector3(CharPos.x, 2, CharPos.z);

        MainCamera.transform.position = Vector3.Lerp(MCPos, MCPosEnd, 1 * Time.deltaTime);

        Transform AreaRotate = Area.transform;

        MainCamera.transform.rotation = Quaternion.Lerp(MainCamera.transform.rotation, Quaternion.LookRotation(Target.transform.position), 0.5f * Time.deltaTime);

        if (Vector3.Distance(MainCamera.transform.position, MCPosEnd) < 1f)
        {
            MainCamera.GetComponent<Camera>().cullingMask = _CullingLayer;
        }
    }
}
