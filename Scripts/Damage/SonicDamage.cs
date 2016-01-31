using UnityEngine;
using System.Collections.Generic;

public class SonicDamage : MonoBehaviour {
    List<Collider> EnemyInside = new List<Collider>();
    List<Collider> TempList = new List<Collider>();
    public float Damage;
    public float Frequency;
    void OnTriggerEnter(Collider Enemy)
    {
        if ((Enemy.transform.tag=="enemy") && (!EnemyInside.Contains(Enemy)))
        {
            EnemyInside.Add(Enemy);
        
        }
    }

   void OnTriggerExit(Collider Enemy)
   {
        if ((Enemy.transform.tag=="enemy") && (EnemyInside.Contains(Enemy)))
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
               DamageInRange(Enemy);
           }
           EnemyInside.Add(Enemy);
    
       }
       
    }

   void DamageInRange(Collider Enemy)
   {
       Enemy.transform.parent.transform.SendMessage("applyDamage", Damage);
   }

	void Start () {
       Damage = this.transform.parent.parent.transform.GetComponent<Shoot>().Damage;

        Frequency = this.transform.parent.parent.GetComponent<Shoot>().Frequency;

        InvokeRepeating("attackAll", 0.0f, 1/Frequency);
	}
	

}
