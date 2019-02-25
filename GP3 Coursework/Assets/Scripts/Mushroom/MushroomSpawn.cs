using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawn : MonoBehaviour
{
    /// <summary>
    /// This class handles the spawning of the mushroom.
    /// <summary>

    #region Mushroom ArrayList
        // Creates a new array called _Mushroom
    [HideInInspector]
    public ArrayList _Mushrooms = new ArrayList();
    #endregion
    
    #region Max Mushrooms
        // Simply sets the max amount of mushrooms to 50.
    private int _MaxMushrooms = 50;
    #endregion

    #region Mushroom Position
    //Saves the mushroom position so it can be inserted into the databse.
    public Vector3 _MushroomPos;
    #endregion

    #region Singleton
    //Creating a singleton for this mushroom class.
    public static MushroomSpawn _MushroomSpawn;
    #endregion

    private void Awake()
    {
        _MushroomSpawn = this;
    }
    void Start ()
    {
        //Makes the mushroom array equal to the array function.
        _Mushrooms = CreateMushrooms();
        // Calls the spawnShroom method at set intervals after 10 seconds.
        InvokeRepeating("SpawnShroom", 10f, Random.Range(5, 10));
	}
	
    private ArrayList CreateMushrooms()
    {
        // Creates a new ArrayList
        ArrayList mushroomCreated = new ArrayList();
        for (int i = 0; i < _MaxMushrooms; i++)
        {
            //For the max amount of mushrooms add the gameobject function SpawnShroom
            mushroomCreated.Add(SpawnShroom());
        }
        //Returns the array created.
        return mushroomCreated;
    }

    private GameObject SpawnShroom()
    {
        // Loads the mushroom object from resources and gives it a random pos between the boundaries and then returns the game object.
        GameObject mushroomObject = (GameObject)Instantiate(Resources.Load("Mushroom"));
        mushroomObject.transform.position = new Vector3(
        Random.Range(PlayerBounds._PLayerBounds._SizeX, -PlayerBounds._PLayerBounds._SizeX),
        0,
        Random.Range(PlayerBounds._PLayerBounds._SizeZ, -PlayerBounds._PLayerBounds._SizeZ));
        _MushroomPos = mushroomObject.transform.position;
        return mushroomObject;
    }
}
