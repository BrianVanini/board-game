using UnityEngine;

public class Unit : MonoBehaviour
{
    // Position
    public int startX;
    public int startY;
    public int currentX;
    public int currentY;

    // Stats
    public int maxHealth;
    public int currentHealth;
    public float damage;
    public float attackSpeed;

    public float moveSpeed;
    public float resistance;
    public int shield;
    public Trait[] traits;

    // Abilities


    // Team 
    public bool isAlly;
    public Material AllyOutline;
    public Material EnemyOutline;

    public Material SelectedAllyOutline;

    public Material SelectedEnemyOutline;
    // Draggable variables
    private bool isDragging = false;
    private Vector3 offset;
    private float mouseZCoord;
    void Start(){
        UpdateOutlineMaterial();
    }

    void Update(){
        if (isDragging){
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }

    // Mouse event handlers for dragging
    private void OnMouseDown(){
        isDragging = true;
        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag(){
        transform.position = GetMouseWorldPosition() + offset;
    }
    

    private void OnMouseUp(){
        isDragging = false;
        SnapToGrid();
    }

    // Snap the unit to the grid
    private void SnapToGrid(){
        // Calculate the grid position based on the unit's position
        Vector3Int gridPosition = new Vector3Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));

        // Snap the unit to the center of the grid square
        transform.position = gridPosition + Vector3.one * 0.5f;
    }

    // Get the mouse position in world coordinates
    private Vector3 GetMouseWorldPosition(){
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mouseZCoord;

        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    // Update the outline material based on the team
    private void UpdateOutlineMaterial(){
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            if (isAlly)
            {
                renderer.material = AllyOutline;
            }
            else
            {
                renderer.material = EnemyOutline;
            }
        }
    }
}
