using UnityEngine;

public class Explode : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float minForce = 10f;
    [SerializeField] private float maxForce = 20f;
    [SerializeField] private float radius = 50f;

    private void Start()
    {
        StartExplode();
    }
    
    private void StartExplode()
    {
        foreach (Transform t in transform)
        {
            var rb = t.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(Random.Range(minForce, maxForce), transform.position, radius);
            }
        }
    }
}
