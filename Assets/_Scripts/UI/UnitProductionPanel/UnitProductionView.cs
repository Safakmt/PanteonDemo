using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitProductionView : MonoBehaviour
{

    [SerializeField]
    private Image _image;
    [SerializeField]
    private TextMeshProUGUI _healthText;
    [SerializeField]
    private TextMeshProUGUI _damageText;
    [SerializeField]
    private TextMeshProUGUI _rangeText;

    public void InitalizeUnitProductionView(Sprite sprite, int maxHealth, int damage, float range)
    {
        _image.sprite = sprite;
        _healthText.text = "Health: "+maxHealth.ToString();
        _damageText.text = "Damage: " + damage.ToString();
        _rangeText.text = "Range: " + range.ToString();
    }

}
