using UnityEngine;
using System.Collections;

public class MachineGunI : DoubleCannon {
    public override void initialize()
    {
        Level = 4;
        Type = CannonType.MachineGunI;
        CannonName = "Machine Gun I";
        Range = 120;
        Frequency = 12;
        TimeBeforeShoot = 0;
        Cost = 568;
        Speed = 6;
        Damage = 3;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.MachineGunII;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/MachineGunII") as GameObject;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/DoubleQuickCannonI") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }

    protected override void generateBullet()
    {

        TimeBeforeShoot = CannonReloadTime;

        Transform pivot = this.transform.Find("PivotPoint");
        Transform barrel = pivot.transform.Find("Capsule");

        Quaternion rotation = barrel.transform.rotation;
        double dispersion = Random.value * 50 - 25;
       
        Vector3 vrot1 = rotation.eulerAngles;
        vrot1.y += (float)dispersion;
        
        rotation = Quaternion.Euler(vrot1);
        

        GameObject NewBullet = (GameObject)Instantiate(bullet, barrel.transform.position + pivot.forward.normalized * 10, rotation) as GameObject;
      

        NewBullet.transform.parent = this.transform;

    }
}
