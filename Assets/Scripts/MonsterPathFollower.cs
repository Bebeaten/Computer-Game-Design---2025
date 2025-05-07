using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPathFollower : MonoBehaviour
{
    public WaypointPath path;
    public float speed = 3f;
    public float reachThreshold = 0.2f;
    public bool loop = false; // Important: set default to false

    private int currentIndex = 0;

    void Update()
    {
        if (path == null || path.waypoints.Length == 0) return;

        Transform target = path.waypoints[currentIndex];
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < reachThreshold)
        {
            currentIndex++;

            if (currentIndex >= path.waypoints.Length)
            {
                if (loop)
                {
                    currentIndex = 0; // Start again
                }
                else
                {
                    Destroy(gameObject); // 💥 DESTROY MONSTER
                }
            }
        }
    }
}
