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
    public GameObject bulletPrefabs;
    public Transform spawnpoint;
    public float bulletForce;
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
        float h = Input.GetAxisRaw(AXIS_H);
        float v = Input.GetAxisRaw(AXIS_V);
        direction = new Vector3(h, v);
        Shooting();
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

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.zero;
            gunPivot.position = direction.normalized + transform.position;
            GameObject bullet = Instantiate(bulletPrefabs, spawnpoint.position, spawnpoint.rotation);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.AddForce(direction, ForceMode.Impulse);
            
        }
    }
}

