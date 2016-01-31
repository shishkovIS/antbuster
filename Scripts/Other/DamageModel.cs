using UnityEngine;
using System.Collections;

public class DamageModel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
          this.rigidbody.angularDrag = 0;
          this.rigidbody.angularVelocity = new Vector3(0,0,0);
          this.rigidbody.velocity = new Vector3(0,0,0);
          this.rigidbody.drag = 0;
	}
}
