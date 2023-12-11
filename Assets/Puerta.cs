using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public GameObject Jugador;
    public GameObject Abrir;
    public int abierto;

    void Update()
    {
        abrir();
    }
    public void abrir()
    {

        Jugador.GetComponent<Jugador>().llave = abierto;
        if (abierto==2)
        {
            Destroy(this.gameObject);
            Instantiate(Abrir, transform.position, transform.rotation);
        }
        
    }

}
