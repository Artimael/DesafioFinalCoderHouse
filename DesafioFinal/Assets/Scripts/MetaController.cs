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
    [SerializeField] private Image imageFadeIn;
    [SerializeField] private Image imageSpeed;
    [SerializeField] private Image imageLife;
    [SerializeField] private Image imageShield;

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

                //

            if(!nombreEscena.Equals("Creditos")){
                imageFadeIn.gameObject.SetActive(true);
                imageSpeed.gameObject.SetActive(false);
                imageLife.gameObject.SetActive(false);
                imageShield.gameObject.SetActive(false);
                GameManager.instance.setPlayerPos(nombreEscena);
                GameManager.instance.setEnemyPosMin(nombreEscena);
                GameManager.instance.setEnemyPosMax(nombreEscena);
                
               //StartCoroutine(LoadLevelAsync(nombreEscena));
            }else{
               // StartCoroutine(LoadLevelAsync(nombreEscena));  
               imageFadeIn.gameObject.SetActive(true);          
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
