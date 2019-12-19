using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTurret1AI : MonoBehaviour
{
    public Transform player;
    public float shotDelay;
    public float currShotDelay;
    public GameObject projectile;
    public Transform gun;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        currShotDelay = shotDelay;
    }

    void Update()
    {
        currShotDelay -= Time.deltaTime;
        if(currShotDelay <= 0)
        {
            Instantiate(projectile, gun.position, gun.rotation);
            currShotDelay = shotDelay;
        }
    }
}
