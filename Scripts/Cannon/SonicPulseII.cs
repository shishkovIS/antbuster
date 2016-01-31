using UnityEngine;
using System.Collections;

public class SonicPulseII : Cannon
{
    Transform Pivot;
    Transform Emmiter;
    Transform EmitRange;
    public override void initialize()
    {
        Level = 5;
        Type = CannonType.SonicPulseII;
        CannonName = "Sonic Pulse II";
        Range = 120;
        Frequency = 4;
        TimeBeforeShoot = 0;
        Cost = 1662;
        Speed = 5;
        Damage = 5;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.Nothing;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = null;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/SonicPulseI") as GameObject;
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
