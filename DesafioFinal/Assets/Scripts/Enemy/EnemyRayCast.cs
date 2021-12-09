using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRayCast : Enemy
{
    public bool isRaycastEnemy;
    public bool canShoot;
    public float distanceRay;
    public int shootCooldown;
    public float timerShoot;
    public GameObject bulletPrefab;
    public Animator animPlayer;
    public GameObject shootOrigen;

    [SerializeField] private ParticleSystem shootParticle;

    // Start is called before the first frame update
    void Start()
    {
        if(isRaycastEnemy){
            animPlayer.SetBool("isShoot", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isRaycastEnemy){
            verifyShoot();
        }

    }

    private void verifyShoot(){
        if (canShoot)
        {
            RaycastShoot();
        }
        else
        {
           timerShoot += Time.deltaTime;
           animPlayer.SetBool("isShoot", false);
        }

     
        if(timerShoot > shootCooldown)
        {
            canShoot = true;
        }  
    }
    
    private void RaycastShoot(){
        RaycastHit hit;
        
        if (Physics.Raycast(shootOrigen.transform.position, shootOrigen.transform.TransformDirection(Vector3.forward), out hit, distanceRay))
        {
            if(hit.transform.tag == "Player")
            {
                Debug.Log("COLISION PLAYER");
                canShoot   = false;
                timerShoot = 0;
                shootParticle.Play();
                GameObject b = Instantiate(bulletPrefab, shootOrigen.transform.position, bulletPrefab.transform.rotation);
                b.GetComponent<Rigidbody>().AddForce(shootOrigen.transform.TransformDirection(Vector3.forward) * 10f, ForceMode.Impulse);
                animPlayer.SetBool("isShoot", true);
            }
        }

    }

    private void OnDrawGizmos()
    {

        if (canShoot) { 
            Gizmos.color = Color.blue;
            Vector3 direction = shootOrigen.transform.TransformDirection(Vector3.forward) * distanceRay;
            Gizmos.DrawRay(shootOrigen.transform.position, direction);
        }

    }



}
