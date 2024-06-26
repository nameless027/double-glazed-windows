﻿/*Задание на C#. 
Есть формула стеклопакета (СП) вида Стекло\Рамка\Стекло (1-камерный СП ). Или Стекло\Рамка\Стекло\Рамка\Стекло (2-х камерный СП). 
Порядок всегда именно такой. Иногда бывают просто отдельный стекла. Камерность у них 0, рамки нет. 
И Стекло, и Рамка могут содержать как числа, так и символы. Числа – однозначные или двухзначные. В начале Стекла или Рамки всегда стоит число, которое показывает толщину Стекла\Рамки. От прочего может отделяться пробелом, нижним подчеркиванием, может и ничем не отделяться. Написать программу на C#, в которой будет вводиться артикул стеклопакета, и которая будет выдавать следующую информацию
1.	СП однокамерный или 2 камерный? 
2.	Толщина всего СП? 
3.	Толщина стекла в данном СП? 
*/


using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите артикул стеклопакета: ");
        string input = Console.ReadLine();

        string[] parts = input.Split('/'); // разделение на массив

        int cam = parts.Length / 2; // определение камерности
        int totalThickness = 0; // общя толщина
        int glassThickness = 0; // толщина стекла
        Regex regex = new Regex(@"\d+"); // регулярное выражение, которое определяет первое число в строке

        for (int i = 0; i < parts.Length; i++)
        {
            Match match = regex.Match(parts[i]);
            if (match.Success) // возвращае true если найдено совпадение регулярному выражению
            {
                int thickness = Convert.ToInt32(match.Value); // нахожу толщину первой позиции

                totalThickness += thickness; // суммирую
            }
            if (i % 2 == 0) // ищу толщину стекл(не четные позиции)
            {
                int thickness = Convert.ToInt32(match.Value);

                glassThickness += thickness; //суммирую
            }

        }

        Console.WriteLine("СП {0}-камерный", cam);
        Console.WriteLine("Толщина всего СП: {0}", totalThickness);
        Console.WriteLine("Толщина стекла в данном СП: {0}", glassThickness);
    }
}
