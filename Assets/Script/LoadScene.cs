using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    public string mainSceneName = "GameplayScene";

    public void StartGame()
    {
        // Load scene chính khi người chơi nhấn nút "Play"
        SceneManager.LoadScene(mainSceneName);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif

    }
}
