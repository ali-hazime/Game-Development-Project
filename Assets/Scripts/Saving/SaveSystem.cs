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
    }

    public static void SaveQuestInfo()
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/questInfo.game";
        FileStream stream = new FileStream(path, FileMode.Create);

        QuestInfo data = new QuestInfo();
        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static QuestInfo LoadQuestInfo()
    {
        string path = Application.persistentDataPath + "/questInfo.game";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            QuestInfo data = formatter.Deserialize(stream) as QuestInfo;
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
    public static void SaveQuestData()
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/questInfo.game";
        FileStream stream = new FileStream(path, FileMode.Create);

        //QuestData data = new QuestData(quest.QTitle, quest.QDescription, quest.MyCollectObjectives, quest.MyKillObjectives, quest.MyKillBosses, quest.MyEscortQuests, quest.MyTalkToQuests);
        //formatter.Serialize(stream, data);
        //stream.Close();

        foreach (Quest quest in QuestLog.MyInstance.MyQuests)
        {
            QuestData data = new QuestData(quest.QTitle, quest.QDescription, quest.MyCollectObjectives, quest.MyKillObjectives, quest.MyKillBosses, quest.MyEscortQuests, quest.MyTalkToQuests); ;
            data.MyQuestData.Add(new QuestData(quest.QTitle, quest.QDescription, quest.MyCollectObjectives, quest.MyKillObjectives, quest.MyKillBosses, quest.MyEscortQuests, quest.MyTalkToQuests));
        }

    }

    public static QuestData LoadQuestData()
    {
        string path = Application.persistentDataPath + "/questInfo.game";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            QuestData data = formatter.Deserialize(stream) as QuestData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
    */
}
