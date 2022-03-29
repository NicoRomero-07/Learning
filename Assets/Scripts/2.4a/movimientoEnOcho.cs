using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoEnOcho : MonoBehaviour
{
    public float velocity;
    public float velocGiro;
    Rigidbody rb; //Puede congelar (Freeze) rotaciones en X Z; también la posición Y. private void Start() {
    
    void Start(){
        velocGiro = 50;
        velocity = 10;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        velocGiro = 50*Mathf.Sin(Time.time / 2);
        print(Time.time);
        transform.Rotate (Vector3.up * velocGiro * Time.deltaTime);
        rb.velocity = transform.forward * velocity;
    }
}
