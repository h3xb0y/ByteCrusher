using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using ByteCrusher.Core.Entities;
using ByteCrusher.Core.IO;

namespace ByteCrusher.Core.Modules
{
  public class Kernel
  {
    public KernelSettings Settings;
    
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

    internal int _width;
    internal int _height;
    internal List<Scene> _scenes;

    private Thread _thread;
    private ILogger _logger;

    public Kernel(ILogger logger = null)
      => _logger = logger;

    public void Play()
    {
      _scenes.ForEach(x => x.Initialize());
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
        Thread.Sleep(Settings.FrameRate);
      }
    }

    private void _Draw()
    {
      // process active scene redrawing by tick
      var activeScene = _scenes[Settings.SceneIndex];
      _scenes.ForEach(x => x.Process(_width, _height));
      
      Console.SetCursorPosition(0, 0);
      Console.CursorVisible = false;
      var drawing = activeScene.Drawing(this);
      _logger.LogDrawing(drawing);
      Console.Write(drawing);
      Time.RecalculateDelta();
    }
  }

  public struct KernelSettings
  {
    public int SceneIndex;
    public int FrameRate;
  }

  public static class GameExtensions
  {
    public static Kernel AddScene(this Kernel kernel, Scene scene)
    {
      if (kernel._scenes == null)
        kernel._scenes = new List<Scene>();

      kernel._scenes.Add(scene);

      return kernel;
    }
  }
}