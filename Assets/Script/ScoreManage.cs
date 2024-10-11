using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;


public enum gameState
{
    playing,
    pause,
    gameOver
};
public class ScoreManage : MonoBehaviour
{

    public gameState _gameState;

    // public int wave = 5;

    // public int waveQuantity = 0;


    [SerializeField] static int score = 0;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI totalScoreText;

    [SerializeField] GameObject wavePanel;
    [SerializeField] TextMeshProUGUI waveText;

    void Start()
    {

        _gameState = gameState.playing;

    }

    public static void AddScore(int amount)
    {
        score += amount;

    }


    // Update is called once per frame
    void Update()
    {

        scoreText.text = $"Score: {score}";
        // if(waveQuantity >= wave){
        //     GameOver();
        // }


    }

    public void GameOver()
    {
        totalScoreText.text = $"Your Score: {score}";
        gameOverPanel.SetActive(true);
        _gameState = gameState.gameOver;

    }

    public IEnumerator WavePanel(int wave)
    {
        waveText.text = $"Wave: {wave}";
        wavePanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        wavePanel.SetActive(false);

    }

    public void OnReload()
    {
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }


    public void OnQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif
    }

}
