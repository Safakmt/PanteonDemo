using Pathfinding;
using System.Collections;
using UnityEngine;

public class Mage : UnitBase, IAttackable, IDamageable
{
    [SerializeField]
    private int _maxHealth;
    [SerializeField]
    private int _health;
    [SerializeField]
    private int _damage;
    [SerializeField]
    private float _attackRange;
    [SerializeField]
    private float _attackSpeed;
    [SerializeField]
    private Sprite _uiSprite;
    private AIPath _aiPath;

    public override UnitType unitType => UnitType.Mage;

    public int DamageAmount { get => _damage; set => _damage = value; }
    public int CurrentHealth { get => _health; set => _health = value; }
    public float AttackRange { get => _attackRange; set => _attackRange = value; }
    public float AttackSpeed { get => _attackSpeed; set => _attackSpeed = value; }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public Sprite UISprite => _uiSprite;


    public void TakeDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;
        if (CurrentHealth <= 0)
            Destroy(gameObject);
    }


    private void Start()
    {
        _health = _maxHealth;
        _aiPath = GetComponentInChildren<AIPath>();
    }


    public override void MoveTo(Vector2 mousePos)
    {
        _aiPath.destination = mousePos;
    }

    public void AttackTo(GameObject target)
    {
        if (target != gameObject)
        {
            StartCoroutine(Attack(target));
        }
    }

    IEnumerator Attack(GameObject target)
    {

        while (target != null)
        {
            if (!IsTargetInRange(target))
            {
                _aiPath.destination = target.transform.position;
                yield return new WaitUntil(() => IsTargetInRange(target));
            }
            else
            {
                _aiPath.destination = transform.position;
                target.GetComponent<IDamageable>().TakeDamage(DamageAmount);
                yield return new WaitForSeconds(1 / AttackSpeed);
            }
        }
        print("outofcoroutine");
        yield return null;
    }

    public bool IsTargetInRange(GameObject target)
    {
        if (AttackRange > Vector2.Distance(transform.position, target.transform.position))
            return true;
        else
            return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}