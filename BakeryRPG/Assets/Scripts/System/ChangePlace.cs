using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlace : MonoBehaviour
{
    public GameObject movePanel;

    public void OnMoveButtonClick()
    {
        if(movePanel.activeSelf)
            movePanel.SetActive(false);
        else
            movePanel.SetActive(true);
    }

    public void OnBackButtonClick()
    {
        movePanel.SetActive(false);
    }
}
