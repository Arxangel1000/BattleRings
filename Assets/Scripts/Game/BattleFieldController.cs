using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleFieldController : MonoBehaviour
{
    private BattleFieldModel model;
    private BattleFieldView view;

    private void Awake()
    {
        model = GetComponent<BattleFieldModel>();
        view = GetComponent<BattleFieldView>();
    }
}
