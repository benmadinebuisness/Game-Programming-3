using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundUI : MonoBehaviour
{
    /// <summary>
    /// This class contains the two methods for the two buttons found in the start screen.
    /// </summary>
    
    /// When the button is clicked, destroy the background gameobject.
    public void DestroyMushroom()
    {
        Destroy(GameObject.Find("Background"));
    }

    //When the start game button is clicked, the load the new scene.
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
