using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    /// <summary>
    ///  This class prevents the player from falling off the edges of the map.
    /// </summary>

    #region Player Position
        //Player position vector.
    private Vector3 _PlayerPosition;
    #endregion

    #region Ground GameObject
        //Ground gameobject.
    [HideInInspector]
    public GameObject _Ground;
    #endregion

    #region Ground Sizes
        //Float variables for ground size and hides them in inspector.
    [HideInInspector]
    public float _SizeX, _SizeZ;
    #endregion

    #region Singleton
        //Creating a singleton.
    public static PlayerBounds _PLayerBounds;
    #endregion

    private void Awake()
    {
        _PLayerBounds = this;
        Assign();
    }

    private void Assign()
    {
        //Fidning the ground game object in the scene.
        _Ground = GameObject.Find("Ground");
        //Assigning the X and Z values of the boundary.
        _SizeX = _Ground.GetComponent<Renderer>().bounds.size.x / 2.0f;
        _SizeZ = _Ground.GetComponent<Renderer>().bounds.size.z / 2.0f;
    }

    private void Update()
    {
        BoundaryPosition();
    }

    /// <summary>
    /// Method loops through the values of the player positon and max and min points of the ground
    /// </summary>
    /// <param name="playerPos"> The player position </param>
    /// <param name="minSize"> The smallest ground size </param>
    /// <param name="maxSize"> The largest ground size </param>
    /// <returns></returns>
    private float LoopValue(float playerPos, float minSize, float maxSize)
    {
        //If playerPos is less than minSize then maxSize is returned, else if playerPos 
        //is greater than maxSize then return minSize. Else return the playersPos 
        return playerPos < minSize ? maxSize : playerPos > maxSize ? minSize : playerPos;
    }

    private void BoundaryPosition()
    {
        //Sets the player positon varible to the players position.
        _PlayerPosition = transform.position;
        //Sets the players X/Z position to the float returned by LoopValue
        _PlayerPosition.x = LoopValue(_PlayerPosition.x, -_SizeX, _SizeX);
        _PlayerPosition.z = LoopValue(_PlayerPosition.z, -_SizeZ, _SizeZ);
        //Sets the new player position
        transform.position = _PlayerPosition;
    }
}
