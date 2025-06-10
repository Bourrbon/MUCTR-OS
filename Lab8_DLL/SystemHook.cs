
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab8_DLL
{
    public class SystemHook_DLL
    {
        public void ChangeButtonColor(Button btn, bool isActive)
        {
            if (isActive)
            {
                btn.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                btn.Background = new SolidColorBrush(Colors.Red);
            }
        }
    }

}
