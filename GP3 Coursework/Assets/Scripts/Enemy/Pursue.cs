using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : AgentBehaviour
{
    /// <summary>
    /// This class manages the actual behaviour of the agent. In this case, pursue.
    /// </summary>

    /// <summary>
    /// This method creates the steering behaviour. 
    /// </summary>
    /// <returns> Returns the steering behaviour </returns>
    public override Steering Behaviour()
    {
        // Creates the new steering values. 
        Steering steering = new Steering();
        // Sets the movement values to the distance between the player and the agent.
        steering._Movement = _Player.transform.position - transform.position;
        // Normalizes the value.
        steering._Movement.Normalize();
        // Sets the movement to the movement multiplied by the max agent acceleration.
        steering._Movement = steering._Movement * _Agent._MaxAcceleration;
        // Returns the steering behaviour.
        return steering;
    }
}
