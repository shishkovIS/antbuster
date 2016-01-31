using UnityEngine;
using System.Collections;

abstract public class Shoot : MonoBehaviour {

    public CannonType Type;
    public GameObject bullet;
    public float Frequency;
    public int Level;
    public int Speed;
    public int Range;
    public int Damage;
    public int Cost;
    public int ID;
    public GameObject[] prefabs;
    public CannonType[] gradeTree;
    public Transform target;
    public string CannonName;
    public int gradeTreeSize;
    public GameObject parent;

    abstract protected void shootAndTransform();
    abstract protected void generateBullet();
    abstract protected Transform chooseNewTarget();
    abstract protected void changeReloadTime();
    abstract protected void setNoTarget();
    abstract protected Quaternion adjustRotation(Quaternion inQuaternion);
    abstract protected void rotate(Transform pivot);
    abstract public void initialize();
    abstract protected void setRange();
    
}
public enum CannonType
{
    SimpleCannon = 0,
    HeavyCannon = 1,
    QuickCannon = 2,
    DoubleCannon = 3,
    HeavyCannonII = 4,
    HeavyCannonIII = 5,
    HeavyCannonIV = 6,
    MissileLauncherI = 7,
    MissileLauncherII = 8,
    ImpactCannonI = 9,
    ImpactCannonII = 10,
    ImpactCannonIII = 11,
    IceCannonI = 12,
    IceCannonII  = 13,
    DoubleHeavyCannonI = 14,
    DoubleHeavyCannonII = 15,
    DoubleHeavyCannonIII = 16,
    SonicPulseI = 17,
    SonicPulseII = 18,
    QuickCannonII = 19,
    QuickCannonIII = 20,
    QuickCannonIV = 21,
    FlameThrowerI = 22,
    FlameThrowerII = 23,
    SniperCannonI = 24,
    SniperCannonII = 25,
    SniperCannonIII = 26,
    LaserI = 27,
    LaserII = 28,
    LongRangeCannonI = 29,
    LongRangeCannonII = 30,
    LongRangeCannonIII = 31,
    ElectricCannonI = 32,
    ElectricCannonII = 33,
    DoubleCannonII = 34,
    DoubleCannonIII = 35,
    DoubleCannonIV = 36,
    DoubleQuickCannonI = 37,
    DoubleQuickCannonII = 38,
    DoubleQuickCannonIII = 39,
    MachineGunI = 40,
    MachineGunII = 41,
    TripleCannonI = 42,
    TripleCannonII = 43,
    TripleCannonIII = 44,
    PoisonSprayI = 45,
    PoisonSprayII = 46,
    Sell = 47,
    Degrade = 48,
    
     
    Nothing = 200
}