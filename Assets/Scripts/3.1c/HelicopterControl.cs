using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterControl : MonoBehaviour
{
    private float fuerzaLevitacion;
    private Rigidbody rb;
    public GameObject ObjetoPerseguido;
    public float RapidezVertical = 0.1f;
    public float AlturaDeseada = 20;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 1000;
        fuerzaLevitacion = -(rb.mass * Physics.gravity.y);
    }
    void FixedUpdate()
    {
        AlcanzarAltura(AlturaDeseada, RapidezVertical);
    }
    private void AlcanzarAltura(float alturaObjetivo, float rapidezVertical)
    {
        float distancia = (alturaObjetivo - transform.position.y);
        
        if (rb.velocity.y >= 0f)
        {
            float factor = distancia * rapidezVertical;
            rb.AddForce(Vector3.up * fuerzaLevitacion * factor);
        }
        else
        {
            float factor = Mathf.Max(0, distancia * rapidezVertical * 5);
            rb.AddForce(Vector3.up * fuerzaLevitacion * factor);
        }
    }

}
