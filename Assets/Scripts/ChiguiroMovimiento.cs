using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiguiroMovimiento : MonoBehaviour
{

    public float speed;
    public float maxspeed;
    public float fuerzaSalto;
    public int saltosMax = 1;


    private int saltosRestantes;
    private Vector2 moveInput;
    private bool mirandoDerecha = true;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();
    }


    void ProcesarSalto(){
        if(Input.GetKeyDown(KeyCode.Space)){
            rigidbody.velocity = new Vector2(rigidbody.velocity.x,0f);
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            animator.SetBool("sky",true);

        }else{
            animator.SetBool("sky",false);
        }
    }

    void Orientacion(){
        if(Input.GetKey(KeyCode.D)){
            animator.SetBool("IsRunningRight",true);
        }
        else{
            animator.SetBool("IsRunningRight",false);
        }
    }
    

    void ProcesarMovimiento(){
        if(Input.GetKey(KeyCode.D)){
            rigidbody.velocity = new Vector2(maxspeed, rigidbody.velocity.y);
        }else if(Input.GetKey(KeyCode.A)){
             rigidbody.velocity = new Vector2(-maxspeed, rigidbody.velocity.y);
             animator.SetBool("IsRunningLeft", true);
        }else{
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
            animator.SetBool("IsRunningLeft", false);
        }
        Orientacion();
        
    }
}
