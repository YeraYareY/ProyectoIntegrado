using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{

    public string nombre;

    private Rigidbody2D rb2D;
    public Animator animator;
    //MOVIMIENTO
    private float movimientoHorizontal = 0f;
    public float velocidadMovimiento = 500f; 

    private float movimientoSalto=0f;
    private bool movimientoAtacar;
    //Antes a 0.05 para suavizarlo sin que se note
    private float suavizadoMovimiento = 0;
    public ParticleSystem particulas;
    public ParticleSystem particulasMuerte;
    private Vector3 velocidad = Vector3.zero;

    private bool mirandoDerecha = true;

    //Variables Basicas
    public Image vidaImg;
    public int maxVida=5;
    public int vida=5;

    public int puntos;
    //SALTO
    public float fuerzaSalto;
    public LayerMask queEsSuelo;
    public Transform controladorSuelo;
    public Vector3 dimensionesCaja;
    private bool enSuelo;
    private bool salto=false;
    public float distanceToGround;
    public GameObject enemigo;
    public static bool golpeado;
    public static bool pausado;
    public AudioSource saltoSonido;
    public bool saltoReproducido;
    public float attackRadius;
    public GameObject derrot;
    
    // Start is called before the first frame update
    void Start()
    {
        string playerName = PlayerPrefs.GetString("PlayerName");
        nombre = playerName;
        Debug.Log("NOMBRE:"+nombre);
        rb2D = GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        
    }
  
    IEnumerator Pausar()
    {
        pausado=true;
        yield return new WaitForSeconds(2);
        pausado=false;
    }
    
     private void OcultarObjeto()
    {
        // Ocultar el objeto
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

        if (vida>maxVida){
            vida=maxVida;
        }
        //HUD VIDAS
        vidaImg.fillAmount = vida / 3f;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemigo");
            Debug.Log("Número de enemigos encontrados: " + enemies.Length);
            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                Debug.Log("Distancia al enemigo: " + distanceToEnemy);
                if (distanceToEnemy <= attackRadius)
                {
                    // Aplicar el ataque al enemigo
                    Enemy enemyScript = enemy.GetComponent<Enemy>();
                    shot shotEnemyScript = enemy.GetComponent<shot>();
                    if (enemyScript != null)
                    {
                        enemyScript.TakeDamage();
                    }
                    if (shotEnemyScript != null)
                    {
                        // Llamar a la función para matar al enemigo con el script "shot"
                        shotEnemyScript.TakeDamage();
                    }
                }
            }
    movimientoAtacar = true;
    //animator.SetTrigger("isAttack"); PUEDE SERVIR
        }

        if(!pausado){
            if (Hit_Enemy.hit)
                {
                    
                    vida--;
                    if(vida>=1){
                    animator.SetTrigger("Golpe");

                    }
                    Debug.Log(vida);
                    Hit_Enemy.hit = false;
                    StartCoroutine(Pausar()); // Restablecer la variable hit de Hit_Enemy a false
                }
        }
       
       if(vida<=0){
            derrot.SetActive(true);
            particulasMuerte.Play();
            Invoke("OcultarObjeto", 1);
       }

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


    }

    private void Mover(float mover, bool saltar){
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoMovimiento);
        // float inputMovimiento = Input.GetAxis("Horizontal");
        // float inputSalto = Input.GetButtonDown("Jump");
       if (movimientoAtacar)
    {
        animator.SetBool("isRun", false);
        animator.SetBool("isWait", false);
        animator.SetBool("isJump", false);
        animator.SetBool("isAttack", true);
        StartCoroutine(PausaAtaque());
        return;
    }if(movimientoHorizontal* velocidadMovimiento!=0 && saltar==false){
            animator.SetBool("isRun",true);
            animator.SetBool("isWait",false);
            animator.SetBool("isJump",false);
            animator.SetBool("isAttack",false);         
        }if(movimientoHorizontal* velocidadMovimiento==0 && saltar==false){
            animator.SetBool("isRun",false);
            animator.SetBool("isWait",true);
            animator.SetBool("isJump",false);
            animator.SetBool("isAttack",false);
        }if(saltar==true){
            animator.SetBool("isRun",false);
            animator.SetBool("isWait",false);
            animator.SetBool("isJump",true);
            animator.SetBool("isAttack",false);
            particulas.Play();
            saltoSonido.Play();
            saltoReproducido=true;
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

IEnumerator PausaAtaque()
{
    Debug.Log("Pausa de ataque...");
    yield return new WaitForSeconds(0.8f);
    movimientoAtacar=false;
    Debug.Log("La pausa ha terminado.");
}

    private void Girar(){
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
        particulas.Play();

    }

    private void FixedUpdate(){
        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);

        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);

        salto = false;
        
    }

}
