using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Spells/AstralBody")]
public class AstralBody : SpawnerSpell
{
    public override void InitSpellObject(GameObject astralBody)
    {
        astralBody.GetComponent<SpellPicker>().Init(spellController.GetComponent<SpellCaster>());
        astralBody.GetComponent<Animator>().SetBool("Flight", true);

        InitMovement(astralBody);
    }

    public void InitMovement(GameObject gameObject)
    {
        var movement = gameObject.GetComponent<CharacterMovement>();
        movement.SetVerticalMovement(this, true);

        var myDirection = spellController.GetComponent<CharacterDirection>();
        movement.transform.localScale = myDirection.transform.localScale;

        movement.SetMoveDirection(myDirection.Direction);
    }
}
