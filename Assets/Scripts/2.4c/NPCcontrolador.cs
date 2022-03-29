using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;



public class NPCcontrolador : MonoBehaviour{

    public NavMeshAgent  miAgente;
    public  GameObject[]  puntosCamino;
    public int puntoActual;
    public bool enemigoDetectado = false;
    private GameObject objetivoActual;

    void Start () { 
        if (miAgente==null)    miAgente = GetComponent<NavMeshAgent>();
        miAgente.SetDestination ( puntosCamino[0].transform.position);   
    }

    void Update(){
        if(!enemigoDetectado){
            patrulla();
        }else{
            persigue();
        }
        
    }

    private void persigue()
    {
        miAgente.SetDestination(objetivoActual.transform.position);
        if (miAgente.remainingDistance-1 <= miAgente.stoppingDistance)
        {
            enemigoDetectado = false;
            Destroy(objetivoActual);
            
        }
    }

    private void patrulla()
    {
        if (miAgente.remainingDistance <= miAgente.stoppingDistance)
        {
            puntoActual++;
            if (puntoActual >= puntosCamino.Length) puntoActual = 0;
            miAgente.destination = puntosCamino[puntoActual].transform.position;
        }
    }

    public void CambiaObjetivo(GameObject objetivo){
        if (objetivo.gameObject.tag == "Enemy") {
            enemigoDetectado = true;
            objetivoActual = objetivo;
        }
        else
        {
            enemigoDetectado = false;
        }
    }
}


