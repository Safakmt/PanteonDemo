using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProduction : MonoBehaviour
{
    [SerializeField]
    private List<UnitTypeSO> _unitTypeSOs;
    [SerializeField]
    private UnitProductionPanelController _unitProductionPanelController;
    public static UnitProduction Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }
    private void Start()
    {
        _unitProductionPanelController.InitalizeUnitProductionButtons(_unitTypeSOs);
        _unitProductionPanelController.DisableButtons();
    }
    public void CreateUnit(UnitType unitType, Vector2 pos)
    {
        foreach (var item in _unitTypeSOs)
        {

            if (unitType == item.UnitType)
            {
                Instantiate(item.Prefab,pos,Quaternion.identity);
            }
        }
    }


}
