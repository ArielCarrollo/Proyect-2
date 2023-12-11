using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private AudioSource ahhhh;
    
    public float SpeedX;
    private Rigidbody2D _comRigiBody;
    private float horizontal;
    public Transform Detector;
    public float raycast;
    public bool Isground;
    public LayerMask Detectar;
    public bool Saltar;
    public float distancia;
    private SpriteRenderer Sprite;
    public int llave = 0;
    public GameObject muro;
    void Awake()
    {
        _comRigiBody = GetComponent<Rigidbody2D>();
        ahhhh = GetComponent<AudioSource>();
        Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Isground = Physics.Raycast(Detector.position, new Vector2(0, -1), raycast, Detectar);
        if (horizontal < 0)
        {
            Sprite.flipX = false;
        }
        if (0 < horizontal)
        {
            Sprite.flipX = true;
        }
        Debug.DrawRay(Detector.position, new Vector2(0, -1) * raycast, Color.yellow);
        if (Input.GetAxis("Jump") != 0 && Isground == true)
        {
            Saltar = true;
        }
        else
        {
            Saltar = false;

        }
    }
    void FixedUpdate()
    {
        _comRigiBody.velocity = new Vector2(horizontal * SpeedX, _comRigiBody.velocity.y);
       if(Saltar == true)
        {
            _comRigiBody.AddForce(new Vector2(0, distancia), ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision2)
    {
        if (collision2.gameObject.tag == "Limites")
        {
            ahhhh.Play();
            Invoke("muere", 1);
           
        }
        if (collision2.gameObject.tag == "Enemigo")
        {
            ahhhh.Play();
            Invoke("muere", 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Caida")
        {
            Invoke("muere", 1);
        }
        if (collision.gameObject.tag == "Enemigo")
        {
            ahhhh.Play();
            Invoke("muere", 1);
        }
        if (collision.gameObject.tag == "Llave")
        {
            
            llave = llave + 1;
            Destroy(muro.gameObject);
        }
    }
    private void muere()
    {
        Destroy(this.gameObject);
    }
 


}