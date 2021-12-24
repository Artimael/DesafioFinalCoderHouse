using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemController : MonoBehaviour
{
    //ENFOQUE POCO EFECTIVO SIN SINGLETON
    [SerializeField] private ObjectManager ObjectManager;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Image imageBuff;
    [SerializeField] private string buffString;

    private float buffSpeed=1.0f;
    private int buffLife=1; 
    public static event Action<int> onDeathChange;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other) {
         if (other.tag=="Player"){
             GameObject Player=other.gameObject;
            if(buffString.Equals("Speed")){
                Debug.Log("Evento Buff Speed");
                float newSpeed=Player.GetComponent<PlayerController>().getSpeed()+buffSpeed;
                Player.GetComponent<PlayerController>().setSpeed(newSpeed);
                gameObject.SetActive(false);
                imageBuff.gameObject.SetActive(true);
                GameManager.instance.AddObjeto(gameObject);
                GameManager.instance.setUseBuff(true);

            } else if(buffString.Equals("Life")){
                Debug.Log("Evento Buff Life");
                gameObject.SetActive(false);
                imageBuff.gameObject.SetActive(true);
                int scoreActual=GameManager.instance.getScore();
                int nuevaScore= scoreActual - buffLife;
                GameManager.instance.setScore(nuevaScore);
                GameManager.instance.AddObjeto(gameObject);
                onDeathChange?.Invoke(GameManager.instance.getScore()); 
                GameManager.instance.setUseBuff(true); 

            } else if(buffString.Equals("Time")){
                Debug.Log("Evento Buff Time");
                gameObject.SetActive(false);
                imageBuff.gameObject.SetActive(true);  
                GameManager.instance.setSpeedBuffEnemy(true);  
                GameManager.instance.setUseBuff(true); 
                GameManager.instance.AddObjeto(gameObject);      
            }  
        }
     
    
    }


    private void OnMouseDown()
    {
        Debug.Log("CLICKED "+gameObject.name);
        //GameManager.instance.addObjetoArray(gameObject);
        GameManager.instance.AddDictionary(gameObject.name, gameObject);
        GameManager.instance.AddObjeto(gameObject);
        Debug.Log("indexObjetoArray: "+GameManager.indexObjetoArray);
        Debug.Log("ObjetoQueue: "+GameManager.objetoQueue.Count);
        Debug.Log("ObjetoDictionary: "+GameManager.objetoDictionary.Count);
        gameObject.SetActive(false);
    }

    public void setBuffSpeed(float newBuffSpeed){
        buffSpeed=newBuffSpeed;
    }

    public float getBuffSpeed(){
        return buffSpeed;
    }
    
}