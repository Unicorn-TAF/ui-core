﻿using Unicorn.Core.Logging;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Unicorn.Core.Reporting
{
    public class Screenshot
    {
        public static Bitmap PrintScreen(string fileName)
        {
            try
            {
                Logger.Instance.Debug("Creating print screen...");
                int screenWidth = Screen.PrimaryScreen.Bounds.Width;
                int screenHeight = Screen.PrimaryScreen.Bounds.Height;
                Bitmap printscreen = new Bitmap(screenWidth, screenHeight);
                Graphics graphics = Graphics.FromImage(printscreen as Image);
                graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
                return printscreen;
//                printscreen.Save(string.Format("{0}{1}.{2}", FILEPATH, fileName, ImageFormat.Jpeg.ToString()), ImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                Logger.Instance.Debug("Failed to get/save print screen...");
                Logger.Instance.Debug("Exception: " + e.ToString());
                return null;
            }
        }
    }
}
