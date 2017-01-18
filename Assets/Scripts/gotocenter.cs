using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotocenter : MonoBehaviour
{

    public Rigidbody rigid;
    public float speed;
    public bool heavy = false;
    private Vector3 target;

    void Start()
    {
        speed = 10.0f;
        target = Vector3.zero;
        rigid.mass = Random.Range(1.0f, 3.0f);
        if(Random.Range(0,50)<1 && Time.timeSinceLevelLoad > 10.0f)
        {
            heavy = true;
            rigid.mass += 100.0f;
            transform.localScale = Vector3.one * 3.0f;
            speed = 100.0f;
            target = Random.onUnitSphere * 4.0f;
            transform.position = -target.normalized * Random.Range(20, 50);
        }
    }

    void Update()
    {
        // Slowdown if space held
        if(Input.GetKey(KeyCode.Space))
        {
            if(!heavy)
            {
                rigid.velocity = rigid.velocity * 0.95f;
                return;
            }
        }

        // Normal movement
        rigid.AddForce((target - transform.position) * speed);
        if(heavy && (target-transform.position).magnitude < 5.0f)
        {
            Destroy(gameObject, 2.0f);
        }
    }
}
