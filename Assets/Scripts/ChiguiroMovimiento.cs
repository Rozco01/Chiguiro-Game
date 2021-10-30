using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiguiroMovimiento : MonoBehaviour
{

    //Salto regulable
    public bool Saltando;
    private float Ypos;
    private int sky_;




    public float speed;
    public float maxspeed;
    public float fuerzaSalto;
    public int saltosMax = 2;
    public LayerMask capaSuelo;


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
        saltosRestantes = saltosMax;
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();
        ProcesarSaltoDerecha();
        ProcesarSaltoIzquierda();
    }

    bool EstaEnSuelo(){
        RaycastHit2D raycastHit= Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down,0.1f,capaSuelo);
        return raycastHit.collider != null;
    }

        public void ProcesarSaltoIzquierda(){
        if(EstaEnSuelo()){
            saltosRestantes = saltosMax;
            animator.SetBool("sky2", false);
        }
        if(Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0 && (animator.GetBool("IsRunningLeft") == true || animator.GetBool("IsRunningLeft") == false)){
            animator.SetBool("sky2",true);
            saltosRestantes--;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x,0f);
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
        if(transform.position.y > Ypos){
            animator.SetFloat("Gravity",1);
        }
        if (transform.position.y < Ypos){
            animator.SetFloat("Gravity", 0);
        }
        Ypos = transform.position.y;
    }

    public void ProcesarSaltoDerecha(){
        if(EstaEnSuelo()){
            saltosRestantes = saltosMax;
            animator.SetBool("sky", false);
        }
        if(Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0 && (animator.GetBool("IsRunningRight") == true || animator.GetBool("IsRunningRight") == false)){
            animator.SetBool("sky",true); 
            saltosRestantes--;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x,0f);
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
        if(transform.position.y > Ypos){
            animator.SetFloat("Gravity",1);
        }
        if (transform.position.y < Ypos){
            animator.SetFloat("Gravity", 0);
        }
        Ypos = transform.position.y;
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
