using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingController : MonoBehaviour
{

    private void OnEnable()
    {
        BuildingSystem.GridChanged += OnGridChanged;

    }

    private void OnGridChanged()
    {
        AstarPath.active.Scan();
    }

    private void OnDisable()
    {
        BuildingSystem.GridChanged -= OnGridChanged;
    }
}
