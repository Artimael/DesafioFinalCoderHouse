using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float lifePlayer;
    [SerializeField] private Animator animPlayer;
    // Start is called before the first frame update
    void Start()
    {
        animPlayer.SetBool("isRun", false);
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        //RotatePlayer();
        if(lifePlayer<=0f){
            transform.position=new Vector3(2f,0f,-25f);
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


    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           GameObject enemy = collision.gameObject;
           Debug.Log("Enemy: "+enemy);
           float damageEnemy= enemy.GetComponent<EnemyController>().getDamage();
           lifePlayer=lifePlayer-damageEnemy;
           Debug.Log("lifePlayer : "+lifePlayer);
        }

        if (collision.gameObject.CompareTag("Bala"))
        {
            transform.position=new Vector3(2f,0f,-25f);
        }   

        if (collision.gameObject.CompareTag("Piso")){
            Jump();
        }
    }

    private void Jump(){
        if(Input.GetKey(KeyCode.Space)){
            Debug.Log("Saltando");
            GetComponent<Rigidbody>().AddForce(Vector2.up* 100f);
        }
    }

}
