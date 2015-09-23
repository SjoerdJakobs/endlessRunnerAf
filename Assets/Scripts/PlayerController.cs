using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    private bool _grounded;
    private Transform _groundCheck;
    float groundRadius = 0.2f;
    public LayerMask WhatIsGround;
    public float jumpforce = 750;
    private bool _Djump = false;

    public AudioClip jumpSound;
    private AudioSource audioOn;

    Rigidbody2D rgd;

    private int health = 5;

    void Start()
    {
        _groundCheck = transform.Find("GroundCheck");
        anim = GetComponent<Animator>();
        rgd = GetComponent<Rigidbody2D>();

        audioOn = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        _grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, groundRadius, WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                _grounded = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * 5f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.right * -5f * Time.deltaTime);
        }
        anim.SetBool("Ground", _grounded);

        anim.SetFloat("vSpeed", rgd.velocity.y);
        if (_grounded)
            _Djump = false;

    }
    void Update()
    {

        if ((_grounded || !_Djump) && Input.GetKeyDown(KeyCode.Space))
        {
            Jump(1, true);
            audioOn.PlayOneShot(jumpSound, 1f);
        }
    }

    void Jump(int type, bool jump)
    {
        anim.SetBool("Ground", false);

        rgd.velocity = new Vector2(rgd.velocity.x, 0);

        if (type == 1) rgd.AddForce(new Vector2(0, 1000));
        else if (type == 2) rgd.AddForce(new Vector2(0, -600));
        else if (type == 3) rgd.AddForce(new Vector2(-0, 1000));

        if (jump && !_grounded)
            _Djump = true;
    }

    public int setHealth
    {
        get { return health; }
        set { health = value; }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemyS+")
        {
            Jump(1, false);
        }
        if (other.tag == "enemyS-")
        {
            Jump(2, false);
        }
        else if (other.tag == "enemyM")
        {
            print("hi");
            Jump(3, false);
        }
    }
}
/*using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    private bool _grounded;
    private Transform _groundCheck;
    float groundRadius = 0.2f;
    public LayerMask WhatIsGround;
    public float jumpforce = 750;
    private bool _Djump = false;
    Rigidbody2D rgd;

    private int health = 5;

    void Start()
    {
        _groundCheck = transform.Find("GroundCheck");
        anim = GetComponent<Animator>();
        rgd = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, groundRadius, WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                _grounded = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * 4f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.right * -4f * Time.deltaTime);
        }
        anim.SetBool("Ground", _grounded);

        anim.SetFloat("vSpeed", rgd.velocity.y);
        if (_grounded)
            _Djump = false;

    }
    void Update()
    {

        if ((_grounded || !_Djump) && Input.GetKeyDown(KeyCode.Space))
        {
            Jump(1);
        }
    }

    void Jump(int type)
    {
        anim.SetBool("Ground", false);

        rgd.velocity = new Vector2(rgd.velocity.x, 0);

        if (type == 1) rgd.AddForce(new Vector2(0, 1000));
        else if (type == 2) rgd.AddForce(new Vector2(0, -600));
        else if (type == 3) rgd.AddForce(new Vector2(-0, 1000));

        if (!_grounded)
            _Djump = true;
    }

    public int setHealth
    {
        get { return health; }
        set { health = value; }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemyS+")
        {
            Jump(1);
        }
        if (other.tag == "enemyS-")
        {
            Jump(2);
        }
        else if (other.tag == "enemyM")
        {
            Jump(3);
        }
    }
}*/