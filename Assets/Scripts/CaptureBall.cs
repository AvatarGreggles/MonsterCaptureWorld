using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CaptureBall : MonoBehaviour
{

    [SerializeField] GameObject creatureModel;
    [SerializeField] LayerMask terrainLayer;

    Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Throw(Vector3 direction)
    {
        Debug.Log("Throw");
    }

    public void LaunchToTarget(Vector3 targetPos)
    {
        transform.parent = null;
        rb.isKinematic = false;
        rb.velocity = CalculateLaunchVelocity(targetPos);
    }

    Vector3 CalculateLaunchVelocity(Vector3 targetPos)
    {
        var startPos = transform.position;
        var displacementY = targetPos.y - startPos.y;

        var displacementXZ = new Vector3(targetPos.x - startPos.x, 0, targetPos.z - startPos.z);

        float h = Mathf.Abs(displacementY) + 0.5f;

        float g = Physics.gravity.y;

        var velocityY = Vector3.up * Mathf.Sqrt(-2 * g * h);
        var velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * h / g) + Mathf.Sqrt(2 * (displacementY - h) / g));

        return velocityXZ + velocityY;


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Vector3 rayOrigin = transform.position + Vector3.up;


            if (Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, 10f, terrainLayer))
            {
                Debug.Log("Hit");
                var creature = Instantiate(creatureModel, hit.point, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
