using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Spells/Blink")]
public class Blink : Spell
{
    private Movement movement;
    private CharacterDirection direction;

    [SerializeField]
    private float distance;

    public override void Init(SpellController controller)
    {
        base.Init(controller);

        movement = controller.GetComponent<Movement>();
        direction = controller.GetComponent<CharacterDirection>();
    }

    public override void Use()
    {
        movement.SetPosition(movement.GetPosition + direction.CastDirection * distance);
    }
}