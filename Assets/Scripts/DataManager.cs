using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DataManager : MonoBehaviour
{
    private string _name;
    public static DataManager Instance;

    private void Awake()
    {
        print(Application.persistentDataPath + "/savefile.json");
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string playerName)
    {
        _name = playerName;
    }

    public TopPlayerData GetTop()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            TopPlayerData data = JsonUtility.FromJson<TopPlayerData>(json);
            return data;
        }
        else return null;
    }

    public void SetTop(int score, string currentName)
    {
        TopPlayerData data = new TopPlayerData(score, currentName);
        string json = JsonUtility.ToJson(data);
        
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    [Serializable]
    public class TopPlayerData
    {
        public int _score;
        public string _name;

        public TopPlayerData(int score, string name)
        {
            _score = score;
            _name = name;
        }

        private TopPlayerData(){}
    }
}
