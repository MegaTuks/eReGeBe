using UnityEngine;
using System.Collections;

public class BulletKiller : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("algo choco?");
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
        }
    }
}
