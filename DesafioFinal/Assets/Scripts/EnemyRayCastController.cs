using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRayCastController : MonoBehaviour
{
    [SerializeField] private GameObject shootOrigen;
    [SerializeField] private float distanceRay = 10f;
    [SerializeField] private int shootCooldown = 2;
    [SerializeField] private float timerShoot = 0;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Animator animPlayer;
    private bool  canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        animPlayer.SetBool("isShoot", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            RaycastToro();
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

    private void RaycastToro()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(shootOrigen.transform.position, shootOrigen.transform.TransformDirection(Vector3.forward), out hit, distanceRay))
        {
            Debug.Log("ACA");
            if(hit.transform.tag == "Player")
            {
                Debug.Log("COLISION PLAYER");
                canShoot   = false;
                timerShoot = 0;
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
