using System;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class GameManager : MonoBehaviour
{
  
   [SerializeField] private Image count;
   [SerializeField] private Sprite[] countImg;
   [SerializeField] private Result resultPanel;
   [SerializeField] private GameObject imgLayer;
   [SerializeField] private TextMeshProUGUI lvlCounter; 

   private Difference[] _differences;
   private int _lvl;
   private DateTime _startTime;
   private GameObject _dif;
   private Image[] _images;
   private bool _isWin;
   
   private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;
   private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;
   private void Start()
   {
      _isWin = false;
      
      YandexGame.Instance._FullscreenShow();
      _lvl = PlayerDataManager.Instance.PlayerData.Level;
      lvlCounter.SetText(_lvl.ToString());

      _dif = Instantiate(Resources.Load<GameObject>($"Diffs/{_lvl}/dif"), imgLayer.transform);
      
      _differences = _dif.GetComponentsInChildren<Difference>();
      Difference.CatchCallBack = CheckWin;
      
      _images = imgLayer.GetComponentsInChildren<Image>();
      _images[0].sprite = Resources.Load<Sprite>($"Diffs/{_lvl}/1");
      _images[1].sprite = Resources.Load<Sprite>($"Diffs/{_lvl}/2");
      
      _startTime = DateTime.Now;
   }

   private void CheckWin()
   {
      var found = _differences.Count(difference => difference.IsCatch);
      count.sprite = countImg[found];
      
      if (found != 5 || _isWin) return;
      _isWin = true;
      PlayerDataManager.Instance.EndLevel((DateTime.Now-_startTime).Seconds);
      resultPanel.SetTime(DateTime.Now-_startTime);
      resultPanel.gameObject.SetActive(true);
   }

   private void Rewarded(int id)
   {
      foreach (var difference in  _differences)
      {
         if (!difference.IsCatch)
         {
            difference.CatchDif();
            break;
         }
      }
   }
   
   public void OpenRewardedVideo()
   {
      YandexGame.RewVideoShow(0);
   }
   
}
