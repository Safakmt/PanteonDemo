using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UnitType")]

public class UnitTypeSO : ScriptableObject
{
    public GameObject Prefab;
    public UnitType UnitType;

    public void GetUnitStats(out int Health,out int Damage,out float Range)
    {
        switch (UnitType)
        {
            default:
            case UnitType.Knight:
                Knight knight = Prefab.GetComponent<Knight>();
                Health = knight.MaxHealth;
                Damage = knight.DamageAmount;
                Range = knight.AttackRange;
                break;
            case UnitType.Mage:
                Mage mage = Prefab.GetComponent<Mage>();
                Health = mage.MaxHealth;
                Damage = mage.DamageAmount;
                Range = mage.AttackRange;
                break;
        }
    }
}
