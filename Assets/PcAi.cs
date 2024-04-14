using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PcAi
{
    private string badge; // Assuming badge is a string
    private string other_badge;
   
    public PcAi(string badge)
    {
        this.badge = badge;
        this.other_badge = (badge == "X") ? "O" : "X";
    }

    public int GetWeightCombination(List<int> row)
    {
        int is_self = row.FindAll(item => item == -1).Count;
        int is_other = row.FindAll(item => item == -2).Count;

        if (is_self > 0 && is_other == 0)
        {
            return 2 * is_self;
        }
        else if (is_self == 0 && is_other > 0)
        {
            return 2 * is_other;
        }
        else if (is_self == 0 && is_other == 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public int GetBestPosition(string[][] board)
    {
        List<List<int>> grid = new List<List<int>>();
        for (int i = 0; i < board.Length; i++)
        {
            List<int> row = new List<int>();
            for (int j = 0; j < board[i].Length; j++)
            {
                Debug.Log($"{i},{j}={board[i][j]}");
                if (board[i][j] == badge)
                    row.Add(-1);
                else if (board[i][j] == other_badge)
                    row.Add(-2);
                else
                    row.Add(0);
            }
            grid.Add(row);
        }

        // Check rows
        for (int i = 0; i < grid.Count; i++)
        {
            for (int j = 0; j < grid[i].Count; j++)
            {
                if (grid[i][j] >= 0)
                {
                    grid[i][j] += GetWeightCombination(grid[i]);
                }
            }
        }

        // Check columns
        for (int col = 0; col < grid[0].Count; col++)
        {
            List<int> columns = new List<int>();
            for (int row = 0; row < grid.Count; row++)
            {
                columns.Add(grid[row][col]);
            }
            for (int i = 0; i < grid.Count; i++)
            {
                if (grid[i][col] >= 0)
                {
                    grid[i][col] += GetWeightCombination(columns);
                }
            }
        }

        // Check diagonals
        List<int> diagonal1 = new List<int>();
        List<int> diagonal2 = new List<int>();

        for (int i = 0; i < grid.Count; i++)
        {
            diagonal1.Add(grid[i][i]);
            diagonal2.Add(grid[i][grid.Count - 1 - i]);
        }

        for (int i = 0; i < grid.Count; i++)
        {
            if (grid[i][i] >= 0)
            {
                grid[i][i] += GetWeightCombination(diagonal1);
            }

            if (grid[i][grid.Count - 1 - i] >= 0)
            {
                grid[i][grid.Count - 1 - i] += GetWeightCombination(diagonal2);
            }
        }

        // Find max value
        List<int> cellList = new List<int>();
        for (int i = 0; i < grid.Count; i++)
        {
            for(int j = 0; j < grid[i].Count; j++)
            { 
                cellList.Add(grid[i][j]);
            }
        }
        // get max index's
        List<int> max_indexs = new List<int>();
        int max_value = cellList.Max();
        for (int i = 0; i < cellList.Count; i++)
        {
            if (cellList[i] == max_value)
            {
                max_indexs.Add(i);
            }
        }
        // return rand index
        return max_indexs[Random.Range(0, max_indexs.Count)];
    }
}


