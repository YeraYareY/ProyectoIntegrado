using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    
    private Rigidbody2D rb2D;
    public Animator animator;
    //MOVIMIENTO
    private float movimientoHorizontal = 0f;
    private float velocidadMovimiento = 500f; 

    private float movimientoSalto=0f;
    private bool movimientoAtacar;
    //Antes a 0.05 para suavizarlo sin que se note
    private float suavizadoMovimiento = 0;

    private Vector3 velocidad = Vector3.zero;

    private bool mirandoDerecha = true;

    //SALTO
    public float fuerzaSalto;
    public LayerMask queEsSuelo;
    public Transform controladorSuelo;
    public Vector3 dimensionesCaja;
    private bool enSuelo;
    private bool salto=false;
    public float distanceToGround;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
        {
            distanceToGround = hit.distance;
        }
  

        //Detecta tecla
        movimientoHorizontal= Input.GetAxisRaw("Horizontal") * velocidadMovimiento;
        movimientoSalto= Input.GetAxisRaw("Jump");
        
        
       if(Input.GetButtonDown("Jump")){
            salto = true;
        }

        if (Input.GetMouseButtonDown(0)) {
    // Aquí colocas el código que quieres que se ejecute cuando se detecte el click izquierdo
            movimientoAtacar=true;
        
        }
    }

    private void Mover(float mover, bool saltar){
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoMovimiento);
        // float inputMovimiento = Input.GetAxis("Horizontal");
        // float inputSalto = Input.GetButtonDown("Jump");
        
        if(movimientoHorizontal* velocidadMovimiento!=0 && saltar==false){
            animator.SetBool("isRun",true);
            animator.SetBool("isWait",false);
            animator.SetBool("isJump",false);
         
        }if(movimientoHorizontal* velocidadMovimiento==0 && saltar==false){
            animator.SetBool("isRun",false);
            animator.SetBool("isWait",true);
            animator.SetBool("isJump",false);
            animator.SetBool("isAttack",false);
        }if(saltar==true){
            animator.SetBool("isRun",false);
            animator.SetBool("isWait",false);
            animator.SetBool("isJump",true);
        }if(movimientoAtacar==true){
            Debug.Log("Attca");
            animator.SetBool("isRun",false);
            animator.SetBool("isWait",false);
            animator.SetBool("isJump",false);
            animator.SetBool("isAttack",true);
            //movimientoAtacar=false;
        }
        if(mover > 0 && !mirandoDerecha){
            Girar();
        }else if(mover < 0 && mirandoDerecha){
            Girar();
        }

        if(enSuelo && saltar){
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaSalto));
        }
    }

    private void Girar(){
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;

    }

    private void FixedUpdate(){
        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);

        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);

        salto = false;
        
    }

}
