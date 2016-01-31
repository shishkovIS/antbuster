using UnityEngine;
using System.Collections;

public class QuickCannonIII : Cannon {

    public override void initialize()
    {
        Level = 4;
        Type = CannonType.QuickCannonIII;
        CannonName = "Quick Cannon III";
        Range = 120;
        Frequency = 6;
        TimeBeforeShoot = 0;
        Cost = 352;
        Speed = 6;
        Damage = 4;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.QuickCannonIV;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.QuickCannonII;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/QuickCannonIV") as GameObject;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/QuickCannonII") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
