using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.UI;

public class SQLitePlayer : SQLiteManager
{
    /// <summary>
    /// This class is responsible for creating the Player Leaderboard. It inherits from the SQL Manager Script.
    /// </summary>
    
    #region UI Features
    // The highscore text and add score button seen on the leaderboard UI.
    public Text _HighScoreText; private Button _AddScoreButton;
    #endregion

    #region String
    // A variable to hold the player name, which allows for the score to be updated or added a new.
    public string _PlayerName;
    #endregion

    #region Boolean
    // This boolean makes sure than the addStats button can be clicked only once.
    private bool _OnlyOnce;
    #endregion

    #region Singleton
        // Creates a singleton for this class.
    public static SQLitePlayer _SQLitePlayer;
    #endregion

    /// <summary>
    /// Simply assigns the singleton.
    /// </summary>
    private void Awake()
    {
        _SQLitePlayer = this;
    }

    /// <summary>
    /// Calls method and assigns the databse name.
    /// </summary>
    private void Start()
    {
        _DatabaseName = "PlayerStatistics";
        CreatePlayerDatabase();
    }

    /// <summary>
    /// This method is called when a new scene is loaded.
    /// </summary>
    /// <param name="level"></param>
    private void OnLevelWasLoaded(int level)
    {
        // If the level is equal to 1, which is 'SampleScene' in this case.
        if (level == 1)
        {
            //Calls the following methods and sets the HighScoreText object.
            GetSetPlayerStats();
            DatabaseButton();
            _HighScoreText = GameObject.Find("PlayerStats").GetComponent<Text>();
            DisplayPlayerScores(5);
        }
    }

    /// <summary>
    /// This method Creates the database for the player.
    /// </summary>
    private void CreatePlayerDatabase()
    {
        //Creates the database if their isnt one already called the database name and add the following stats.
        CreateDatabase("'PlayerStatistics'  ( " +
                                  "  'id' INTEGER PRIMARY KEY, " +
                                  "  'name' TEXT NOT NULL, " +
                                  "  'score' INTEGER NOT NULL, " +
                                  "  'health' FLOAT NOT NULL, " +
                                  "  'energy' FLOAT NOT NULL, " +
                                  "  'xcoord' FLOAT NOT NULL, " +
                                  "  'ycoord' FLOAT NOT NULL, " +
                                  "  'zcoord' FLOAT NOT NULL " +
                                  ");");
    }

    /// <summary>
    /// This method is called when the button is clicked.
    /// </summary>
    public void AddDatabaseInfo()
    {
        //Checks that the onlyOnce bool is set to false.
        if (!_OnlyOnce)
        {
            // If the player name is equal to a name in the database then update the database.
            if (PlayerID._PlayerID._PlayerName == _PlayerName)
            {
                //Call the UpdatePlayerData method.
                UpdatePlayerData(PlayerID._PlayerID._PlayerName,
                PlayerScore._PlayerScore._PlayerScoreCount,
                PlayerStats._PlayerStats._PlayerHealth,
                PlayerStats._PlayerStats._PlayerEnergy,
                PlayerStats._PlayerStats._PlayerPosition.x, PlayerStats._PlayerStats._PlayerPosition.y, PlayerStats._PlayerStats._PlayerPosition.z);
                //Call the DisplayedHighScores method and set the boolean to true.
                DisplayPlayerScores(5);
                _OnlyOnce = true;
            }
            //If the name doesnt equal a name in the database.
            else
            {
                //Call the insertPlayerData.
                InsertPlayerData(PlayerID._PlayerID._PlayerName,
                PlayerScore._PlayerScore._PlayerScoreCount,
                PlayerStats._PlayerStats._PlayerHealth,
                PlayerStats._PlayerStats._PlayerEnergy,
                PlayerStats._PlayerStats._PlayerPosition.x, PlayerStats._PlayerStats._PlayerPosition.y, PlayerStats._PlayerStats._PlayerPosition.z);
                //Call the DisplayedHighScores method and set the boolean to true.
                DisplayPlayerScores(5);
                _OnlyOnce = true;
            }
        }
    }

    /// <summary>
    /// This method initialy inserts the player data into the database.
    /// </summary>
    /// <param name="playerName"> The players name. </param>
    /// <param name="playerScore"> The players score. </param>
    /// <param name="playerHealth"> The players health. </param>
    /// <param name="playerEnergy"> The players energy. </param>
    /// <param name="playerX"> The players X position. </param>
    /// <param name="playerY"> The players Y position. </param>
    /// <param name="playerZ"> The players Z position. </param>
    private void InsertPlayerData(string playerName, int playerScore, float playerHealth, float playerEnergy, float playerX, float playerY, float playerZ)
    {
        using (var conn = new SqliteConnection(_DBPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                //Inserts the corresponding values to the correct information in the database.
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO PlayerStatistics (name, score, health, energy, xcoord, ycoord, zcoord) " +
                                  "VALUES (@Name, @Score, @Health, @Energy, @Xcoord, @Ycoord, @Zcoord);";

                #region Adding the values to the database.
                //Adds the playerName(score etc...) to the parameterName 'Name' which links to the 'name' collum in the database.
                cmd.Parameters.Add(new SqliteParameter { ParameterName = "Name", Value = playerName });

                cmd.Parameters.Add(new SqliteParameter { ParameterName = "Score", Value = playerScore });

                cmd.Parameters.Add(new SqliteParameter { ParameterName = "Health", Value = playerHealth });

                cmd.Parameters.Add(new SqliteParameter { ParameterName = "Energy", Value = playerEnergy });

                cmd.Parameters.Add(new SqliteParameter { ParameterName = "Xcoord", Value = playerX });

                cmd.Parameters.Add(new SqliteParameter { ParameterName = "Ycoord", Value = playerY });

                cmd.Parameters.Add(new SqliteParameter { ParameterName = "Zcoord", Value = playerZ });
                #endregion
                var result = cmd.ExecuteNonQuery();
            }
        }
    }

