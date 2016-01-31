using UnityEngine;
using System.Collections;

public class QuickCannonII : Cannon
{
    public override void initialize()
    {
        Level = 3;
        Type = CannonType.QuickCannonII;
        CannonName = "Quick Cannon II";
        Range = 100;
        Frequency = 4;
        TimeBeforeShoot = 0;
        Cost = 80;
        Speed = 6;
        Damage = 2;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.QuickCannonIII;
        gradeTree[1] = CannonType.FlameThrowerI;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/QuickCannonIII") as GameObject;
        prefabs[1] = Resources.Load("Prefabs/FlameThrowerI") as GameObject;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/QuickCannon") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }

}
