using UnityEngine;

public class EnemyParameterBase : CharacterParameterBase
{
    public enum EnemyType {
        Invalide = -1,
        Normal, 
        High
    }
    
    [SerializeField]
    private int enemyHitPoint;

    [SerializeField]
    private int enemyAttackPoint;

    private void Awake()
    {
        base.HitPoint = enemyAttackPoint;
        base.maxHitPoint = base.HitPoint;
        base.AttackPoint = enemyAttackPoint;
    }
    
}
