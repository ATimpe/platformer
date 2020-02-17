using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float spd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * Time.deltaTime * spd;
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * Time.deltaTime * spd;
        }

        if (Input.GetKey(KeyCode.W)) {
            transform.position += Vector3.up * Time.deltaTime * spd;
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.position += Vector3.down * Time.deltaTime * spd;
        }
    }
}
