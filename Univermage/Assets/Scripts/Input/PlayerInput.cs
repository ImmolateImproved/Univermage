using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Movement movement;
    private SpellCaster spellManager;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        spellManager = GetComponent<SpellCaster>();
    }

    private void Update()
    {
        MovementInput();
        ToolsInput();

        Restart();
    }

    private void MovementInput()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        var direction = new Vector2(h, v);

        movement.SetInputDirection(direction);
    }

    private void ToolsInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spellManager.UseSpell();
        }
    }

    private void Restart()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LevelManager.Restart();
        }
    }
}