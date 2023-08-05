using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class EndGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI allTimeUI;
    private void Start()
    {
        allTimeUI.SetText(TimeSpan.FromSeconds(PlayerDataManager.Instance.PlayerData.AllTime).ToString("c"));
    }

    public void ResetSave()
    {
        PlayerDataManager.Instance.ReSave();
        SceneManager.LoadScene(1);
    }
}
