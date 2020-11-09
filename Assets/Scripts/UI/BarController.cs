using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    [SerializeField] private Image blueLine;
    [SerializeField] private Image redLine;
    private float bluePersent;
    private float redPersent;
    private float sumAll;
    

    private void Update()
    {
        sumAll = GameData.SumRadiusBlueUnit + GameData.SumRadiusRedUnit;
        bluePersent = (GameData.SumRadiusBlueUnit * 100) / sumAll;
        redPersent = (GameData.SumRadiusRedUnit * 100) / sumAll;
        blueLine.fillAmount = bluePersent/100;
        redLine.fillAmount = redPersent/100;
    }
}
