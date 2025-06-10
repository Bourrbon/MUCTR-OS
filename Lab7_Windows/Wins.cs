using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab7
{
    class Wins
    {
        public static uint MaxTitleLength = 128;
        public static bool SearchOnlyVisibleWindows = false;
        public static List<IntPtr> handleList = new List<IntPtr>();
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        public static IntPtr SelectedWindowHandle = IntPtr.Zero;

        [DllImport("user32.dll")]
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int GetWindowTextA(IntPtr hWnd, StringBuilder lpString, uint nMaxCount);

        [DllImport("user32.dll")]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int newWidth, int newHeight, bool needsRepaint);

        [DllImport("user32.dll")]
        public static extern bool SetWindowText(IntPtr hWnd, string lpString);



        public static bool EnumWindowsOnlyVisibleCallback(IntPtr hWnd, IntPtr lParam)
        {
            // Проверяем, видимо ли окно
            if (IsWindowVisible(hWnd))
            {
                handleList.Add(hWnd);
            }
            return true;
        }

        public static bool EnumWindowsAllCallback(IntPtr hWnd, IntPtr lParam)
        {
            handleList.Add(hWnd);
            return true;
        }



    }
}
