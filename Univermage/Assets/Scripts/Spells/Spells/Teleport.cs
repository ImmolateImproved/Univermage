using UnityEngine;
using System;

[CreateAssetMenu(menuName = "ScriptableObjects/Spells/Teleport")]
public class Teleport : Portal
{
    private CharacterDirection direction;

    [SerializeField]
    private float distance;

    [SerializeField]
    private LayerMask obstacleMask;

    public event Action<Vector2> OnCast = delegate { };

    public override void Init(SpellController controller)
    {
        base.Init(controller);
        direction = controller.GetComponent<CharacterDirection>();
    }

    protected override Vector2 GetPositon()
    {
        var origin = (Vector2)(spellController.spawnPointMid).position;

        var hit = Physics2D.Raycast(origin, direction.Direction, distance, obstacleMask);

        var teleportPoint = origin + direction.Direction * distance;

        if (hit)
        {
            teleportPoint = hit.point;
            teleportPoint.x += hit.normal.x * 0.5f;
        }

        OnCast(teleportPoint);

        return teleportPoint;
    }
}