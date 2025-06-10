using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_ShellExecute
{
    internal class Shell
    {
        public struct SHELLEXECUTEINFOA
        {
            public int cbSize; // (!) Размер самой структуры
            public uint fMask; // ???
            public IntPtr hwnd; // Декскриптор текущего окна (якорь координат для дочерних)
            public string lpVerb; // (!) Действие
            public string lpFile; // (!) Путь к исполняемому (открываемому) файлу
            public string lpParameters; // строка с параметрами исполнения
            public string lpDirectory; // путь к текущей папкке
            public string lpClass; // Способ обработки файла

            public int nShow; // (!) Нужно ли показать приложение после исполнения файла
            public IntPtr hInstApp; // ???
            public IntPtr lpIDList; // ???
            public IntPtr hkeyClass; // дескриптор класса файла в реестре
            public uint dwHotKey; // горячая клавиша исполняющего приложения
            public IntPtr hIcon;
            public IntPtr hProcess; // Через ShellExecuteEx возвращается не всегда, поэтому необязательный
        }

        public static SHELLEXECUTEINFOA execInfo = new SHELLEXECUTEINFOA();
        //public static StringBuilder filePath = new StringBuilder();

        [DllImport("shell32.dll", CharSet = CharSet.Ansi)]
        public static extern bool ShellExecuteExA(ref SHELLEXECUTEINFOA lpExecInfo);

    }
}
