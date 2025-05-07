using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private GameObject target;
    private float speed;
    public int damage = 1;

    public void SetTarget(GameObject t, float s)
    {
        target = t;
        speed = s;
    }
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = (target.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.transform.position) < 0.2f)
        {
            MonsterHealth mh = target.GetComponent<MonsterHealth>();
            if (mh != null)
            {
                mh.TakeDamage(damage);
            }

            Destroy(gameObject); // Destroy arrow regardless
        }
    }
}
