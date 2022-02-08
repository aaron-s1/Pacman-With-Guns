using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopsOnBoundaryTouch : MonoBehaviour
{
    public int moveSpeed;
    int originalMoveSpeed;
    GameManager gameManager;
    bool initialInputTriggered;
    public bool canApplyMovement;
    
    GameObject player;

    bool InitialInputTriggered;

    void Awake() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();        
        player = gameManager.player;
        originalMoveSpeed = moveSpeed;
        moveSpeed = 0;
    }

    // void FixedUpdate() {
    //     if (fixedUpdateCanApplyMovement) {
    //         SetMovementSpeed(originalMoveSpeed);
    //         player.transform.position += transform.right * Time.deltaTime * moveSpeed;
    //     }
    // }

    void Update() {
        InitialInput();
        MoveInput();
    }

    void MoveInput() {
        // InitialInput();
        if (gameManager.acceptingMovementInput) {
            if (Input.GetKeyDown("right")) {                
                SetMovementSpeed(0);                
                player.transform.localEulerAngles = new Vector3(0, 0, 0);            
            }
            
            else if (Input.GetKeyDown("up")) {
                SetMovementSpeed(0);
                player.transform.localEulerAngles = new Vector3(0, 0, 90);
            }

            else if (Input.GetKeyDown("left")) {
                SetMovementSpeed(0);
                player.transform.localEulerAngles = new Vector3(0, 0, 180);
            }

            else if (Input.GetKeyDown("down")) {
                SetMovementSpeed(0);
                player.transform.localEulerAngles = new Vector3(0, 0, 270);
            }

            else if (canApplyMovement) {
                player.transform.position += transform.right * Time.deltaTime * moveSpeed;
                SetMovementSpeed(originalMoveSpeed);
            }
        }

    }    


    void InitialInput() {        
        if (gameManager.acceptingMovementInput && !initialInputTriggered) {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) ||
                Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) ) {
                    initialInputTriggered = true;
                    canApplyMovement = true;
            }
        }
    }

    // void Blah(string tomato) {}

    void OnTriggerEnter(Collider boundary) {
        if (boundary.gameObject.tag == "boundary") {
            SetMovementSpeed(0);
            canApplyMovement = false;            
        }
    }

    void OnTriggerExit(Collider boundary) {
        if (boundary.gameObject.tag == "boundary") {
            SetMovementSpeed(originalMoveSpeed);
            canApplyMovement = true;
        }
    }
    

    public void SetMovementSpeed(int newSpeed) {        
        if (moveSpeed != newSpeed) {
            moveSpeed = newSpeed;

            // if (moveSpeed == 0)
            //     canApplyMovement = false;
            // else if (moveSpeed > 0)
            //     canApplyMovement = true;
        }        
    }
 
    public void SetOriginalMovementSpeed() => SetMovementSpeed(originalMoveSpeed);


////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////

/*

    
    // void OnTriggerEnter(Collider boundary) {
    //     if (boundary.tag == "boundary") {
    //         SetMovementSpeed(0);
    //     }
    // }

    void InitialInput() {
        //if (gameManager.playerCanMove && !initialInputTriggered) {
        //if (gameManager.playerCanMove && !canApplyMovement) {
        if (gameManager.playerCanMove && !initialInputTriggered) {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) ||
                Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) ) {
                    initialInputTriggered = true;
                    canApplyMovement = true;
                    //     initialInputTriggered = true;
                    // if (!canApplyMovement) {
                    // }
                    // initialInputTriggered = true;
                    // GetComponentInChildren<StopPlayerMovementOnBoundaryTouch>().testStop = true;
                    // SetOriginalMovementSpeed();
                    //SetMovementSpeed(originalMoveSpeed);
            }
        }            
    }


    public void SetMovementSpeed(int newSpeed) {
        if (moveSpeed != newSpeed) {
            Debug.Log("move speed = " + moveSpeed);
            Debug.Log("parameter speed = " + newSpeed);
            moveSpeed = newSpeed;            
        }        
    }

    // void SetBoolIfNotSet(bool boolToSet) { 
    //     if (!)
    // }

    // public void KillPlayerMovement() => SetMovementSpeed(0);
    public void SetOriginalMovementSpeed() => SetMovementSpeed(originalMoveSpeed);
}

// if (gameObject.GetComponentInChildren<TestMovementStop>().boundariesBeingTouched == 0)
// SetMovementSpeed(originalMoveSpeed); //

// Whatever();


 */



  

    // public void Tomato() {
    //     testStop = true;
    // }
        
    //     // testStop = false;
    //     // if (boundary.gameObject.tag == "boundary") {//
    //     //     Debug.Log("entered boundary");//
    //     //     // GetComponentInParent<PlayerMovement>().SetMovementSpeed(0);
    //     //     playerMovement.SetMovementSpeed(0);
    //     // }//
    // }

    // void OnTriggerStay(Collider other) {
    //     if (other.gameObject.tag == "boundary") {
    //         Debug.Log("trigger stay");
    //         playerMovement.SetMovementSpeed(0);
    //     }

    //     // else Debug.Log("stay 2");
    // }

    // void Update() {
    //     if (testStop) {
    //         playerMovement.SetOriginalMovementSpeed();
    //     }
    // }

    // void OnTriggerStay(Collider boundary) {
    //     if (boundary.gameObject.tag == "boundary") {
    //         testStop = false;
    //         playerMovement.SetMovementSpeed(0);
    //     }
    // }



    // void OnTriggerExit(Collider boundary) {
    //     if (boundary.gameObject.tag == "boundary") {//
    //         Debug.Log("exited boundary {StopPlayerMovement.cs}"); //
    //         GetComponentInParent<PlayerMovement>().SetOriginalMovementSpeed();
    //         // playerMovement.SetMovementSpeed(playerMovement.originalMoveSpeed);
    //         // playerMovement.SetOriginalMovementSpeed();
    //         // playerMovement.SetOriginalMovementSpeed();
    //     }//
    // }

    
}

        // if (gameObject.tag == "StopMovementOnBoundaryHit") {
            // touchingMultipleBoundaries = true;
            // GetComponentInParent<PlayerMovement>().moveSpeed = 0;
            // GetComponentInParent<PlayerMovement>().canMoveForward = false;

            // GetComponent<PlayerMovement>().SetMovementSpeed(0);
            
            // boundariesBeingTouched++;
            // Debug.Log("touched = " + boundariesBeingTouched);
            // canMove = false;
            // touchingBoundary = true;
        // }

