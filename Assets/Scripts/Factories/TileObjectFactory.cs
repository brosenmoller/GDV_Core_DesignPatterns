using UnityEngine;

public class TileObjectFactory
{
    private readonly Transform tileParent;
    public TileObjectFactory(Transform _tileParent)
    {
        tileParent = _tileParent;
    }

    public TileObject CreateTileObject(Vector3 position, GroundType groundType)
    {
        GameObject newGameObject = new(groundType.name);
        TileObject tileObject = new(
            newGameObject.AddComponent<MeshCollider>(),
            newGameObject.AddComponent<MeshFilter>(),
            newGameObject.AddComponent<MeshRenderer>(),
            newGameObject.transform,
            new TileData(newGameObject, groundType)
        );

        tileObject.MeshRenderer.materials = groundType.Model.materials;
        tileObject.MeshFilter.mesh = groundType.Model.mesh;
        tileObject.Colllider.sharedMesh = groundType.Model.mesh;
        tileObject.Transform.position = position;
        tileObject.Transform.localScale = groundType.Model.scale;
        tileObject.Transform.parent = tileParent;

        return tileObject;
    }
}

