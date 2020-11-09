using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Creator : MonoBehaviour
{
    public static Creator instance;
    public List<Vector2> correctPos = new List<Vector2>();
    private List<GameObject> dummys = new List<GameObject>();

    private void Awake() { instance = this; }

    void Start()
    {
        CreateBattleField();
        SpawnAllUnits();
    }

    private void CreateBattleField()
    {
        Instantiate(new BattleFieldCreate().BuildObject(GameData.GameAreaWidth, GameData.GameAreaHeight));
    }

    private void SpawnAllUnits()
    {
        StartCoroutine(SpawnAllUnitsIE());
        IEnumerator SpawnAllUnitsIE()
        {
            while (correctPos.Count != GameData.NumUnitsToSpawn * 2)
            {
                yield return new WaitForSeconds(0);
                FindCorrectPos();
            }
            DestroyDummys();
            StartCoroutine(CreateAllUnits());
        }
    }

    private void FindCorrectPos()
    {
        GameObject prefab = (new DummyCreate().BuildObject());
        GameObject dummy = Instantiate(prefab);
        dummy.transform.localScale = new Vector2(GameData.UnitSpawnMaxRadius, GameData.UnitSpawnMaxRadius);
        dummy.transform.position = SpawnPoint();
        dummys.Add(dummy);
    }

    private void DestroyDummys()
    {
        foreach (var dummy in dummys)
            Destroy(dummy);
    }

    private void CreateUnit(EnumRingColors.RingColor type)
    {
        GameObject unit = Instantiate(new RingFactory().BuildObject(type));
        unit.transform.position = correctPos[GameData.CurrentCountUnit];
    }

    IEnumerator CreateAllUnits()
    {
        var typeUnit = EnumRingColors.RingColor.blue;
        while (GameData.CurrentCountUnit != GameData.NumUnitsToSpawn*2) 
        {
            yield return new WaitForSeconds(GameData.UnitSpawnDelay);
            if (GameData.CurrentCountUnit == GameData.NumUnitsToSpawn)
                typeUnit = EnumRingColors.RingColor.red;

            CreateUnit(typeUnit);
            GameData.CurrentCountUnit++;
        }

        yield return new WaitForSeconds(1f);
        EventSpawnIsFinished.OnSpawnIsFinished();
    }

    private Vector2 SpawnPoint()
    {
        float minX = GameData.GameAreaWidth * (-2.1f);
        float maxX = GameData.GameAreaHeight * (2.1f);
        float minY = GameData.GameAreaWidth * (-2.1f);
        float maxY = GameData.GameAreaHeight * (2.1f);

        var point = new Vector2(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY));

        return point;
    }
}