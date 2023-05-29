﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersController : MonoBehaviour
{
    public GameObject player;
    public Collider2D floorCollider2;
    public Collider2D floorCollider3;
    private GameObject[] lowerStaircaseColliders;
    private int levelLocation = 3;

    // Start is called before the first frame update
    void Start()
    {
        lowerStaircaseColliders = GameObject.FindGameObjectsWithTag("LowerStaircaseCollider");
        // switch (levelLocation)
        // {
        //     case 3:
        //         transform.position = new Vector3(0f, 0f, 0f);
        //         floorCollider3.enabled = false;
        //         break;
        //     default:
        //         transform.position = new Vector3(0f, 4f, 0f);
        //         levelLocation = 6;
        //         break;
        // }
        // if (transform.position.y < 1.5f)
        // {
        //     levelLocation = 3;
        // }
        // else if (transform.position.y < -0.4f)
        // {
        //     levelLocation = 1
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLevelLocation(int newLevel)
    {
        levelLocation = newLevel;
        switch (levelLocation)
        {
            case 1:
            floorCollider2.enabled = false;
            floorCollider3.enabled = false;
            StaircaseCollidersEnabled(false);
            break;

            case 2:
            floorCollider2.enabled = false;
            floorCollider3.enabled = false;
            StaircaseCollidersEnabled(true);
            break;
            
            case 3:
            floorCollider2.enabled = true;
            floorCollider3.enabled = false;
            StaircaseCollidersEnabled(false);
            break;

            default:
            break;
        }
    }

    private void StaircaseCollidersEnabled(bool b)
    {
        Debug.Log("Run");
        foreach (GameObject s in lowerStaircaseColliders)
        {
            s.GetComponent<EdgeCollider2D>().enabled = b;
        }
    }
}
