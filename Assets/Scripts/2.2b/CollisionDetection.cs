using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    bool colisionado = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(colisionado){
            transform.position = transform.position + new Vector3(0.0f, 0.1f, 0.0f);
        }
    }

    private void OnCollisionEnter(Collision collision){
        
        if (collision.gameObject.tag == "Player"){
            print("colision!");
            GetComponent<Collider>().attachedRigidbody.useGravity = false;
            colisionado=true;
        }
        
    }
}
