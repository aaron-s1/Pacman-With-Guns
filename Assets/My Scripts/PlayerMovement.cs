using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardRaycastMultiplier;

    GameManager gameManager;
    GameObject player;

    RaycastHit hit;

    float moveSpeed;
    float originalMoveSpeed;
    bool canApplyMovement;

    bool touchingBoundary;
    bool initialInputTriggered;


    [SerializeField] Transform raycastOrigin1;
    [SerializeField] Transform raycastOrigin2;
    [SerializeField] Transform raycastOrigin3;
    [SerializeField] Transform raycastOrigin4;
    [SerializeField] Transform raycastOrigin5;


    void Awake() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        player = gameManager.player;        
        originalMoveSpeed = gameManager.playerSpeed;
        moveSpeed = 0;
    }

    void Update() =>
        MoveInput();

    
    void FixedUpdate() {
        if (!initialInputTriggered)
            return;


        if (PlayerRaycastsHitABoundary()) {
            moveSpeed = 0;
        }

        else {
            if (moveSpeed != originalMoveSpeed)
                moveSpeed = originalMoveSpeed;

            player.transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
    }


    void MoveInput() {
        InitialInput();        

        if (gameManager.acceptingMovementInput && !PauseGame.paused) {            
            if (Input.GetKeyDown("right"))
                player.transform.localEulerAngles = new Vector3(0, 0, 0);
                // StartCoroutine("Waiting");
            
            else if (Input.GetKeyDown("up"))
                player.transform.localEulerAngles = new Vector3(0, 0, 90);
                // StartCoroutine("Waiting");

            else if (Input.GetKeyDown("left"))
                player.transform.localEulerAngles = new Vector3(0, 0, 180);
                // StartCoroutine("Waiting");

            else if (Input.GetKeyDown("down"))
                player.transform.localEulerAngles = new Vector3(0, 0, 270);
                // StartCoroutine("Waiting");
        }
    }

    // IEnumerator Waiting()
    // {
    //     moveSpeed = 0;
    //     yield return new WaitForEndOfFrame();
    //     // yield return new WaitForFixedUpdate();
    // }


    public void SetMovementSpeed(float newSpeed, bool speedWasSetUsingInput = false) {
        if (!PauseGame.paused)
            moveSpeed = newSpeed;
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

    
    // Hey, it's stupid, but it's simple and works.
    bool PlayerRaycastsHitABoundary(float offsets1 = 0.25f, float offsets2 = 0.5f) {
        if (Physics.Raycast(raycastOrigin1.position, transform.right, out hit, forwardRaycastMultiplier, 1 << 10))
            return true;
        if (Physics.Raycast(raycastOrigin2.position, transform.right, out hit, forwardRaycastMultiplier, 1 << 10))
            return true;
        if (Physics.Raycast(raycastOrigin3.position, transform.right, out hit, forwardRaycastMultiplier, 1 << 10))
            return true;
        if (Physics.Raycast(raycastOrigin4.position, transform.right, out hit, forwardRaycastMultiplier, 1 << 10))
            return true;
        if (Physics.Raycast(raycastOrigin5.position, transform.right, out hit, forwardRaycastMultiplier, 1 << 10))
            return true;                        

        return false;
    }

}
