using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player Death class just holds values for the players death boolean and creates a singleton.
/// </summary>
public class PlayerDeath : MonoBehaviour
{
    #region Singleton
        // Sets up a singleton value.
    public static PlayerDeath _PlayerDeath;
    #endregion

    #region Boolean
        // Players death boolean.
    public bool _PLayerDie;
    #endregion

    /// <summary>
    /// Sets the singleton.
    /// </summary>
    private void Awake()
    {
        _PlayerDeath = this;
    }
}
