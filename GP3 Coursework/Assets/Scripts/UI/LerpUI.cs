using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpUI : MonoBehaviour
{
    /// <summary>
    /// This class handles the lerp when the leaderboard moves down from the top of the screen.
    /// </summary>

    #region Transforms
        // Varaible for the end position of the lerp.
    public Transform endPos;
    #endregion
    #region Floats
        // Variable for the users speed.
    public float speed;
    #endregion

    //Check if the player is dead and if so then call the lerp function.
    void Update()
    {
        if (PlayerDeath._PlayerDeath._PLayerDie)
            Lerp();
    }

    // Changes the position of the leaderboard to the end position over time, speed.
    private void Lerp()
    {
        transform.position = Vector2.Lerp(transform.position, endPos.position, speed);
    }
}
