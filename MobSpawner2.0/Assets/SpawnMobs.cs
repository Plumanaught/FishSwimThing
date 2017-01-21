using UnityEngine;
using System.Collections;

public class SpawnMobs : MonoBehaviour
{

    bool b_move = false;
    bool b_isAlive = false;
    private Vector3 startMarker = new Vector3(0, 0, 100);
    private Vector3 endMarker = new Vector3(0, 0, 0);
    public float f_randX;
    public float f_randY;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!b_isAlive)
        {
            if (Random.value * 10 > 9.99)
            {
                Spawn();
            }
        }
        else
        {
            Move();
        }

    }

    /// <summary>
    /// Check if enemy is at the despawn point (3,3,3)
    /// Move enemy to the spawn zone (0, 0, 100) (maybe)
    /// set bool to move to true
    /// </summary>
    void Spawn()
    {
        b_isAlive = true;
        b_move = true;
        f_randX = (Random.value * 10);
        f_randY = (Random.value * 10);

        startMarker = new Vector3(f_randX, f_randY, 70);
        transform.position = startMarker;

    }


    /// <summary>
    /// Move to despawn point (3,3,3) and move to false
    /// </summary>
    void Despawn()
    {
        b_move = false;
        b_isAlive = false;

    }

    /// <summary>
    /// Move towards camera (0, 0, 0) per update loop
    /// </summary>
    void Move()
    {
        if (b_move)
        {
            Debug.Log(this.name + "--" + transform.position);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.2f);
        }
        if (transform.position.z < 0) Despawn();

    }
}
