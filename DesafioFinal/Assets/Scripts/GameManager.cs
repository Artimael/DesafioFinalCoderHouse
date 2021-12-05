using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int score=0;
    public static int difficult;

    public static Queue objetoQueue;
    public static Dictionary<string, GameObject> objetoDictionary;
    public static GameObject[] objetoArray;
    public static int indexObjetoArray = 0;

    public static ListaNiveles listaNiveles;
    public static Vector3 playerPos;
    public static Vector3 enemyPosMin;
    public static Vector3 enemyPosMax;

    private void Awake()
    {
        objetoQueue = new Queue();
        objetoDictionary = new Dictionary<string, GameObject>();
        objetoArray = new GameObject[4];


        string saveFile = Application.dataPath +"/Properties/properties.json";
        Debug.Log("saveFile: "+saveFile);
        if(File.Exists(saveFile))
        {
            Debug.Log("Archivo existe");
            string jsonString = File.ReadAllText(saveFile); 
            print(jsonString);
            listaNiveles = JsonUtility.FromJson<ListaNiveles> (jsonString);

        }
        else
        {
            Debug.Log("No Archivo existe");
        }

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
        //PlayerController.onDeath -=GameOver;//dessuscribirte al evento
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    [System.Serializable]
    public class PlayerPos{
        public float xDefaultPosPlayer;
        public float yDefaultPosPlayer;
        public float zDefaultPosPlayer;
    }

    [System.Serializable]
    public class EnemyPos{
        public float xDefaultPosEnemyMin;
        public float xDefaultPosEnemyMax;
        public float yDefaultPosEnemy;
        public float zDefaultPosEnemyMin;
        public float zDefaultPosEnemyMax;
    }
    
    [System.Serializable]
    public class Nivel{
        public string NombreNivel;
        public PlayerPos PlayerPosition;
        public EnemyPos EnemyPosition;
    }
  
    [System.Serializable]
    public class ListaNiveles{
        public Nivel[] Niveles;
    }

    public void setPlayerPos(string nombreEscena){
        for(int i=0;i<listaNiveles.Niveles.Length;i++){
            if(string.Equals(listaNiveles.Niveles[i].NombreNivel, nombreEscena)){
                Debug.Log("Set valores");
                playerPos = new Vector3(listaNiveles.Niveles[i].PlayerPosition.xDefaultPosPlayer,listaNiveles.Niveles[i].PlayerPosition.yDefaultPosPlayer,listaNiveles.Niveles[i].PlayerPosition.zDefaultPosPlayer);
            }
        }
    }

    public Vector3 getPlayerPos(){
        return playerPos;
    }

    public void setEnemyPosMin(string nombreEscena){
        for(int i=0;i<listaNiveles.Niveles.Length;i++){
            if(string.Equals(listaNiveles.Niveles[i].NombreNivel, nombreEscena)){
                enemyPosMin = new Vector3(listaNiveles.Niveles[i].EnemyPosition.xDefaultPosEnemyMin,listaNiveles.Niveles[i].EnemyPosition.yDefaultPosEnemy,listaNiveles.Niveles[i].EnemyPosition.zDefaultPosEnemyMin);
            }
        }
    }

    public Vector3 getEnemyPosMin(){
        return enemyPosMin;
    }

    public void setEnemyPosMax(string nombreEscena){
        for(int i=0;i<listaNiveles.Niveles.Length;i++){
            if(string.Equals(listaNiveles.Niveles[i].NombreNivel, nombreEscena)){
                enemyPosMax = new Vector3(listaNiveles.Niveles[i].EnemyPosition.xDefaultPosEnemyMax,listaNiveles.Niveles[i].EnemyPosition.yDefaultPosEnemy,listaNiveles.Niveles[i].EnemyPosition.zDefaultPosEnemyMax);
            }
        }
    }

    public Vector3 getEnemyPosMax(){
        return enemyPosMax;
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


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////INVENTARIO////////////////////////////////////////////////////////////////////////////////////
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
