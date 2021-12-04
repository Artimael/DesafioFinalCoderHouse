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

    private Vector3 enemyPosMin;
    private Vector3 enemyPosMax;

    // Start is called before the first frame update
    void Start()
    {
        if(enemyData.isBasicEnemy){
        enemyPosMin=GameManager.instance.getEnemyPosMin();
        enemyPosMax=GameManager.instance.getEnemyPosMax();
        transform.position= new Vector3(Random.Range(enemyPosMin.x,enemyPosMax.x),enemyPosMin.y,Random.Range(enemyPosMin.z,enemyPosMax.z));
        xRandomPosEnemy = Random.Range(enemyPosMin.x,enemyPosMax.x);
        ZRandomPosEnemy = Random.Range(enemyPosMin.z,enemyPosMax.z);
        randomVector= new Vector3(xRandomPosEnemy,enemyPosMin.y,ZRandomPosEnemy);
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
            xRandomPosEnemy = Random.Range(enemyPosMin.x,enemyPosMax.x);
            ZRandomPosEnemy = Random.Range(enemyPosMin.z,enemyPosMax.z);
            randomVector= new Vector3(xRandomPosEnemy,enemyPosMin.y,ZRandomPosEnemy);
            esDestino=false;
        }
    }

    private void verifyCoolDown(){
        timerEnemy += Time.deltaTime;
        if(timerEnemy > MoveCooldown)
        {
            xRandomPosEnemy = Random.Range(enemyPosMin.x,enemyPosMax.x);
            ZRandomPosEnemy = Random.Range(enemyPosMin.z,enemyPosMax.z);
            randomVector= new Vector3(xRandomPosEnemy,enemyPosMin.y,ZRandomPosEnemy);
            esDestino=false;
            timerEnemy=0f;
        } 
    }
   
    private void OnCollisionStay(Collision other){

        if (other.gameObject.CompareTag("Muro"))
        {
           tiempoColision=tiempoColision+Time.deltaTime;
        } 
        if(tiempoColision>2.0f){
            Debug.Log("Colisionaste mas de 2f");
            xRandomPosEnemy = Random.Range(enemyPosMin.x,enemyPosMax.x);
            ZRandomPosEnemy = Random.Range(enemyPosMin.z,enemyPosMax.z);
            randomVector= new Vector3(xRandomPosEnemy,enemyPosMin.y,ZRandomPosEnemy);
            esDestino=false;
            tiempoColision=0f;
            
        }else{

        }
 

      
    }


    
}