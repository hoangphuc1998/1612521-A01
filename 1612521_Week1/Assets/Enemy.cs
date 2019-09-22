using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector2 pos;
    Animator anim;
    int attackHash = Animator.StringToHash("Attack");
    System.Random rand = new System.Random();
    int cnt = 0;
    public int frames = 50;
    public float speed = 0.1f;
    public int moveFrames = 20;
    int movecnt = 0;
    bool left = true;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        anim = GetComponent<Animator>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        movecnt++;
        if (left)
        {
            if (pos.x > 0)
            {
                pos.x -= speed;
            }
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            if (pos.x < screenBounds.x)
            {
                pos.x += speed;
            }
            GetComponent<SpriteRenderer>().flipX = true;
        }
        transform.position = pos;
        if (movecnt > moveFrames)
        {
            movecnt = 0;
            int r = rand.Next(0, 2);
            if(r == 0)
            {
                left = false;
            }
            else
            {
                left = true;
            }
        }
        
        cnt++;
        if (cnt > frames)
        {
            anim.SetTrigger(attackHash);
            cnt = 0;
        }
    }
}
