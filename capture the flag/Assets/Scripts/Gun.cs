using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float velocity;

    public void Shoot(Vector3 position, Vector3 dir)
    {
        GameObject bulletInstance = Instantiate(bullet, position, Quaternion.identity);
        Rigidbody rb = bulletInstance.GetComponent<Rigidbody>();
        
        rb.useGravity = false;
        rb.AddForce(dir * velocity, ForceMode.Impulse);
    }
}
