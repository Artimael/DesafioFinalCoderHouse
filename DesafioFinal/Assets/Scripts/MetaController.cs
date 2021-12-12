using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MetaController : MonoBehaviour
{

    [SerializeField] private string nombreEscena;
    [SerializeField] private Image image;

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
            image.enabled=true;
            GameManager.instance.setPlayerPos(nombreEscena);
            GameManager.instance.setEnemyPosMin(nombreEscena);
            GameManager.instance.setEnemyPosMax(nombreEscena);
            SceneManager.LoadScene(nombreEscena);
        }

    }
}
