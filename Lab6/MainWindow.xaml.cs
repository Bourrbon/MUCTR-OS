using System.IO;
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
			PathInputBox.Text = @"D:\Unik\4 sem\OS\Lab6_DLL\bin\Debug\net8.0-windows\Lab6_DLL.dll";

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

				ImageBox.IsEnabled = true;


                //const string resourceName = "Lab6_DLL.Images.testimage.png";
                const string resourceName = "Lab6_DLL.testimage.png";

                using (Stream? s = assembly.GetManifestResourceStream(resourceName))
                {
                    if (s == null)
                        throw new Exception($"Ресурс {resourceName} не найден в {path}");

                    var im = new BitmapImage();
					im.BeginInit();
                    im.StreamSource = s;
					im.CacheOption = BitmapCacheOption.OnLoad;
					im.EndInit();
					im.Freeze();

					ImageBox.Source = im;
                }
            }
			catch (Exception ex)
			{
				MessageBoxResult result = MessageBox.Show(
				ex.Message,
				"Ошибка подключения DLL-библиотеки",
				MessageBoxButton.OK,
				MessageBoxImage.Error);


				if (result == MessageBoxResult.OK)
				{
					Environment.Exit(1);
				}
			}
		}

        private void InvokeButton_Click(object sender, RoutedEventArgs e)
        {
			LoadDLL(PathInputBox.Text);
        }

        private void LoadImageButton_Click(object sender, RoutedEventArgs e)
        {
            // Предположим, pictureBox1 уже есть на форме
            string dllPath = @"C:\path\to\MyLib.dll";
            Assembly asm = Assembly.LoadFrom(dllPath);


        }
    }
}