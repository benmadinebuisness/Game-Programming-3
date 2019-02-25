using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    /// <summary>
    /// This class creates the varaibles used for the behaviours and calculates the agents movement.
    /// </summary>

    #region Floats
        // Creates the variables used to control the agent, speed, acceleration.
    public float _MaxSpeed;
    public float _MaxAcceleration;
    #endregion

    #region Vector
        // Creates the agents velocity vector.
    public Vector3 _Velocity;
    #endregion

    #region Steering
        // Gets the steering script.
    protected Steering _Steering;
    #endregion

    /// <summary>
    /// Assigns the Velocity and Steering Values.
    /// </summary>
    void Start ()
    {
        _Velocity = Vector3.zero;
        _Steering = new Steering();
	}
	
    /// <summary>
    /// This method assigns the sttering behaviour.
    /// </summary>
    /// <param name="steering"> The actual steering behaviour being used. </param>
	public void AssignBehaviour(Steering steering)
    {
        // Sets the steering varaible to the behaviour assigned.
        _Steering = steering;
    }

    /// <summary>
    /// This method controls the agents movement.
    /// </summary>
    public virtual void Update()
    {
        // Creates the offset varaible, which is made equal to the agents veclocity multipled by the current time.
        Vector3 offset = _Velocity * Time.deltaTime;
        // Moves the agent towards the offset in the world space.
        transform.Translate(offset, Space.World);
        // Rotates the object to prevent the agent from falling over.
        transform.rotation = new Quaternion();
    }

    /// <summary>
    /// This method updates the behaviours values.
    /// </summary>
    public virtual void LateUpdate()
    {
        // Adds the movement values and time to the Velocity vector.
        _Velocity += _Steering._Movement * Time.deltaTime;
        // Checks is the Velocity value is greator than the max speed.
        if (_Velocity.magnitude > _MaxSpeed)
        {
            // Normalizes the velocity and multiplies it by the max speed.
            _Velocity.Normalize();
            _Velocity = _Velocity * _MaxSpeed;
        }
        // Checks if the Movement is equal to zero.
        if (_Steering._Movement.sqrMagnitude == 0.0f)
        {
            // Sets the velocity to zero.
            _Velocity = Vector3.zero;
        }
        _Steering = new Steering();
    }
}
