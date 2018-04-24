using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolInstances : MonoBehaviour
{
    public ObjectPooling _impactPool;
    public ObjectPooling _enemyExplosionPool;

    public static ObjectPooling impactPool;
    public static ObjectPooling enemyExplosionPool;

    void Start ()
    {
        impactPool = _impactPool;
        enemyExplosionPool = _enemyExplosionPool;
    }
}
