using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(PlayerChar playerchar)
    {
        
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerData.game";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        PlayerGameData data = new PlayerGameData(playerchar);
        formatter.Serialize(stream, data);
        stream.Close();
        
    }

    public static PlayerGameData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/playerData.game";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerGameData data = formatter.Deserialize(stream) as PlayerGameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

    /*
    public static void SaveGameInfo()
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gameInfo.game";
        FileStream stream = new FileStream(path, FileMode.Create);

        InfoGameData data = new InfoGameData();
        formatter.Serialize(stream, data);
        stream.Close();

    }
    
    public static InfoGameData LoadGameInfo()
    {
        string path = Application.persistentDataPath + "/gameInfo.game";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            InfoGameData data = formatter.Deserialize(stream) as InfoGameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }*/
}
