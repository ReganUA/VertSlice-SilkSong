using System.Runtime.Serialization;
using UnityEngine;

public class Player : MovingEntity
{
    [SerializeField] private float playerJumpPower;
    [SerializeField] private float playerWalkSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = playerWalkSpeed;
        jumpingPower = playerJumpPower;
        walk();
        turn();
        if (jumpAction.WasPressedThisFrame() && IsGrounded())
        {
            jump();
        }
    }
}
