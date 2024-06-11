// Sadie Gress, June 2024
// Movement Code for TwoFeetTall

using UnityEngine;

public class Movement : MonoBehaviour
{
    float yVel = 0f, grav = -9.81f, velocitySpeed;
    Vector2 playerInput, velocity, desiredVelocity;
    [SerializeField] CharacterController controller;
    [SerializeField] float walkingTopSpeed = 10f, sprintingTopSpeed = 15f, accelerationSpeed = 10f, jumpVelocity = 10f;

    void Awake() {
        velocitySpeed = walkingTopSpeed;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            velocitySpeed = sprintingTopSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)){
            velocitySpeed = walkingTopSpeed;
        }
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized; //check input direction
        velocity = Vector2.Lerp(velocity, playerInput * velocitySpeed, accelerationSpeed * Time.deltaTime); //accelerate towards desired velocity
        yVel = controller.isGrounded ? -2f : yVel + grav * Time.deltaTime; //lock to ground or accelerate via gravity
        if (Input.GetButtonDown("Jump") && controller.isGrounded) {
            yVel = jumpVelocity;
        }
        controller.Move((transform.forward * velocity.y + transform.up * yVel + transform.right * velocity.x) * Time.deltaTime); //move by velocity
    }
}

