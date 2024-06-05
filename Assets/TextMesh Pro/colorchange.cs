using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class colorchange : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        if (textMeshProUGUI == null)
        {
            textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        }

        UpdateTextColor();
    }

    void UpdateTextColor()
    {
        // Metni renklendir
        textMeshProUGUI.text = "<color=green>1.G�rev - �i�ek toplamak</color>\n<color=red>2.G�rev - �i�ekleri ekmek</color>\n<color=red>3.G�rev - Duay� bulup okumak</color>";
    }
}