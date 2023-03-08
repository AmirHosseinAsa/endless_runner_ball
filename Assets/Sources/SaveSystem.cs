
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveMenuSettings(MenuSettingsData menuSettings)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/menusettings.un";
        FileStream stream = new FileStream(path, FileMode.Create);

        MenuSettingsData data = new MenuSettingsData(menuSettings);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static MenuSettingsData LoadMenuOptionSettings()
    {
        string path = Application.persistentDataPath + "/menusettings.un";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            MenuSettingsData data = formatter.Deserialize(stream) as MenuSettingsData;
            stream.Close(); 
            
            return data;
        }
        else
        {
            return null;
        }
    }

    public static void SaveMaxmimumScore(ScoreData score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.un";
        FileStream stream = new FileStream(path, FileMode.Create);

        ScoreData data = new ScoreData(score);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ScoreData LoadMaximumScore()
    {
        string path = Application.persistentDataPath + "/score.un";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ScoreData data = formatter.Deserialize(stream) as ScoreData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
