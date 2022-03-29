using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imprimePosiciones : MonoBehaviour
{
    private float posYInicial;
    private Transform[] arrayTr;
    private int ultimoEliminado=0; 
    private float ultimoTiempo;
    // Start is called before the first frame update
    void Start()
    {
        posYInicial = transform.position.y;
        arrayTr = gameObject.GetComponentsInChildren<Transform>();
        foreach(Transform t in arrayTr){
            print(t.position);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if(Time.realtimeSinceStartup>3 & transform.position.y<posYInicial+1){
            transform.position += new Vector3(0.0f, 0.001f, 0.0f);
        }
            
        if(Time.realtimeSinceStartup>4){
            ultimoEliminado=0;
            ultimoTiempo = Time.time;
            if(Time.time>ultimoTiempo+1){
                ultimoTiempo = Time.time;
                ultimoEliminado+=1;
                //arrayTr[ultimoEliminado].setActive(false);
            }
            
        }
    }
}
