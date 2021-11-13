 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int difficult;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("spawnEnemy",2.0f,1.5f);

        switch(difficult){
            case 0://Easy
                for(int i=0;i<3;i++){
                    spawnEnemy();
                }
            break;
            case 1://Medium
                for(int i=0;i<10;i++){
                    spawnEnemy();
                }
            break;
            case 2://Hard
                for(int i=0;i<20;i++){
                    spawnEnemy();
                }
            break; 
            default:
                for(int i=0;i<10;i++){
                    spawnEnemy();
                }
            break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnEnemy(){
        Instantiate(enemyPrefab, transform.position, enemyPrefab.transform.rotation);
    }
}
