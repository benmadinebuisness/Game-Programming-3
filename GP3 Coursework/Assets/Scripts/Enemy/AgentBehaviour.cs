using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehaviour : MonoBehaviour
{
    /// <summary>
    /// This class is used as the agents base class. The use of the virtual methods allow the contents to be overritten by the agent.
    /// </summary>

    #region GameObject
    // Variable for the player object.
    public GameObject _Player;
    #endregion

    #region Agent
    // Sets the agent script.
    protected Agent _Agent;
    #endregion

    /// <summary>
    /// Sets the agent script variable. Gets it from the attached gameobject.
    /// </summary>
    public virtual void Awake()
    {
        _Agent = gameObject.GetComponent<Agent>();
    }

    /// <summary>
    /// Calls the Set steering behaviour from the Agent class and sets it to the steering behaviour that is returned from the Behaviour class.
    /// </summary>
    public virtual void Update()
    {
        _Agent.AssignBehaviour(Behaviour());
    }

   /// <summary>
   /// Returns the Steering Behaviour fromt the Pursue class. Method is virtual so that it can be overitten by inherited class, Pursue.
   /// </summary>
   /// <returns> Returns the steering behaviour. </returns>
    public virtual Steering Behaviour()
    {
        return new Steering();
    }
}
