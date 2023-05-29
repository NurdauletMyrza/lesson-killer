using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingController : MonoBehaviour
{
    public bool isFacingRight = true;
    private Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFacingRight && transform.position.x > oldPosition.x || isFacingRight && transform.position.x < oldPosition.x)
        {
            isFacingRight = !isFacingRight;
            
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
        oldPosition =transform.position;
    }
}
