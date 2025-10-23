using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("移动设置")]
    public float moveSpeed = 5f; // 角色移动速度，可以在Unity编辑器中调整 
    public float jumpSpeed = 10f;
    public float groundCheckDistance = 0.9f;
    public LayerMask groundLayer;
        
    private Collider2D playerCollider;
    private bool isGrounded;
    
    private Rigidbody2D rb; // 用于存储Rigidbody2D组件的引用
    
    void Start()
    {
        // 获取角色上的Rigidbody2D组件
        rb = GetComponent<Rigidbody2D>();
        playerCollider=GetComponent<Collider2D>();
        // 如果角色没有Rigidbody2D，会自动添加一个（可选，但建议手动添加）
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D组件缺失！请为角色添加Rigidbody2D。");
        }
        if (groundLayer == 0)
        {
            groundLayer = Physics2D.AllLayers;
            Debug.LogWarning("未设置地面层级，将使用所有层级进行地面检测。");
        }
    }

    void Jump()
    {
        rb.linearVelocityY = jumpSpeed;
    }
    
    bool CheckGrounded()
    {
        // 方法1：使用射线检测（简单有效）
        Vector2 rayOrigin = transform.position;
        // 稍微向下偏移射线起点，确保从角色底部发射
        rayOrigin.y -= playerCollider.bounds.extents.y;
        
        // 向下发射射线检测地面
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, groundCheckDistance, groundLayer);
        
        // 可视化射线（仅在编辑器中可见）
        Debug.DrawRay(rayOrigin, Vector2.down * groundCheckDistance, Color.red);
        
        // 如果射线碰到了地面物体，则角色在地面上
        isGrounded = (hit.collider != null);
        return isGrounded;
        
    }
    void CheckJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&CheckGrounded())
        {
            Jump();
        }
    }

    void Update()
    {
        CheckJumpInput();
    }
    void FixedUpdate()
    {
        // 获取水平输入（A/D键或左/右箭头键），范围从-1（左）到1（右）
        float HmoveInput = Input.GetAxis("Horizontal"); 
        
        // 设置角色的水平速度，保持垂直速度不变（例如重力影响）
        rb.linearVelocityX= HmoveInput * moveSpeed;
        
    }
}