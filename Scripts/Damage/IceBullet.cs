using UnityEngine;
using System.Collections;

public class IceBullet : Bullet {


    override protected void OnCollisionEnter(Collision touch)
    {
        if (touch.gameObject.tag == "enemy")
        {
            touch.gameObject.SendMessage("applyDamage", Damage);
            touch.gameObject.SendMessage("applySlow");
        }

        destroyBullet();
    }
}
