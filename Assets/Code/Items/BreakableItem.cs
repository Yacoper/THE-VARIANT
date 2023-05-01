using System;
using UnityEngine;

public class BreakableItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.CompareTag("Player"))
            return;
        
        if(!other.transform.GetComponent<PlayerRedCubePower>().IsBuffApplied)
            return;
        
        Debug.LogError("Can destroy");
    }
}
