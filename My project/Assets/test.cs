using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    
    public Animation Ani;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if(Ani.isPlaying == false)
        {
            AnimationState state = Ani["Terry"];
            Ani.Play();
            state.time = 0;
            Ani.Sample();
            state.enabled = false;
        }   
    }
}
