using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public float currentWeight = 3;

    private bool isSurrounded = false;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        //DetectObjectInRange();
    }

    // Update is called once per frame
    void Update()
    {
        //DropItDown();
        //print(isSurrounded);
        //print(targetPosition);
        //DetectObjectInRange();
        //DetectSurrounding();
        //MoveItDown();
    }

    void FixedUpdate()
    {
        //MoveItDown();
        DetectObjectInRange();
    }

    private void SetWeight(float weight)
    {
        currentWeight = weight;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collider collision detected");
        GameObject obj = collision.gameObject;
        Debug.Log("Collision with "+obj);

        if (obj.GetComponent<Attacker_TypeA>())
        {
            Debug.Log("it works like heck");
        }
        else
        {
            Debug.Log("it works like dang");
            currentWeight = 0;
            rigidbody2D.gravityScale = 0; //didn't effect anything
            rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            boxCollider2D.isTrigger = true;
        }
    }*/

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision detected");
        GameObject obj = collision.gameObject;
        Debug.Log(obj);

        if (obj.GetComponent<Block>())
        {
            Debug.Log("it is the block");
        }
        else
        {
            Debug.Log("Something else");
        }
    }*/

    void DetectObjectInRange()
    {
        //Debug.Log((transform.position.y) + " " + (transform.position.y-1));
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y - 1, 0);

        //Debug.Log("object " + transform.position);
        RaycastHit2D hit = Physics2D.Raycast(newPos, Vector2.down, 1000f, LayerMask.GetMask("Defender_obj"));
        //Debug.Log("raycast " + hit.transform.position);
        if (hit.collider != null)
        {
            isSurrounded = true;

            //Debug.Log("i hit " + hit.collider.gameObject + " and its position = " + hit.collider.gameObject.transform.position);
            float speed = currentWeight * Time.deltaTime;
            Vector3 targetPos = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y + 1, 0);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);
            targetPosition = targetPos;
        }
        else {
            isSurrounded = false;
        }
    }

    void MoveItDown()
    {
        float speed = currentWeight * Time.deltaTime;
        if (isSurrounded)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed);
        }
    }

    /*void DetectSurrounding()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = Vector3.down;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                Debug.Log("i hit " + hit.collider.gameObject);
            }
        }
    }*/

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //Debug.Log("No more collision");
    //rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    //}

}
