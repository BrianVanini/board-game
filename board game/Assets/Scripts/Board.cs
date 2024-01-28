using UnityEngine;

public class Board : MonoBehaviour{
    [Header("Art")]
    [SerializeField] private Material tileMaterial;
    [SerializeField] private float tileSize = 1.0f;
    [SerializeField] private float yOffSet = 0.2f;

    // Logic
    private const int TILE_COUNT_X = 15;
    private const int TILE_COUNT_Y = 15;
    private GameObject[,] tiles;
    private Camera currentCamera;
    private Vector2Int currentHover;

    private void Awake(){
        GenerateGrid(tileSize, TILE_COUNT_X, TILE_COUNT_Y);
    }

    private void Update(){
        if (!currentCamera){
            currentCamera = Camera.main;
            return;
        }

        RaycastHit info;
        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out info, 100, LayerMask.GetMask("Tile"))){
            // Get index at tile hit
            Vector2Int hitPos = LookupTileIndex(info.transform.gameObject);

            // If hovering tile after not hovering
            if(currentHover == -Vector2Int.one){
                currentHover = hitPos;
                currentHover = hitPos;
                tiles[hitPos.x, hitPos.y].layer = LayerMask.NameToLayer("Hover");
            }
            
            // If already hovering a tile, change tile
            if(currentHover != hitPos){
                tiles[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Tile");
                currentHover = hitPos;
                tiles[hitPos.x, hitPos.y].layer = LayerMask.NameToLayer("Hover");
            }
        }
        else{
            if(currentHover != -Vector2Int.one){
                tiles[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Tile");
                currentHover = -Vector2Int.one;
            }
        }
    }

    // Generate board
    private void GenerateGrid(float tileSize, int tileCountX, int tileCountY){
        yOffSet += transform.position.y;
        bounds = new Vector3(tileCountX/2 * tileSize, 0, tileCountX/2 * tileSize + boardCenter = 0;)
        tiles = new GameObject[tileCountX, tileCountY];
        for (int x = 0; x < tileCountX; x++)
        {
            for (int y = 0; y < tileCountY; y++)
            {
                tiles[x, y] = GenerateTile(tileSize, x, y);
            }
        }
    }

    private GameObject GenerateTile(float tileSize, int x, int y){
        GameObject tileObject = new GameObject(string.Format("X:{0}, Y:{1}", x, y));
        tileObject.transform.parent = transform;

        Mesh mesh = new Mesh();
        tileObject.AddComponent<MeshFilter>().mesh = mesh;
        tileObject.AddComponent<MeshRenderer>().material = tileMaterial;

        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(x * tileSize, yOffSet, y * tileSize) - bounds;
        vertices[1] = new Vector3(x * tileSize, yOffSet, (y + 1) * tileSize) - bounds;
        vertices[2] = new Vector3((x + 1) * tileSize, yOffSet, y * tileSize) - bounds;
        vertices[3] = new Vector3((x + 1) * tileSize, yOffSet, (y + 1) * tileSize) - bounds;

        int[] tris = new int[] { 0, 1, 2, 1, 3, 2 };

        mesh.vertices = vertices;
        mesh.triangles = tris;
        mesh.RecalculateNormals();

        tileObject.layer = LayerMask.NameToLayer("Tile");
        tileObject.AddComponent<BoxCollider>();

        return tileObject;
    }

    // Helper functions
    private Vector2Int LookupTileIndex(GameObject hitInfo){
        for (int x = 0; x < TILE_COUNT_X; x++){
            for (int y = 0; y < TILE_COUNT_Y; y++){
                if(tiles[x, y] == hitInfo){
                    return new Vector2Int(x, y);
                }
            }
        }
        return -Vector2Int.one; //Invalid
    }
}