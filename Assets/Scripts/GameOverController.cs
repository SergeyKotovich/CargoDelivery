using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [UsedImplicitly]
    public void RestartGame()
    {
        SceneManager.LoadScene("game");
    }

    
}
