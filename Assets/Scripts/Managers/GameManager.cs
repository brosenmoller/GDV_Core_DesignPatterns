using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Farm")]
    [SerializeField] private Crop[] availableCrops;
    [SerializeField] private GroundType[] availableGroundTypes;

    [Header("Constructing Farm")]
    [SerializeField] private int farmHeight;
    [SerializeField] private int farmWidth;
    [SerializeField] private Transform tileParent;

    [HideInInspector] public List<TileObject> land;
    private InputManager inputHandler;
    private TileObjectFactory tileObjectFactory;

    private void Awake()
    {
        Instance = this;

        inputHandler = new InputManager();
        tileObjectFactory = new TileObjectFactory(tileParent);

        SetupLand();
    }

    private void Update()
    {
        inputHandler.HandleInput();
    }

    private void FixedUpdate()
    {
        EventManager.InvokeEvent(EventType.ON_TICK);
    }

    private void SetupLand()
    {
        land = new List<TileObject>();

        for (int x = 0; x < farmWidth; x++)
        {
            for (int y = 0; y < farmHeight; y++)
            {
                land.Add(tileObjectFactory.CreateTileObject(new Vector3(x, 0, y), availableGroundTypes[0]));
            }
        }
    }
}
