using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    //ENFOQUE POCO EFECTIVO SIN SINGLETON
    [SerializeField] private ObjectManager ObjectManager;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Image imageBuff;
    private float buffSpeed=1.0f;
    private int buffLife=1; 
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.onBuff+= onBuffHandler;
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void onBuffHandler(string buffString){
       Debug.Log("Evento buffString "+buffString);
        if(buffString.Equals("Speed")){
            Debug.Log("Evento Buff Speed");
            GameObject Player=GameObject.FindWithTag("Player");
            float newSpeed=Player.GetComponent<PlayerController>().getSpeed()+buffSpeed;
            Player.GetComponent<PlayerController>().setSpeed(newSpeed);
            gameObject.SetActive(false);
            imageBuff.gameObject.SetActive(true);
            GameManager.instance.AddObjeto(gameObject);

        } else if(buffString.Equals("Life")){
            Debug.Log("Evento Buff Life");
            GameObject Player=GameObject.FindWithTag("Player");
            int scoreActual=GameManager.instance.getScore();
            int nuevaScore= scoreActual - buffLife;
            GameManager.instance.setScore(nuevaScore);
            gameObject.SetActive(false);
            imageBuff.gameObject.SetActive(true);
            GameManager.instance.AddObjeto(gameObject);
        } else if(buffString.Equals("Time")){
            Debug.Log("Evento Buff Time"); 
        }


    }

    private void OnMouseDown()
    {
        Debug.Log("CLICKED "+gameObject.name);
        GameManager.instance.addObjetoArray(gameObject);
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