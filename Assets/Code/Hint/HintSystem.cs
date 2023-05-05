using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintSystem : MonoBehaviour
{
    public GameObject Canvas;
    public Animator Animator;
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Animator.SetTrigger("CloseHint");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            Animator.SetTrigger("Hint");
        }    
    }
}
