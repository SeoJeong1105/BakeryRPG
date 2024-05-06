using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaleList : MonoBehaviour
{
    private Button closeBtn;
    private RectTransform rect;

    private void Awake() {
        rect = GetComponent<RectTransform>();
        closeBtn = GetComponentInChildren<Button>();
    }

    public void OpenList()
    {
        rect.anchoredPosition = Vector3.zero;
    }
    public void CloseList()
    {
        rect.anchoredPosition = new Vector2(0, -1500);
    }
}
