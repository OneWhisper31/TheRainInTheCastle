using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    public static BulletFactory Instance
    {
        get
        {
            return _instance;
        }
    }
    static BulletFactory _instance;

    [SerializeField] Bullet _bulletPrefab;

    [SerializeField] int _bulletStock = 10;

    public ObjectPool<Bullet> pool;


    void Awake()
    {
        _instance = this;

        pool = new ObjectPool<Bullet>(BulletCreator, Bullet.TurnOn, Bullet.TurnOff, _bulletStock);
    }

    Bullet BulletCreator()
    {
        return Instantiate(_bulletPrefab);
    }

    public void ReturnBullet(Bullet b)
    {
        pool.ReturnObject(b);
    }
}
