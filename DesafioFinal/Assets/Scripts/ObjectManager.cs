using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    //My Camera
    [SerializeField] private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject myGift = GameManager.instance.GetObjeto();
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -mainCamera.transform.position.z;
            myGift.transform.position = mainCamera.ScreenToWorldPoint(mousePos);
            myGift.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {

            GameObject myGift = GameManager.instance.GetObjetoDictonary("CoinSilver");
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -mainCamera.transform.position.z;
            myGift.transform.position = mainCamera.ScreenToWorldPoint(mousePos);
            myGift.SetActive(true);

        }

        if (Input.GetKeyDown(KeyCode.T))
        {

            GameObject myGift = GameManager.instance.GetObjetoArray(0);
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -mainCamera.transform.position.z;
            myGift.transform.position = mainCamera.ScreenToWorldPoint(mousePos);
            myGift.SetActive(true);

        }


    }

}
