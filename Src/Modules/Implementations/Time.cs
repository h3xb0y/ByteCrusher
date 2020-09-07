using System;

namespace ByteCrusher.Modules.Implementations
{
  public class Time : IKernelModule
  {
    public float DeltaTime => _dt;

    private float _lastTime;
    private float _dt;

    public void Update()
    {
      var now = DateTime.Now.Millisecond;
      _dt = (now - _lastTime) / 1000;
      _lastTime = now;
    }
  }
}