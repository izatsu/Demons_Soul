using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    //move
    private Joystick joystick;
    private Rigidbody2D rb;
    public Vector2 direction;
    [SerializeField] private float speed = 3;

    Animator ani;

    //dash
    Button dash_button;
    private bool canDash = true;
    private bool isDashing;
    [SerializeField] float DashingPower = 10f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    //Check player isLive
    PlayerHealth pl_h;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<FixedJoystick>().GetComponent<FixedJoystick>();
        ani = GetComponent<Animator>();
        pl_h = GetComponent<PlayerHealth>();

        dash_button = GameObject.Find("DashButton").GetComponent<Button>();
        dash_button.onClick.AddListener(DashButton);
    }

    void Update()
    {
        /*direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");*/

        direction.x = joystick.Direction.x;
        direction.y = joystick.Direction.y;


        ani.SetFloat("Horizontal", direction.x);
        ani.SetFloat("Vertical", direction.y);
        ani.SetFloat("Speed", direction.sqrMagnitude);

        /*if (Input.GetKey(KeyCode.LeftShift) && canDash && !pl_h.isDie)
        {
            StartCoroutine(Dash());
        }*/

        if (pl_h.isDie)
            rb.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        if(!pl_h.isDie)
            rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    private void DashButton()
    {
        if (canDash && !pl_h.isDie)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(direction.x * DashingPower, direction.y * DashingPower);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}
