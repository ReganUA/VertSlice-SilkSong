using UnityEngine;
using UnityEngine.InputSystem;
public class MovingEntity : Entity
{
    private float speed;
    private int health;
    private bool isFacingRight;
    private int attackPower;
    private float horizontal;
    private InputActionMap map;
    private InputAction moveAction;
    [SerializeField] private string actionMapName = "Player";
    [SerializeField] private InputActionAsset input;

    void OnEnable()
    {
        map?.Enable();
    }
    void OnDisable()
    {
        map?.Disable();
    }
    void Awake()
    {
        map = input.FindActionMap(actionMapName);
        moveAction = map.FindAction("Move");
    }
    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        float currentMoveSpeed = moveInput.y * speed * Time.deltaTime;
        horizontal = moveAction.ReadValue<Vector2>().x;
    }

    public void turn()
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void loseHealth()
    {
        //action event waneer ik geraakt word
        health--;
    }
    public void die()
    {
        if (health <= 0)
        {
            //speel de dood gaan animatie
        }
    }
    public void isGrounded()
    {
        
    }
    public void gravity()
    {
        
    }
    public void jump()
    {
        
    }
    public void walk()
    {
        
    }
    public void falling()
    {
        
    }
    public void ledgeGrab()
    {
        
    }
}
