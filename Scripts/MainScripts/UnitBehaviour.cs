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
    
    abstract protected void changeVector(); // Смена направления движения юнита 
    abstract protected void changeVectorOnEdge(); //Смена направления движения юнита при попадании за пределы карты
    abstract protected void boxIsInside(); // Метод вызывается, когда юнит вернулся с запределья карты внутрь
    abstract protected void destroyBox(); // Похоронная процессия юнита
    abstract protected void checkTotalDestroy(); // Проверка, выполнилась ли анимация смерти
    abstract protected void applyDamage(int Damage); // Получение урона от любой пушки 
    abstract protected void applySlow(); // Вызывается, когда в юнита попала снежинка(Снежные пушки -замедоениие)
    abstract protected void applyFast(); // Вызывается, когда юнит подожжен(Огнемет - ускорение)
    abstract protected void nearCannon(Transform Cannon);
    abstract protected void checkCake(); // Проверка, может ли юнит взять пирог
    abstract protected void checkSlow(); // Измененеи скорости в зависимости от полученых вызовов applySlow, applyFast
    abstract protected void checkDestroy(); //Проверяет, надо ли уничтожать моба (судить об этом можно по ХП но не факт что это единтсвенный фактор) 
    abstract protected void transformation(); //изменение положеня моба
    abstract protected void changeBehaviour(); // Измненение приоритета для движения моба (пирог, жилище юнита, центр карты .. )
    abstract protected void startMoving(); // Вызов функции изменения направления. 
   
}
