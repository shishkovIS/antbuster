using UnityEngine;
using System.Collections;

public class DoubleQuickCannonI : DoubleCannon{
    public override void initialize()
    {
        Level = 3;
        Type = CannonType.DoubleQuickCannonI;
        CannonName = "Double Quick Cannon I";
        Range = 75;
        Frequency = 2.6f;
        TimeBeforeShoot = 0;
        Cost = 80;
        Speed = 6;
        Damage = 2;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.DoubleQuickCannonII;
        gradeTree[1] = CannonType.MachineGunI;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/DoubleQuickCannonII") as GameObject;
        prefabs[1] = Resources.Load("Prefabs/MachineGunI") as GameObject;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/DoubleCannon") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
