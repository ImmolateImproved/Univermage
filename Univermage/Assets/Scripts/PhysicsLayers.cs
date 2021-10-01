using UnityEngine;

public static class PhysicsLayers
{
    public static int Player = LayerMask.NameToLayer("Player");
    public static int ClosingObstacleLayer = LayerMask.NameToLayer("ClosingObstacle");
    public static int GhostObstacle = LayerMask.NameToLayer("GhostObstacle");
    public static int Tilemap = LayerMask.NameToLayer("Tilemap");
}