using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour
{
    /// <summary>
    /// This class simply manages most of the games UI.
    /// </summary>

    #region Images
        //The different variables for the health, image and score.
    private Image _PlayerHealthImage, _PlayerEnergyImage, _PlayerScoreImage;
    #endregion

    #region Player score
        // The variable for the player score text.
    private Text _PLayerScoreText;
    #endregion

    //Calls the assign method on start.
    void Start ()
    {
        Assign();
	}

    //Simply assigns the following variables by finding the correct componenet for them.
    private void Assign()
    {
        _PlayerHealthImage = GameObject.Find("HealthImageFill").GetComponent<Image>();
        _PlayerEnergyImage = GameObject.Find("EnergyImageFill").GetComponent<Image>();
        _PlayerScoreImage = GameObject.Find("ScoreFill").GetComponent<Image>();
        _PLayerScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    //Calls the three methods below.
	void Update ()
    {
        PlayerHealthManager();
        PlayerEnergyManager();
        PlayerScoreManager();
    }

    //Sets the fill amount of the health to max and then devided by 100 because max fill amount is 1.
    private void PlayerHealthManager()
    {
        _PlayerHealthImage.fillAmount = PlayerStats._PlayerStats._PlayerHealth / 100;
    }

    //Sets the fill amount of energy to the current energy level divided by 100.
    private void PlayerEnergyManager()
    {
        _PlayerEnergyImage.fillAmount = PlayerStats._PlayerStats._PlayerEnergy / 100f;
    }

    //Displays the player score in text form as well the fillamount for the text.
    private void PlayerScoreManager()
    {
        _PLayerScoreText.text = "Score: " + PlayerScore._PlayerScore._PlayerScoreCount;
        _PlayerScoreImage.fillAmount = PlayerScore._PlayerScore._PlayerScoreCount / 50f;
    }
}
