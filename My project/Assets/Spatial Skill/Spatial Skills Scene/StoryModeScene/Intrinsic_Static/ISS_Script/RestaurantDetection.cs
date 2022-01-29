using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RestaurantDetection : MonoBehaviour
{
    public bool PlayerDetect;

    // Start is called before the first frame update
    void Start()
    {
        PlayerDetect = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerDetect = true;
            Debug.Log("Player Enter Restaurant?");
        }
        return;
    }

    private void OnTriggerExit (Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerDetect = false;
            Debug.Log("Player leave the Restaurant!");
        }
        return;
    }
}
