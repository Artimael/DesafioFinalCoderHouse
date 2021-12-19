using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Threading;


public class MetaController : MonoBehaviour
{

    [SerializeField] private string nombreEscena;
    [SerializeField] private Image image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

                image.gameObject.SetActive(true);

            if(!nombreEscena.Equals("Creditos")){
                //image.gameObject.SetActive(true);

                GameManager.instance.setPlayerPos(nombreEscena);
                GameManager.instance.setEnemyPosMin(nombreEscena);
                GameManager.instance.setEnemyPosMax(nombreEscena);
                
               //StartCoroutine(LoadLevelAsync(nombreEscena));
            }else{
               // StartCoroutine(LoadLevelAsync(nombreEscena));              
            }

        }

    }

    private IEnumerator LoadLevelAsync(string nombreEscena)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nombreEscena);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if(asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
    
                    asyncLoad.allowSceneActivation = true;

                
            }
            yield return null;
        }
    }




}
