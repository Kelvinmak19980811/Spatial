using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAniManager : MonoBehaviour
{
    public GameObject[] Char;
    [SerializeField]
    GameObject Area;
    private GameObject Character;
    private float charspeed = 1.0f;
    public Animator animator;
    public RuntimeAnimatorController idle;
    public RuntimeAnimatorController running;

    RandomSpawnManager RSP;

    public GameObject MCam;

    private Vector3 SpawnCharPos;
    // Start is called before the first frame update
    void Start()
    {
        float RandX, RandZ;
        RandX = Area.transform.position.x + Random.Range(Area.transform.localScale.x / 2, -Area.transform.localScale.x / 2);
        RandZ = Area.transform.position.z + Random.Range(Area.transform.localScale.z / 2, -Area.transform.localScale.z / 2);
        SpawnCharPos = new Vector3(RandX, 1, RandZ);
        Character = Instantiate(Char[Random.Range(0, Char.Length)], SpawnCharPos, Quaternion.identity);
        Character = RSP.SpawnObjDetail("Character", "Character", 10);
        Character.transform.LookAt(Area.transform.position);
        animator = Character.GetComponent<Animator>();

        Character.GetComponent<Animator>();
        Camera();
    }

    private void Update()
    {
        
    }

    public void CharMovement()
    {
        Vector3 CharPos = Character.transform.position;
        animator.runtimeAnimatorController = running;
        Character.transform.position = Vector3.Lerp(CharPos, Area.transform.position, charspeed * Time.deltaTime);

        if(Vector3.Distance(CharPos, Area.transform.position) < 0.1f)
        {
            Debug.Log("Arrive");
            animator.runtimeAnimatorController = idle;
        }
    }

    void Camera()
    {
        Debug.Log("Camera");
        Vector3 MCPos = MCam.transform.position;

        Vector3 MCPosEnd = new Vector3(Character.transform.position.x, 2, Character.transform.position.z);

        MCam.transform.position = Vector3.Lerp(MCPos, MCPosEnd, charspeed * Time.deltaTime);
        
        MCam.transform.LookAt(Area.transform.position);
    }
}
