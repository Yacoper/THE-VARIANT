using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCubeAnimTrigger : MonoBehaviour
{
    public Animator animator;
    public BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(BlueCubeHideAnim());
    }
    IEnumerator BlueCubeHideAnim()
    {
        yield return new WaitForSeconds(45);
        animator.SetBool("BlueCubesBool", true);
        boxCollider.enabled = true;
    }
}
