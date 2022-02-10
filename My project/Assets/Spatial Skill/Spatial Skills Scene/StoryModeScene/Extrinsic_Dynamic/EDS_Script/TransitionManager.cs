using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterMove CharMove;

    private ScalingPic ScalPic;

    public GameObject PlayerChoice; //need to define from button
    public GameObject Area;//need to define from area gameobject

    public GameObject[] Character;

    public RuntimeAnimatorController isRunning;

    public bool isMoving = false;
    public bool isTurning = false;
    public bool isScaling = false;

    public GameObject PictureFrame;
    

    void Start()
    {
        CharMove = gameObject.GetComponent<CharacterMove>();
        ScalPic = gameObject.GetComponent<ScalingPic>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving == true)
        {
            CharMove.CharacterMoving();
        }

        if(isTurning == true)
        {
            CharMove.CharacterRotation();
        }

        if(isScaling == true)
        {
            ScalPic.PicMoving();
        }
    }

    public void CharacterManager()
    {
        CharMove.Spawn();
    }
}
