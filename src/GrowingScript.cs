using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingScript : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnCollisionEnter(Collision collision) {
        float scale = 0.25f;
        if (collision.gameObject.name == "Player") {
            transform.localScale += new Vector3(scale, scale, scale);
            transform.position += new Vector3(0, scale, 0);
        }
    }
}
