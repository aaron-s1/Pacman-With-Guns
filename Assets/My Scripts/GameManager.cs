using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{   
    public bool playerIsInvulnerable;       // temp public
    
    public GameObject player; // [SerializeField]
    public float playerSpeed;
    [SerializeField] SimpleShoot enemyGun;
    [Space(5)]
    [HideInInspector] public GameObject mainScreen; // [SerializeField]
    [SerializeField] GameObject restartScreen;
    [SerializeField] GameObject remainingLivesScreen;
    [SerializeField] GameObject scoreScreen;
    [SerializeField] GameObject invulnerabilityStatusScreen;    

    public GameObject collectibles;
    [HideInInspector] public int extraLives = 0;
    [HideInInspector] public bool acceptingMovementInput;
    [HideInInspector] public int scoreToWin = 0;
    [HideInInspector] public int score = 0;

    // PlayerMovement playerMovement;

    bool gameCanBeRestarted;
    int secondsBeforeGameStart = 3;
 

    void Awake() {
        InvokeRepeating("WaitToStartGame", 1f, 1f);
        // playerMovement = player.GetComponent<PlayerMovement>();
    }

    void Update() {
        // InitialInputAllowsMovement();        
        ToggleInvulnerability();
        RestartOnGameOver();
    }


#region ~ Starting up game ~

    void WaitToStartGame() {
        if (secondsBeforeGameStart == 0) {
            CancelInvoke("WaitToStartGame");
            SetScreenText(mainScreen, "Go!");
            Invoke("StartGame", 1f);
        }

        else {
            SetScreenText(mainScreen, secondsBeforeGameStart.ToString());
            secondsBeforeGameStart--;
        }
    }

    void StartGame() {
        SetScreenText(mainScreen, "");
        enemyGun.FireGun(true);
        acceptingMovementInput = true;
        // Debug.Log("accepting on game manager = " + acceptingMovementInput);
    }

#endregion


#region ~ Mechanics ~

    void ToggleInvulnerability(bool forceOn = false) {                
        if (Input.GetKeyDown(KeyCode.I) && acceptingMovementInput) {
            playerIsInvulnerable = !playerIsInvulnerable;
        
            if (playerIsInvulnerable) {
                SetScreenText(remainingLivesScreen, "inf.");
                SetScreenText(invulnerabilityStatusScreen, "ON");
            }
            else {
                SetScreenText(remainingLivesScreen, extraLives.ToString());
                SetScreenText(invulnerabilityStatusScreen, "OFF");
            }
        }
    }
#endregion


#region ~ Game Outcome / Restarting ~

    public void GameOver() {
        Invoke("WaitBeforeAllowingRestart", 2f);
        restartScreen.SetActive(true);

        if (score == scoreToWin) {
            SetScreenText(mainScreen, "You win!");
            ToggleInvulnerability(true);
            enemyGun.FireGun(false);        
        }

        else {
            SetScreenText(mainScreen, "You lose :(");
            acceptingMovementInput = false;
            player.GetComponentInChildren<PlayerMovement>().SetMovementSpeed(0);                        
        }        
    }

    void RestartOnGameOver() {
        if (gameCanBeRestarted) {
            if (Input.GetKeyDown("space"))
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

#endregion


#region ~ Helper Scripts ~

    public void AdjustLives(int adjustment) {        
        // if extraLives is -1, player is dead.

        if (adjustment > 0) {
            extraLives += adjustment;

            if (!playerIsInvulnerable)
                SetScreenText(remainingLivesScreen, extraLives.ToString());
        }

        else if (!playerIsInvulnerable) {
            extraLives += adjustment;

            if (extraLives >= 0) {
                player.GetComponentInChildren<ExplodeWhenTouched>().Explode();
                SetScreenText(remainingLivesScreen, extraLives.ToString());
            }

            if (extraLives < 0) {
                GameOver();                
                SetScreenText(remainingLivesScreen, "0");
            }
        }
    }


    // void PauseOrUnpauseGame() {
    //     if (Time.timeScale == 1) {
    //         SetScreenText(mainScreen, "PAUSED");
    //         Time.timeScale = 0;
    //     }

    //     else if (Time.timeScale == 0) {
    //         SetScreenText(mainScreen, "", false);
    //         Time.timeScale = 1;
    //     }
    // }


    public void IncrementScore(int toAdd) {
        score += toAdd;
        SetScreenText(scoreScreen, score.ToString());

        if (score == scoreToWin)
            GameOver();
    }

    public void SetScreenText(GameObject screen, string replacementText, bool setState = true) {
        if (screen.GetComponent<TextMeshPro>().text != replacementText)
            screen.GetComponent<TextMeshPro>().text = replacementText;

        
        screen.SetActive(setState);
    }


    // public void AutoWin() => IncrementScore(scoreToWin - score);
    void WaitBeforeAllowingRestart() => gameCanBeRestarted = true;

#endregion
}