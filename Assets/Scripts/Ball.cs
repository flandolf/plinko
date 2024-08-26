using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public double value = 0;
    private GameObject variables;
    void Start()
    {
        variables = GameObject.Find("Variables");
        value = variables.GetComponent<Variables>().dropValue;
    }
}
