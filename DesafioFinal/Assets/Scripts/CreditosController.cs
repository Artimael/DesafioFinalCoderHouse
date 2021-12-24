using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreditosController : MonoBehaviour
{
    [SerializeField] private Text textCreditos;
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.instance.getScoreTotal()==0){
            textCreditos.text="Gracias por Jugar y no morir!!\n";
        }else if (GameManager.instance.getScoreTotal()==1){
            textCreditos.text="Solo te tomo :"+GameManager.instance.getScoreTotal()+" intento sigue asi!!\n";
        }else{
            textCreditos.text="Te has muerto :"+GameManager.instance.getScoreTotal()+" veces\n";
        }

            //GameManager.instance.GetObjeto();
        if(GameManager.instance.getUseBuff()){
            int cantidadBuff= GameManager.objetoQueue.Count;
            textCreditos.text=textCreditos.text+"Ademas has usado "+cantidadBuff+" buffs, trata de no usarlos la proxima vez!! \n";
        }else{
            textCreditos.text=textCreditos.text+"No usaste buffs, eres lo maximo \n";
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
