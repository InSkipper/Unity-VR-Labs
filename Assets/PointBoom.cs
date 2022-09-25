using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBoom : MonoBehaviour
{

    public float radius = 0.5f;
    public float force = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pointPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(pointPosition, radius);
        foreach (Collider colider in colliders)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if(rb!=null){
                rb.AddExplosionForce(force,pointPosition,radius);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
