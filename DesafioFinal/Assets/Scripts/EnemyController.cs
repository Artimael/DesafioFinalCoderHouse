using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private float xRandomPosEnemy;
    private float ZRandomPosEnemy;
    private Vector3 randomVector;
    private bool esDestino=false;
    private float speed=3.0f;
    private float tiempoColision=0.0f;
    private float damageEnemy=5.0f;


    // Start is called before the first frame update
    void Start()
    {
        transform.position= new Vector3(Random.Range(1f,3f),0.2f,Random.Range(-5f, 15f));
        Debug.Log("Inicio Enemy: "+transform.position);
        xRandomPosEnemy = Random.Range(1f,3f);
        ZRandomPosEnemy = Random.Range(-5f, 15f);
        randomVector= new Vector3(xRandomPosEnemy,0,ZRandomPosEnemy);
        Debug.Log("randomVector Enemy: "+randomVector);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("randomVector Enemy: "+randomVector+ " Inicio Enemy"+transform.position);
        if(!esDestino){
            Vector3 direction = (randomVector - transform.position).normalized;
            transform.position+= speed * direction * Time.deltaTime;
            //Debug.Log("direction Enemy: "+transform.position);
            if(transform.position.x == xRandomPosEnemy && transform.position.z == ZRandomPosEnemy){
                Debug.Log("Llegue");
                esDestino=true;
            }

        }else{
            xRandomPosEnemy = Random.Range(0f,4f);
            ZRandomPosEnemy = Random.Range(-5f, 15f);
            randomVector= new Vector3(xRandomPosEnemy,0,ZRandomPosEnemy);
            esDestino=false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);    
    }

    
    private void OnCollisionStay(Collision other){

        if (other.gameObject.CompareTag("Muro"))
        {
           tiempoColision=tiempoColision+Time.deltaTime;
        } 
        //Debug.Log("tiempoColision "+tiempoColision);
        if(tiempoColision>2.0f){
            Debug.Log("Colisionaste mas de 2f");
            xRandomPosEnemy = Random.Range(0f,4f);
            ZRandomPosEnemy = Random.Range(-5f, 15f);
            //Debug.Log("xRandomPosEnemy "+xRandomPosEnemy);
            //Debug.Log("ZRandomPosEnemy "+ZRandomPosEnemy);
            randomVector= new Vector3(xRandomPosEnemy,0,ZRandomPosEnemy);
            esDestino=false;
            tiempoColision=0f;
            
        }else{

        }
 

        
    }

    public float getDamage(){
        return damageEnemy;
    }


    
}
