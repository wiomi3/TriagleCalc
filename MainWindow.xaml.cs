
using System;
using System.Windows;
using System.Windows.Controls;

namespace TriangleTypeChecker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            // Считываем длины сторон из текстовых полей
            if (int.TryParse(One.Text, out int a) && int.TryParse(Two.Text, out int b) &&
                int.TryParse(Three.Text, out int c))
            {
                string triangleType;

                // Проверка положительности сторон
                if (a <= 0 || b <= 0 || c <= 0)
                {
                    triangleType = "Стороны треугольника должны быть положительными.";
                }
                else if (a == b && b == c)
                {
                    triangleType = "Треугольник равносторонний.";
                }
                else if (a == b || b == c || a == c)
                {
                    triangleType = "Треугольник равнобедренный.";
                }
                else
                {
                    triangleType = "Треугольник разносторонний.";
                }

                // Выводим результат
                ResultTextBlock.Text = triangleType;
            }
            else
            {
                ResultTextBlock.Text = "Пожалуйста, введите корректные целые числа.";
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.StartsWith("Сторона"))
            {
                textBox.Text = string.Empty;
            }
        }


        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrEmpty(textBox.Text))
            {
                if (textBox.Name == "One")
                {
                    textBox.Text = "Сторона A";
                }
                else if (textBox.Name == "Two")
                {
                    textBox.Text = "Сторона B";
                }
                else if (textBox.Name == "Three")
                {
                    textBox.Text = "Сторона C";
                }
            }
        }

    }
}
