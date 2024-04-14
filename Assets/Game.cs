using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeGame : MonoBehaviour
{
    public List<Button> buttonList; // Масив кнопок, які представляють клітинки гри
    public Text gameOverText; // Текст для відображення результату гри
    public GameObject gameOverPanel; // Панель для відображення результату гри
    public bool isRunning = false;


    private string playerX = "X"; // Символ гравця X
    private string playerO = "O"; // Символ гравця O
    private string currentPlayer; // Поточний гравець
    private string lastStartPlayer = "O";
    private int moveCount; // Лічильник ходів
    private bool isFriend = true;
    private PcAi Pc;

    void Start()
    {
        SetButtonsInteractable(false);
        gameOverText.text = "Welcome to Tic-Tac-Toe";
        gameOverPanel.SetActive(true);
    }

    private void Move(int cellNum)
    { 
        buttonList[cellNum].GetComponentInChildren<Text>().text = currentPlayer; // Встановлюємо символ гравця на кнопці
        buttonList[cellNum].interactable = false; // Забороняємо клік по цій кнопці
        moveCount++; // Збільшуємо лічильник ходів

        if (CheckForWin())
        {
            EndGame(currentPlayer); // Переможець знайдений
        }
        else if (moveCount >= 9)
        {
            EndGame(null); // Нічия
        }
        else
        {
            // Зміна гравця
            currentPlayer = (currentPlayer == playerX) ? playerO : playerX;
        }
    }

    private string[][] GetBoard()
    {
        string[][] board = new string[3][];
        string[] row = new string[3];
        int i = 0;
        while (i < 9)
        {
            string text = buttonList[i].GetComponentInChildren<Text>().text;
            row[i % 3] = text;
            if (i % 3 == 2)
            {
                board[i / 3] = row;
                row = new string[3];
            }
            i++;
        }
        return board;
    }

    private void MovePc()
    {
        int position = Pc.GetBestPosition( GetBoard() );
        Move(position);
    }

    public void ButtonClicked(int buttonIndex)
    {
        Move(buttonIndex);
        if (!isFriend)
        {
            MovePc();
        }
    }

    bool CheckForWin()
    {
        // Перевірка на переможця
        return (CheckLine(0, 1, 2) || CheckLine(3, 4, 5) || CheckLine(6, 7, 8) ||
                CheckLine(0, 3, 6) || CheckLine(1, 4, 7) || CheckLine(2, 5, 8) ||
                CheckLine(0, 4, 8) || CheckLine(2, 4, 6));
    }

    bool CheckLine(int i1, int i2, int i3)
    {
        // Перевірка рядка клітинок
        return (buttonList[i1].GetComponentInChildren<Text>().text == currentPlayer &&
                buttonList[i2].GetComponentInChildren<Text>().text == currentPlayer &&
                buttonList[i3].GetComponentInChildren<Text>().text == currentPlayer);
    }

    void SetButtonsInteractable(bool value)
    {
        // Встановлення доступності кнопок
        foreach (Button button in buttonList)
        {
            button.interactable = value;
            if (value)
            {
                button.GetComponentInChildren<Text>().text = "";
                button.onClick.AddListener(() => ButtonClicked(buttonList.IndexOf(button)));
            }
            else
            {
                button.onClick.RemoveAllListeners();
            }
        }
    }

    void EndGame(string? player)
    {
        isRunning = false;
        string result = "It's a draw!";
        if (player != null)
        {
             result = currentPlayer + " wins!";
        }
        gameOverText.text = result; // Встановлення результату гри в текст
        gameOverPanel.SetActive(true); // Показуємо панель з результатом
        SetButtonsInteractable(false); // Забороняємо клік по кнопкам
    }
    
    public void StartGame()
    {
        SetButtonsInteractable(false);
        isRunning = true;
        isFriend = true;
        gameOverPanel.SetActive(false); // При початку гри панель з результатом ховаємо
        moveCount = 0;
        lastStartPlayer = (lastStartPlayer == playerX) ? playerO : playerX;
        currentPlayer = lastStartPlayer;
        SetButtonsInteractable(true); // Робимо всі клітинки доступними для кліку
    }

    public void StartGamePc()
    {
        StartGame();
        isFriend = false;
        Pc = new PcAi(lastStartPlayer);
        if (currentPlayer == playerO)
        {
            MovePc();
        }
    }
}
