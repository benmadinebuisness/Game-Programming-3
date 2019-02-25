using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// This class handles the player collisions.
/// </summary>
public class PlayerCollisions : MonoBehaviour
{
    #region Delegates
        //Creating a event that will reference when players enter mushrooms.
    public event Action MushroomCollide = delegate { };
    #endregion

    #region Singleton
        // Creating a singleton to refernce the class.
    public static PlayerCollisions _PlayerCollisions;
    #endregion

    /// <summary>
    /// Setting the singleton.
    /// </summary>
    private void Awake()
    {
        _PlayerCollisions = this;
    }

    /// <summary>
    /// Handles the collisions triggers.
    /// </summary>
    /// <param name="other"> The other parameter is the object that has been collided with </param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mushroom")
        {
            // Destroy the mushroom and calls the event.
            Destroy(other.gameObject);
            MushroomCollide();
        }

        if(other.tag == "Blackhole")
        {
            // Sets the player death boolean to true if hits the black hole.
            PlayerDeath._PlayerDeath._PLayerDie = true;
        }
    }
}
