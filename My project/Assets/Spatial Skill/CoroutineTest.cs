using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator RunA()
    {
        Debug.Log("(1) Frame" + Time.frameCount);
        yield return null;
        Debug.Log("(2) Frame" + Time.frameCount);
        yield return null;
        Debug.Log("(3) Frame" + Time.frameCount);
        yield return null;
        Debug.Log("(4) Frame" + Time.frameCount);
        yield return null;
    }
}
