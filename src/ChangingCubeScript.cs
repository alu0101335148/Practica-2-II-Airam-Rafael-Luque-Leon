using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingCubeScript : MonoBehaviour
{
    public float scale = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.name == "Player2") {
            transform.localScale += new Vector3(scale, scale, scale);
            transform.position += new Vector3(0, scale, 0);
        }
        if (collision.gameObject.name == "Player") {
            transform.localScale -= new Vector3(scale, scale, scale);
            transform.position -= new Vector3(0, scale, 0);
        }
    }
}
