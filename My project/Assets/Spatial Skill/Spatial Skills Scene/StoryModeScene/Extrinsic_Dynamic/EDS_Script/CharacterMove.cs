using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Animator animator; // no need to define

    private GameObject Character;
    private int i = 0;
    //test
    private TransitionManager TranManager;
    

    void Start()
    {
        TranManager = gameObject.GetComponent<TransitionManager>();

        //Character = TranManager.Character[i];
    }

    public void Spawn()
    {
        DestroyObj("Character");
        float SpawnX = TranManager.PlayerChoice.transform.position.x + Random.Range(0, 50);
        float SpawnZ = TranManager.PlayerChoice.transform.position.z + Random.Range(0, 50);
        Vector3 SpawnPos = new Vector3(SpawnX, 1, SpawnZ);

        i = Random.Range(0, TranManager.Character.Length);

        Character = Instantiate(TranManager.Character[i], SpawnPos, Quaternion.identity);

        animator = Character.GetComponent<Animator>();

        Character.name = ("Character");
        Character.tag = "Character";
        Character.layer = 10;

        animator.runtimeAnimatorController = TranManager.isRunning;

        TranManager.isMoving = true;
    }

    public void CharacterMoving()
    {
        Character.transform.LookAt(TranManager.PlayerChoice.transform.position);

        Vector3 CharPos = Character.transform.position;

        //Debug.Log(CharPos);

        if (Vector3.Distance(CharPos, TranManager.PlayerChoice.transform.position) < 1.5f)
        {
            TranManager.isMoving = false;
            animator.SetBool("isRunning", false);
            TranManager.isTurning = true;
        }
    }

    public void CharacterRotation()
    {
        Quaternion SpawnCharRotation = Character.transform.rotation;
        
        Quaternion.Lerp(SpawnCharRotation, Quaternion.LookRotation(TranManager.Area.transform.position), 1 * Time.deltaTime);

        if(Quaternion.Angle(SpawnCharRotation, Quaternion.LookRotation(TranManager.Area.transform.position)) < 1)
        {
            TranManager.isTurning = false;
            TranManager.isScaling = true;
        }
    }

    private void DestroyObj(string ObjectTag)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(ObjectTag);
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
    }
}
