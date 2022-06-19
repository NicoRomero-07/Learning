using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall : MonoBehaviour
{
    public GameObject brick;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newBrick;
        for (int i =0;i<5;i++)
        {
            for (int j = 0; j < 5; j++)
            {
                
                newBrick = Instantiate(brick, transform.position+new Vector3(i * 0.5f, j*0.2f, 0), Quaternion.identity);
                newBrick.transform.SetParent(gameObject.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
