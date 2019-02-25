using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// This class handles the players movement.
    /// </summary>

    #region Vector Movement
        //Vector to assign movement values.
    private Vector3 _Movement;
    #endregion

    #region Player Body
        //Players rigidbody.
    private Rigidbody _Rigidbody;
    #endregion

    #region Player Speed
        //Speed of the player.
    private float _Speed = 10f;
    #endregion

    #region Player Rotation
        //Players rotation value
    private float _Rotation = 90f;
    #endregion

    private void Start()
    {
        GetComps();
    }

    private void GetComps()
    {
        //Assigning the rigidbody value.
        _Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        //Sets the movement values to the horizontal and vertical inputs set in the player input class.
        _Movement = new Vector3(0.0f, 0.0f, PlayerInputs._PlayerInputs._Vertical);
        //Makes direction relative to player.
        _Movement = transform.TransformDirection(_Movement);
        //Rotates the player along the horizontal axis.
        transform.Rotate(0, _Rotation * Time.deltaTime * PlayerInputs._PlayerInputs._Horizontal, 0);
        //Adds the force to the rigidbody, basically what actualy makes the player move.
        _Rigidbody.AddForce(_Movement * _Speed);
    }
}
