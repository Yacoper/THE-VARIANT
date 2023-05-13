using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandShow : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("ShowHand");
    }
}
