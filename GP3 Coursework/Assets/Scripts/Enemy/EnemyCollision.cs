using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats._PlayerStats._PlayerEnergy --;
            EnemyStats._EnemyStats._EnemyEnergyAmount ++;
            PlayerStats._PlayerStats._PlayerHealth --;
            PlayerScore._PlayerScore._PlayerScoreCount --;
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blackhole")
        {
            Destroy(gameObject);
        }
    }
}
