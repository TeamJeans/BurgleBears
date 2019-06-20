using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armControl : MonoBehaviour
{
    float rotx = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            rotx++;
        }
        if (Input.GetKey(KeyCode.K))
        {
            rotx--;
        }


        transform.Rotate(rotx,0,0);
        rotx = 0;
    }

}
