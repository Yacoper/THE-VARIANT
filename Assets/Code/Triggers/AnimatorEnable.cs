using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEnable : MonoBehaviour
{

    public BoxCollider BoxCollider;
    // Start is called before the first frame update
    void Start()
    {
        //m_Animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (BoxCollider.enabled == false)
        {
            BoxCollider.enabled = true;
        }
    }
}
