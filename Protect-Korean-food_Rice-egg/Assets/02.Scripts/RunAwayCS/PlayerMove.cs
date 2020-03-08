using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float life = 3;
    Rigidbody2D rigid;
    public bool inputLeft = false;
    public bool inputRight = false;
    public bool inputUp = false;
    public bool inputDown = false;
    SpriteRenderer spriteRenderer;
    Animator animator;
    Transform _transform;
    

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life == 0)
        {
            SceneManager.LoadScene("Main");
        }
        if (inputLeft)
        {
            _transform.rotation = Quaternion.Euler(0,0,90);
        }
        else if (inputRight)
        {
            _transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (inputDown)
        {
            _transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (inputUp)
        {
            _transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (rigid.velocity.normalized.x != 0 || rigid.velocity.normalized.y != 0)
        {
            animator.SetBool("IsMove", true);
        }
    }

    void FixedUpdate()
    {
        /*float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        rigid.AddForce(Vector2.up * v, ForceMode2D.Impulse);*/

        if (inputRight)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (inputLeft)
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        }
        else if (inputUp)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, maxSpeed);

        }
        else if (inputDown)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, maxSpeed * (-1));

        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Food"))
        {
            Destroy(coll.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy") && life > 0)
        {
            life--;
        }
    }
}
