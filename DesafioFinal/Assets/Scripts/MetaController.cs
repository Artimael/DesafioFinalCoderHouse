using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetaController : MonoBehaviour
{

    [SerializeField] private string nombreEscena;

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
            GameManager.instance.setPlayerPos(nombreEscena);
            GameManager.instance.setEnemyPosMin(nombreEscena);
            GameManager.instance.setEnemyPosMax(nombreEscena);
            SceneManager.LoadScene(nombreEscena);
        }

    }
}
