using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the Player's colour vector.
/// </summary>
public class PlayerColour : MonoBehaviour
{
    #region Renderer
        // Accessing the renderer component on the player.
    private Renderer _PlayerColour;
    #endregion

    /// <summary>
    /// Sets the renderer value to the component.
    /// </summary>
    private void Start()
    {
        _PlayerColour = GetComponent<Renderer>();
    }

    /// <summary>
    /// Updates the players colour material dependin gon the current engergy value.
    /// </summary>
    private void Update()
    {
        _PlayerColour.material.color = new Color(
           - PlayerStats._PlayerStats._PlayerEnergy/10, 
           - PlayerStats._PlayerStats._PlayerEnergy/10,
           - PlayerStats._PlayerStats._PlayerEnergy/10, 
            255);   
    }
}
