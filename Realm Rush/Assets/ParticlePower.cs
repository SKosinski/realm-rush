using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePower : MonoBehaviour
{
    [SerializeField] int hitPower = 5; 

    public int GetHitPower()
    {
        return hitPower;
    }
}
