using System;
using UnityEngine;

public class TicTacToe : MonoBehaviour
{
    private bool _active;
    
    private int _gamer = 1;
    private int[,] _board = new int[3, 3];

    private int _moveCount = 0;
    
    void Start()
    {
        NewGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))  NewGame();
    }

    private void NewGame()
    {
        _active = true;
        _gamer = 1;
        _board = new int[3, 3]; 
        _moveCount = 0;
    }

    public String NextStap(int x, int y)
    {
        if (_board[x, y] != 0 || !_active) return "";
        _moveCount++;
        
        _board[x, y] = _gamer;
         int cw = CheckWinner(_board);
         if (cw != 0) Debug.Log($"Победил игрок: {_gamer}");
         if (_moveCount == 9) Debug.Log($"Ничья");
         _gamer = _gamer == 1 ? 2 : 1;
         return _gamer == 1 ? "O" : "X";
    }

    private int CheckWinner(int[,] board)
    {
        // Проверка строк
        for (int row = 0; row < 3; row++)
        {
            if (board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2] && board[row, 0] != 0)
            {
                _active = false;
                return board[row, 2]; 
            }
        }

        // Проверка столбцов
        for (int col = 0; col < 3; col++)
        {
            if (board[0, col] == board[1, col] && board[1, col] == board[2, col] && board[0, col] != 0)
            {
                _active = false;
                return board[0, col]; 
            }
        }

        // Проверка главной диагонали
        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != 0)
        {
            _active = false;
            return board[1, 1]; 
        }

        // Проверка побочной диагонали
        if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != 0)
        {
            _active = false;
            return board[1, 1]; 
        }
            

        return 0;
    }
    
}
