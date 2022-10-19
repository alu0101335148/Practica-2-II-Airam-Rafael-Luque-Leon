using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5.0f;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update() {
        // Use the keys awsd to move the player (transform.Translate(X, Y, Z))
        float xMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float zMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(xMovement, 0, zMovement);
        // transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // Rotate the player around the y-axis using the keys q and e (transform.Rotate(X, Y, Z))
        if (Input.GetKey(KeyCode.Q)) {
            transform.Rotate(0, -speed / 100, 0);
        }
        if (Input.GetKey(KeyCode.E)) {
            transform.Rotate(0, speed / 100, 0);
        }
        //transform.Rotate(Vector3.up, Time.deltaTime * 100 * Input.GetAxis("Horizontal"));

        // when we press the space bar all the Cylinder objects will be pushed away from the player last position        
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject[] cylinders = GameObject.FindGameObjectsWithTag("PushCylinder");
            foreach (GameObject cylinder in cylinders) {
                Vector3 direction = cylinder.transform.position - transform.position;
                cylinder.GetComponent<Rigidbody>().AddForce(direction * 100);
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "ScoreCylinder") {
            score += 1;
            Debug.Log("Score: " + score);
        }
    }
}
