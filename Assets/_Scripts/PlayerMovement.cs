using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool walking = false;
    public Vector2 lastMovement = Vector2.zero;
    private const string AXIS_H = "Horizontal", AXIS_V = "Vertical", WALK = "Walking", LAST_H = "LastH", LAST_V = "LastV";
    private Animator anim;
    private Rigidbody2D rb;
    public Transform gunPivot;
    public Vector3 direction;
    public float h, v;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        walking = false;
        if (Mathf.Abs(Input.GetAxisRaw(AXIS_H)) > 0.2f)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw(AXIS_H), rb.velocity.y);
            walking = true;
            lastMovement = new Vector2(Input.GetAxisRaw(AXIS_H), 0);
        }
        if (Mathf.Abs(Input.GetAxisRaw(AXIS_V)) > 0.2f)
        {
            rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw(AXIS_V));
            walking = true;
            lastMovement = new Vector2(0, Input.GetAxisRaw(AXIS_V));
        }
        h = Input.GetAxisRaw(AXIS_H);
        v = Input.GetAxisRaw(AXIS_V);
        direction = new Vector2(h, v);
        GunController();
        
    }

    private void LateUpdate()
    {
        if (!walking) 
        {
            rb.velocity = Vector2.zero;
        }
        anim.SetFloat(AXIS_H, Input.GetAxisRaw(AXIS_H));
        anim.SetFloat(AXIS_V, Input.GetAxisRaw(AXIS_V));
        anim.SetBool(WALK, walking);
        anim.SetFloat(LAST_H, lastMovement.x);
        anim.SetFloat(LAST_V, lastMovement.y);

    }
    void GunController()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector3.zero;
            gunPivot.position = direction.normalized + transform.position;

        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            print("s");
        }
    }
}

