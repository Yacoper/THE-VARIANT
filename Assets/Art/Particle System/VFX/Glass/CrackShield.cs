using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class CrackShield : MonoBehaviour
{
    private Material shieldMat;
    public GameObject glassBrake;
    void Start()
    {
        shieldMat = GetComponent<MeshRenderer>().sharedMaterial;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Dupa");
         StartCoroutine(Crack());
    }

    IEnumerator Crack()
    {
        for (int i = 5; i > 0; i--)
        {
            shieldMat.SetFloat("_CrackAmount", i);
            yield return new WaitForSeconds(0.15f);
        }
        glassBrake.SetActive(true);
        Destroy(gameObject);
        shieldMat.SetFloat("_CrackAmount", 10);
    }
}
