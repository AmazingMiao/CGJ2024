using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEditor;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
  
    // Update is called once per frame



    //使用时在unity中创建不同空object以使用此脚本
    public TextAsset csvFile; // 在Inspector里把CSV文件拖到此字段

    private string[,] grid;

    void Start()
    {
        grid = ReadCSV(csvFile);
        PrintGrid(grid);
    }
    void Update()
    {
        
    }

    string[,] ReadCSV(TextAsset csvFile)
    {
        // 使用StringReader读取csv文件内容
        StringReader reader = new StringReader(csvFile.text);
        List<string[]> rows = new List<string[]>();

        // 读取csv文件的每一行并分割成数组
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            rows.Add(values);
        }

        // 获取行数和列数
        int rowCount = rows.Count;
        int colCount = rows[0].Length;

        // 创建二维数组
        string[,] grid = new string[rowCount, colCount];

        // 填充二维数组
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                grid[i, j] = rows[i][j];
            }
        }

        return grid;
    }

    void PrintGrid(string[,] grid)
    {
        int rowCount = grid.GetLength(0);
        int colCount = grid.GetLength(1);

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                Debug.Log($"grid[{i},{j}] = {grid[i, j]}");
            }
        }
    }
    public string GetValue(int row, int col)
    {
        if (row >= 0 && row < grid.GetLength(0) && col >= 0 && col < grid.GetLength(1))
        {
            return grid[row, col];
        }
        else
        {
            Debug.LogError("Index out of range");
            return null;
        }
    }
    public void CSVUser()
    {
        // 读取CSV文件中的特定值,调用时行数以Random方法生成的数组成员nLine[]代替,下为示例
        string value = GetValue(1, 2); // 获取第1行第2列的值
        Debug.Log($"[1,2]的标签: {value}");
    }
}
