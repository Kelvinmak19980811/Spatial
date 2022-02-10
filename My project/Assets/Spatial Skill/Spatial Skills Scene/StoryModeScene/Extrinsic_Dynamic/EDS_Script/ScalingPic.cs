using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScalingPic : MonoBehaviour
{
    // Start is called before the first frame update
    TransitionManager TranManager;

    private Animator animator;


    void Start()
    {
        TranManager = gameObject.GetComponent<TransitionManager>();
    }

    public void PicMoving()
    {
        animator = TranManager.PictureFrame.GetComponent<Animator>();
        animator.SetBool("isMoving", true);
        Debug.Log(TranManager.PictureFrame.GetComponent<Animator>());
        TranManager.isScaling = false;
        
    }
}
