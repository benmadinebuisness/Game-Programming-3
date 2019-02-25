using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    /// <summary>
    /// Class prevents an object being destroyed through scenes.
    /// </summary>
    

    private void Awake()
    {
        // Creates an array of gameobjects and makes it equal to the dont destroy object in the screen.
        GameObject[] gameObject = GameObject.FindGameObjectsWithTag("DontDestroy");
        // Checks the length of the array and if the length is greater than 1 then destory this gameobject.
        if (gameObject.Length > 1)
        {
            Destroy(this.gameObject);
        }
        // Prevents the object from being destroyed through scenes.
        DontDestroyOnLoad(this.gameObject);
    }
}
