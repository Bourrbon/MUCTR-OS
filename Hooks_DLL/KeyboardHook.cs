using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Hooks_DLL
{
    public static class KeyboardHook
    {
        // 
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        // Логирование нажаых клавиш
        private static readonly StringBuilder _log = new StringBuilder();


        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;

        // Все нажатые клавиши
        public static string Log => _log.ToString();

        // KBDLLHOOKSTRUCT из WinAPI
        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public uint vkCode;     // виртуальный код клавиши
            public uint scanCode;   // Scan-код клавиши
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(
            int idHook,
            LowLevelKeyboardProc lpfn,
            IntPtr hMod,
            uint dwThreadId
        );

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr CallNextHookEx(
            IntPtr hhk,
            int nCode,
            IntPtr wParam,
            IntPtr lParam
        );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        // Привязать ловушку
        public static void SetHook()
        {
            // Передать в ловушку дескриптор этой DLL
            string moduleName = System.IO.Path.GetFileName(Assembly.GetExecutingAssembly().Location);
            IntPtr hMod = GetModuleHandle(moduleName);

            _hookID = SetWindowsHookEx(
                WH_KEYBOARD_LL,
                _proc,
                hMod,
                0
            );

            if (_hookID == IntPtr.Zero)
            {
                throw new Exception(Convert.ToString(Marshal.GetLastWin32Error()));
            }
                
        }

        // Отвязать ловушку
        public static void UnsetHook()
        {
            if (_hookID != IntPtr.Zero)
            {
                bool success = UnhookWindowsHookEx(_hookID);
                if (!success)
                {
                    throw new Exception(Convert.ToString(Marshal.GetLastWin32Error()));
                }

                _hookID = IntPtr.Zero;
            }
        }


        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 &&
                (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
            {
                var kb = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);
                Keys key = (Keys)kb.vkCode;
            
                _log.Append($"{key} \t {kb.scanCode}\n");
            }


            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }


    }
}
