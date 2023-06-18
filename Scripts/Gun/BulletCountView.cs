using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCountView : MonoBehaviour
{

    [SerializeField] 
    List<GameObject> bullets;

    [SerializeField] 
    public Text reloadText;

    [SerializeField]
    [Header("�����[�h�e�L�X�g�̃t�F�C�h�X�s�[�h")]
    private int reloadFadeSpeed;

    public int ReloadFadeSpeed { get => reloadFadeSpeed;  }

    public void SetBulletCount(int bulletCount)
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            GameObject bullet = bullets[i];
            bullet.SetActive(bulletCount > i);

        }
    }

   



}
