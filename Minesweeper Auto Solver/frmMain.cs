using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProcessMemoryReaderLib;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace Minesweeper_Auto_Solver
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        ProcessMemoryReader pmrMine = new ProcessMemoryReader();

        int iWidthAddress;
        int iHeightAddress;
        int iMinesAddress;
        int iCellBaseAddress;

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern int SetForegroundWindow(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rectangle rectangle);

        public struct Rect
        {
            public int Left { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
            public int Top { get; set; }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        private void btnGet_Click(object sender, EventArgs e)
        {
            iWidthAddress = 0x1005334;
            iHeightAddress = 0x1005338;
            iMinesAddress = 0x1005330;
            iCellBaseAddress = 0x1005340;


            Process[] prMine = Process.GetProcessesByName("winmine");
            if (prMine.Length == 0) return;

            pmrMine.ReadProcess = prMine[0];

            pmrMine.OpenProcess();

            int iWidth;
            int iHeight;
            int iMinesCount;


            byte[] byBuff;
            int bytesReaded;
            byBuff = pmrMine.ReadProcessMemory((IntPtr)iWidthAddress, 1, out bytesReaded);
            iWidth = byBuff[0];

            byBuff = pmrMine.ReadProcessMemory((IntPtr)iHeightAddress, 1, out bytesReaded);
            iHeight = byBuff[0];

            byBuff = pmrMine.ReadProcessMemory((IntPtr)iMinesAddress, 1, out bytesReaded);
            iMinesCount = byBuff[0];

            lblWH.Text = "Width: " + iWidth.ToString() + "  " + "Height: " + iHeight.ToString() + " " + "Mines Count: " + iMinesCount.ToString();

            Button[,] btnArray = new Button[iWidth, iHeight];
            picBtnCon.Controls.Clear();

            IntPtr i = Process.GetProcessesByName("winmine")[0].MainWindowHandle;
            Rectangle rect = new Rectangle();
            GetWindowRect(i, ref rect);
            SetForegroundWindow(Process.GetProcessesByName("winmine")[0].MainWindowHandle);
            Thread.Sleep(100);
            for (int y = 0; y < iHeight; y++)
            {
                for (int x = 0; x < iWidth; x++)
                {
                    btnArray[x, y] = new Button();
                    btnArray[x, y].Location = new Point(x * 20, y * 20);
                    btnArray[x, y].Name = "";
                    btnArray[x, y].Size = new Size(20, 20);
                    btnArray[x, y].Parent = picBtnCon;
                    picBtnCon.Controls.Add(btnArray[x, y]);


                    int iAdd = iCellBaseAddress + (32 * (y + 1) + (x + 1));
                    byBuff = pmrMine.ReadProcessMemory((IntPtr)iAdd, 1, out bytesReaded);
                    int iIsMine = byBuff[0];

                    Cursor.Position = new Point(rect.X + 15 + 6 + 16 * x, rect.Y + 104 + 5 + 16 * y);
                    //Thread.Sleep(1);

                    if (x == 0 && y == 0)
                    {
                        if (iIsMine == 0x8F)
                        {
                            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                        }
                        else
                        {
                            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                        }
                    }

                    if (iIsMine == 0x8F)
                    {
                        mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                        btnArray[x, y].Text = "X";
                    }
                    else
                    {
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                    }
                    Application.DoEvents();
                }
            }
            picBtnCon.Size = new Size(iWidth * 20, iHeight * 20);
            this.Height = picBtnCon.Height + 140;
            this.Width = picBtnCon.Width + 30;

            pmrMine.CloseHandle();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Environment.OSVersion.Version.Major != 5)
            {
                MessageBox.Show("For Windows XP only!");
                Environment.Exit(1);
            }
        }
    }
}
