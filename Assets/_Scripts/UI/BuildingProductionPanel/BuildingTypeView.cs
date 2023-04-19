using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingTypeView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_TextMeshPro;


    public void InitalizeButton(string buildingName)
    {
        m_TextMeshPro.text = buildingName;
    }
}
