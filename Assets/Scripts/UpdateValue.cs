using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class UpdateValue : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public GameObject variables;
    
    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Value: " + FormatMoney(variables.GetComponent<Variables>().dropValue);
    }

    string FormatMoney(double money)
    {
        string moneyString = money.ToString();
        string formattedMoney = "";
        for (int i = 0; i < moneyString.Length; i++)
        {
            if (i != 0 && i % 3 == 0)
            {
                formattedMoney = "," + formattedMoney;
            }
            formattedMoney = moneyString[moneyString.Length - 1 - i] + formattedMoney;
        }
        return formattedMoney;
    }
}