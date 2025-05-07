using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject arrowPrefab;
    public float fireRate = 1.0f;
    public float arrowSpeed = 10f;
    public string monsterTag = "Monster";

    private float fireCooldown = 0f;
	
	// Update is called once per frame
    void Update()
    {
        fireCooldown -= Time.deltaTime;

        GameObject target = FindFirstMonster();
        if (target != null && fireCooldown <= 0f)
        {
            ShootArrow(target);
            fireCooldown = fireRate;
        }
    }

    GameObject FindFirstMonster()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag(monsterTag);
        if (monsters.Length == 0) return null;

        return monsters[0]; // Optional: sort by distance or spawn time if needed
    }

    void ShootArrow(GameObject target)
    {
        if (arrowPrefab == null) return;

        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        Arrow arrowScript = arrow.GetComponent<Arrow>();
        if (arrowScript != null)
        {
            arrowScript.SetTarget(target, arrowSpeed);
        }
    }
}
