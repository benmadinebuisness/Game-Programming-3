using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    /// <summary>
    /// This class handles the enemy stats that are used for the data base.
    /// </summary>
    /// 

    #region Singleton
        //Creates a singleton.
    public static EnemyStats _EnemyStats;
    #endregion

    #region Float
    // For the current enemy amount
    public float _EnemyEnergyAmount;
    #endregion

    #region Vector
       // For the enemy position.
    public Vector3 _EnemyPosition;
    #endregion


    private void Awake()
    {
        //Sets the singleton
        _EnemyStats = this;
    }

    private void Start()
    {
        // If the enemy is at the origin and doesnt have a file in the data base
        if(_EnemyPosition == null || _EnemyPosition == Vector3.zero)
            transform.position = new Vector3(-47f, 1f, 44f);
        else
            transform.position = _EnemyPosition; // Sets position to position in data base
    }

    private void LateUpdate()
    {
        // Updates the enemy position variable after everythign else
        _EnemyPosition = transform.position;
    }
}
