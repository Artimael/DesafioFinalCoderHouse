 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;
    private int dificultad;
    // Start is called before the first frame update
    void Start()
    {

        if(GameManager.instance!=null){
        dificultad=GameManager.instance.getDifficult();
        }else{
        dificultad=0;
        }

        Debug.Log("Dificultad: "+dificultad);
        switch(dificultad){
            case 0://Easy
                for(int i=0;i<15;i++){
                    spawnEnemy();
                }
            break;
            case 1://Medium
                for(int i=0;i<20;i++){
                    spawnEnemy();
                }
            break;
            case 2://Hard
                for(int i=0;i<25;i++){
                    spawnEnemy();
                }
            break; 
            default:
                for(int i=0;i<30;i++){
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
