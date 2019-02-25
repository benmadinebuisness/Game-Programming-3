using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class SQLiteManager : MonoBehaviour
{
    #region File Location of database.
    // The database file path. If you want to see it simply uncomment the second line the start method!
    public string _DBPath { get; set; }
    public string _DatabaseName { get; set; }
    #endregion

    #region PrimaryKeys
    public int _PlayerPrimaryKey { get; set; }
    #endregion

    public void CreateDatabase(string databaseName)
    {
        _DBPath = "URI=file:" + Application.persistentDataPath + "/" + _DatabaseName + ".db";
        CreateSchema(databaseName);
    }

    private void CreateSchema(string databaseInfo)
    {
        // Using the databse from the datapath.
        using (var conn = new SqliteConnection(_DBPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                //Creates the database if their isnt one already called the database name and add the following stats.
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS " + databaseInfo;

                var result = cmd.ExecuteNonQuery();
            }
        }
    }
}
