using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeWhenTouched : MonoBehaviour
{
    // For big orbs. Player touching them creates shockwaves that disables bullets.
    GameManager gameManager;
    ParticleSystem shockwaveParticle;
    bool canKillBullets;
    bool canExplode = true;

    
    void Awake() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        shockwaveParticle = GetComponentInChildren<ParticleSystem>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            if (gameObject.tag == "orb") {
                GetComponent<ToggleRendererOnDelay>().KillToggle();
                Explode();
            }
        }

        // if (other.gameObject.tag == "bullet") {
            // if (gameObject.tag == "shockwave") {
                // Debug.Log("shockwave");
                // other.transform.parent.gameObject.SetActive(false);
            // }
        // }
    }

    void OnTriggerStay(Collider bullet) {
        if (bullet.gameObject.tag == "bullet")
            if (canKillBullets)
                bullet.transform.parent.gameObject.SetActive(false);            
    }


    public float testRepeatRate = 0.016f;

    public void Explode() {
        if (canExplode) {
            canKillBullets = true;
            canExplode = false;
            // InvokeRepeating("IncreaseRadiusOfBulletKillZone", 0.26f, 0.03f);
            InvokeRepeating("IncreaseRadiusOfBulletKillZone", 0f, testRepeatRate);
            shockwaveParticle.Play();
        }
    }


    void IncreaseRadiusOfBulletKillZone() {
        if (GetComponent<SphereCollider>().radius >= 20f) {
            CancelInvoke("IncreaseRadiusOfBulletKillZone");
            gameObject.SetActive(false);
        }

        else
            GetComponent<SphereCollider>().radius += 0.5f;
    }    
}