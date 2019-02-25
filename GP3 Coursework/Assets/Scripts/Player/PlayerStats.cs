using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    /// <summary>
    /// This class handles the different playerstats that are loaded to the database.
    /// <summary>

    #region Singleton
        // Creates a singleton.
    public static PlayerStats _PlayerStats;
    #endregion

    #region Player Stats
        // Assigns the playeerHealth and energy a value and creates the player position vecotor.
    public float _PlayerHealth = 100;
    public float _PlayerEnergy = 0;
    public Vector3 _PlayerPosition;
    #endregion

    // Assigns the singleton.
    private void Awake()
    {
        _PlayerStats = this;
    }

    //Sets the player to the position from the database.
    private void Start()
    {
        GameObject.Find("Player").GetComponent<Transform>().position = _PlayerPosition;
    }

    // Assigns the playerPosition varaible to the players position in game. In late update so it does not override the database value before it is applied.
    private void LateUpdate()
    {
        _PlayerPosition = GameObject.Find("Player").GetComponent<Transform>().position;
    }
}
