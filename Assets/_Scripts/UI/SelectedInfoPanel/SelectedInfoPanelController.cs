using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedInfoPanelController : MonoBehaviour
{

    [SerializeField]
    private GameObject _infoPrefab;
    [SerializeField]
    private Transform _parentPanel;
    private SelectedInfoView _selectedInfoView;
    private List<GameObject> _createdViews;
    private void Start()
    {
        _createdViews = new List<GameObject>();
    }
    public void InitalizeSelectedList(List<IDamageable> selectedList)
    {
        foreach (IDamageable item in selectedList)
        {
            GameObject obj = Instantiate(_infoPrefab, _parentPanel);
            _selectedInfoView = obj.GetComponent<SelectedInfoView>();
            _selectedInfoView.InitalizeSelectedInfoView(item.UISprite, item.MaxHealth, item.CurrentHealth);
            _createdViews.Add(obj);
        }
    }
    public void ClearCreatedViews()
    {
        //TODO: create objectpool
        foreach (var item in _createdViews)
        {
            Destroy(item);
        }
        _createdViews.Clear();
    }
}
