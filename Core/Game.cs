using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace ByteCrusher.Core
{
  public class Game
  {
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool GetConsoleMode(IntPtr handle, out int mode);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GetStdHandle(int handle);


    internal int _width;
    internal int _height;

    internal int _frameRate;

    internal List<Scene> _scenes;

    private Thread _thread;

    private ILogger _logger;
    private bool _isPlaying;
    private int _activeSceneIndex = 1;

    public Game(ILogger logger = null)
      => _logger = logger;

    public void Play()
    {
      _scenes.ForEach(x => x.Initialize());
      _thread = new Thread(_StartThread);
      _isPlaying = true;
      _thread.Start();
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
      var activeScene = _scenes[_activeSceneIndex];
      activeScene.Drawing();
      _scenes.ForEach(x => x.Process());
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