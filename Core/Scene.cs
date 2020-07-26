using System.Collections.Generic;

namespace ByteCrusher.Core
{
  public sealed class Scene
  {
    private List<Entity> _entities;
    private IEntityDrawer _backgroundDrawer;

    public Scene WithEntity(Entity entity)
    {
      if(_entities == null)
        _entities = new List<Entity>();
      
      _entities.Add(entity);

      return this;
    }

    public Scene WithBackground(IEntityDrawer drawer)
    {
      _backgroundDrawer = drawer;
      return this;
    }

    public void Initialize()
    {
      // TODO
    }

    public void Process()
      => _entities.ForEach(x => x.Process(this));

    public string Drawing(Game game)
    {
      var layer = new Layer.Layer(game._width, game._height);
      
      layer.Apply(_backgroundDrawer);

      // apply all entities drawing by layering
      foreach (var entity in _entities)
        layer.Apply(entity.Drawer(), entity.Position);
      
      return layer.ToString();
    }
    
  }
}