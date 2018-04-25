using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolInstances : MonoBehaviour
{
    public ObjectPooling _impactPool;
    public ObjectPooling _enemyExplosionPool;
    public ObjectPooling _enemyShieldHitExplosionPool;

    public static ObjectPooling impactPool;
    public static ObjectPooling enemyExplosionPool;
    public static ObjectPooling enemyShieldHitExplosionPool;

    void Start ()
    {
        impactPool = _impactPool;
        enemyExplosionPool = _enemyExplosionPool;
        enemyShieldHitExplosionPool = _enemyShieldHitExplosionPool;
    }
}
