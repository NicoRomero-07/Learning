using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento_cinematico : MonoBehaviour
{
    public float velocidad = 1;
    void Start()
    {
        print("Soy NPC con control cimenático ");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
           transform.position = transform.position + new Vector3(0.01f, 0, 0);
        
        //alternativamente también permite:
        //a) transform.Translate(new Vector3(0.02f, 0,0));
        //
        //b) float velocidadX=1;
        //   transform.Translate(new Vector3( velocidadX * Time.deltaTime, 0, 0));

    }
}
