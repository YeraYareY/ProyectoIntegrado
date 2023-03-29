using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public int rutina;
    public float cronometro;
    public Animator animator;
    public int direccion;
    public float speed_walk;
    public float speed_run;
    public GameObject objetivo;
    public bool atacando;

    public float rango_vision;
    public float rango_ataque;
    public GameObject rango;
    public GameObject Hit;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        objetivo = GameObject.Find("Player");
    }


    public void Comportamiento()
    {
        if (Mathf.Abs(transform.position.x - objetivo.transform.position.x) > rango_vision && !atacando)
        {


            //animator.SetBool("isRun",false)
            animator.SetBool("moverse",false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {

                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    //bool caminar =false
                    animator.SetBool("quieto",true);

                    break;
                case 1:
                    direccion = Random.Range(0, 2);
                    rutina++;
                    break;
                case 2:
                    switch (direccion)
                    {
                        case 0:
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                            break;
                        case 1:
                            transform.rotation = Quaternion.Euler(0, 180, 0);
                            transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                            break;
                    }
                    //activar animacion caminar
                    animator.SetBool("moverse",true);

                    break;
            }
           
        }
        else
        {
            if (Mathf.Abs(transform.position.x - objetivo.transform.position.x) > rango_ataque && !atacando)
            {
                if (transform.position.x < objetivo.transform.position.x)
                {
                    //animacion caminar falsa y correr verdadera
                    animator.SetBool("quieto",false);
                    animator.SetBool("moverse",true);
                    transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    //animacion atacar falsa
                    animator.SetBool("atacar",false);

                }
                else
                {
                    //animacion caminar falsa y correr verdadera
                    animator.SetBool("quieto",false);
                    animator.SetBool("moverse",true);
                    transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    //animacion atacar falsa
                    animator.SetBool("atacar",false);
                }
            }
            else
            {
                if (!atacando)
                {
                    if (transform.position.x < objetivo.transform.position.x)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    //false animacion correr y andar
                    animator.SetBool("moverse",false);

                }
            }
                

        }
       
    }

    public void Final_Ani()
    {
        //animacion atacar falsa
        animator.SetBool("atacar",false);


        atacando = false;
        rango.GetComponent<BoxCollider2D>().enabled = true;

    }

    public void ColliderWeaponTrue()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponFalse()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento();
    }


}
