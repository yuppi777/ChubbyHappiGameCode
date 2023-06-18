using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClearMove : MonoBehaviour
{
    [SerializeField]
    [Header("シーン内にあるTextAnimationManager")]
    private DOAnimationManager textAnimation;

    [SerializeField]
    private Text ClearText;

    [SerializeField]
    private float fadespeed;

    [SerializeField]
    [Header("タイトルボタンのイメージ")]
    private Image TitolButton;
    private void Awake()
    {
        textAnimation.DOFadeTextInitialize(ClearText);
        textAnimation.DOFadeImageInitialize(TitolButton);
        //textAnimation.DOFadeImageInitialize(TitolButton);
    }
    void Start()
    {
        textAnimation.DOFadeInText(ClearText, fadespeed);
        textAnimation.DOFadeImageLoop(TitolButton, fadespeed);
    }

    // Update is called once per frame
   
}
