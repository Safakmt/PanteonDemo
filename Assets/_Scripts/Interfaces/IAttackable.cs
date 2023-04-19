using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IAttackable
{
    public int DamageAmount { get; set; }
    public float AttackRange { get; set; }
    public float AttackSpeed { get; set; }

    public void AttackTo(GameObject damageable);
    public bool IsTargetInRange(GameObject target);
}

