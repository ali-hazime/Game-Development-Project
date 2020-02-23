using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static string[] saveFiles = {"/playerData.game", "/monsterData.game" };
    public static void SavePlayer(PlayerChar playerchar)
    {
        
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerData.game";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        GameData data = new GameData(playerchar);
        formatter.Serialize(stream, data);
        stream.Close();
        
    }

    public static void SaveEnemy(EnemyHealth eh)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/monsterData.game";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(eh);
        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static GameData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/playerData.game";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
                
            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

    public static GameData LoadEnemy()
    {
        string path = Application.persistentDataPath + "/monsterData.game";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}
