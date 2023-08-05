using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
   public void LoadGameScene()
   {
      if (Resources.Load<GameObject>($"Diffs/{PlayerDataManager.Instance.PlayerData.Level}/dif") == null)
      {
         SceneManager.LoadScene(2);
         return;
      }
      SceneManager.LoadScene(sceneBuildIndex: 1);
   }
}
