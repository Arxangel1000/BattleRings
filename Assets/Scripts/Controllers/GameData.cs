using UnityEngine;

public static class GameData
{
   private static int gameAreaWidth;
   private static int gameAreaHeight;
   private static int numUnitsToSpawn;
   private static float unitSpawnDelay;
   private static float unitSpawnMinRadius;
   private static float unitSpawnMaxRadius;
   private static float unitSpawnMinSpeed;
   private static float unitSpawnMaxSpeed;
   private static float unitDestroyRadius;
   private static float unitDeflateStep;

   private static float sumRadiusBlueUnit;
   private static float sumRadiusRedUnit;
   private static int currentCountUnit;
   private static int blueUnitAtScene;
   private static int redUnitAtScene;

   public static int CurrentCountUnit
   {
      get => currentCountUnit;
      set => currentCountUnit = value;
   }

   public static int GameAreaWidth
   {
      get => gameAreaWidth;
      set => gameAreaWidth = value;
   }

   public static int GameAreaHeight
   {
      get => gameAreaHeight;
      set => gameAreaHeight = value;
   }

   public static int NumUnitsToSpawn
   {
      get => numUnitsToSpawn;
      set => numUnitsToSpawn = value;
   }

   public static float UnitSpawnDelay
   {
      get => unitSpawnDelay;
      set => unitSpawnDelay = value;
   }

   public static float UnitSpawnMinRadius
   {
      get => unitSpawnMinRadius;
      set => unitSpawnMinRadius = value;
   }

   public static float UnitSpawnMaxRadius
   {
      get => unitSpawnMaxRadius;
      set => unitSpawnMaxRadius = value;
   }

   public static float UnitSpawnMinSpeed
   {
      get => unitSpawnMinSpeed;
      set => unitSpawnMinSpeed = value;
   }

   public static float UnitSpawnMaxSpeed
   {
      get => unitSpawnMaxSpeed;
      set => unitSpawnMaxSpeed = value;
   }

   public static float UnitDestroyRadius
   {
      get => unitDestroyRadius;
      set => unitDestroyRadius = value;
   }

   public static float SumRadiusBlueUnit
   {
      get => sumRadiusBlueUnit;
      set => sumRadiusBlueUnit = value;
   }

   public static float SumRadiusRedUnit
   {
      get => sumRadiusRedUnit;
      set => sumRadiusRedUnit = value;
   }

   public static float UnitDeflateStep
   {
      get => unitDeflateStep;
      set => unitDeflateStep = value;
   }

   public static int BlueUnitAtScene
   {
      get => blueUnitAtScene;
      set => blueUnitAtScene = value;
   }

   public static int RedUnitAtScene
   {
      get => redUnitAtScene;
      set => redUnitAtScene = value;
   }
}
