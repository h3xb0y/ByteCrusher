using System;
using System.Runtime.InteropServices;
using System.Threading;
using ByteCrusher.Entities;
using ByteCrusher.Entities;
using ByteCrusher.IO;

namespace ByteCrusher.Modules
{
  public class Kernel
  {
    
    #region API

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool GetConsoleMode(IntPtr handle, out int mode);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetStdHandle(int handle);

    private const int ENABLE_QUICK_EDIT = 0x0040;

    private const int STD_INPUT_HANDLE = -10;

    private const int STD_OUTPUT_HANDLE = -11;

    #endregion
    
    internal readonly GameSettings _settings;
    internal readonly ILogger _logger;

    private Thread _thread;

    public Kernel(GameSettings settings, ILogger logger = null)
    {
      _settings = settings;
      _logger = logger;
    }

    public void Start()
    {
      _settings.Scenes.ForEach(x => x.Initialize());
      _thread = new Thread(_StartThread);
      _thread.Start();

      // block input mode in console
      var handle = GetStdHandle(STD_INPUT_HANDLE);
      GetConsoleMode(handle, out var mode);
      mode &= ~ENABLE_QUICK_EDIT;
      SetConsoleMode(handle, mode | 0x4);

      // set console output ansii style
      handle = GetStdHandle(STD_OUTPUT_HANDLE);
      GetConsoleMode(handle, out mode);
      SetConsoleMode(handle, mode | 0x4);
    }

    private void _StartThread()
    {
      while (true)
      {
        _Draw();
        Thread.Sleep(_settings.FrameRate);
      }
    }

    private void _Draw()
    {
      var activeScene = _settings.Scenes[_settings.SceneIndex];
      activeScene.Process(_settings.Width, _settings.Height);
      
      Console.SetCursorPosition(0, 0);
      Console.CursorVisible = false;
      
      var drawing = activeScene.Drawing(this);
      
      Console.Write(drawing);
      Time.RecalculateDelta();
      Input.Update();
    }
  }
}