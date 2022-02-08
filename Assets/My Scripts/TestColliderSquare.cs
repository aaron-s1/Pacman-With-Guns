using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColliderSquare : MonoBehaviour
{

    PlayerMovement playerMovement;

    void Awake() {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }
    
    void OnTriggerEnter(Collider boundary) {
        if (boundary.tag == "boundary") {
            Debug.Log("entered boundary {TestColliderSquare.cs}");
            // playerMovement.SetMovementSpeed(0);
        }
    }
}
