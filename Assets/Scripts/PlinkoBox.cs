using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlinkoBox : MonoBehaviour
{
    private GameObject variables;
    public float multiplier = 1.0f;

    private void Start()
    {
        variables = GameObject.Find("Variables");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            variables.GetComponent<Variables>().money += other.gameObject.GetComponent<Ball>().value * multiplier;
            variables.GetComponent<Variables>().money = (double)System.Math.Round(variables.GetComponent<Variables>().money, 0);
            Destroy(other.gameObject);
        }
    }
}
