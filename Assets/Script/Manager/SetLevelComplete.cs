using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLevelComplete : MonoBehaviour
{
    public Sprite spriteComplete;
    public Button[] btnLevels;
    public DataSO dataSO;
    void Start()
    {
        SetButton();
    }

    private void SetButton()
    {
        for(int i=0; i<dataSO.maxLevelPass; i++){
            btnLevels[i].GetComponent<Image>().sprite = spriteComplete;
        }
    }
}
