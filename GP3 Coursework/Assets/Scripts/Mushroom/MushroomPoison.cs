using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomPoison : MonoBehaviour
{
    /// <summary>
    /// The class subscribes to the Mushroom delegate event and checks whethere the mushroom is bad or not. Depending on that, certain stats are affacted.
    /// <summary>

    private void Start()
    {
        //Subscribes to the event Mushroom collide with Mushroom CHeck.
        PlayerCollisions._PlayerCollisions.MushroomCollide += MushroomCheck;
    }

    private void MushroomCheck()
    {
        //Checks if the mushroom is bad or not depending on the half life
        if (MushroomLife._MushroomLife._IsPoison)
            PoisonMushroom();
        if (!MushroomLife._MushroomLife._IsPoison)
            NormalMushroom();
    }

    #region Effects
    //These simply add or subtract health, enrgy and score from the player.
    private void PoisonMushroom()
    {
        PlayerScore._PlayerScore._PlayerScoreCount --;
        if (PlayerStats._PlayerStats._PlayerEnergy > 0)
            PlayerStats._PlayerStats._PlayerEnergy --;
        if (PlayerStats._PlayerStats._PlayerHealth > 0)
            PlayerStats._PlayerStats._PlayerHealth --;
    }

    private void NormalMushroom()
    {
        PlayerScore._PlayerScore._PlayerScoreCount ++;
        if (PlayerStats._PlayerStats._PlayerEnergy < 100)
            PlayerStats._PlayerStats._PlayerEnergy ++;
        if (PlayerStats._PlayerStats._PlayerHealth < 100)
            PlayerStats._PlayerStats._PlayerHealth ++;
    }
    #endregion
   
}
