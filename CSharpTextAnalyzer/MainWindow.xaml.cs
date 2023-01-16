using CSharpTextAnalyzer.Models;
using CSharpTextAnalyzer.View;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;

namespace CSharpTextAnalyzer
{
    //MainWindow
    public partial class MainWindow : Window
    {
        //Standart constructor
        public MainWindow()
        {
            InitializeComponent();
        }

        //Method that allows user to move the application window
        private async void GridBackground_Loaded(object sender, RoutedEventArgs e) => MouseDown += delegate { DragMove(); };

        //Button close window action
        private async void ButtonCloseWindow_Click(object sender, RoutedEventArgs e) => Close();

        //Button minimize window action
        private async void ButtonMinimizeWindow_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        //Button choose file with text action
        private async void ButtonChooseTextFromFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                TextBoxWithText.Text = FileController.GetTextFromFile(openFileDialog.FileName);
            }
        }

        //Method that clears label with results of analyzing text
        private async void ClearLabelsWithResults()
        {
            LabelWordCountResult.Content = "__________";
            LabelMaxOccuringWordResult.Content = "__________";
            LabelMaxOccuringWordCountResult.Content = "__________";
            LabelClassicTextNauseaResult.Content = "__________";
            LabelNumberOfCharactersWithSpacesResult.Content = "__________";
            LabelNumberOfCharactersWithoutSpacesResult.Content = "__________";
            LabelNumberOfDelimitersResult.Content = "__________";
            LabelMaxOccuringCharacterResult.Content = "__________";
            LabelCountOfMaxOccuringCharacterResult.Content = "__________";
            LabelBigLetterCountResult.Content = "__________";
            LabelLowLetterCountResult.Content = "__________";
        }

        //Button text analysis action
        private async void ButtonTextAnalyz_Click(object sender, RoutedEventArgs e)
        {
            string text = TextBoxWithText.Text;

            if (!text.Equals("") && text != null)
            {
                using (ViewResults viewResults = new ViewResults())
                {
                    viewResults.ShowResultsOfAnalyzingText(LabelWordCountResult, LabelMaxOccuringWordResult, LabelMaxOccuringWordCountResult,
                        LabelClassicTextNauseaResult, LabelNumberOfCharactersWithSpacesResult, LabelNumberOfCharactersWithoutSpacesResult,
                        LabelNumberOfDelimitersResult, LabelMaxOccuringCharacterResult, LabelCountOfMaxOccuringCharacterResult,
                        LabelBigLetterCountResult, LabelLowLetterCountResult, text);
                }
            }
            else
            {
                ClearLabelsWithResults();
            }
        }

        //Block windows-1251 unicode in TextBoxWithText
        private async void TextBoxWithText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char ch = e.Text[0];
            if ((ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я'))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        //Block menu with paste in TextBoxWithText
        private async void TextBoxWithText_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e) => e.Handled = true;

        //Block Ctrl+V combination
        private async void TextBoxWithText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                e.Handled = true;
            }
        }

        //Button clear text action
        private async void ButtonClearTextBoxWithText_Click(object sender, RoutedEventArgs e) => TextBoxWithText.Clear();
    }
}
