using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAfterDelay : MonoBehaviour
{
    // For cherry / fruit collectible
    [SerializeField] private int spawnDelay;
    
    private void Awake() => Invoke("Spawn", spawnDelay);

    private void Spawn() {
        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
}
