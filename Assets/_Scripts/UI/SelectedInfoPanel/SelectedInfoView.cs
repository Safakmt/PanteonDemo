using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedInfoView : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private TextMeshProUGUI _textMeshPro;


    public void InitalizeSelectedInfoView(Sprite sprite,int maxHealth,int currentHealth)
    {
        _image.sprite = sprite;
        _textMeshPro.text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }
}
