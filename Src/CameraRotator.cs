using System.Collections;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float rotationAngle = 180f;
    public float rotationDuration = 1.0f;

    private bool isRotating = false;

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            float remainingRotation = rotationAngle - transform.localEulerAngles.y % 360;
            float rotationSpeed = remainingRotation / rotationDuration;
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }

    // Method to initiate camera rotation
    public void RotateCamera()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateCameraCoroutine());
        }
    }

    // Coroutine to smoothly rotate the camera
    private IEnumerator RotateCameraCoroutine()
    {
    isRotating = true;

    float startRotation = transform.localEulerAngles.y % 360;
    float targetRotation = startRotation + rotationAngle;

    float elapsedTime = 0f;

    while (elapsedTime < rotationDuration)
    {
        float currentRotation = Mathf.Lerp(startRotation, targetRotation, elapsedTime / rotationDuration);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, currentRotation, transform.rotation.eulerAngles.z);

        elapsedTime += Time.deltaTime;
        yield return null;
    }

    // Ensure a precise 180-degree rotation at the end
    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, targetRotation, transform.rotation.eulerAngles.z);

    isRotating = false;
    }

}


