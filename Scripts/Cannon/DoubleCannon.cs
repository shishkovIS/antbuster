using UnityEngine;
using System.Collections;

public class DoubleCannon : Cannon {

	// Use this for initialization
	


   public override void initialize()
    {
        Level = 2;
        Type = CannonType.DoubleCannon;
        CannonName = "Double Cannon";
        Range = 100;
        Frequency = 4;
        TimeBeforeShoot = 0;
        Cost = 40;
        Speed = 4;
        Damage = 1;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.DoubleCannonII;
        gradeTree[1] = CannonType.DoubleQuickCannonI;
        gradeTree[2] = CannonType.TripleCannonI;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/DoubleCannonII") as GameObject;
        prefabs[1] = Resources.Load("Prefabs/DoubleQuickCannonI") as GameObject;
        prefabs[2] = Resources.Load("Prefabs/TripleCannonI") as GameObject;
        prefabs[3] = Resources.Load("Prefabs/Cannon") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
	// Update is called once per frame
   protected override void generateBullet()
   {

       TimeBeforeShoot = CannonReloadTime;

       Transform pivot = this.transform.Find("PivotPoint");
       Transform barrel = pivot.transform.Find("Capsule");

       Quaternion rotation1 = barrel.transform.rotation;
       Quaternion rotation2 = barrel.transform.rotation;

       Vector3 vrot1 = rotation1.eulerAngles;
       vrot1.y += 10;
       Vector3 vrot2 = rotation2.eulerAngles;
       vrot2.y -= 10;

       rotation1 = Quaternion.Euler(vrot1);
       rotation2 = Quaternion.Euler(vrot2);
       
       GameObject NewBullet = (GameObject)Instantiate(bullet, barrel.transform.position + pivot.forward.normalized * 10, rotation1) as GameObject;
       GameObject NewBullet2 = (GameObject)Instantiate(bullet, barrel.transform.position + pivot.forward.normalized * 10, rotation2) as GameObject;
      
       NewBullet.transform.parent = this.transform;
       NewBullet2.transform.parent = this.transform;
   }
}
