using UnityEngine;
using System.Collections;

public class PoisonDamage : MonoBehaviour {
    float Poison;

	void Start () {
        Poison = 15;
       
	}


    void OnTriggerStay(Collider inRange)
    {
        if (inRange.transform.tag == "enemy")
        {
            inRange.gameObject.SendMessage("applyPoison", Poison);
        }
    }
    void Update () {
	
	}

}
