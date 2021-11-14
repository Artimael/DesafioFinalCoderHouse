using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int score;
    public static int difficult;

    private void Awake()
    {
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

    public void setDifficult(int difficulties){
        Debug.Log("Difficulties: "+difficulties);
        difficult=difficulties;
    }

    public int getDifficult(){
        Debug.Log("difficult: "+difficult);
        return difficult;
    }
}
