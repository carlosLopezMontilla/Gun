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
}

/*{
    float v,h;
    public string hDirec = "Horizontal", vDirec = "Vertical";
    public Rigidbody2D rb;
    public Animator _anim;
    public bool isWalking;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isWalking = false;
    }

    void Update()
    {
        isWalking = false;

        if (Mathf.Abs(Input.GetAxisRaw(hDirec)) > 0.2)
        {
            h = Input.GetAxisRaw(hDirec);
            isWalking = true;
        }
        if (Mathf.Abs(Input.GetAxisRaw(vDirec)) > 0.2)
        {
            v = Input.GetAxisRaw(vDirec);
            isWalking = true;
        }
      

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(h, v);
        if (isWalking == false)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void LateUpdate()
    {
        _anim.SetFloat("Horizontal", h);
        _anim.SetFloat("Vertical", v);
        _anim.SetBool("Walking", isWalking);
    }
}*/
