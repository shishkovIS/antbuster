using UnityEngine;
using System.Collections;

public class HeavyCannon : Cannon {

	// Use this for initialization
   
	
	// Update is called once per frame
  public override void initialize()
    {
        Level = 2;
        Type = CannonType.HeavyCannon;
        CannonName = "Heavy Cannon";
        Range = 100;
        Frequency = 3;
        TimeBeforeShoot = 0;
        Cost = 60;
        Speed = 4;
        Damage = 2;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.HeavyCannonII;
        gradeTree[1] = CannonType.ImpactCannonI;
        gradeTree[2] = CannonType.DoubleHeavyCannonI;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/HeavyCannonII") as GameObject;
        prefabs[1] = Resources.Load("Prefabs/ImpactCannonI") as GameObject;
        prefabs[2] = Resources.Load("Prefabs/DoubleHeavyCannonI") as GameObject;
        prefabs[3] = Resources.Load("Prefabs/Cannon") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }

}
