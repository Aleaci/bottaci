using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using bottaci.Properties;

namespace bottaci
{
    public partial class Form1
    {
        //creo i mouse event che ci permetteranno i click
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags);
        
        //funzione random 
        Random numRand = new Random();


        //inizializzo coordinate e dizionario per memorizzare coordinate
        int posX, posY, posL, posK;
        Dictionary<string, Point> NameCoords = new Dictionary<string, Point>();


        //esegue uno screen dello schermo e restituisce l'immagine 
        private Bitmap Screening()
        {
            Bitmap screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                              Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(screenCapture);

            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                             Screen.PrimaryScreen.Bounds.Y,
                             0, 0,
                             screenCapture.Size,
                             CopyPixelOperation.SourceCopy);

            Bitmap myPic = Resources.minimizza;
            return myPic;
        }

        
        //controlla in tutto lo schermo se trova l'immagine data
        private bool IsInCapture(Bitmap searchFor, Bitmap searchIn)
        {
            for (int x = 0; x < searchIn.Width; x++)
            {
                for (int y = 0; y < searchIn.Height; y++)
                {
                    bool invalid = false;
                    int k = x, l = y;
                    for (int a = 0; a < searchFor.Width; a++)
                    {
                        l = y;
                        for (int b = 0; b < searchFor.Height; b++)
                        {
                            if (searchFor.GetPixel(a, b) != searchIn.GetPixel(k, l))
                            {
                                invalid = true;
                                break;
                            }
                            else
                                l++;
                        }
                        if (invalid)
                            break;
                        else
                            k++;
                    }
                    if (!invalid)
                    {
                        posX = x;
                        posY = y;
                        posL = l;
                        posK = k;
                        return true;
                    }
                }
            }
            return false;
        }


        //aggiunge al dizionario le coordinate
        private void addCoords(string key, Point values)
        {
            NameCoords.Add(key, values);
        }


        //bluestack's path
        OpenFileDialog openDir = new OpenFileDialog();
        Process Blues = new Process();

        //circoscrivi area interessata
        /*[DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }
        Process[] processes = Process.GetProcessesByName("Bluestacks");
        Process lol = processes[1];
        IntPtr ptr = lol.MainWindowHandle;
        Rect NotepadRect = new Rect();
        GetWindowRect(ptr, ref NotepadRect);*/
    }
}
