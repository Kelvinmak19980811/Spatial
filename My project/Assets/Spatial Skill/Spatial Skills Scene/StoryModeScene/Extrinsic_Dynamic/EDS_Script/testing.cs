using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject testcharacter;
    public GameObject lookat;
    public GameObject target;

    public RuntimeAnimatorController run;

    private Animator animator;
    void Start()
    {
        float SpawnX = target.transform.position.x + Random.Range(0, 50);
        float SpawnZ = target.transform.position.z + Random.Range(0, 50);
        Vector3 SpawnPos = new Vector3(SpawnX, target.transform.position.y, SpawnZ);
        testcharacter = Instantiate(testcharacter, SpawnPos, Quaternion.identity);
        testcharacter.transform.LookAt(target.transform.position);

        animator = testcharacter.GetComponent<Animator>();
        animator.runtimeAnimatorController = run;
        animator.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(testcharacter.transform.position, target.transform.position) < 1f)
        {
            animator.SetBool("isRunning", false);
        }
    }
}
