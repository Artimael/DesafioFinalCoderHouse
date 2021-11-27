using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Enemy Data",menuName="Enemy Data")]
public class EnemyData : ScriptableObject
{
    //Basic Enemy
    public bool isBasicEnemy;
    public float speed;

    //RayCast Enemy
    // public bool isRaycastEnemy;
    // public bool canShoot;
    // public float distanceRay;
    // public int shootCooldown;
    // public float timerShoot;

    
    
    // [SerializeField] private GameObject shootOrigen;
    // [SerializeField] private float distanceRay = 10f;
    // [SerializeField] private int shootCooldown = 2;
    // [SerializeField] private float timerShoot = 0;
    // [SerializeField] private GameObject bulletPrefab;
    // [SerializeField] private Animator animPlayer;
}
