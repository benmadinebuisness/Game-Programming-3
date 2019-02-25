using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Fireweapon class manages the projectile spawning and rotation when first instantiated.
/// </summary>
public class FireWeapon : MonoBehaviour
{
    #region Gameobjects
        // The projectile is the actual bullet objects and the _Shotpoint is where the projectile spawns.
    private GameObject _Projectile, _Shotpoint;
    #endregion

    #region Floats
        // The timeshot is the time that the bullet counts down to and starttimeshot is the initial shot time.
    private float _Timeshot, _StartTimeshot = 0.10f;
    #endregion

    /// <summary>
    /// Subscribes to the event from player inputs. The shotpoint object is also found.
    /// </summary>
    private void Start()
    {
        PlayerInputs._PlayerInputs.LeftFire += Shooting;
        _Shotpoint = GameObject.Find("ShotPoint");
    }

    /// <summary>
    /// Timeshot value is declained every seconed.
    /// </summary>
    private void Update()
    {
        _Timeshot -= Time.deltaTime;
    }

    /// <summary>
    /// The project is loaded from resources. The transform position is set to the shot point and so is the rotation. The timeshot is made equal to the initial value.
    /// </summary>
    private void Shooting()
    {
        if (_Timeshot < 0)
        {
            _Projectile = (GameObject)Instantiate(Resources.Load("Projectile"));
            _Projectile.transform.position = _Shotpoint.transform.position;
            _Projectile.transform.rotation = _Shotpoint.transform.rotation;
            _Timeshot = _StartTimeshot;
        }
    }
}
