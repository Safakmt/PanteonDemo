using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionSystem : MonoBehaviour
{

    [SerializeField]
    private SelectedInfoPanelController _selectedInfoPanelController;
    [SerializeField]
    private UnitProductionPanelController _unitProductionPanelController;
    private Vector2 _firstMousePos;
    private List<IDamageable> _selectedDamageables;
    private Building _selectedBuilding;
    
    void Start()
    {
        _selectedDamageables = new List<IDamageable>();
        _selectedBuilding = null;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _selectedDamageables.Clear();
            _selectedBuilding = null;
            _selectedInfoPanelController.ClearCreatedViews();
            _firstMousePos = Utils.GetMouseWorldPos();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Collider2D[] colliderArray = Physics2D.OverlapAreaAll(_firstMousePos, Utils.GetMouseWorldPos());

            foreach (Collider2D collider in colliderArray)
            {
                if (collider.TryGetComponent<IDamageable>(out IDamageable damageable))
                {
                    _selectedDamageables.Add(damageable);
                }
                if (collider.TryGetComponent<Building>(out Building building))
                {
                    _selectedBuilding = building;
                }
            }
            if (_selectedDamageables.Count != 0)
            {
                _selectedInfoPanelController.InitalizeSelectedList(_selectedDamageables);
            }
            if (_selectedBuilding != null)
            {
                if (_selectedBuilding.UnitList.Count != 0)
                {
                    _unitProductionPanelController.EnableSelectedButtons(_selectedBuilding.UnitList);
                }
                else
                {
                    _unitProductionPanelController.DisableButtons();
                }
            }
            else
            {
                _unitProductionPanelController.DisableButtons();
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            if (_selectedBuilding != null)
            {
                _selectedBuilding.SpawnPoint = Utils.GetMouseWorldPos();
            }
        }

    }



}
