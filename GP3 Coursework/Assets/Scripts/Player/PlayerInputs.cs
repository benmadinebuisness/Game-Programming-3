using UnityEngine;
using System;

public class PlayerInputs : MonoBehaviour
{
    /// <summary>
    /// This class handles all player input throughout the game.
    /// </summary>

    #region Player Movement
        //Sets horizontal and vertical axis, private set so that classes outside this cannot change value.
    public float _Horizontal { get; private set; }
    public float _Vertical { get; private set; }
    #endregion

    #region Player Shooting
        //Booleans to check if player is shooting for both mouse buttons, private set so that classes outside this cannot change value.
    public bool _LeftShoot { get; private set; }
    public bool _RightShoot { get; private set; }
    #endregion

    #region Player Events
        //Player events for shooting, using events so that code is not repeated, any class that calls the Left/Right fire event will called when mouse press.
    public event Action LeftFire = delegate { };
    #endregion

    #region Singleton
        //Creating a singleton.
    public static PlayerInputs _PlayerInputs;
    #endregion

    private void Awake()
    {
        _PlayerInputs = this;
    }

    private void Update()
    {
        Inputs();
    }

    private void Inputs()
    {
        //Assigns values to the variables above.
        _Horizontal = Input.GetAxis("Horizontal");
        _Vertical = Input.GetAxis("Vertical");
        _LeftShoot = Input.GetMouseButton(0);

        //Just a simple IF statement, to see if the boolean is true. If so, event is called.
        if (_LeftShoot)
            LeftFire();
    }
}
