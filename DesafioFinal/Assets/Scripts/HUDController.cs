using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text textMuertes;
    

    void Start()
    {
      textMuertes.text="Muertes: 0";  
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMuerteUI();
    }

    void UpdateMuerteUI(){
        int muerteCount=GameManager.instance.getScore();
        textMuertes.text="Muertes: "+muerteCount;
    }
}