////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class StopPlayerMovementOnBoundaryTouch : MonoBehaviour
// {
//     bool canForward;
//     PlayerMovement playerMovement;

//     public bool testStop = false;

//     void Awake() {
//         playerMovement = GetComponentInParent<PlayerMovement>();
//     }

//     // void Update() {
//     //     if (testStop)
//     //         playerMovement.SetOriginalMovementSpeed();
//     // }

    
//     void OnTriggerEnter(Collider boundary) {
//         if (boundary.gameObject.tag == "boundary") {
//             // testStop = false;
//             // testStop = false;
//             // if (testStop) {
//                 // testStop = false;
//                 // playerMovement.SetMovementSpeed(0);
//                 playerMovement.canApplyMovement = false;
//             // }
//         }
//     }

//     void OnTriggerExit(Collider boundary) {
//         if (boundary.gameObject.tag == "boundary") 
//             playerMovement.canApplyMovement = true;
//             // testStop = true;
//     }    






  

//     // public void Tomato() {
//     //     testStop = true;
//     // }
        
//     //     // testStop = false;
//     //     // if (boundary.gameObject.tag == "boundary") {//
//     //     //     Debug.Log("entered boundary");//
//     //     //     // GetComponentInParent<PlayerMovement>().SetMovementSpeed(0);
//     //     //     playerMovement.SetMovementSpeed(0);
//     //     // }//
//     // }

//     // void OnTriggerStay(Collider other) {
//     //     if (other.gameObject.tag == "boundary") {
//     //         Debug.Log("trigger stay");
//     //         playerMovement.SetMovementSpeed(0);
//     //     }

//     //     // else Debug.Log("stay 2");
//     // }

//     // void Update() {
//     //     if (testStop) {
//     //         playerMovement.SetOriginalMovementSpeed();
//     //     }
//     // }

//     void OnTriggerStay(Collider boundary) {
//         if (boundary.gameObject.tag == "boundary") {
//             testStop = false;
//             playerMovement.SetMovementSpeed(0);
//         }
//     }



//     // void OnTriggerExit(Collider boundary) {
//     //     if (boundary.gameObject.tag == "boundary") {//
//     //         Debug.Log("exited boundary {StopPlayerMovement.cs}"); //
//     //         GetComponentInParent<PlayerMovement>().SetOriginalMovementSpeed();
//     //         // playerMovement.SetMovementSpeed(playerMovement.originalMoveSpeed);
//     //         // playerMovement.SetOriginalMovementSpeed();
//     //         // playerMovement.SetOriginalMovementSpeed();
//     //     }//
//     // }

    
// }

//         // if (gameObject.tag == "StopMovementOnBoundaryHit") {
//             // touchingMultipleBoundaries = true;
//             // GetComponentInParent<PlayerMovement>().moveSpeed = 0;
//             // GetComponentInParent<PlayerMovement>().canMoveForward = false;

//             // GetComponent<PlayerMovement>().SetMovementSpeed(0);
            
//             // boundariesBeingTouched++;
//             // Debug.Log("touched = " + boundariesBeingTouched);
//             // canMove = false;
//             // touchingBoundary = true;
//         // }
