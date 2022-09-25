using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySphereOnCollision : MonoBehaviour
{
    public float radius = 0.5f;
    public float force = 10.0f;
    public GameObject prefForcePoint;
    public GameObject prefSpheres;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Sphere")
        {
            Destroy(other.gameObject);
            Vector3 pointPosition = other.gameObject.transform.position;
            Quaternion pointRotation = other.gameObject.transform.rotation;
            Instantiate(prefForcePoint, pointPosition, pointRotation);
            Instantiate(prefSpheres, pointPosition, pointRotation);
            
            Collider[] colliders = Physics.OverlapSphere(pointPosition, radius);
            foreach (Collider colider in colliders)
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(force, pointPosition, radius);
                }
            }
        }
    }
}
