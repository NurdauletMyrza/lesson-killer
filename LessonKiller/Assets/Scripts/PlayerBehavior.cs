using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private float horizontal;
    public float speed = 1f;
    // private float jumpingPower = 16f;
    private int levelLocation = 3;
    public CollidersController collidersController;

    [SerializeField] private Rigidbody2D rb;

    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Press \"F\" to stand on the stairs or leave the stairs");
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        

        if (Input.GetKeyDown(KeyCode.F))
        {
            switch (collider.gameObject.tag)
            {
                case "LowerTrigger2":
                levelLocation = (levelLocation == 3) ? 2 : 3;
                collidersController.ChangeLevelLocation(levelLocation);
                break;
    
                default:
                break;
            }
        }
    }
}
