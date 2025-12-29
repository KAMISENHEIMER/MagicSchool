using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class Enlarge : MonoBehaviour, ICastable
{
    // [SerializeField] private SpriteRenderer sr;
    // [SerializeField] private Sprite sprite;

    public bool isLarge = false;
    public float scale;

    public Color magicColor { get; } = Color.red; 

    void Start()
    {
        //makes sure it starts at the correct size
        if (isLarge)
        {
            gameObject.tag = "immovables";
            transform.localScale = new Vector3(scale, scale, 1f);
        }
        else
        {
            gameObject.tag = "pushables";
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        // sr = gameObject.GetComponent<SpriteRenderer>();
    }

    public void ToggleMagic(Vector2 position)
    {
        isLarge = !isLarge;
        if (isLarge)
        {
            gameObject.tag = "immovables";
            transform.localScale = new Vector3(3f, 3f, 1f);
        }
        else
        {
            gameObject.tag = "pushables";
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

}
