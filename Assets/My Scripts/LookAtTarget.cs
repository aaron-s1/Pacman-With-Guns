using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] Transform playerModel;
    
    public void FixedUpdate() => transform.LookAt(playerModel.position);
}
