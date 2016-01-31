using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
    Transform FullBar;
    Transform EmptyBar;
    float FullScale;
    int HP;
    float shift = 0;
    void Start () {
        FullBar = this.transform.FindChild("FullHP");
        EmptyBar = this.transform.FindChild("EmptyHP");
        FullScale =  FullBar.transform.localScale.z;
	}

    void Update()
    {
     //   FullBar.transform.parent = null;
      //  EmptyBar.transform.parent = null;
        
        Vector3 FullBarPosition = FullBar.transform.position;
        Vector3 EmptyBarPosition = EmptyBar.transform.position;
        

        FullBarPosition.x = this.transform.position.x + 12;
        FullBarPosition.z = this.transform.position.z-shift;
        FullBarPosition.y = 20;
        
        EmptyBarPosition.x = this.transform.position.x + 12;
        EmptyBarPosition.z = this.transform.position.z;
        EmptyBarPosition.y = 19;

        FullBar.transform.rotation = Quaternion.identity;
        EmptyBar.transform.rotation = Quaternion.identity;
        FullBar.transform.position = FullBarPosition;
        EmptyBar.transform.position = EmptyBarPosition;

        //FullBar.transform.parent = this.transform;
        //EmptyBar.transform.parent = this.transform;

    }

    void ChangeHP()
    {
        float MaxHP = this.transform.GetComponent<BoxBehaviour>().MaxHealthPoint;
        float CurHP = this.transform.GetComponent<BoxBehaviour>().HealthPoint;
        if (CurHP > 0)
        {
            Vector3 Scale = FullBar.transform.localScale;
            Scale.z = (float)(FullScale * (CurHP / MaxHP));
            FullBar.transform.localScale = Scale;

            shift = (EmptyBar.transform.lossyScale.z - FullBar.transform.lossyScale.z) / 2;
        }
        else
        {
            Vector3 Scale = FullBar.transform.localScale;
            Scale.z = 0.001f;
            FullBar.transform.localScale = Scale;

        }
    }
}
