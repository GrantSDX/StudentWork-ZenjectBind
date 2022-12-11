using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Artillery : MonoBehaviour
{
    private Bullet.Factory _bulletFactory;
    [SerializeField] private Transform bulletSpawn;

    [Inject]
    private void Construct(Bullet.Factory bulletFactory)
    {
        _bulletFactory = bulletFactory;
    }

    private void Fire()
    {
        var bullet = _bulletFactory.Create(bulletSpawn.position);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * 1000f);
    }

    private void Movement()
    {
        var xPos = Input.GetAxisRaw("Horizontal");
        var zPos = Input.GetAxisRaw("Vertical");
        
        var distance = new Vector3(xPos, 0f, zPos) * 10f * Time.deltaTime;
        transform.position += distance;

        distance = distance == Vector3.zero ? Vector3.forward : distance;
        transform.rotation = Quaternion.LookRotation((transform.position + distance).normalized * 5f);

    }


    private void Update()
    {
        Movement();

        if (Input.GetMouseButtonDown(0))
            Fire();
    }
}
