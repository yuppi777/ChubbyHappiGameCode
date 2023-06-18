using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : IPlayerData
{

    private const float SPEED = 2000;
    private const float XSENSI = 3; //c‚ÌŠ´“x
    private const float YSENSI = 3;//‰¡‚ÌŠ´“x
    private const int MAXHP = 100;

    private int Hp = MAXHP; 

    private Transform playerTransform;

    public float speed {get => SPEED;  }
    public float x_sensi { get => XSENSI; }
    public float y_sensi { get => YSENSI; }
    public int maxHp { get => MAXHP; }
    public Transform PlayerTransform { get => playerTransform; set => playerTransform = value; }
    public int hp { get => Hp; set => Hp = value; }
}
