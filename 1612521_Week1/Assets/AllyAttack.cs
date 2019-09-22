using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAttack : MonoBehaviour
{
    Animator anim;
    Vector2 pos;
    int attackHash = Animator.StringToHash("Attack");
    public float speed = 0.1f;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        pos = transform.position;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(attackHash);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (pos.x > -screenBounds.x)
            {
                pos.x -= speed;
            }
            transform.position = pos;
            GetComponent<SpriteRenderer>().flipX = true;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (pos.x < screenBounds.x)
            {
                pos.x += speed;
            }
            transform.position = pos;
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
