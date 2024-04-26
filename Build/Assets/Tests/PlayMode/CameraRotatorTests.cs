using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests
{
    public class CameraRotatorTests
    {
        [UnityTest]
        public IEnumerator CameraRotates()
        {
            // Load the scene containing the camera rotator
            yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("SampleScene");

            // Find the camera rotator GameObject in the scene
            GameObject cameraRotatorGameObject = GameObject.Find("CameraRotator");

            // Get the CameraRotator component from the GameObject
            CameraRotator cameraRotator = cameraRotatorGameObject.GetComponent<CameraRotator>();

            // Save the initial rotation
            Quaternion initialRotation = cameraRotator.transform.rotation;

            // Rotate the camera
            cameraRotator.RotateCamera();

            // Wait for a short time to allow for rotation
            yield return new WaitForSeconds(1.0f);

            // Check if the camera has rotated
            Quaternion rotatedRotation = cameraRotator.transform.rotation;
            Assert.AreNotEqual(initialRotation, rotatedRotation, "Camera did not rotate");
        }
    }
}


