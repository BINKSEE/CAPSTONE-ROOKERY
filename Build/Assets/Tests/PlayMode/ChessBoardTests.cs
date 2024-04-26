using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests
{
    public class ChessboardTests
    {
        [UnityTest]
        public IEnumerator ChessboardGameObjectExists()
        {
            // Load the scene containing the chessboard
            yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("SampleScene");

            // Find the chessboard GameObject in the scene
            GameObject chessboardGameObject = GameObject.Find("ChessBoard");

            // Check if the chessboard GameObject exists
            Assert.NotNull(chessboardGameObject, "Chessboard GameObject not found in the scene");
        }
    }
}
