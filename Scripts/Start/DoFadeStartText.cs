using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoFadeStartText : MonoBehaviour
{
    [SerializeField]
    private DOAnimationManager animationManager;

    [SerializeField]
    private Text startText;

    [SerializeField]
    private int fadeSpeed;


    private void Awake()
    {
        animationManager.DOFadeTextInitialize(startText);
    }
    private void Start()
    {
        animationManager.DOFadeTextLoop(startText, fadeSpeed);
    }

    
  
}
