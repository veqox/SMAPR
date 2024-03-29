﻿namespace SMAPR
{
    public class ProgressBar
    {
        private static int Length { get { return Console.BufferWidth; } }
        private char ProgressChar { get; }
        private char PlaceholderChar { get; }
        protected double Progress { get; set; }
        private double Total { get; set; }
        private ConsoleColor ProgressColor { get; }
        private ConsoleColor PlaceholderColor { get; }

        public ProgressBar(double total, char progressChar = '#', char placeholderChar = '-')
        {
            ProgressChar = progressChar;
            PlaceholderChar = placeholderChar;
            if (total <= 0)
                throw new ArgumentException("Total can not be less than or equal to 0");
            Total = total;
            Progress = 0;
        }

        public ProgressBar(double total, char progressChar = '#', char placeholderChar = '-', ConsoleColor progressColor = ConsoleColor.Green, ConsoleColor placeholderColor = ConsoleColor.White) : this(total, progressChar, placeholderChar)
        {
            ProgressColor = progressColor;
            PlaceholderColor = placeholderColor;
        }

        public void Update(double progress)
        {
            Progress += progress;
            PrintProgressBar();
        }

        protected void PrintProgressBar()
        {
            int length = Length - 2;

            // Amount of # in the ProgressBar
            double mask = Progress / Total * length;

            Console.ForegroundColor = PlaceholderColor;
            Console.Write("[");

            Console.ForegroundColor = ProgressColor;
            Console.Write(new string(ProgressChar, (int)mask));

            Console.ForegroundColor = PlaceholderColor;
            Console.Write($"{new string(PlaceholderChar, length - (int)mask)}]");

            Console.ResetColor();
        }
    }
}