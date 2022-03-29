using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public float velocity;
    public GameObject enemigo;
    Rigidbody rb; //Puede congelar (Freeze) rotaciones en X Z; también la posición Y. private void Start() {
    
    void Start(){
        
        velocity = 9;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(enemigo.transform.position);
        rb.velocity = transform.forward * velocity;
    }
}
