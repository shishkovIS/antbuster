using UnityEngine;
using System.Collections;

public class Bullet : MainBullet {
  
  

    // Use this for initialization
	void Start () {
        initialize();
	}
    
    void Update()
    {
        transformation();
    }

    override protected void initialize()
    {
        this.BulletSpeedFactor = 20;
        this.Speed = this.transform.parent.GetComponent<Shoot>().Speed * BulletSpeedFactor;
        this.Damage = this.transform.parent.GetComponent<Shoot>().Damage;
        this.CannonRange = this.transform.parent.GetComponent<Shoot>().Range;
    }


    override protected void transformation()
    {
        Vector3 position = this.transform.position;
        position.y = 10;
        this.transform.position = position;
        transform.Translate(transform.forward.normalized * Time.deltaTime * Speed);
        if ((this.transform.position - this.transform.parent.position).magnitude > CannonRange)
        {
            destroyBullet();
        }
    }
    override protected void OnCollisionEnter(Collision touch)
    {
    }

   protected void OnTriggerEnter(Collider touch) 
   {  
       if (touch.transform.tag == "enemy")
        {
           touch.transform.parent.transform.SendMessage("applyDamage", Damage);
         
        }

      destroyBullet();
   }

  

   override protected void destroyBullet()
   {
       Destroy(this.gameObject);     
   }
}
