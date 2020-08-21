using System;

namespace ByteCrusher.Core.IO
{
  public static class Time
  {
    public static float deltaTime;

    private static float _lastTime;

    public static void RecalculateDelta()
    {
      var now = DateTime.Now.Millisecond;
      deltaTime = (now - _lastTime) / 1000;
      _lastTime = now;
    }
  }
}