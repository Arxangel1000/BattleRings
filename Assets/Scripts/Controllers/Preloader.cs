using System.IO;
using UnityEngine;

public class Preloader : MonoBehaviour
{
    private void Awake()
    {
        TextAsset txtAsset = (TextAsset)Resources.Load("GameConfig", typeof(TextAsset));
        string json = txtAsset.text;
        GameProperties loadedData = JsonUtility.FromJson<GameProperties>(json);

        GameData.GameAreaWidth = loadedData.gameAreaHeight;
        GameData.GameAreaHeight = loadedData.gameAreaHeight;
        GameData.NumUnitsToSpawn = loadedData.numUnitsToSpawn;
        GameData.UnitSpawnDelay = loadedData.unitSpawnDelay;
        GameData.UnitSpawnMinRadius = loadedData.unitSpawnMinRadius;
        GameData.UnitSpawnMaxRadius = loadedData.unitSpawnMaxRadius;
        GameData.UnitSpawnMinSpeed = loadedData.unitSpawnMinSpeed;
        GameData.UnitSpawnMaxSpeed = loadedData.unitSpawnMaxSpeed;
        GameData.UnitDestroyRadius = loadedData.unitDestroyRadius;
        GameData.UnitDeflateStep = loadedData.unitDeflateStep;
    }

    class GameProperties
    {
        public int gameAreaWidth;
        public int gameAreaHeight;
        public int numUnitsToSpawn;
        public float unitSpawnDelay;
        public float unitSpawnMinRadius;
        public float unitSpawnMaxRadius;
        public float unitSpawnMinSpeed;
        public float unitSpawnMaxSpeed;
        public float unitDestroyRadius;
        public float unitDeflateStep;
    }
}
