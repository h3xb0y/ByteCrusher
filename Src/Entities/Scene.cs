using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteCrusher.Entities
{
  public sealed class Scene : IDisposable
  {
    private readonly List<Entity> _entities = new List<Entity>();
    
    private List<Type> _entityTypes;
    private List<Type> _controllerTypes;
    private List<Type> _initControllerTypes;
    
    private IEntityDrawer _drawer;
    private List<SceneController> _controllers;
    private List<InitializationSceneController> _initControllers;

    public Scene Entity<T>() where T : Entity, new()
    {
      if (_entityTypes == null)
        _entityTypes = new List<Type>();

      _entityTypes.Add(typeof(T));
      return this;
    }

    public Scene Controller<T>() where T : SceneController, new()
    {
      if(_controllerTypes == null)
        _controllerTypes = new List<Type>();
      
      _controllerTypes.Add(typeof(T));
      return this;
    }

    public Scene InitController<T>() where T : InitializationSceneController, new()
    {
      if(_initControllerTypes == null)
        _initControllerTypes = new List<Type>();
      
      _initControllerTypes.Add(typeof(T));
      return this;
    }
    
    public Scene AddBackground(IEntityDrawer drawer)
    {
      _drawer = drawer;
      return this;
    }

    public void Initialize()
    {
      if (_entityTypes != null)
      {
        _entities.AddRange(
          _entityTypes
            .Select(x => (Entity) Activator.CreateInstance(x))
            .ToArray()
        );
      }
      
      if (_initControllerTypes != null)
      {
        _initControllers = new List<InitializationSceneController>();
        _initControllers.AddRange(
          _initControllerTypes
            .Select(x => (InitializationSceneController) Activator.CreateInstance(x))
            .ToArray()
        );
      }
      
      if (_controllerTypes != null)
      {
        _controllers = new List<SceneController>();
        _controllers.AddRange(
          _controllerTypes
            .Select(x => (SceneController) Activator.CreateInstance(x))
            .ToArray()
          );
      }

      _initControllers?.ForEach(x => x.Initialize(_entities));
      _controllers?.ForEach(x => x.Initialize());
      _entities?.ForEach(x => x.Initialize());
    }

    public void Process(int sceneWidth, int sceneHeight)
    {
      _controllers?.ForEach(x => x.Process(_entities, sceneWidth, sceneHeight));
      _entities?.ForEach(x => x.Process(this));
    }

    public string Drawing(Kernel kernel)
    {
      var layer = new Layer.Layer(kernel._settings.Width, kernel._settings.Height);

      if (_drawer != null)
        layer.Apply(_drawer);

      // apply all entities drawing by layering
      foreach (var entity in _entities ?? Enumerable.Empty<Entity>())
        layer.Apply(entity.Drawer, entity.Position);

      return layer.ToString();
    }

    public void Dispose()
    {
      _controllers?.ForEach(x => x.Dispose());
      _controllers?.Clear();
      _controllers = null;
      
      _initControllers?.ForEach(x => x.Dispose());
      _initControllers?.Clear();
      _initControllers = null;
      
      _entities.ForEach(x => x.Dispose());
      _entities.Clear();
    }
  }
}