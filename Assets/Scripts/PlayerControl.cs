using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float controlSpeed = 60f;

    [SerializeField] float positionPitchFactor = -1.6f;
    [SerializeField] float controlPitchFactor = -3f;
    [SerializeField] float positionYawFactor = 1;
    [SerializeField] float controlRollFactor = -27;

    float yThrow;
    float xThrow;

    //Boundaries where player can move on screen
    [SerializeField] float xRange = 30f;
    [SerializeField] float yRange = 25f;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;

        float pitch = pitchDueToPosition + pitchDueToControl;
        float yaw = yawDueToPosition;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw ,roll);
    }

    private void ProcessTranslation()
    {
        //Get Input
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        //Moving with clamping
        float xOffSet = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffSet;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffSet = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffSet;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3
        (clampedXPos,
         clampedYPos,
         transform.localPosition.z);
    }
}
