using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShot : MonoBehaviour
{
    public GameObject prefabSphere;
    public float Fx;
    public float Fy;
    public float Fz;
    public int cadencia;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Planificador");

    }
    IEnumerator Planificador()
    {
        for (int i = 1; i < 10; i++)
        {
            GameObject sphere = Instantiate(prefabSphere) as GameObject;
            sphere.GetComponent<Rigidbody>().mass = i;
            sphere.GetComponent<Rigidbody>().AddForce(new Vector3(Fx, Fy, Fz), ForceMode.Impulse);
            Destroy(sphere, 2);
            yield return new WaitForSeconds(cadencia);
        }
    }
        
}
