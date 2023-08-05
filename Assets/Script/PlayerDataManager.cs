using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance { get; set; }

    public PlayerData PlayerData { get; private set; }
    

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeManager();
    }

    private void InitializeManager()
    {

    }

    private void GetLoad()
    {
        PlayerData = new PlayerData
        {
            AllTime = YandexGame.savesData.allTime,
            BestTime = YandexGame.savesData.bestTime,
            Level = YandexGame.savesData.level
        };
        var s = PlayerData.AllTime + " " + PlayerData.BestTime + " " + PlayerData.Level;
        print(s);
        s = YandexGame.savesData.allTime + " " + YandexGame.savesData.bestTime + " " + YandexGame.savesData.level;
        print(s);
    }

    public void EndLevel(int time)
    {
        PlayerData.Level++;
        if (time < PlayerData.BestTime || PlayerData.BestTime == 0)
        {
            PlayerData.BestTime = time;
        }
        
        PlayerData.AllTime += time;
        SaveData();
    }

    private void SaveData()
    {
        YandexGame.savesData.allTime = PlayerData.AllTime;
        YandexGame.savesData.bestTime = PlayerData.BestTime;
        YandexGame.savesData.level = PlayerData.Level;
        YandexGame.SaveProgress();
    }
    
    public void ReSave()
    {
        YandexGame.ResetSaveProgress();
        SaveData();
    }
}