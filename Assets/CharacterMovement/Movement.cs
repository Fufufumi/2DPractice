using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("移动设置")]
    public float moveSpeed = 5f; // 角色移动速度，可以在Unity编辑器中调整 
    public float jumpSpeed = 10f;
    private Rigidbody2D rb; // 用于存储Rigidbody2D组件的引用
    
    void Start()
    {
        // 获取角色上的Rigidbody2D组件
        rb = GetComponent<Rigidbody2D>();
        // 如果角色没有Rigidbody2D，会自动添加一个（可选，但建议手动添加）
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D组件缺失！请为角色添加Rigidbody2D。");
        }
    }

    void Jump()
    {
        rb.linearVelocityY = jumpSpeed;
    }
    
    void CheckJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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