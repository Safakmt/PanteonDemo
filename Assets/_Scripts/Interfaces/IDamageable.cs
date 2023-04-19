using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    Sprite UISprite { get; }
    int CurrentHealth { get; set; }
    int MaxHealth { get; set; }
    void TakeDamage(int damageAmount);
}
