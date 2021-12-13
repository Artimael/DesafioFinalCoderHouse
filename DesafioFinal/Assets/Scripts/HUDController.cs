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
    private HUDController instance;
    
    private void Awake() {

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

        textMuertes=textMuertes.GetComponent<Text>();
        Debug.Log("Defaulto text: "+textMuertes);
        Debug.Log("Defaulto text: "+textMuertes.text);
        PlayerController.onDeathChange+= onDeathHandler;   
        Debug.Log("Awake Hub");
    }

    void Start()
    {
      Debug.Log("Start Hub");
      textMuertes.text="Muertes: "+GameManager.instance.getScore();
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
        Debug.Log("onDeathHandler Hub");
        if(textMuertes){
            Debug.Log("Existe");
        }else{
            Debug.Log("No existe");
        }
        Debug.Log("Evento Actualizar Contador");
        textMuertes.text="Muertes: "+deads;
    }
}
