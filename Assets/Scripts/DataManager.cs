using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string username;
    public string bestUsername;
    public int score;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    [System.Serializable]
    class SavedData
    {
        public string bestUsername;
        public int score;
    }

    public void SaveData()
    {
        SavedData data = new SavedData();
        data.bestUsername = bestUsername;
        data.score = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (!File.Exists(path))
            return;

        string json = File.ReadAllText(path);
        SavedData data = JsonUtility.FromJson<SavedData>(json);

        bestUsername = data.bestUsername;
        score = data.score;
    }
}
