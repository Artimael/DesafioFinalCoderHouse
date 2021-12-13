using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreditosController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCreditos;
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.instance.getScoreTotal()==0){
            textCreditos.text="Gracias por Jugar y no morir!!";
        }else if (GameManager.instance.getScoreTotal()==1){
            textCreditos.text="Solo te tomo :"+GameManager.instance.getScoreTotal()+" intento sigue asi!!";
        }else{
            textCreditos.text="Te has muerto :"+GameManager.instance.getScoreTotal()+" veces";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
