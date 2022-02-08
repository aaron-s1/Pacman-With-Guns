using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRendererOnDelay : MonoBehaviour
{    
    [SerializeField] float toggleSpeed;
    [SerializeField] float delayBetweenToggles;
    Renderer rend;
    
    
    private void Awake() {
        rend = GetComponent<Renderer>();        
        InvokeRepeating("RendererOff", 0f, toggleSpeed);        
    }

    public void KillToggle() {        
        CancelInvoke("RendererOff");
        CancelInvoke("RendererOn");
        rend.enabled = false;
    }

    private void RendererOff() {
        rend.enabled = false;

        if (rend)
            Invoke("RendererOn", delayBetweenToggles);
    }

    private void RendererOn() => rend.enabled = true;



}
