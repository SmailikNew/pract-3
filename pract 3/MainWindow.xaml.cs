using LibMas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_2;
using Microsoft.Win32;

namespace pract_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Arrayx array;

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ИСП - 34, Горшков Илья, Вариант 2. Дана матрица размера M × N и целое число K (1 ≤ K ≤ N). Найти сумму и произведение элементов K-го столбца данной матрицы.");
        }

        private void find(object sender, RoutedEventArgs e)
        {
            try
            {
                array = new Arrayx(int.Parse(tbm.Text), int.Parse(tbn.Text));
                array.Initialize(1, 10);
                datagrid1.ItemsSource = array.ToDataTable().DefaultView;
                var result = array.SumAndProduct(int.Parse(tbk.Text));
                tbrez.Text = $"Произведение = {result.Item1}, сумма = {result.Item2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Data.ToString()}");
            }
        }

        private void save(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
                savefile.DefaultExt = ".txt";
                savefile.FilterIndex = 1;
                savefile.Title = "Сохранение массива";

                if (savefile.ShowDialog() == true)
                {
                    array.Save(savefile.FileName);
                }
                datagrid1.ItemsSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Data.ToString()}");
            }
        }

        private void open(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
                openfile.DefaultExt = ".txt";
                openfile.FilterIndex = 1;
                openfile.Title = "Открытие массива";

                if (openfile.ShowDialog() == true)
                {
                    array.Open(openfile.FileName);
                }
                datagrid1.ItemsSource = array.ToDataTable().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Data.ToString()}");
            }
        }
    }
}
