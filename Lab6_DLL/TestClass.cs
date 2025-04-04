
using System.Windows;

namespace Lab6_DLL
{
    public class TestClass
    {
        public static void CreateForm()
        {
            Window w = new Window
            {
                Title = "Новое окно из DLL",
                Width = 800,
                Height = 600,   
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            NewWindowControl nwc = new NewWindowControl();
            w.Content = nwc;
            w.Show();
            
        }

        public static double func(double x)
        {
            return Math.Exp(Math.Sin(x));
        }
    }

}
