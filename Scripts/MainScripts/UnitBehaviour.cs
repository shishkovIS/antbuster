using UnityEngine;
using System.Collections;

public abstract class UnitBehaviour : MonoBehaviour {




    public Vector3 generPosition;
    public Vector3 cakePosition;
    public Vector3 currentDirectionVector;
    public Vector3 center;


    public float HealthPoint;
    public float MaxHealthPoint;
    public int Level;
    public float DeathTime;
    public bool hasCake;
    public bool Destroyed;
    public float SlowTime;
    public float MaxSlowTime;

    public float SpeedFactor;
    public float ChangeDirectionTime;

    public float normalChangeDirectionTime;
    public float maxSpeedFactor;
    public float normalSpeedFactor;
    public float deltaSpeedFactor;
    public float deltaChangeDirectionTime;
    public float minSpeedFactor;

   
    public const float RotationFactor = 10f;
    public float destroyDistance;

    public int numberOfVectors;
    
    public const float movingAngleCorrector = .895f;
    public float PositionY;
    public bool boxIsOutside;


    public float[] randomDistribution;
    
    abstract protected void changeVector(); // ����� ����������� �������� ����� 
    abstract protected void changeVectorOnEdge(); //����� ����������� �������� ����� ��� ��������� �� ������� �����
    abstract protected void boxIsInside(); // ����� ����������, ����� ���� �������� � ���������� ����� ������
    abstract protected void destroyBox(); // ���������� ��������� �����
    abstract protected void checkTotalDestroy(); // ��������, ����������� �� �������� ������
    abstract protected void applyDamage(int Damage); // ��������� ����� �� ����� ����� 
    abstract protected void applySlow(); // ����������, ����� � ����� ������ ��������(������� ����� -�����������)
    abstract protected void applyFast(); // ����������, ����� ���� ��������(������� - ���������)
    abstract protected void nearCannon(Transform Cannon);
    abstract protected void checkCake(); // ��������, ����� �� ���� ����� �����
    abstract protected void checkSlow(); // ��������� �������� � ����������� �� ��������� ������� applySlow, applyFast
    abstract protected void checkDestroy(); //���������, ���� �� ���������� ���� (������ �� ���� ����� �� �� �� �� ���� ��� ��� ������������ ������) 
    abstract protected void transformation(); //��������� �������� ����
    abstract protected void changeBehaviour(); // ���������� ���������� ��� �������� ���� (�����, ������ �����, ����� ����� .. )
    abstract protected void startMoving(); // ����� ������� ��������� �����������. 
   
}
