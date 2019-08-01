using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 40f;
    [SerializeField] ParticleSystem projectileParticle; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy)
        {
            FireAtEnemy();
        }
        else
        {
            SetProjectileActive(false);
        }
    }

    private void FireAtEnemy()
    {
        objectToPan.LookAt(targetEnemy);
        float distance = Vector3.Distance(transform.position, targetEnemy.transform.position);
        //print(distance);
        if(distance<=attackRange)
        {
            SetProjectileActive(true);
        }
        else
        {
            SetProjectileActive(false);
        }
    }

    private void SetProjectileActive(bool v)
    {
        var projectileEmission = projectileParticle.emission;
        projectileEmission.enabled = v;
    }
}
