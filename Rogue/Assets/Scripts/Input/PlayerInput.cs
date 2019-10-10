using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Movement movement;
    ItemManager toolsManager;

    [SerializeField]
    Joystick joystick;

    float Horizontal
    {
        get => Input.GetAxisRaw("Horizontal");
    }

    float Vertical
    {
        get => Input.GetAxisRaw("Vertical");
    }

    void Awake()
    {
        movement = GetComponent<Movement>();
        toolsManager = GetComponent<ItemManager>();
    }

    void Update()
    {
        MovementInput();
        ToolsInput();

        Restart();
    }

    void MovementInput()
    {
        float h = Horizontal;
        float v = Vertical;

        var direction = new Vector2(h, v);

        if (direction == Vector2.zero)
        {
            direction = joystick.Direction;
        }

        movement.SetMoveVector(direction);
    }

    void ToolsInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toolsManager.UseItem();
        }
    }

    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LevelManager.Restart();
        }
    }
}