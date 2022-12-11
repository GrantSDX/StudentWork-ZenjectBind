using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class Bullet : MonoBehaviour
{
    [Inject]
    private void Construct(Vector3 position)
    {
        transform.position = position;
    }

    public class Factory : PlaceholderFactory<Vector3, Bullet>
    { }
}
