using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantaAsmatico : MonoBehaviour
{
    public GameObject Objetivo;
    public float Velocidad;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position,
            Objetivo.transform.position, Velocidad * Time.deltaTime);
    }
}
