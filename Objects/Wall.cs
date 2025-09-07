using Shnake.Map;
using Shnake.Services;

namespace Shnake.Objects;

public class Wall(TileMap tileMap, Position position) : AbstractSolidObject(tileMap, position,
    SpriteManager.Instance.GetTexture(Sprite.FlowerBush7));