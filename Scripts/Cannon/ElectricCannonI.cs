using UnityEngine;
using System.Collections;

public class ElectricCannonI : Cannon {

    public override void initialize()
    {
        Level = 4;
        Type = CannonType.ElectricCannonI;
        CannonName = "Electric Cannon I";
        Range = 120;
        Frequency = 3;
        TimeBeforeShoot = 0;
        Cost = 745;
        Speed = 1;
        Damage = 5;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.ElectricCannonII;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/ElectricCannonII") as GameObject;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/LongRangeCannonI") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;

    }
}
