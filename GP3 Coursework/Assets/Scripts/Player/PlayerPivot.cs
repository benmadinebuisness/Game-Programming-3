using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPivot : MonoBehaviour
{
    /// <summary>
    /// This class handles the rotation of the players arm.
    /// <summary>

    #region Singleton
        //Creates a singleton of this class.
    public static PlayerPivot _PlayerPivot;
    #endregion
    
    #region Quaternion
        //Creats a quaternion which is the players direction.
    public Quaternion _PlayerDir;
    #endregion

    // Makes the singleton equal to this script.
    private void Awake()
    {
        _PlayerPivot = this;
    }

    // Calls the lookAt method.
    void Update()
    {
        LookAt();
    }

    private void LookAt()
    {
        // Creates a ray that points to the mouse posiiton.
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Creates the raylength variable.
        float rayLength;
        // Creates a plane varaible which is positioned at the centre of the world.
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        // If the Ray hits the ground plane.
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            // Creates a vector 3 positon of the ray position on the plane.
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            // Turns the players arm to look at the position.
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}
