using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] ParticleSystem hitFX;
    [SerializeField] int health = 200;


    void OnParticleCollision(GameObject other)
    {
        Hit(other);
        //Destroy(other);
    }

    private void Hit(GameObject other)
    {
        health = health - other.GetComponent<ParticlePower>().GetHitPower();
        hitFX.Play();
        //GameObject newHitFX = Instantiate(hitFX, transform.position, Quaternion.identity);
        //newHitFX.transform.parent = transform;
        if (health<=0)
        {
            Death();
        }
    }

    private void Death()
    {
        GameObject newDeathFX = Instantiate(deathFX, transform.position, Quaternion.identity);
        //newDeathFX.transform.parent = transform;
        Destroy(gameObject);
    }
}
