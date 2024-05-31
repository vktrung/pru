using UnityEngine;

public class WordScolling : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;

    Vector2Int currentTilePosition = new Vector2Int(0, 0);

    [SerializeField]
    Vector2Int playerTilePosition;

    Vector2Int onTileGridPlayerPosition;

    [SerializeField]
    float titleSize = 20f;

    GameObject[,] terrainTiles;

    [SerializeField]
    int terrainTileHorizontalCount;
    [SerializeField]
    int terrainTileVerticalCount;

    [SerializeField]
    int fieldOfVisionHeight = 3;

    [SerializeField]
    int fieldOfVisionWidth = 3;


    private void Awake()
    {
        terrainTiles = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];
    }

    private void Start()
    {
        UpdateTilesOnScreen();
    }

    public void Add(GameObject titleGameObject, Vector2Int tilePosition)
    {
        terrainTiles[tilePosition.x, tilePosition.y] = titleGameObject;
    }

    private void Update()
    {
        playerTilePosition.x = (int)(playerTransform.position.x / titleSize);
        playerTilePosition.y = (int)(playerTransform.position.y / titleSize);

        playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0;
        playerTilePosition.y -= playerTransform.position.y < 0 ? 1 : 0;

        if (currentTilePosition != playerTilePosition)
        {
            currentTilePosition = playerTilePosition;

            onTileGridPlayerPosition.x = CalculatePositionOnAxist(onTileGridPlayerPosition.x, true);
            onTileGridPlayerPosition.x = CalculatePositionOnAxist(onTileGridPlayerPosition.y, false);
            UpdateTilesOnScreen();
        }
    }

    private void UpdateTilesOnScreen()
    {
        for (int pov_x = -(fieldOfVisionWidth / 2); pov_x <= fieldOfVisionWidth / 2; pov_x++)
        {
            for (int pov_y = -(fieldOfVisionHeight / 2); pov_y <= fieldOfVisionHeight / 2; pov_y++)
            {
                int tileToUpdate_x = CalculatePositionOnAxist(playerTilePosition.x + pov_x, true);
                int tileToUpdate_y = CalculatePositionOnAxist(playerTilePosition.y + pov_y, false);

                GameObject tile = terrainTiles[tileToUpdate_x, tileToUpdate_y];
                tile.transform.position = CalculatTilePosition(
                    playerTilePosition.x + pov_x,
                    playerTilePosition.y + pov_y);
            }
        }
    }

    private Vector3 CalculatTilePosition(int x, int y)
    {
        return new Vector3(x * titleSize, y * titleSize, 0f);
    }

    private int CalculatePositionOnAxist(float currentValue, bool horizontal)
    {
        if (horizontal)
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileHorizontalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileHorizontalCount - 1 + currentValue % terrainTileHorizontalCount;
            }
        }
        else
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileVerticalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileVerticalCount - 1 + currentValue % terrainTileVerticalCount;
            }
        }

        return (int)currentValue;

    }
}