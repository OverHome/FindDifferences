using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Difference : MonoBehaviour
{
    public static Action CatchCallBack { get; set; }
    public bool IsCatch { get; private set; }
    [SerializeField] private Image dif1;
    [SerializeField] private Image dif2;

    private void Start()
    {
        IsCatch = false;
        dif1 = dif1.GetComponent<Image>();
        dif2 = dif2.GetComponent<Image>();
        dif1.fillAmount = 0;
        dif2.fillAmount = 0;
    }

    public void CatchDif()
    {
        if (IsCatch) return;
        IsCatch = true;
        dif1.DOFillAmount(1, 1);
        dif2.DOFillAmount(1, 1).OnComplete(() =>
        {
            CatchCallBack.Invoke();
        });
    }
}