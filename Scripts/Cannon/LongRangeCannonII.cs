using UnityEngine;
using System.Collections;

public class LongRangeCannonII : Cannon {
    public override void initialize()
    {
        Level = 4;
        Type = CannonType.LongRangeCannonII;
        CannonName = "Long Range Cannon II";
        Range = 180;
        Frequency = 3;
        TimeBeforeShoot = 0;
        Cost = 502;
        Speed = 7;
        Damage = 6;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.LongRangeCannonIII;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.LongRangeCannonI;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/LongRangeCannonIII") as GameObject;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/LongRangeCannonI") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
