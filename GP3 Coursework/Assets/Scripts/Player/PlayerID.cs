using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds the playerID string value.
/// </summary>
public class PlayerID : MonoBehaviour
{
    #region Singleton
        // Creates a singleton value.
    public static PlayerID _PlayerID;
    #endregion

    #region String
        // Creates the _PLayername string.
    public string _PlayerName;
    #endregion

    /// <summary>
    /// Sets the singleton value.
    /// </summary>
    private void Awake()
    {
        _PlayerID = this;
    }
}
