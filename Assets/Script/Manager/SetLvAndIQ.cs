using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetLvAndIQ : MonoBehaviour
{
    public TextMeshProUGUI textLv;
    public TextMeshProUGUI textIQ;

    void Start()
    {
        SetText();
    }

    private void SetText()
    {
        ManagerScene.Instance.dataSO.IQ +=1;
        textLv.text = "Level"+ManagerScene.Instance.dataSO.currentLevel;
        textIQ.text = "-"+ManagerScene.Instance.dataSO.IQ+" IQ";
    }
}
