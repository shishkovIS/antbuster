using UnityEngine;
using System.Collections;

public class FlameThrowerII : FlameThrowerI {


    public override void initialize()
    {
        Level = 5;
        Type = CannonType.FlameThrowerII;
        CannonName = "Flame Thrower II";
        Range = 100;
        Frequency = 12;
        TimeBeforeShoot = 0;
        Cost = 1385;
        Speed = 5;
        Damage = 2;
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
        prefabs[3] = Resources.Load("Prefabs/FlameThrowerI") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
        Pivot = this.transform.FindChild("PivotPoint");
        EmitRange = Pivot.transform.FindChild("Range");
        EmitRange.gameObject.SetActive(true);
    }
}
