using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAniManager : MonoBehaviour
{
    public GameObject[] Char;
    [SerializeField]
    GameObject Area;
    private GameObject SpawnChar;
    private float charspeed = 1.0f;
    public RuntimeAnimatorController idle;
    public RuntimeAnimatorController running;

    private Vector3 SpawnCharPos;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCharPos = new Vector3(Area.transform.position.x + 10, 1, Area.transform.position.z + 10);
        SpawnChar = Instantiate(Char[Random.Range(0, Char.Length)], SpawnCharPos, Quaternion.identity);
        SpawnChar.name = ("Character");
        SpawnChar.transform.LookAt(Area.transform.position);
        SpawnChar.tag = ("Character");
        SpawnChar.layer = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharMovement()
    {
        SpawnChar.GetComponent<Animator>().runtimeAnimatorController = running;
        SpawnChar.transform.position = Vector3.Lerp(SpawnChar.transform.position, Area.transform.position, charspeed * Time.deltaTime);

        if(SpawnChar.transform.position.x == Area.transform.position.x && SpawnChar.transform.position.z == Area.transform.position.z)
        {
            SpawnChar.GetComponent<Animator>().runtimeAnimatorController = idle;
        }

    }
}
