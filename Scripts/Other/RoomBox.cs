using UnityEngine;
using System.Collections;

public class RoomBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider box)
    {
        if (box.transform.tag == "enemy")
        {
            box.transform.parent.transform.SendMessage("changeVectorOnEdge");
        }
    }

    void OnTriggerEnter(Collider box)
    {
        if (box.transform.tag == "enemy")
        {
            box.transform.parent.transform.SendMessage("boxIsInside");
        }
    }
}
