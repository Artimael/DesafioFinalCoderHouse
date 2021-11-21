using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int score=0;
    public static int difficult;

    public static Queue objetoQueue;
    public static Dictionary<string, GameObject> objetoDictionary;
    public static GameObject[] objetoArray;
    public static int indexObjetoArray = 0;

    private void Awake()
    {
        objetoQueue = new Queue();
        objetoDictionary = new Dictionary<string, GameObject>();
        objetoArray = new GameObject[4];

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void addScore(){
        score++;
    }

    public int getScore(){
        return score;
    }

    public void setDifficult(int difficulties){
        Debug.Log("Difficulties: "+difficulties);
        difficult=difficulties;
    }

    public int getDifficult(){
        Debug.Log("difficultGet: "+difficult);
        return difficult;
    }

    public void AddObjeto(GameObject objeto)
    {
        objetoQueue.Enqueue(objeto);
    }

    public GameObject GetObjeto()
    {
        return objetoQueue.Dequeue() as GameObject;
    }

    public void AddDictionary(string key, GameObject objeto)
    {
        objetoDictionary.Add(key, objeto);
    }

    public GameObject GetObjetoDictonary(string key)
    {
        return objetoDictionary[key];
    }

    public void addObjetoArray(GameObject objeto){
        objetoArray[indexObjetoArray] = objeto;
        indexObjetoArray++;        
    }

        public GameObject GetObjetoArray(int index)
    {
        return objetoArray[index];
    }
    
}
