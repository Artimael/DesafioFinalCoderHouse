using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    //ENFOQUE POCO EFECTIVO SIN SINGLETON
    [SerializeField] private ObjectManager ObjectManager;
    [SerializeField] private Camera mainCamera;
    private float buffSpeed=1.0f; 
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.onBuff+= onBuffHandler;
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void onBuffHandler(float speedPlayer){
        Debug.Log("Evento Buff Speed");
        GameObject Player=GameObject.FindWithTag("Player");
        float newSpeed=speedPlayer+buffSpeed;
        Player.GetComponent<PlayerController>().setSpeed(newSpeed);
        gameObject.SetActive(false);
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