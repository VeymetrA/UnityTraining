using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            transform.Rotate(0.5f, 0.0f, 0.0f, Space.World);//----
            //transform.Rotate(Vector3.right * 0.5f, Space.World);//+++
            //transform.Rotate(new Vector3(0.5f, 0, 0), Space.World);//++
        }

        if (Input.GetKey(KeyCode.K))
        {
            transform.transform.Rotate(-0.5f, 0.0f, 0.0f, Space.World);
        }

        if (Input.GetKey(KeyCode.J))
        {
            transform.transform.Rotate(0.0f, 0.5f, 0.0f, Space.World);
        }

        if (Input.GetKey(KeyCode.L))
        {
            transform.transform.Rotate(0.0f, -0.5f, 0.0f, Space.World);
        }

        if (Input.GetKey(KeyCode.U))
        {
            transform.transform.Rotate(0.0f, 0.0f, 0.5f, Space.World);
        }

        if (Input.GetKey(KeyCode.O))
        {
            transform.transform.Rotate(0.0f, 0.0f, -0.5f, Space.World);
        }
    }
}
