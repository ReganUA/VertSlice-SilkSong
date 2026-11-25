using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
public class MovingEntity : Entity
{
    protected float speed = 10;
    private int health;
    private bool isFacingRight;
    private int attackPower;
    private float horizontal;
    private InputActionMap map;
    private InputAction moveAction;
    protected InputAction jumpAction;
    //private Vector2 moveInput;
    protected float jumpingPower;
    [SerializeField] private Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private string actionMapName = "Player";
    [SerializeField] private InputActionAsset input;
    [SerializeField] private Rigidbody2D rb;

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
        rb = GetComponent<Rigidbody2D>();
        map = input.FindActionMap(actionMapName);
        moveAction = map.FindAction("Move");
        jumpAction = map.FindAction("jump");
    }
    void Update()
    {

        
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
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
    public void takeDamage()
    {
        //action event waneer ik geraakt word door needel of enemy
        health--;
    }
    public void die()
    {
        if (health <= 0)
        {
            //speel de dood gaan animatie
        }
    }
    protected bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    public void jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
    }
    public void walk()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        //float currentMoveSpeed = moveInput.y * speed * Time.deltaTime;
        horizontal = moveAction.ReadValue<Vector2>().x;
    }
    public void falling()
    {
        if (rb.linearVelocity.y <= -1f)
        {
            //falling animation
        }
    }
    public void ledgeGrab()
    {
        
    }
    
}
