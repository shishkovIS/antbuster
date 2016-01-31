using UnityEngine;
using System.Collections;

public class LongRangeCannonIII : Cannon
{
    public override void initialize()
    {
        Level = 5;
        Type = CannonType.LongRangeCannonIII;
        CannonName = "Long Range Cannon III";
        Range = 180;
        Frequency = 3;
        TimeBeforeShoot = 0;
        Cost = 1199;
        Speed = 10;
        Damage = 12;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.Nothing;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.LongRangeCannonII;
        prefabs = new GameObject[4];
        prefabs[0] = null;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/LongRangeCannonII") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
