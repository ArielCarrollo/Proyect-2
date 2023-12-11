using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caida : MonoBehaviour
{
    private AudioSource noo;
    void Awake()
    {
        noo = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collider2D collision2)
    {
        if (collision2.gameObject.tag == "Jugador")
        {
            noo.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision2)
    {
        if (collision2.gameObject.tag == "Jugador")
        {
            noo.Play();
        }
     
    }

}
