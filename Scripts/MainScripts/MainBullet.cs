using UnityEngine;
using System.Collections;

public abstract class MainBullet : MonoBehaviour
{
    public float Speed;
    public float Damage;
    public float BulletSpeedFactor;
    public float CannonRange;
    public Vector3 direction;

    abstract protected void OnCollisionEnter(Collision touch);
    abstract protected void destroyBullet();
    abstract protected void initialize();
    abstract protected void transformation();
}
