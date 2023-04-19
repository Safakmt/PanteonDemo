using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIPath),typeof(Seeker))]
public abstract class UnitBase : MonoBehaviour
{
    public abstract UnitType unitType { get; }

    public abstract void MoveTo(Vector2 mousePos);

}
