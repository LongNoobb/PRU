using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ArmorBar : MonoBehaviour
{
    public Image armorBar;
    public TextMeshProUGUI armorText;
    public void UpdateBar(int currentValue, int maxValue)
    {
        armorBar.fillAmount = (float)currentValue / (float)maxValue;
        armorText.text = currentValue.ToString() + " / " + maxValue.ToString();
    }
}
