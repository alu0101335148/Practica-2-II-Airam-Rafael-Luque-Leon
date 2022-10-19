using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAwayScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // When the player is near to the object, it will be pushed away from the player before the player touches it
    void Update()
    {
        // if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < 5) {
        //     Vector3 awayFromPlayer = transform.position - GameObject.Find("Player").transform.position;
        //     GetComponent<Rigidbody>().AddForce(awayFromPlayer / 100, ForceMode.Impulse);
        // }
    }

    // push the object away from the player when the player touches it
    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.name == "Player") {
            Vector3 distanceToPlayer = transform.position - collision.transform.position;
            GetComponent<Rigidbody>().AddForce(distanceToPlayer * 1.5f, ForceMode.Impulse);
        }
    }
}
