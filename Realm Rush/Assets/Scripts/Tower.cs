using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //parameters
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 40f;
    [SerializeField] ParticleSystem projectileParticle;

    //state
    [SerializeField] Transform targetEnemy;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();

        if (targetEnemy)
        {
            FireAtEnemy();
        }
        else
        {
            SetProjectileActive(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyHealth>();
        if(sceneEnemies.Length == 0) {  return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyHealth testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform closestEnemy, Transform testEnemyTransform)
    {
        float distance1 = Vector3.Distance(transform.position, closestEnemy.position);
        float distance2 = Vector3.Distance(transform.position, testEnemyTransform.position);
        if (distance2<distance1)
        {
            return testEnemyTransform;
        }
        else
        {
            return closestEnemy;
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
