
using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;

namespace NasaBackground.Services;

public static class Wallpaper
{
    const int SPI_SETDESKWALLPAPER = 20;
    const int SPIF_UPDATEINIFILE = 0x01;
    const int SPIF_SENDWININICHANGE = 0x02;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);


    public static void Define()
    {
        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

        key.SetValue(@"WallpaperStyle", 1.ToString());
        key.SetValue(@"TileWallpaper", 0.ToString());


        SystemParametersInfo(SPI_SETDESKWALLPAPER,
            0,
            @"C:\Users\kw5285\OneDrive - EQUANS\Images\NASA\Today.jpg",
            SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
    }
}
