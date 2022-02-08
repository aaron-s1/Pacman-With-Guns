using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKillsPlayer : MonoBehaviour
{
    GameManager gameManager;
    float bulletDuration = 12f;

    void OnEnable() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Invoke("BulletDisablesInSeconds", bulletDuration);
    }


    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {            
            gameObject.SetActive(false);
            
            if (gameManager.extraLives >= 0 && !gameManager.playerIsInvulnerable)
                gameManager.AdjustLives(-1);
        }
    }

    void BulletDisablesInSeconds() => gameObject.SetActive(false);
    void OnDisable() => CancelInvoke("BulletDisablesInSeconds");

}
