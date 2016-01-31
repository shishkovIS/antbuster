using UnityEngine;
using System.Collections;

public class QuickCannon : Cannon
{

    // Use this for initialization
  
    public  override void initialize()
    {
        Level = 2;
        Type = CannonType.QuickCannon;
        CannonName = "Quick Cannon";
        Range = 100;
        Frequency = 4;
        TimeBeforeShoot = 0;
        Cost = 40;
        Speed = 4;
        Damage = 1;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.QuickCannonII;
        gradeTree[1] = CannonType.SniperCannonI;
        gradeTree[2] = CannonType.LongRangeCannonI;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/QuickCannonII") as GameObject;
        prefabs[1] = Resources.Load("Prefabs/SniperCannonI") as GameObject;
        prefabs[2] = Resources.Load("Prefabs/LongRangeCannonI") as GameObject;
        prefabs[3] = Resources.Load("Prefabs/Cannon") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }

    // Update is called once per frame

}
