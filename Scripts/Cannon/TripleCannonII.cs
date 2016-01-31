using UnityEngine;
using System.Collections;

public class TripleCannonII : TripleCannonI {
    public override void initialize()
    {
        Level = 4;
        Type = CannonType.TripleCannonII;
        CannonName = "Triple Cannon II";
        Range = 110;
        Frequency = 2;
        TimeBeforeShoot = 0;
        Cost = 502;
        Speed = 6;
        Damage = 6;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.TripleCannonIII;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/TripleCannonIII") as GameObject;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/TripleCannonI") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
