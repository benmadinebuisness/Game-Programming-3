using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    /// <summary>
    /// This class handles the players score.
    /// </summary>

    #region Playerscore
        // Creates a variable to hold the players score.
    public int _PlayerScoreCount = 0;
    #endregion

    #region Singleton
        // Creates a singleton.
    public static PlayerScore _PlayerScore;
    #endregion

    // Assigns the singleton to this script.
    private void Awake()
    {
        _PlayerScore = this;
    }
}
