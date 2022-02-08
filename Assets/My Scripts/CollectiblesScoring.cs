using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesScoring : MonoBehaviour
{
    [SerializeField] int scoreToAdd;
    GameManager gameManager;
    bool canAddScore = true;
        
    Renderer rend;
    Collider coll;

    void Awake() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.scoreToWin += scoreToAdd;        
        rend = GetComponent<Renderer>();
        coll = GetComponent<Collider>();
    }


    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {

            if (IsGlobule())
                gameObject.SetActive(false);
                        
            // /\ Globules increase Score on disable, and disable instantly,
            // But Orbs don't disable instantly (see "ExplodeWhenTouched.cs"),
            // \/ This makes Orbs increase Score immediately rather than wait for them to disable.
            if (IsBigOrb() && canAddScore) {
                canAddScore = false;
                gameManager?.IncrementScore(scoreToAdd);
            }
                                    
            if (IsFruit()) {
                gameManager.AdjustLives(1);
                gameObject.SetActive(false);
            }
        }
    }

    // void DisableSelf() => gameObject.SetActive(false);

    void OnDisable() {
        if (!IsBigOrb())
            gameManager?.IncrementScore(scoreToAdd);
    }


    // "ExplodeWhenTouched.cs" handles disabling if is big Orb
    bool IsGlobule() {
        if (gameObject.tag == "globule (collectible)")
            return true;
        else return false;                
    }

    bool IsBigOrb() {
        if (gameObject.tag == "orb")
            return true;
        else return false;
    }

    bool IsFruit() {
        if (gameObject.tag == "fruit (collectible)")
            return true;
        else return false;
    }
}
