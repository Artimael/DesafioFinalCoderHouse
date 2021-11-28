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
        SceneManager.LoadScene("Nivel1A");
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
        canvasDificultad.SetActive(false);
        canvasMenuPrincipal.SetActive(true);        
    }

    public void setDificultadMedio(){
        GameManager.instance.setDifficult(1);    
        canvasDificultad.SetActive(false);
        canvasMenuPrincipal.SetActive(true);   
    }

    public void setDificultadDificl(){
        GameManager.instance.setDifficult(2);  
        canvasDificultad.SetActive(false);
        canvasMenuPrincipal.SetActive(true);     
    }

    public void regresar(){
        canvasDificultad.SetActive(false);
        canvasMenuPrincipal.SetActive(true);
    }

    
}
