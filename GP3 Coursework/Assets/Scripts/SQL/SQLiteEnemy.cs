using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class SQLiteEnemy : SQLiteManager
{
    /// <summary>
    /// This class is responsible for creating the EnemySQL leaderboard, inherits from the SQLiteManager.
    /// </summary>
    
    #region IDKey
    [SerializeField]
    private int _EnemyID , _PlayerID;
    #endregion

    /// <summary>
    /// Calls method and assigns the database name.
    /// </summary>
    private void Start()
    {
        _DatabaseName = "EnemyStatistics";
        CreateEnemyDatabase();
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
            // Assigns the PlayerID variable to the ID retrieved from the PLayer SQL class.
            _PlayerID = SQLitePlayer._SQLitePlayer.GetPlayerID();
            GetSetEnemyStats();          
        }
    }

    /// <summary>
    /// This method Creates the database for the Enemy.
    /// </summary>
    private void CreateEnemyDatabase()
    {
        //Creates the database if their isnt one already called the database name and add the following stats.
        CreateDatabase("'EnemyStatistics'  ( " +
                                  "  'id' INTEGER PRIMARY KEY, " +
                                  "  'energy' FLOAT NOT NULL, " +
                                  "  'xcoord' FLOAT NOT NULL, " +
                                  "  'ycoord' FLOAT NOT NULL, " +
                                  "  'zcoord' FLOAT NOT NULL " +
                                  ");");
    }

    /// <summary>
    /// Inserts the enemy data into the database.
    /// </summary>
    /// <param name="enemyEnergy"> The enemy energy level. </param>
    /// <param name="enemyX"> The enemy x position. </param>
    /// <param name="enemyY"> The enemy y position. </param>
    /// <param name="enemyZ"> The enemy z position. </param>
    private void InsertEnemyData(float enemyEnergy, float enemyX, float enemyY, float enemyZ)
    {
        using (var conn = new SqliteConnection(_DBPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                //Inserts the corresponding values to the correct information in the database.
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO EnemyStatistics (energy, xcoord, ycoord, zcoord) " +
                                  "VALUES (@Energy, @Xcoord, @Ycoord, @Zcoord);";

                #region Adding the values to the database.
                //Adds the enemyEnergy(position etc...) to the parameterName 'Energy' which links to the 'energy' collum in the database.
                cmd.Parameters.Add(new SqliteParameter { ParameterName = "Energy", Value = enemyEnergy });

                cmd.Parameters.Add(new SqliteParameter { ParameterName = "Xcoord", Value = enemyX });

                cmd.Parameters.Add(new SqliteParameter { ParameterName = "Ycoord", Value = enemyY });

                cmd.Parameters.Add(new SqliteParameter { ParameterName = "Zcoord", Value = enemyZ });
                #endregion
                var result = cmd.ExecuteNonQuery();
            }
        }
    }

    /// <summary>
    /// This method is used to update the enemy data from the database. It is called when the session has finished and if their is already an Enemy
    /// with the same ID in the database.
    /// </summary>
    /// <param name="enemyID"> The enemy ID, is the same as the current playerID. </param>
    /// <param name="enemyEnergy"> The current amount of energy the enemy has. </param>
    /// <param name="enemyX"> X coordinate of the enemy. </param>
    /// <param name="enemyY"> Y coordinate of the enemy. </param>
    /// <param name="enemyZ"> Z coordinate of the enemy. </param>
    private void UpdateEnemyData(int enemyID, float enemyEnergy, float enemyX, float enemyY, float enemyZ)
    {
        using (var conn = new SqliteConnection(_DBPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                //Updates the database with the current players values.
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE EnemyStatistics" +
                                                   " SET energy = " + enemyEnergy +
                                                   ", xcoord = " + enemyX +
                                                   ", ycoord = " + enemyY +
                                                   ", zcoord = " + enemyZ +
                                                   " WHERE id = '" + enemyID + "'";
                var result = cmd.ExecuteNonQuery();
            }
        }
    }

    /// <summary>
    /// This method, gets the users stats from the database and sets them to the player.
    /// </summary>
    private void GetSetEnemyStats()
    {     
        using (var conn = new SqliteConnection(_DBPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                //Selects all the data from the database.
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM EnemyStatistics;";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Sets the ID to the first item in the database which is the ID in the database.
                    var ID = reader.GetInt32(0);
                    // If enemy ID is equal to the Player ID, means that the correct enemy is loaded to the player.
                    if (ID == _PlayerID)
                    {
                        _EnemyID = ID;
                        #region Sets the variables to their position in the database. //TEST PLS
                        var energy = reader.GetFloat(1);
                        var xPos = reader.GetFloat(2); var yPos = reader.GetFloat(3); var zPos = reader.GetFloat(4);
                        #endregion
                        #region Sets the current enemies stats to their saved stats in the database.
                        EnemyStats._EnemyStats._EnemyEnergyAmount = energy;
                        EnemyStats._EnemyStats._EnemyPosition = new Vector3(xPos, yPos, zPos);
                        #endregion

                    }
                }
            }
        }
    }

    /// <summary>
    /// Calls when the application has been quit.
    /// </summary>
    private void OnApplicationQuit()
    {
        //If the enemy ID is the same as the players then update the enemies data with the one already in the database. If not add the new enemy data to the databse.
        if(_EnemyID == _PlayerID)
        {
            UpdateEnemyData(_EnemyID, EnemyStats._EnemyStats._EnemyEnergyAmount,
            EnemyStats._EnemyStats._EnemyPosition.x,
            EnemyStats._EnemyStats._EnemyPosition.y,
            EnemyStats._EnemyStats._EnemyPosition.z);
        }
        else
        {
            InsertEnemyData(EnemyStats._EnemyStats._EnemyEnergyAmount,
            EnemyStats._EnemyStats._EnemyPosition.x,
            EnemyStats._EnemyStats._EnemyPosition.y,
            EnemyStats._EnemyStats._EnemyPosition.z);
        
        }
    }
}
