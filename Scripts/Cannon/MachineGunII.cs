using UnityEngine;
using System.Collections;

public class MachineGunII : MachineGunI {
    public override void initialize()
    {
        Level = 5;
        Type = CannonType.MachineGunII;
        CannonName = "Machine Gun II";
        Range = 120;
        Frequency = 12;
        TimeBeforeShoot = 0;
        Cost = 1420;
        Speed = 6;
        Damage = 8;
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
        prefabs[3] = Resources.Load("Prefabs/MachineGunI") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
