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
        textMeshProUGUI.text = "<color=green>1.Görev - Çiçek toplamak</color>\n<color=red>2.Görev - Çiçekleri ekmek</color>\n<color=red>3.Görev - Duayý bulup okumak</color>";
    }
}