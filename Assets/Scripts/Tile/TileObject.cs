using UnityEngine;

public class TileObject
{
    public MeshCollider Colllider;
    public MeshFilter MeshFilter;
    public MeshRenderer MeshRenderer;
    public Transform Transform;
    public TileData TileData;

    public TileObject(MeshCollider _colllider, MeshFilter _meshFilter, MeshRenderer _meshRenderer, Transform _transform, TileData _tileData)
    {
        Colllider = _colllider;
        MeshFilter = _meshFilter;
        MeshRenderer = _meshRenderer;
        Transform = _transform;
        TileData = _tileData;

        EventManager.AddListener(EventType.ON_TICK, OnTick);
    }

    public void OnTick()
    {
        GrowRandomizer();
        TileUpdate();
    }

    public void TileUpdate()
    {
        if (!TileData.RequiresUpdate) { return; }

        TileData.RequiresUpdate = false;

       
    }

    private void GrowRandomizer()
    {
        if (!TileData.IsSeeded || TileData.IsHarvestable) { return; }

        if (Random.Range(0, TileData.asscoiatedCrop.GrowthChancePerTick) == 0)
        {
            TileData.RequiresUpdate = true;
            TileData.CurrentGrowthStage++;

            foreach (Transform child in TileData.TileGameObject.transform) { Object.Destroy(child.gameObject); }
            Object.Instantiate(TileData.asscoiatedCrop.cropPrefabs[TileData.CurrentGrowthStage], TileData.TileGameObject.transform);

            if (TileData.CurrentGrowthStage == TileData.asscoiatedCrop.cropPrefabs.Length - 1)
            {
                TileData.IsHarvestable = true;
            }
        }
    }
}

