using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace ByteCrusher.Core
{
  public class Game
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

    internal int _width;
    internal int _height;

    internal int _frameRate;

    internal List<Scene> _scenes;

    private Thread _thread;

    private ILogger _logger;
    private bool _isPlaying;
    private int _activeSceneIndex = 0;

    public Game(ILogger logger = null)
      => _logger = logger;

    public void Play()
    {
      _scenes.ForEach(x => x.Initialize());
      _thread = new Thread(_StartThread);
      _isPlaying = true;
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

    public void Stop()
      => _isPlaying = false;

    private void _StartThread()
    {
      while (_isPlaying)
      {
        _Draw();
        Thread.Sleep(_frameRate);
      }
    }

    private void _Draw()
    {
      // process active scene redrawing by tick
      var activeScene = _scenes[_activeSceneIndex];
      _scenes.ForEach(x => x.Process());
      
      Console.SetCursorPosition(0, 0);
      Console.CursorVisible = false;
      var drawing = activeScene.Drawing(this);
      Console.Write(drawing);
    }
  }

  public static class GameExtensions
  {
    public static Game WithScene(this Game game, Scene scene)
    {
      if (game._scenes == null)
        game._scenes = new List<Scene>();

      game._scenes.Add(scene);

      return game;
    }

    public static Game ByFrameRate(this Game game, int frameRate)
    {
      game._frameRate = frameRate;
      return game;
    }

    public static Game WithWidthAndHeight(this Game game, int width, int height)
    {
      game._width = width;
      game._height = height;

      return game;
    }
  }
}