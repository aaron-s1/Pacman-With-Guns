using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWin : MonoBehaviour
{    
    GameManager gameManager;

    void Awake() => gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    void Update() {
        if (Input.GetKeyDown(KeyCode.Keypad0))
            if (gameManager.acceptingMovementInput)  // game has started
                if (gameManager.scoreToWin > gameManager.score) {
                    gameManager.collectibles.SetActive(false);
                    gameManager.IncrementScore(gameManager.scoreToWin - gameManager.score);
                }
                    // gameManager.collectibles.SetActive(false);
    }
}