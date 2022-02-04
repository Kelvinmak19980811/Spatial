using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImgScale : MonoBehaviour
{
    public GameObject img;
    protected Vector3 X;
    // Start is called before the first frame update
    void Start()
    {
        X = new Vector3(img.GetComponent<RectTransform>().localScale.x * 2, img.GetComponent<RectTransform>().localScale.y * 2, img.GetComponent<RectTransform>().localScale.z * 2);
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform T = img.GetComponent<RectTransform>();
        Vector3 Z = new Vector3(T.localScale.x, T.localScale.y, T.localScale.z);
        T.localScale = Vector3.Lerp(Z, X, 1 * Time.deltaTime);
    }
}
