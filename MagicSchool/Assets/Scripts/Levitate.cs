using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class Levitate : MonoBehaviour, ICastable
{
    // [SerializeField] private SpriteRenderer sr;
    // [SerializeField] private Sprite sprite;

    public bool isLevitating = false;

    public Color magicColor { get; } = Color.blue; 

    void Start()
    {
    }

    public void ToggleMagic(Vector2 position)
    {
        isLevitating = !isLevitating;
        if (isLevitating)
        {
            gameObject.tag = "pushables";
        }
        else
        {
            gameObject.tag = "immovables";
        }
    }

}