    /// <summary>
    /// This method updates the current users stats.
    /// </summary>
    /// <param name="dataBase"> The name of the database. </param>
    /// <param name="playerName"> The players name. </param>
    /// <param name="playerScore"> The players score. </param>
    /// <param name="playerHealth"> The players health. </param>
    /// <param name="playerEnergy"> The players energy. </param>
    /// <param name="playerX"> The players X position. </param>
    /// <param name="playerY"> The players Y position. </param>
    /// <param name="playerZ"> The players Z position. </param>
    private void UpdatePlayerData(string playerName, int playerScore, float playerHealth, float playerEnergy, float playerX, float playerY, float playerZ)
    {
        using (var conn = new SqliteConnection(_DBPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                //Updates the database with the current players values.
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE PlayerStatistics" +
                                                   " SET score = " + playerScore +
                                                   ", health = " + playerHealth +
                                                   ", energy = " + playerEnergy +
                                                   ", xcoord = " + playerX +
                                                   ", ycoord = " + playerY +
                                                   ", zcoord = " + playerZ +
                                                   " WHERE name = '" + playerName + "'";
                var result = cmd.ExecuteNonQuery();
            }
        }
    }

    /// <summary>
    /// This method, gets the users stats from the database and sets them to the player.
    /// </summary>
    private void GetSetPlayerStats()
    {
        using (var conn = new SqliteConnection(_DBPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                //Selects all the data from the database.
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM PlayerStatistics;";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Sets the username varaible to the second item in the database colum, which is the user name
                    var userName = reader.GetString(1); 
                    
                    // Checks if the player name is equal to the username variable above. If so, set the other player stats and retrive fromn database.
                    if (PlayerID._PlayerID._PlayerName == userName)
                    {
                        _PlayerName = userName;
                        var score = reader.GetInt32(2); 
                        var health = reader.GetFloat(3); 
                        var energy = reader.GetFloat(4);

                        var xPos = reader.GetFloat(5); var yPos = reader.GetFloat(6); var zPos = reader.GetFloat(7); 
                        PlayerScore._PlayerScore._PlayerScoreCount = score;
                        PlayerStats._PlayerStats._PlayerHealth = health;
                        PlayerStats._PlayerStats._PlayerEnergy = energy;
                        PlayerStats._PlayerStats._PlayerPosition = new Vector3(xPos, yPos, zPos);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Gets the current highscores.
    /// </summary>
    /// <param name="limit"> The limit is the number of highscores displayed. </param>
    private void DisplayPlayerScores(int limit)
    {
        //Sets the highscore text equal to nothing.
        _HighScoreText.text = "";
        using (var conn = new SqliteConnection(_DBPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                //Selects the scores from the database and ordereds them.
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM PlayerStatistics ORDER BY score DESC LIMIT @Count;";

                //Adds a new parameter to the database for the limit of scores displayed.
                cmd.Parameters.Add(new SqliteParameter { ParameterName = "Count", Value = limit });

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Sets the id variable to the first item in the database, name to second, score to thrird.
                    var id = reader.GetInt32(0);
                    var highScoreName = reader.GetString(1);
                    var score = reader.GetInt32(2);
                    // Sets the text string to display the high scores.
                    var text = string.Format("Name: {0} || Score: {1} || ID: [#{2}]", highScoreName, score, id);
                    //Creates a new line in the highscoreText variable so the scores arent on the same line.
                    _HighScoreText.text += text + "\n";
                }
            }
        }
    } 

    /// <summary>
    /// A integar method used to return the current playersID. The ID us used to associate the correct enemy agent with the correct player.
    /// </summary>
    /// <returns> The players primary Key, the ID </returns>
    public int GetPlayerID()
    {
        using (var conn = new SqliteConnection(_DBPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                //Selects the specific ID from that databse where the name is equal to the name the user entered.
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT id FROM PlayerStatistics WHERE name = '" + _PlayerName + "'";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Sets the ID to the first item in the database which is the ID in the database.
                    var playerID = reader.GetInt32(0);
                    //Sets the _PlayerPrimaryKey to the playerID.
                    _PlayerPrimaryKey = playerID;
                }
            }
        }
        //Retruns the players ID.
        return _PlayerPrimaryKey;
    }

    /// <summary>
    /// This method attaches to the button.
    /// </summary>
    private void DatabaseButton()
    {
        _AddScoreButton = GameObject.Find("AddStatsButton").GetComponent<Button>();
        _AddScoreButton.onClick.AddListener(AddDatabaseInfo);
    }

    /// <summary>
    /// Calls when the application has been quit.
    /// </summary>
    private void OnApplicationQuit()
    {
        UpdatePlayerData(PlayerID._PlayerID._PlayerName,
                PlayerScore._PlayerScore._PlayerScoreCount,
                PlayerStats._PlayerStats._PlayerHealth,
                PlayerStats._PlayerStats._PlayerEnergy,
                PlayerStats._PlayerStats._PlayerPosition.x, PlayerStats._PlayerStats._PlayerPosition.y, PlayerStats._PlayerStats._PlayerPosition.z);
    }
}
