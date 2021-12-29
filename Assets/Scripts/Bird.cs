using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isDead=false;
    private Rigidbody2D rb2d;
    public Animator anim;
    public float upForce = 200f;
    //public GameController gameController;
    //La misma funcion que la de arriba pero usando un 
    //single too en el scripr de gameController

    void Awake()
    {
        rb2d=GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }*/
        //el code de arriba es una forma
        //pero se puede optimizar usando un return
        //el cual va a hacer que se termine la ejecucion
        //del metodo si la condicional is dead ==false es
        //cierta
        //de esta forma
        if (isDead == true)
            return; //aqui decimos que pare de ejecutarse
        //el metodo si el pajaro murio
        //si no se cumple esta condicion el metodo seguira
        if (Input.GetMouseButtonDown(0))
        {
            SoundSystem.instance.PlayFlap();
            rb2d.velocity = Vector2.zero;
            //rb2d.AddForce(new Vector2(0, upForce));
            rb2d.AddForce(Vector2.up * upForce);
            anim.SetTrigger("Flap");
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        anim.SetTrigger("Die");
        //gameController.BirdDie();
        //La linea anterior la reemplazare por un
        //single too
        GameController.instance.BirdDie();
        rb2d.velocity = Vector2.zero;
        SoundSystem.instance.PlayHit();

    }


}
