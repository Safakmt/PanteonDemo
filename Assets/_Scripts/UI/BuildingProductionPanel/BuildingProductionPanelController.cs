using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingProductionPanelController : MonoBehaviour
{
    [SerializeField]
    private List<BuildingTypeSO> _buildingTypes;
    [SerializeField]
    private GameObject _buttonPrefab;
    [SerializeField]
    private Transform _parentPanel;
    private BuildingTypeView _buildingTypeView;
    private void Start()
    {
        InitalizeBuildingButtons();
    }

    private void InitalizeBuildingButtons()
    {
        foreach (var item in _buildingTypes)
        {
            GameObject button = Instantiate(_buttonPrefab,_parentPanel);
            _buildingTypeView = button.GetComponent<BuildingTypeView>();
            _buildingTypeView.InitalizeButton(item.BuildingName);
            button.GetComponent<Button>().onClick.AddListener(delegate
            {
                BuildingSystem.Instance.ChooseBuilding(item);
            });
        }
    }
}
