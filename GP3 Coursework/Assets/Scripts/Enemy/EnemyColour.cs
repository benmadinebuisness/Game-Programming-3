using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColour : MonoBehaviour
{
    private Renderer EnemyColor;

    private void Start()
    {
        EnemyColor = GetComponent<Renderer>();
    }

    private void Update()
    {
        EnemyColor.material.color = new Color(
            0,
            0,
            EnemyStats._EnemyStats._EnemyEnergyAmount / 10,
            255);
    }
}
