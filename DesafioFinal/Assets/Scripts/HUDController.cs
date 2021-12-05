using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text textMuertes;
    [SerializeField] private TextMeshProUGUI textGameOver;
    
    private void Awake() {
          PlayerController.onDeathChange+= onDeathHandler;   
    }

    void Start()
    {
      textMuertes.text="Muertes: 0";  
      PlayerController.onDeath+= onDeadHandler;
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateMuerteUI();
    }

    void UpdateMuerteUI(){
        int muerteCount=GameManager.instance.getScore();
        textMuertes.text="Muertes: "+muerteCount;
    }

    private void onDeadHandler(){
        Debug.Log("Evento Texto GameOver");
        textGameOver.text="GAME OVER";
    }

    private void onDeathHandler(int deads){
        Debug.Log("Evento Actualizar Contador");
        textMuertes.text="Muertes: "+deads;
    }
}
