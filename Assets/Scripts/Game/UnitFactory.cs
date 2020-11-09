using System;
using UnityEngine;
using Random = UnityEngine.Random;

abstract class UnitFactory 
{
    public abstract GameObject BuildObject(EnumRingColors.RingColor color);
}

class RingFactory : UnitFactory
{
    public override GameObject BuildObject(EnumRingColors.RingColor color)
    {
        GameObject prefab = Resources.Load<GameObject>(UnitType(color));
        RingModel model = prefab.GetComponentInChildren<RingModel>();
        model.unitSpawnRadius = Random.Range(GameData.UnitSpawnMinRadius, GameData.UnitSpawnMaxRadius);
        model.unitDestroyRadius = GameData.UnitDestroyRadius;
        model.unitSpeed = Random.Range(GameData.UnitSpawnMinSpeed, GameData.UnitSpawnMaxRadius);
        
        if (color == EnumRingColors.RingColor.blue)
            model.GetComponent<RingModel>().isBlue = true;
        else if (color == EnumRingColors.RingColor.red)
            model.GetComponent<RingModel>().isBlue = false;
        
        return prefab;
    }
    
    private string UnitType(EnumRingColors.RingColor color)
    {
        string typePrefab = "BlueRing";
        if (color == EnumRingColors.RingColor.blue) typePrefab = "BlueRing";
        else if (color == EnumRingColors.RingColor.red) typePrefab = "RedRing";
        return typePrefab;
    }
}

class DummyCreate
{
    public GameObject BuildObject()
    {
        GameObject prefab = Resources.Load<GameObject>("dummy");
        return prefab;
    }
}

class BattleFieldCreate 
{
    public GameObject BuildObject(int width, int height)
    {
        GameObject prefab = Resources.Load<GameObject>("BattleField");
        BattleFieldModel p = prefab.GetComponent<BattleFieldModel>();
        p.areaWidth = width;
        p.areaHeight = height;
        return prefab;
    }
}


