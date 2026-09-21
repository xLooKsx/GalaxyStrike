using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [Header("MovementParams")]
    [SerializeField] float movementSpeed;
    [SerializeField] float xMaxClampValue;
    [SerializeField] float yMaxClampValue;
    
    [Header("RollParams")]
    [SerializeField] float rollValue;
    [SerializeField] float rollSpeed;

    [Header("PitchParams")]
    [SerializeField] float pitchValue;
    [SerializeField] float pitchSpeed;

    Vector2 movement;
    void Update()
    {
        GetNewLocalMovementPosition();
        QuaternionRotation();
        QuaternionPitch();
    }

    public void OnDirections(InputValue inputValue){
       movement = inputValue.Get<Vector2>();
    }

    void QuaternionPitch()
    {
        float pitchRotation = pitchValue * movement.y * -1;
        Quaternion desiredPitchChange = Quaternion.Euler(pitchRotation, 0f, 0f);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, desiredPitchChange, pitchSpeed * Time.deltaTime);;
    }

    void QuaternionRotation()
    {
        float rollRotation = rollValue * movement.x * -1;
        Quaternion desiredRollChange = Quaternion.Euler(0f, 0f, rollRotation);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, desiredRollChange, rollSpeed * Time.deltaTime);
    }

    void GetNewLocalMovementPosition()
    {
        float rawXPosition = MovementDirection(movement.x) + transform.localPosition.x;
        float rawYPosition = MovementDirection(movement.y) + transform.localPosition.y;

        float clampedXPosition = ClampeMovement(rawXPosition, xMaxClampValue);
        float clampedYPosition = ClampeMovement(rawYPosition, yMaxClampValue);

        transform.localPosition = new Vector3(clampedXPosition, clampedYPosition, 0f);
    }

    float ClampeMovement(float movementValue, float maxClampValue)
    {
        return Mathf.Clamp(movementValue, -maxClampValue, maxClampValue);
    }

    float MovementDirection(float movementDirection)
    {
        return movementDirection * movementSpeed * Time.deltaTime;
    }

}
