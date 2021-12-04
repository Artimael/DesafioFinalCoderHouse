using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed;
    [SerializeField] private Animator animPlayer;
    private Vector3 playerPos;

    // Start is called before the first frame update

    //Evento
    public static event Action onDeath;
    public static event Action<int> onDeathChange;


    void Start()
    {
        playerPos=GameManager.instance.getPlayerPos();
        //transform.position=playerPos;
        Debug.Log("playerPos "+playerPos);
        Debug.Log("transform.position "+transform.position);
        animPlayer.SetBool("isRun", false);
        onDeathChange?.Invoke(GameManager.instance.getScore());
        Debug.Log("Probando Start");
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        //RotatePlayer();
    }

    void movePlayer(){
        float ejeHorizontal = Input.GetAxisRaw("Horizontal");
        float ejeVertical = Input.GetAxisRaw("Vertical");

        if (ejeHorizontal != 0 || ejeVertical != 0) {
            animPlayer.SetBool("isRun", true);
            Vector3 direction = new Vector3(ejeHorizontal, 0, ejeVertical);
            transform.Translate(speed * Time.deltaTime * direction);
        }
        else
        {
            animPlayer.SetBool("isRun", false);
        }

        Jump();

        if(GameManager.instance.getScore()>3){
            Debug.Log("GAME OVER");
            onDeath?.Invoke();
        }


    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Aca");
            GameManager.instance.addScore();
            transform.position=playerPos;
            onDeathChange?.Invoke(GameManager.instance.getScore());

        }

        if (collision.gameObject.CompareTag("Bala"))
        {
            GameManager.instance.addScore();
            Debug.Log("playerPos: "+playerPos);
            transform.position=playerPos;
            onDeathChange?.Invoke(GameManager.instance.getScore());
        }   

        if (collision.gameObject.CompareTag("Piso")){
            //Jump();
        }
    }

    private void Jump(){
        if(Input.GetKey(KeyCode.Space)){
            Debug.Log("Saltando");
            GetComponent<Rigidbody>().AddForce(Vector2.up* 100f);
        }
    }

}
