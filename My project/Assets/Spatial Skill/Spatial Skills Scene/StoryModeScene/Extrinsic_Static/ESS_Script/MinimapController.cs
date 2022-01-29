using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    public GameObject MinimapSystem;
    public GameObject ShowMinimap;
    public GameObject HideMinimap;

    public GameObject ConfirmButton;
    public GameObject ShowConfirm;
    public GameObject HideConfirm;
    // Start is called before the first frame update
    void Start()
    {
        ShowMinimap.SetActive(false);
        ShowConfirm.SetActive(false);
    }

    public void TurnOnMinimap()
    {
        MinimapSystem.SetActive(true);
        HideMinimap.SetActive(true);
        ShowMinimap.SetActive(false);
    }

    public void TurnOffMinimap()
    {
        MinimapSystem.SetActive(false);
        HideMinimap.SetActive(false);
        ShowMinimap.SetActive(true);

    }

    public void TurnOnConfirmButton()
    {
        ConfirmButton.SetActive(true);
        HideConfirm.SetActive(true);
        ShowConfirm.SetActive(false);
    }
    public void TurnOffConfirmButton()
    {
        ConfirmButton.SetActive(false);
        HideConfirm.SetActive(false);
        ShowConfirm.SetActive(true);
    }

}
