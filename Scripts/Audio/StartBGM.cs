using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBGM : MonoBehaviour
{
    [SerializeField]
    [Header("—¬‚·BGM")]
    private string _bgmname;

    void Start()
    {
        AudioManager.Instance.PlayBGM(_bgmname);
    }

    // Update is called once per frame
    
}
