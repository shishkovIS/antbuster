using UnityEngine;
using System.Collections;

public class AvoidCannon : MonoBehaviour {

	// Use this for initialization
    void OnTriggerEnter(Collider nearCannon)
    {
        if ((nearCannon.transform.tag == "enemy") || (nearCannon.transform.tag == "boss"))
        {
            nearCannon.transform.parent.transform.SendMessage("nearCannon",this.transform.parent);
        }
        
    }
}
