using UnityEngine;
using System.Collections;

public class TripleCannonI : DoubleCannon {
    public override void initialize()
    {
        Level = 4;
        Type = CannonType.TripleCannonI;
        CannonName = "Triple Cannon I";
        Range = 110;
        Frequency = 2;
        TimeBeforeShoot = 0;
        Cost = 92;
        Speed = 4;
        Damage = 2;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.TripleCannonII;
        gradeTree[1] = CannonType.PoisonSprayI;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/TripleCannonII") as GameObject;
        prefabs[1] = Resources.Load("Prefabs/PoisonSprayI") as GameObject;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/DoubleCannon") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }

    protected override void generateBullet()
    {

        TimeBeforeShoot = CannonReloadTime;

        Transform pivot = this.transform.Find("PivotPoint");
        Transform barrel = pivot.transform.Find("Capsule");

        Quaternion rotation1 = barrel.transform.rotation;
        Quaternion rotation2 = barrel.transform.rotation;
        Quaternion rotation3 = barrel.transform.rotation;
        
        Vector3 vrot1 = rotation1.eulerAngles;
        vrot1.y += 15;
        Vector3 vrot2 = rotation2.eulerAngles;
        vrot2.y -= 15;

        rotation1 = Quaternion.Euler(vrot1);
        rotation2 = Quaternion.Euler(vrot2);

        GameObject NewBullet = (GameObject)Instantiate(bullet, barrel.transform.position + pivot.forward.normalized * 10, rotation1) as GameObject;
        GameObject NewBullet2 = (GameObject)Instantiate(bullet, barrel.transform.position + pivot.forward.normalized * 10, rotation2) as GameObject;
        GameObject NewBullet3 = (GameObject)Instantiate(bullet, barrel.transform.position + pivot.forward.normalized * 10, barrel.transform.rotation) as GameObject;

        NewBullet.transform.parent = this.transform;
        NewBullet2.transform.parent = this.transform;
        NewBullet3.transform.parent = this.transform;

    }
}
