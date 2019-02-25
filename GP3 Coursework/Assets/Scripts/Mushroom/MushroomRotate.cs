using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomRotate : MonoBehaviour
{
    /// <summary>
    /// This class just rotates the mushroom.
    /// <summary>

    #region Float
        // A float identifing the mushroom rotation speed.
        [SerializeField]
    private float _MushroomRotateSpeed;
    #endregion

    // Assigns a random speed to the mushroom on start.
    private void Start()
    {
        _MushroomRotateSpeed = Random.Range(10, 50);
    }

	void Update ()
    {
        // Makes an angle based on a sin wave - affetced by deltatime.
        float angle = Mathf.Sin(Time.deltaTime);
        // Applies the angle and rotation speed to the mushroom rotate field.
        transform.Rotate(Vector3.up, angle * _MushroomRotateSpeed);
	}
}
