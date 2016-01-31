using UnityEngine;
using System.Collections.Generic;

public class LightDamage : MonoBehaviour {

    List<Collider> EnemyInside = new List<Collider>();
    List<Collider> TempList = new List<Collider>();

    float LightDamagePoints = 50;
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
               Enemy.transform.SendMessage("applyDamage", LightDamagePoints);
           }
           EnemyInside.Add(Enemy);
    
       }
       
    }
	
	void Start () {
	
	}
	

}
