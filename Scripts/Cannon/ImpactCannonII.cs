using UnityEngine;
using System.Collections;

public class ImpactCannonII : HeavyCannon {

    public override void initialize()
    {
        Level = 4;
        Type = CannonType.ImpactCannonII;
        CannonName = "Impact Cannon II";
        Range = 110;
        Frequency = 2.4f;
        TimeBeforeShoot = 0;
        Cost = 230;
        Speed = 6;
        Damage = 7;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.ImpactCannonIII;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/ImpactCannonIII") as GameObject;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/ImpactCannonI") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
