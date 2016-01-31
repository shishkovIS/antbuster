using UnityEngine;
using System.Collections;

public class SonicPulseI : Cannon {
    public Transform Pivot;
    public Transform Emmiter;
    public Transform EmitRange;
    public override void initialize()
    {
        Level = 4;
        Type = CannonType.SonicPulseI;
        CannonName = "Sonic Pulse I";
        Range = 90;
        Frequency = 4;
        TimeBeforeShoot = 0;
        Cost = 588;
        Speed = 4;
        Damage = 1;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.SonicPulseII;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/SonicPulseII") as GameObject;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/DoubleHeavyCannonI") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 50;
        Pivot = this.transform.FindChild("PivotPoint");
        EmitRange = Pivot.transform.FindChild("Range");
        EmitRange.gameObject.SetActive(true);
    }
    override protected void shootAndTransform()
    {
        generateBullet();
        rotate(Pivot);
    }
    override protected void generateBullet()
    {
       Pivot.particleSystem.enableEmission = true;
    }

    override protected void setNoTarget()
    {
       this.target = null;
       Pivot.particleSystem.enableEmission = false;   
    }
}
