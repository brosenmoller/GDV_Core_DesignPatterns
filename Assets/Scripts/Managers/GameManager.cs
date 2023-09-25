using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Farm")]
    public Crop[] availableCrops;
    public GroundType[] availableGroundTypes;

    [Header("Constructing Farm")]
    [SerializeField] private int farmHeight;
    [SerializeField] private int farmWidth;
    [SerializeField] private Transform tileParent;
    [SerializeField] private Material hoverMaterial;

    [HideInInspector] public List<TileObject> land;

    private InputManager inputHandler;
    private TileObjectFactory tileObjectFactory;
    private SelectionManager selectionManager;

    public TileCommandType currentCommandType;

    public void SetCommandType(int commandType)
    {
        currentCommandType = (TileCommandType)commandType;
    }

    private void Awake()
    {
        Instance = this;
        inputHandler = new InputManager();
        tileObjectFactory = new TileObjectFactory(tileParent);
        selectionManager = new SelectionManager(hoverMaterial);

        EventManager.AddListener(EventType.ON_TICK, selectionManager.OnTick);
        EventManager.AddListener(EventType.ON_MOUSE_DOWN, selectionManager.OnSelect);

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
