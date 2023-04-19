using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitProductionPanelController : MonoBehaviour
{
    [SerializeField]
    private GameObject _unitButtonPrefab;
    [SerializeField]
    private Transform _parentPanel;
    private UnitProductionView _unitProductionView;
    private Dictionary<UnitType, UnitProductionView> _createdViews;
    void Awake()
    {
        _createdViews = new Dictionary<UnitType, UnitProductionView>();

    }


    public void InitalizeUnitProductionButtons(List<UnitTypeSO> units)
    {
        if (units.Count != 0)
        {
            foreach (UnitTypeSO unit in units)
            {
                GameObject createdObject = Instantiate(_unitButtonPrefab,_parentPanel);
                _unitProductionView = createdObject.GetComponent<UnitProductionView>();
                Button button = createdObject.GetComponent<Button>();
                Sprite sprite = unit.Prefab.GetComponent<IDamageable>().UISprite;
                unit.GetUnitStats(out int Health, out int Damage, out float Range);
                _unitProductionView.InitalizeUnitProductionView(sprite, Health, Damage, Range);
                Vector2 pos = Camera.main.transform.position;
                button.onClick.AddListener(delegate
                {
                    UnitProduction.Instance.CreateUnit(unit.UnitType, pos);
                });

                _createdViews.Add(unit.UnitType, _unitProductionView);
            }

        }
    }

    public void DisableButtons()
    {
        foreach (UnitProductionView Value in _createdViews.Values)
        {
            Value.gameObject.SetActive(false);
        }
    }

    public void EnableSelectedButtons(List<UnitType> units)
    {
        foreach (UnitType item in units)
        {
            if (_createdViews.TryGetValue(item, out UnitProductionView value))
            {
                value.gameObject.SetActive(true);
            }
        }
    }
}
