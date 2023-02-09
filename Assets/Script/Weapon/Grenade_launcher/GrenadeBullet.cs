using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionRadius;
    public float explosionForce;
    public int damage;

    private List<Health> oldVictims = new List<Health>();
    public void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        BlowObject();
    }

    private void BlowObject()
    {
        oldVictims.Clear();
        Collider[] affectedObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        for (int i = 0; i < affectedObjects.Length; i++)
        {
            DeliverDamage(affectedObjects[i]);
           // AddForceToObject(affectedObjects[i]); 
        }
    }

    private void DeliverDamage(Collider victim)
    {
        Health health = victim.GetComponentInParent<Health>();

        if (health != null && !oldVictims.Contains(health))
        {
            health.TakeDamage(damage);
            oldVictims.Add(health);
        }
    }

    private void AddForceToObject(Collider affectedObject)
    {
        Rigidbody rigibody = affectedObject.attachedRigidbody;
        if (rigibody)
        {
            rigibody.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1, ForceMode.Impulse);
        }
    }
    
}
