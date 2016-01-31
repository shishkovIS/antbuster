using UnityEngine;
using System.Collections;

public class FlameThrowerI : SonicPulseI
{

    public override void initialize()
    {
        Level = 4;

        Type = CannonType.FlameThrowerI;
        CannonName = "Flame Thrower I";
        Range = 75;
        Frequency = 12;
        TimeBeforeShoot = 0;
        Cost = 640;
        Speed = 3;
        Damage = 1;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.FlameThrowerII;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/FlameThrowerII") as GameObject;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/QuickCannonII") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
        Pivot = this.transform.FindChild("PivotPoint");
        EmitRange = Pivot.transform.FindChild("Range");
        EmitRange.gameObject.SetActive(true);
    }
}
