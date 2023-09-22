using UnityEngine;

[System.Serializable]
public class Model
{
    public Mesh mesh;
    public Material[] materials;
    public Vector3 scale;

    public Model(Mesh _mesh, Material[] _materials, Vector3 _scale)
    {
        mesh = _mesh;
        materials = _materials;
        scale = _scale;
    }
}

