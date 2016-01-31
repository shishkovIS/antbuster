using UnityEngine;
using System.Collections.Generic;

public class LaserDamage : MonoBehaviour {
    List<Collider> EnemyInside = new List<Collider>();
    List<Collider> TempList = new List<Collider>();
    float Damage;
    float Frequency;
    void OnTriggerEnter(Collider Enemy)
    {
        if ((Enemy.transform.tag == "enemy") && (!EnemyInside.Contains(Enemy)))
        {
            EnemyInside.Add(Enemy);

        }
    }

    void OnTriggerExit(Collider Enemy)
    {
        if ((Enemy.transform.tag == "enemy") && (EnemyInside.Contains(Enemy)))
        {
            EnemyInside.Remove(Enemy);

        }
    }

    void attackAll()
    {

        int i = 0;
        TempList.Clear();
        foreach (Collider Enemy in EnemyInside)
        {
            if (Enemy != null)
            {
                TempList.Add(Enemy);
            }
        }

        EnemyInside.Clear();

        foreach (Collider Enemy in TempList)
        {
            i++;
            if (Enemy != null)
            {
                Enemy.transform.parent.transform.SendMessage("applyDamage", Damage);
                Debug.Log(Damage);
            }
            EnemyInside.Add(Enemy);

        }

    }

    void Start()
    {
        Damage = this.transform.parent.parent.transform.GetComponent<Shoot>().Damage;
  
    }
	
}
