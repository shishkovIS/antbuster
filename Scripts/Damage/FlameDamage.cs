using UnityEngine;
using System.Collections;

public class FlameDamage : SonicDamage {

	// Use this for initialization
    void DamageInRange(Collider Enemy)
    {
        Enemy.transform.SendMessage("applyDamage", Damage);
        Enemy.transform.SendMessage("applyFast");
    }

    void Start()
    {
        Damage = this.transform.parent.parent.transform.GetComponent<Shoot>().Damage; 
        Frequency = this.transform.parent.parent.GetComponent<Shoot>().Frequency;
        InvokeRepeating("attackAll", 0.0f, 1 / Frequency);
    }
}
