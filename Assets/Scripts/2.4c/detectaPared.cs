using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class detectaPared : MonoBehaviour
{
    public NavMeshAgent  miAgente;
    private GameObject enemy;
    private NPCcontrolador scriptNPC;

    // Start is called before the first frame update
    void Start()
    {
        if (miAgente==null)    miAgente = GetComponentInParent<NavMeshAgent>();
        scriptNPC = gameObject.GetComponentInParent<NPCcontrolador>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            enemy = hit.collider.gameObject;
            if (hit.collider.gameObject.tag == "Enemy")
            {
                visualizaEnemigo(hit);
            }
            if(hit.collider.gameObject.tag != "Enemy")
            {
                pierdeDeVistaEnemigo(hit);
            }
        }
    }

    private void pierdeDeVistaEnemigo(RaycastHit hit)
    {
        print("pared en frente " + hit.collider.gameObject.tag + " a distancia: " + hit.distance);
        Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.blue);
        miAgente.speed = 2;
        scriptNPC.CambiaObjetivo(enemy);
    }

    private void visualizaEnemigo(RaycastHit hit)
    {
        print("Enemigo en frente " + hit.collider.gameObject.tag + " a distancia: " + hit.distance);
        Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.blue);
        miAgente.speed = 4;
        scriptNPC.CambiaObjetivo(enemy);
    }

}
