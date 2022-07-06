using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortalCulling : MonoBehaviour
{
    private Room[] rooms;
    private Room lastClosest;

    private float speed = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        rooms = FindObjectsOfType<Room>();
        lastClosest = rooms[0];
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRoomsRender();
        Movement();
    }


    private void UpdateRoomsRender()
    {
        float minDistance = Mathf.Infinity;
        Room closest = null;

        foreach (Room room in rooms)
        {
            if (Vector3.Distance(transform.position, room.transform.position) > minDistance)
                continue;

            minDistance = Vector3.Distance(transform.position, room.transform.position);
            closest = room;
            //Debug.Log("minDistance: " + minDistance);
        }
       
        if (Equals(lastClosest,closest))
            return;

        lastClosest.SetAllRender(false);
        lastClosest = closest;
        lastClosest.SetAllRender(true);
        
    }


    private void Movement()
    {
        float x = 0, z = 0;

        x = Input.GetAxisRaw("Vertical");
        z = Input.GetAxisRaw("Horizontal");

        x *= speed;
        z *= speed;

        //if(Input.GetKey(KeyCode.W))
        //{
        //    x += speed;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    x -= speed;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    z += speed;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    z -= speed;
        //}

        transform.position += new Vector3(x, 0, z);
    }
}
