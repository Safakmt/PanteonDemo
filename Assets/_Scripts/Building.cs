using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour , IDamageable
{
    [SerializeField]
    private int _currentHealh;
    [SerializeField]
    private int _maxHealth;
    [SerializeField]
    private Sprite _uiSprite;
    [SerializeField]
    private List<UnitType> unitTypes = new List<UnitType>();
    public int CurrentHealth { get => _currentHealh; set => _currentHealh = value; }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public Sprite UISprite => _uiSprite;
    public Vector2 SpawnPoint { get; set; }

    public List<UnitType> UnitList { get => unitTypes; }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
    public void TakeDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
            BuildingSystem.Instance.ClearBuilding(gameObject.transform);
        }
    }

    public List<UnitType> GetUnits() { return unitTypes; }
}
