using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DOAnimationManager : MonoBehaviour
{

    Tweener tweener;
    Tweener nowTweener;


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


    public void DOFadeImageLoop(Image image,float fadeLoopSpeed)
    {
              image.DOFade(1f, fadeLoopSpeed)
                        .SetLoops(-1, LoopType.Yoyo)
                        .SetLink(gameObject);
    }
    public void DOFadeTextLoop(Text text,float fadeLoopSpeed)
    {
     nowTweener = text.DOFade(1f,fadeLoopSpeed)
            .SetLoops(-1,LoopType.Yoyo)
            .SetLink(this.gameObject);
        

    }

    public void DORotateObject(GameObject gameObject,float speed,Vector3 vector3)
    {
        gameObject.transform.DORotate(vector3, speed,RotateMode.FastBeyond360)
                            .SetEase(Ease.Linear)
                            .SetLoops(-1, LoopType.Incremental)
                            .SetLink(this.gameObject);

    }


    public void DOTweenerSet()
    {
        tweener = nowTweener;
    }

    public void DOLoopEnd()
    {
        nowTweener.Kill();
    }
    



}
