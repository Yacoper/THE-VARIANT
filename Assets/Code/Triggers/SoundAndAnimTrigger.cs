using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAndAnimTrigger : MonoBehaviour
{
    public AudioSource sound;
    public Animator animator;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            sound.Play();
            animator.SetTrigger("Open");
        }
    }
    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            sound.Play();
            animator.SetTrigger("Close");
        }
    }
}
