using UnityEngine;
using System.Collections;

public class ElectricCannonII : Cannon {

    public override void initialize()
    {
        Level = 5;
        Type = CannonType.ElectricCannonII;
        CannonName = "Electric Cannon II";
        Range = 120;
        Frequency = 3;
        TimeBeforeShoot = 0;
        Cost = 1631;
        Speed = 1;
        Damage = 12;
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
        prefabs[3] = Resources.Load("Prefabs/ElectricCannonI") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;

    }
}
