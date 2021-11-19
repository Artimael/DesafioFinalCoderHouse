using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    //ENFOQUE POCO EFECTIVO SIN SINGLETON
    [SerializeField] private ObjectManager ObjectManager;
    [SerializeField] private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.G))
        // {
        //     GameObject myGift = GameManager.instance.GetObjeto();
        //     Vector3 mousePos = Input.mousePosition;
        //     mousePos.z = -mainCamera.transform.position.z;
        //     myGift.transform.position = mainCamera.ScreenToWorldPoint(mousePos);
        //     myGift.SetActive(true);
        // }

        // if (Input.GetKeyDown(KeyCode.W))
        // {

        //     GameObject myGift = GetGiftDictonary("CandyCane");
        //     Vector3 mousePos = Input.mousePosition;
        //     mousePos.z = -mainCamera.transform.position.z;
        //     myGift.transform.position = mainCamera.ScreenToWorldPoint(mousePos);
        //     myGift.SetActive(true);

        // }

    }

    private void OnMouseDown()
    {
        Debug.Log("CLICKED "+gameObject.name);
        GameManager.instance.addObjetoArray(gameObject);
        GameManager.instance.AddDictionary(gameObject.name, gameObject);
        GameManager.instance.AddObjeto(gameObject);
        Debug.Log("indexObjetoArray: "+GameManager.indexObjetoArray);
        Debug.Log("ObjetoQueue: "+GameManager.objetoQueue.Count);
        Debug.Log("ObjetoDictionary: "+GameManager.objetoDictionary.Count);
        gameObject.SetActive(false);
    }
    
}