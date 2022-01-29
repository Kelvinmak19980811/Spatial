using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LikeBar : MonoBehaviour
{
    public Image Likebar;
    public float CurrentHealth;
    private float MaxHealth = 5f;
    EDS_QM CountHealth;
    // Start is called before the first frame update
    void Start()
    {
        Likebar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = CountHealth.CorrectCount;
        Likebar.fillAmount = CurrentHealth / MaxHealth;
    }
}
