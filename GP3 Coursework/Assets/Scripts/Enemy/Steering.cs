using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering 
{
    /// <summary>
    /// This class is used to store the movement for the agent, the enemy.
    /// </summary>
    /// 
    #region Vector
    // The movement Vector for the agent.
    public Vector3 _Movement;
    #endregion

    public Steering()
    {
        // Sets the movement for the agent.
        _Movement = new Vector3();
    }
}
