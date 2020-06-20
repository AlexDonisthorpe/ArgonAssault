using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In meters per second (ms^-1")] [SerializeField] float controlSpeed = 16;
    [Tooltip("in m")][SerializeField] float xRange = 11f;
    [Tooltip("in m")][SerializeField] float yRange = 7f;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -2.77f;
    [SerializeField] float positionYawFactor = 2.5f;

    [Header("Control-throw Based")]
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controlRollFactor = -30f;

    float xThrow, yThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float xPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        yThrow = Input.GetAxis("Vertical");
        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float yPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }
}
