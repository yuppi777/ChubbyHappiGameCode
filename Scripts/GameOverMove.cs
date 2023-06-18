using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOverMove : MonoBehaviour
{
    [SerializeField]
    private Button exitButton;

    [SerializeField]
    private Text gameOverText;

    [SerializeField]
    private float fadeLoopSpeed;

    [SerializeField]
    private float fadeInSpeed;


    private void Awake()
    {
        gameOverText.DOFade(0.0f, 0f)
                    .SetLink(gameObject);
        exitButton.image.DOFade(0.0f, 0f)
                        .SetLink(gameObject);
    }
    private void Start()
    {
        DOFadeInText();
            
    }

    private void GameOver()
    {
     
    }

    private void DOFadeInText()
    {
        gameOverText.DOFade(1f, fadeInSpeed)
                    .SetEase(Ease.Linear)
                    .SetLink(this.gameObject)
                    .OnComplete(() => { DOFadeLoop(); });
    }

    private void DOFadeLoop()
    {
        exitButton.image.DOFade(1f, fadeLoopSpeed)
                        .SetLoops(-1, LoopType.Yoyo)
                        .SetLink(gameObject);
    }





}
