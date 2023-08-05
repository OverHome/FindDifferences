using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeUI;
    [SerializeField] private TextMeshProUGUI bestTimeUI;
    
    public void SetTime(TimeSpan time)
    {
        timeUI.SetText(time.ToString("mm':'ss"));
        bestTimeUI.SetText(TimeSpan.FromSeconds(PlayerDataManager.Instance.PlayerData.BestTime).ToString("mm':'ss"));
    }

    public void NextLevel()
    {
        if (Resources.Load<GameObject>($"Diffs/{PlayerDataManager.Instance.PlayerData.Level}/dif") == null)
        {
            SceneManager.LoadScene(2);
            return;
        }
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
