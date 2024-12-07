using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f; // Speed multiplier for player movement
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        // Get horizontal input (left/right arrow keys or A/D keys)
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Check if the player presses the Jump button (Space by default)
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        // Check if the player presses or releases the crouch button (Ctrl by default)
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        // Pass movement, crouch, and jump inputs to the CharacterController2D
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
