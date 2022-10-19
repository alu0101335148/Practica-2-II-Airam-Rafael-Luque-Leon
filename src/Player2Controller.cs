using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() {
        if (Input.GetKey(KeyCode.I))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.L))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);            
        }
        if (Input.GetKey(KeyCode.J))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.K)) {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        // Rotate the player around the y-axis using the keys "u" and "o"
        if (Input.GetKey(KeyCode.U)) {
            transform.Rotate(0, -speed / 100, 0);
        }
        if (Input.GetKey(KeyCode.O)) {
            transform.Rotate(0, speed / 100, 0);
        }

    }
}
