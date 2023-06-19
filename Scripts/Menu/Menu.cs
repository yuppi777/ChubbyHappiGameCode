using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UniRx;

public class Menu : MonoBehaviour
{
    [SerializeField]
    [Header("メニュー画面")]
    private Image _menu;

    [SerializeField]
    private CusLook cusLook;    

    private void Awake()
    {
        _menu.transform.DOScale(new Vector3(0f, 0f, 0), 0f);
        _menu.gameObject.SetActive(true);
        
       

    }
    private void Start()
    {
        Observable.EveryUpdate()
                 .Where(_ => Input.GetKeyDown(KeyCode.Escape))
                 .Subscribe(value =>
                 {
                     
                     OnClick();
                 })
                 .AddTo(this);
    }

    /// <summary>
    /// メニューを開く処理
    /// </summary>
    public void OnClick()
    {
        cusLook.AnLookCus();
        _menu.transform.DOScale(new Vector3(1f, 1f, 0),1f);
        
    }

    public void OnClose()
    {
        cusLook.LookCus();
        _menu.transform.DOScale(new Vector3(0f, 0f, 0), 1f);

    }
}
