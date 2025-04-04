using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab6
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		public void LoadDLL(string path)
		{
			try
			{	
				//var path = @"D:\Unik\4 sem\OS\Lab6_DLL\bin\Debug\net8.0-windows\Lab6_DLL.dll";

				var assembly = Assembly.LoadFile(path);

				var type = assembly.GetType("Lab6_DLL.TestClass");

				var obj = Activator.CreateInstance(type);

				var method = type.GetMethod("CreateForm");

				method.Invoke(obj, new object[] { });
			}
			catch (Exception ex)
			{
				// Вызываем диалоговое окно с сообщением об ошибке
				MessageBoxResult result = MessageBox.Show(
				ex.Message,
				"Ошибка подключения DLL-библиотеки",
				MessageBoxButton.OK,
				MessageBoxImage.Error);


				if (result == MessageBoxResult.Yes)
				{
					// Сделать что-то
				}
			}
		}

        private void InvokeButton_Click(object sender, RoutedEventArgs e)
        {
			LoadDLL(PathInputBox.Text);
        }
    }
}