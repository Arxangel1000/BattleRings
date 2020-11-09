using System;
using System.Collections;
using UnityEngine;

public class RingView : MonoBehaviour
{
    private RingModel model;
    private bool attention;

    private void Awake()
    {
        model = GetComponent<RingModel>();
    }

    IEnumerator Start()
    {
        transform.localScale = new Vector3(model.unitSpawnRadius,model.unitSpawnRadius,model.unitSpawnRadius );
        yield return new WaitForSeconds(GameData.UnitSpawnDelay);
        GetComponent<SpriteRenderer>().enabled = true;
    }

    private void Update()
    {
        transform.localScale = new Vector3(model.unitCurrentRadius,model.unitCurrentRadius,model.unitCurrentRadius );
    }
}
