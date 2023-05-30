using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 3f;
    // private float jumpingPower = 16f;
    private int levelLocation = 3;
    private bool verticalOn = false;
    public CollidersController collidersController;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;

    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical") / 2;
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, (verticalOn) ? vertical * speed : rb.velocity.y);
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
                case "LowerTrigger1":
                levelLocation = (levelLocation == 1) ? 2 : 1;
                collidersController.ChangeLevelLocation(levelLocation);
                UpdateLayerOrder();
                break;
                
                case "LowerTrigger2":
                levelLocation = (levelLocation == 3) ? 2 : 3;
                collidersController.ChangeLevelLocation(levelLocation);
                UpdateLayerOrder();
                break;

                case "UpperTrigger1":
                if (levelLocation == 3)
                {
                    levelLocation = 4;
                    verticalOn = true;
                    rb.gravityScale = 0;
                    collidersController.ChangeLevelLocation(levelLocation);
                }
                else if (levelLocation == 4)
                {
                    levelLocation = 3;
                    verticalOn = false;
                    rb.gravityScale = 10;
                    collidersController.ChangeLevelLocation(levelLocation);
                }
                break;

                case "UpperTrigger2":
                if (levelLocation == 5)
                {
                    levelLocation = 4;
                    verticalOn = true;
                    rb.gravityScale = 0;
                    collidersController.ChangeLevelLocation(levelLocation);
                }
                else if (levelLocation == 4)
                {
                    levelLocation = 5;
                    collidersController.ChangeLevelLocation(levelLocation);
                    verticalOn = false;
                    rb.gravityScale = 10;
                }
                break;
    
                default:
                break;
            }
        }
    }

    private void UpdateLayerOrder()
    {
        switch (levelLocation)
        {
            case 1:
            spriteRenderer.sortingOrder = 31;
            break;

            case 2:
            spriteRenderer.sortingOrder = 11;
            break;

            case 3:
            spriteRenderer.sortingOrder = -9;
            break;

            default:
            break;
        }
    } 
}
