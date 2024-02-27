using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public GameObject brickPrefab;
    public float brickSpacing = 1f;
    public static  int level = 9;
    public List<Sprite> bricks;

    void Start()
    {
        level = 9;
        gameObject.GetComponent<SpriteRenderer>().sprite = bricks[Random.Range(0, 4)];

    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Bricks").Length == 1)
        {
            level += 1;
            for (int i = 0; i < level; i++)
            {
                Vector2 pos = Vector2.zero;
                bool valid = false;
                while (!valid)
                {
                    pos = new Vector2(Random.Range(-7.6f, 7.6f), Random.Range(-4.5f, 14.3f));
                    Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, 0.5f);
                    if (colliders.Length == 0) valid = true;
                }
                Instantiate(brickPrefab, pos, Quaternion.identity);
            }
        }
    }
}