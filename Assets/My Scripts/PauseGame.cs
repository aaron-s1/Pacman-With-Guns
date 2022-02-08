using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [HideInInspector] public static bool paused;
    GameManager gameManager;
    GameObject pausedText;
    // GameObject screen;


    void Awake() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        pausedText = transform.GetChild(0).gameObject;        
    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }


    void Pause() {
        paused = !paused;
        pausedText.SetActive(paused);

        if (paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;        
    }
}
