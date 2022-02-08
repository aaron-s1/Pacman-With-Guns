using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_OLD : MonoBehaviour
{
    public GameObject stopper;
    public int moveSpeed;
    int originalMoveSpeed;
    GameManager gameManager;
    bool initialInputTriggered;

    public bool canApplyMovement;

    // public TestMovementStop testMovementStop;
    public bool canMoveForward;
    bool InitialInputTriggered;

    // void Awake() {
    //     gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    //     originalMoveSpeed = moveSpeed;
    //     moveSpeed = 0;
    // }

    // //void FixedUpdate() => transform.position += transform.right * Time.deltaTime * moveSpeed;

    // void Update() {
    //     // InitialInputTriggered();
    //     MoveInput();
    // }
 

    // void MoveInput() {
    //     InitialInput();

    //     if (gameManager.playerCanMove) {
    //         if (Input.GetKeyDown("right")) {                
    //             SetMovementSpeed(0);
    //             transform.localEulerAngles = new Vector3(0, 0, 0);
    //             // GetComponentInChildren<StopPlayerMovementOnBoundaryTouch>().testStop = true;
    //         }
            
    //         else if (Input.GetKeyDown("up")) {
    //             SetMovementSpeed(0);
    //             transform.localEulerAngles = new Vector3(0, 0, 90);
    //             // GetComponentInChildren<StopPlayerMovementOnBoundaryTouch>().testStop = true;
    //         }

    //         else if (Input.GetKeyDown("left")) {
    //             SetMovementSpeed(0);
    //             transform.localEulerAngles = new Vector3(0, 0, 180);
    //             // GetComponentInChildren<StopPlayerMovementOnBoundaryTouch>().testStop = true;
    //         }

    //         else if (Input.GetKeyDown("down")) {
    //             SetMovementSpeed(0);
    //             Blah("speed 0");
    //             transform.localEulerAngles = new Vector3(0, 0, 270);
    //             Blah("rotated");
    //             // GetComponentInChildren<StopPlayerMovementOnBoundaryTouch>().testStop = true;
    //         }

    //         else if (canApplyMovement) {
    //             SetOriginalMovementSpeed();
    //         }
    //     }

    //     transform.position += transform.right * Time.deltaTime * moveSpeed;        
    // }

    
    // // void OnTriggerEnter(Collider boundary) {
    // //     if (boundary.tag == "boundary") {
    // //         SetMovementSpeed(0);
    // //     }
    // // }

    // void Blah(string tomato) {
    //     Debug.Log(tomato);
    // }

    // void InitialInput() {
    //     if (gameManager.playerCanMove && !initialInputTriggered) {
    //         if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) ||
    //             Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) ) {
    //                 initialInputTriggered = true;
    //                 canApplyMovement = true;
    //         }
    //     }            
    // }

    // public void SetMovementSpeed(int newSpeed) {
    //     if (moveSpeed != newSpeed) {
    //         Debug.Log("move speed = " + moveSpeed);
    //         Debug.Log("parameter speed = " + newSpeed);
    //         moveSpeed = newSpeed;            
    //     }        
    // }


    // public void KillPlayerMovement() => SetMovementSpeed(0);
    // public void SetOriginalMovementSpeed() => SetMovementSpeed(originalMoveSpeed);
}

// if (gameObject.GetComponentInChildren<TestMovementStop>().boundariesBeingTouched == 0)
// SetMovementSpeed(originalMoveSpeed); //

// Whatever();