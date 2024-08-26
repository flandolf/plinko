using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class UpdateMoney : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public GameObject variables;
    
    // Update is called once per frame
    void Update()
    {
        double money = variables.GetComponent<Variables>().money;
        moneyText.text = "Money: " + money;
    }

   
}