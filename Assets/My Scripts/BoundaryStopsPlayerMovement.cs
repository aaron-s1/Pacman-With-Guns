using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryStopsPlayerMovement : MonoBehaviour
{
    // Player should stop anyways if touching boundary. This is an extra safeguard.

    void OnTriggerEnter(Collider stopper) {
        // if (stopper.gameObject.tag == "MovementStopper")
        //     stopper.gameObject.GetComponent<PlayerMovement>().SetMovementSpeed(0);
    }    
}
