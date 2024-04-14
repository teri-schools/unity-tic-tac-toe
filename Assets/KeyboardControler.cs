using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    public GameObject gameOverPanel; // Панель для відображення результату гри
    public TicTacToeGame gameObj;

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameObj.isRunning)
            {
                gameObj.gameOverText.text = "Pause";
                gameOverPanel.SetActive(!gameOverPanel.activeSelf);
            }
            else
            {
               CloseGameButton.CloseGame();
            }
        }
    }
}
