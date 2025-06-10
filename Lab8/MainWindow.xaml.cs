using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Lab8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml <br/>
    /// фывфывфыв
    /// </summary>
    public partial class MainWindow : Window
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate IntPtr HookProc(int nCode, UIntPtr wParam, IntPtr lParam);

        private HookProc msProc;
        private HookProc kbProc;

        public IntPtr MouseHook { get; private set; } = IntPtr.Zero;
        public IntPtr KeyboardHook { get; private set; } = IntPtr.Zero;

        public event EventHandler<NewMouseMessageEventArgs> NewMouseMessage;
        public event EventHandler<NewKeyboardMessageEventArgs> NewKeyboardMessage;

        public MainWindow()
        {
            InitializeComponent();
        }

        internal enum HookType
        {
            LowLevelKeyboard = 13,
            LowLevelMouse = 14
        }

        internal class NativeMethods
        {
            [DllImport("user32.dll")]
            internal static extern IntPtr SetWindowsHookEx(HookType idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);

            [DllImport("user32.dll")]
            internal static extern int UnhookWindowsHookEx(IntPtr hHook);

            [DllImport("user32.dll")]
            internal static extern IntPtr CallNextHookEx(IntPtr _, int nCode, UIntPtr wParam, IntPtr lParam);
        }
    }
}