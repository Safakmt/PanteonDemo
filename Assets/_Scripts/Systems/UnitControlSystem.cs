using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class UnitControlSystem : MonoBehaviour
{

    //TODO: Make this script singleton and use in the selection system

    private Vector2 _firstMousePos;
    private List<UnitBase> _selectedUnits;


    private void Start()
    {
        _selectedUnits = new List<UnitBase>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _selectedUnits.Clear();
            _firstMousePos = Utils.GetMouseWorldPos();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Collider2D[] colliderArray = Physics2D.OverlapAreaAll(_firstMousePos,Utils.GetMouseWorldPos());

            foreach (Collider2D collider in colliderArray)
            {
                if (collider.TryGetComponent<UnitBase>( out UnitBase unit))
                {
                    _selectedUnits.Add(unit);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Collider2D collider;
            if (collider = Physics2D.OverlapPoint(Utils.GetMouseWorldPos())) //if clicked area has a collider and Idamageable ,all units will attack else they will set destination
            {
                if (collider.TryGetComponent<IDamageable>(out IDamageable target))
                {
                    foreach (UnitBase unit in _selectedUnits)
                    {
                        unit.TryGetComponent<IAttackable>(out IAttackable attackable);
                        if (collider.gameObject != null)
                        {
                            attackable.AttackTo(collider.gameObject);
                        }

                    }
                }

            }
            else
            {
                for (int i = 0; i < _selectedUnits.Count; i++)
                {
                    int x = i % 3;
                    int y = i / 3;
                    _selectedUnits[i].MoveTo(Utils.GetMouseWorldPos()+new Vector2(x,y));
                }
            }
        }
    }
}
