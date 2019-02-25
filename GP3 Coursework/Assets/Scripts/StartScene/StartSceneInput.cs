using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneInput : MonoBehaviour
{
    /// <summary>
    /// This script assigns the player name using the value entered in the input field.
    /// </summary>

    #region InputField
        //Creates the variable for the input field. Done this so the text entered can be took.
    private InputField _PLayerNameInput;
    #endregion

    //Calls the assign method.
    private void Start ()
    {
        Assign();
	}
	
    //Assigns the playerNameInput to the input field in the scene.
    private void Assign()
    {
        _PLayerNameInput = GameObject.Find("PlayerNameInput").GetComponent<InputField>();
    }
	
    //Calls the PlayerNameManager method.
	private void Update ()
    {
        PlayerNameManager();
    }

    //Assigns the actual players name to the text entered into the input field.
    private void PlayerNameManager()
    {
        PlayerID._PlayerID._PlayerName = _PLayerNameInput.text;
    }
}
