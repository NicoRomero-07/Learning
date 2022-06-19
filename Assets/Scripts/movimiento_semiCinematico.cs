using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento_semiCinematico : MonoBehaviour
{
    public float velocidad=1;
    void Start()
    {
        print("Soy NPC con control semicimenático ");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0);

        //alternativamente también permite
        //transform.position = transform.position + new Vector3(0.02f, 0,0);
    }
}
