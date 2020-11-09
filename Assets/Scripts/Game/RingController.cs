using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RingController : MonoBehaviour, IMove
{
    private RingModel model;
    private RingView view;
    private bool isMove;
    private bool isDeflate;
    private float x, y;
    private int moveBack = 1;
    private bool gameRegime;
    private float deflateStep = 0.02f;

    private void Awake()
    {
        model = GetComponent<RingModel>();
        view = GetComponent<RingView>();
    }

    private void Start()
    {
        model.unitCurrentRadius = model.unitSpawnRadius;
        x = Random.Range(-1, -0.1f);
        y = Random.Range(-1, -0.1f);
        Subscribe();
        AddTeamSumRadius();
    }

    private void FixedUpdate()
    {
        if (gameRegime) isMove = true;
        if (isMove) Move();
        if (isDeflate && gameRegime) Deflate();
        Destroyer();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (this.name.Equals(other.collider.name))
        {
            RotateInCollision(); 
            MoveBackUnit();
        }
        else if (other.collider.name == "BattleField(Clone)")
        {
            RotateInCollision(); 
            MoveBackUnit();
        }
        else
        {
            isDeflate = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (!this.name.Equals(other.collider.name))
            isDeflate = false;
    }
    
    public void Move()
    {
         transform.Translate(new Vector2(x* moveBack, y* moveBack)
                             * model.unitSpeed * Time.deltaTime);
    }

    private void RotateInCollision()
    {
        transform.eulerAngles = new Vector3( transform.eulerAngles.x,
            transform.eulerAngles.y,  transform.eulerAngles.z + 30);
    }
    
    public void Deflate()
    {
        model.unitCurrentRadius -= deflateStep;
    }

    private void MoveAfterSpawn()
    {
        Debug.Log("Spawn is finished and i can stat to move");
        gameRegime = true;
        UnSubscribe();
    }

    private void Destroyer()
    {
        if (model.unitCurrentRadius < model.unitDestroyRadius)
        {
            SubtractTeamSumRadius();

            if (GameData.BlueUnitAtScene <= 0 || GameData.RedUnitAtScene <= 0)
            {
                EventUnitsTeamIsGone.OnUnitsTeamIsGone();
            }

            Destroy(this.gameObject);
        }
    }

    private void MoveBackUnit()
    {
        moveBack *= -1;
    }
    
    private void AddTeamSumRadius()
    {
        if (model.isBlue)
        {
            GameData.SumRadiusBlueUnit += model.unitSpawnRadius;
            GameData.BlueUnitAtScene++;
        }
        else if (!model.isBlue)
        {
            GameData.SumRadiusRedUnit += model.unitSpawnRadius;
            GameData.RedUnitAtScene++;
        }
    }

    private void SubtractTeamSumRadius()
    {
        if (model.isBlue)
        {
            GameData.SumRadiusBlueUnit -= model.unitSpawnRadius;
            GameData.BlueUnitAtScene--;
        }
        else if (!model.isBlue)
        {
            GameData.SumRadiusRedUnit -= model.unitSpawnRadius;
            GameData.RedUnitAtScene--;
        }
    }
    
    public void Subscribe()
    {
        EventSpawnIsFinished.spawnIsFinish += MoveAfterSpawn;
    }

    private void UnSubscribe()
    {
        EventSpawnIsFinished.spawnIsFinish -= MoveAfterSpawn;
    }
}