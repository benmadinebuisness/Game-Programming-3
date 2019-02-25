using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    /// <summary>
    /// This class simply detects if the player has clicked the 'Quit' game button and if they do then the applcation will close.
    /// </summary>
    
    public void QuitButton()
    {
        Application.Quit();
    }
}
