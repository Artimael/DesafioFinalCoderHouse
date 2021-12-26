using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject canvasMenuPrincipal;
    public GameObject canvasDificultad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void escenaJuego(){
        GameManager.instance.setPlayerPos("Nivel1A");
        GameManager.instance.setEnemyPosMin("Nivel1A");
        GameManager.instance.setEnemyPosMax("Nivel1A");
        SceneManager.LoadScene("Nivel1A");
    }

    public void goToEscena2(){
        GameManager.instance.setPlayerPos("Nivel2");
        GameManager.instance.setEnemyPosMin("Nivel2");
        GameManager.instance.setEnemyPosMax("Nivel2");
        SceneManager.LoadScene("Nivel2");
    }

    public void goToEscena3(){
        GameManager.instance.setPlayerPos("Nivel3");
        GameManager.instance.setEnemyPosMin("Nivel3");
        GameManager.instance.setEnemyPosMax("Nivel3");
        SceneManager.LoadScene("Nivel3");
    }

    
    public void goToEscenaMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    
    public void goToEscenaEspejo(){
        SceneManager.LoadScene("NivelEspejo");
    }
 
    public void goToEscenaCreditos(){
        SceneManager.LoadScene("Creditos");
    }

    public void salir(){
        Application.Quit();
    }

    public void opciones(){
        canvasDificultad.SetActive(true);
        canvasMenuPrincipal.SetActive(false); 
    }

    public void setDificultadFacil(){
        GameManager.instance.setDifficult(0);     
    }

    public void setDificultadMedio(){
        GameManager.instance.setDifficult(1);      
    }

    public void setDificultadDificl(){
        GameManager.instance.setDifficult(2);      
    }
    
}
