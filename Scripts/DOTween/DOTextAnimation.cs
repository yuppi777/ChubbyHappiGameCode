using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DOTextAnimation : MonoBehaviour
{




    /// <summary>
    /// テキストを最初にFadeする関数
    /// </summary>
    /// <param name="text"></param>
    public void DOFadeTextInitialize(Text text)
    {
        text.DOFade(0.0f, 0f)
                   .SetLink(gameObject);
    }
    /// <summary>
    /// イメージを最初にFadeする関数
    /// </summary>
    /// <param name="image"></param>
    public void DOFadeImageInitialize(Image image)
    {

       image.DOFade(0.0f, 0f)
                   .SetLink(gameObject);
    }


    public void DOFadeInText(Text text,float fadespeed)
    {
        text.DOFade(1f, fadespeed)
                    .SetEase(Ease.Linear)
                    .SetLink(this.gameObject);
                    
    }


    public void DOFadeLoop(Image image,float fadeLoopSpeed)
    {
              image.DOFade(1f, fadeLoopSpeed)
                        .SetLoops(-1, LoopType.Yoyo)
                        .SetLink(gameObject);
    }

    
}
