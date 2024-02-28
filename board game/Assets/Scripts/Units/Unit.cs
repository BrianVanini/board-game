using UnityEngine;

public class Unit : MonoBehaviour
{
    // Position
    public int currentX;
    public int currentY;

    // Stats from DB
    public int heath;
    public int damage;
    public int attackSpeed;
    public Trait[] traits;

    // Team 
    public bool isAlly;
    public Material allyOutline;
    public Material enemyOutline;

    // Draggable variables
    private bool isDragging = false;
    private Vector3 offset;

    void Start()
    {
        UpdateOutlineMaterial();
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }

    // Mouse event handlers for dragging
    private void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseUp()
    {
        isDragging = false;
        SnapToGrid();
    }

    // Snap the unit to the grid
    private void SnapToGrid()
    {
        // Calculate the grid position based on the unit's position
        Vector3Int gridPosition = new Vector3Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));

        // Snap the unit to the center of the grid square
        transform.position = gridPosition + Vector3.one * 0.5f;
    }

    // Update the outline material based on the team
    private void UpdateOutlineMaterial()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            if (isAlly)
            {
                renderer.material = allyOutline;
            }
            else
            {
                renderer.material = enemyOutline;
            }
        }
    }

    // Get the mouse position in world coordinates
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
