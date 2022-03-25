using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GameManager gameManager;
    GameObject player;
    float moveSpeed;
    float originalMoveSpeed;
    bool canApplyMovement;

    bool touchingBoundary;
    bool initialInputTriggered;


    void Awake() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        player = gameManager.player;        
        originalMoveSpeed = gameManager.playerSpeed;        // originalMoveSpeed = moveSpeed;
        moveSpeed = 0;
    }


    void Update() =>  MoveInput();

    void FixedUpdate() => player.transform.position += transform.right * moveSpeed * Time.deltaTime;


    void MoveInput() {
        InitialInput();        

        if (gameManager.acceptingMovementInput && !PauseGame.paused) {            
            if (Input.GetKeyDown("right"))
                player.transform.localEulerAngles = new Vector3(0, 0, 0);
            
            else if (Input.GetKeyDown("up"))
                player.transform.localEulerAngles = new Vector3(0, 0, 90);

            else if (Input.GetKeyDown("left"))
                player.transform.localEulerAngles = new Vector3(0, 0, 180);

            else if (Input.GetKeyDown("down"))
                player.transform.localEulerAngles = new Vector3(0, 0, 270);
        }
    }


    public void SetMovementSpeed(float newSpeed, bool speedWasSetUsingInput = false) {
        // if (!PauseGame.paused) {
        if (moveSpeed != newSpeed && !PauseGame.paused) {
            moveSpeed = newSpeed;

            if (newSpeed > 0) 
                canApplyMovement = true;                

            else if (newSpeed == 0) {
                canApplyMovement = false;
                
                if (speedWasSetUsingInput)
                    StartCoroutine(ReapplyMovementAfterOneFrame());
            }
        }
    }

 
    IEnumerator ReapplyMovementAfterOneFrame() {
        yield return new WaitUntil(() => canApplyMovement);
        SetMovementSpeed(originalMoveSpeed);
    }


    void OnTriggerEnter(Collider boundary) {
        if (boundary.gameObject.tag == "boundary")
            moveSpeed = 0;
    }

    

    void OnTriggerExit(Collider boundary) {
        if (boundary.gameObject.tag == "boundary") {            
            if (!touchingBoundary)
                moveSpeed = originalMoveSpeed;
        }
    }


    void InitialInput() {        
        if (gameManager.acceptingMovementInput && !initialInputTriggered && !PauseGame.paused) {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) ||
                Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) ) {
                    initialInputTriggered = true;
                    moveSpeed = originalMoveSpeed;                    
            }
        }
    }
}