using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClampRange = 10f;
    [SerializeField] float yClampRange = 10f;
    [SerializeField] float rollDegree = 20f;
    [SerializeField] float pitchDegree = 20f;
    [SerializeField] float rotationSpeed = 10f;

    Vector2 movement;

    void Update()
    {
        ProcessShipMovement();
        ProcessRotation();
    }

    void ProcessShipMovement()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXValue = transform.localPosition.x + xOffset;
        float clampedXValue = Mathf.Clamp(rawXValue, -xClampRange, xClampRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYValue = transform.localPosition.y + yOffset;
        float clampedYValue = Mathf.Clamp(rawYValue, -yClampRange, yClampRange);
        transform.localPosition = new Vector3(clampedXValue, clampedYValue, 0f);
    }

    void ProcessRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(-pitchDegree * movement.y, 0f, -rollDegree * movement.x);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    public void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
        Debug.Log(value.Get<Vector2>());
    }
}
