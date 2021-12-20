using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed;
    [SerializeField] private Animator animPlayer;
    [SerializeField] private float cameraAxisX = -90f;
    private Vector3 playerPos;

    // Start is called before the first frame update

    //Evento
    public static event Action onDeath;
    public static event Action<int> onDeathChange;
    public static event Action<bool> onDamageChange;
    private bool isDamaged;
    private float timeRedScreen= 0f;

    void Start()
    {
        isDamaged=false;
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
        rotatePlayer();
        movePlayer();
        if(isDamaged){
            timeRedScreen=timeRedScreen+Time.deltaTime;
            if(timeRedScreen>1.0f){
                isDamaged=false;
                onDamageChange?.Invoke(false);
                timeRedScreen=0f;
            }
        }
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
            Destroy(gameObject);
        }


    }


    private void rotatePlayer(){
        cameraAxisX += Input.GetAxis("Mouse X");
        Quaternion angulo   = Quaternion.Euler(0, cameraAxisX, 0);
        transform.rotation = angulo;
    }


    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            onDamageChange?.Invoke(true);
            GameManager.instance.addScore();
            GameManager.instance.addScoreTotal();
            transform.position=playerPos;
            onDeathChange?.Invoke(GameManager.instance.getScore());
            isDamaged=true;
        }

        if (collision.gameObject.CompareTag("Bala"))
        {
            onDamageChange?.Invoke(true);            
            GameManager.instance.addScore();
            GameManager.instance.addScoreTotal();
            Debug.Log("playerPos: "+playerPos);
            transform.position=playerPos;
            onDeathChange?.Invoke(GameManager.instance.getScore());  
            isDamaged=true;         
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

    public void setSpeed(float newSpeed){
        speed=newSpeed;
    }


    public float getSpeed(){
        return speed;
    }

}
