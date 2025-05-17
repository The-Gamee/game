namespace theGame;

 /*
 *  Renju Checker
 *  =============
 *  – читає тестові дані з файлу input.txt
 *  – обробляє кожну дошку 19 × 19
 *  – записує результат у файл output.txt
 *
 *  Формат вхідних та вихідних даних описано у постановці задачі.
 */

using System;
using System.IO;
using System.Linq;
using System.Text;

class Program
{
    /* напрямки перевірки (→, ↓, ↘, ↗) */
    private static readonly int[,] Dir = { { 0, 1 }, { 1, 0 }, { 1, 1 }, { -1, 1 } };

    static void Main()
    {
        /* ---------- Блок читання з input.txt ---------- */
        const string inputFile = "input.txt";
        const string outputFile = "output.txt";

        string[] allLines = File.ReadAllLines(inputFile);
        int ptr = 0;
        int tests = int.Parse(allLines[ptr++].Trim());

        var sbOut = new StringBuilder();

        for (int tc = 0; tc < tests; tc++)
        {
            /* читаємо одну дошку */
            int[,] board = new int[19, 19];
            for (int r = 0; r < 19; r++)
            {
                int[] row = allLines[ptr++]
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int c = 0; c < 19; c++) board[r, c] = row[c];
            }

            /* ---------- Основна логіка перевірки ---------- */
            int winner = 0, ansR = -1, ansC = -1;
            bool found = false;

            for (int r = 0; r < 19 && !found; r++)
            {
                for (int c = 0;     c < 19 && !found; c++)
                {
                    int color = board[r, c];
                    if (color == 0) continue;

                    for (int d = 0; d < 4 && !found; d++)
                    {
                        int dr = Dir[d, 0], dc = Dir[d, 1];

                        /* не стартуємо всередині довшої послідовності */
                        if (Inside(r - dr, c - dc) && board[r - dr, c - dc] == color) continue;

                        /* перевіряємо рівно 5 каменів */
                        bool ok = true;
                        for (int k = 1; k < 5; k++)
                        {
                            int nr = r + dr * k, nc = c + dc * k;
                            if (!Inside(nr, nc) || board[nr, nc] != color) { ok = false; break; }
                        }
                        if (!ok) continue;

                        /* відкидаємо «довгі» рядки (>5) */
                        if (Inside(r + dr * 5, c + dc * 5) &&
                            board[r + dr * 5, c + dc * 5] == color) continue;

                        winner = color;
                        ansR = r; ansC = c;
                        found = true;
                    }
                }
            }

            /* ---------- Формування вихідних даних ---------- */
            sbOut.AppendLine(winner.ToString());
            if (winner != 0) sbOut.AppendLine($"{ansR + 1} {ansC + 1}");
        }

        /* ---------- Запис результату у output.txt ---------- */
        File.WriteAllText(outputFile, sbOut.ToString().TrimEnd());
    }

    private static bool Inside(int r, int c) => r >= 0 && r < 19 && c >= 0 && c < 19;
}
