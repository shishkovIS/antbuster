using UnityEngine;
using System.Collections;

public class HeavyCannonIII : HeavyCannon {


    public override void initialize()
    {
        Level = 4;
        Type = CannonType.HeavyCannonIII;
        CannonName = "Heavy Cannon III";
        Range = 120;
        Frequency = 2.4f;
        TimeBeforeShoot = 0;
        Cost = 228;
        Speed = 5;
        Damage = 8;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.HeavyCannonIV;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/HeavyCannonIV") as GameObject;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/HeavyCannonII") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
