using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject variables;

    public void AllIn()
    {
        variables.GetComponent<Variables>().dropValue = variables.GetComponent<Variables>().money;
    }

    public void GameReset()
    {
        variables.GetComponent<Variables>().dropValue = 10;
        variables.GetComponent<Variables>().money = 1000;
    }
}
