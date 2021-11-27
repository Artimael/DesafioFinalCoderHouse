using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float xRandomPosEnemy;
    private float ZRandomPosEnemy;
    private float timerEnemy=0f;
    private float tiempoColision=0.0f;
    private float MoveCooldown = 5f;
    private bool esDestino=false;
    private Vector3 randomVector;
    private Animator animEnemy;
    [SerializeField] public EnemyData enemyData;

    // Start is called before the first frame update
    void Start()
    {
        if(enemyData.isBasicEnemy){
        transform.position= new Vector3(Random.Range(1f,3f),0.2f,Random.Range(-5f, 15f));
        xRandomPosEnemy = Random.Range(1f,3f);
        ZRandomPosEnemy = Random.Range(-5f, 15f);
        randomVector= new Vector3(xRandomPosEnemy,0,ZRandomPosEnemy);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(enemyData.isBasicEnemy){
            moveEnemy();
            verifyCoolDown();
        }
    }

    private void moveEnemy(){
        if(!esDestino){
            Vector3 direction = (randomVector - transform.position).normalized;
            transform.position+= enemyData.speed * direction * Time.deltaTime;
        }else{
            xRandomPosEnemy = Random.Range(0f,4f);
            ZRandomPosEnemy = Random.Range(-5f, 15f);
            randomVector= new Vector3(xRandomPosEnemy,0,ZRandomPosEnemy);
            esDestino=false;
        }
    }

    private void verifyCoolDown(){
        timerEnemy += Time.deltaTime;
        if(timerEnemy > MoveCooldown)
        {
            xRandomPosEnemy = Random.Range(0f,4f);
            ZRandomPosEnemy = Random.Range(-5f, 15f);
            randomVector= new Vector3(xRandomPosEnemy,0,ZRandomPosEnemy);
            esDestino=false;
            timerEnemy=0f;
        } 
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


    
}