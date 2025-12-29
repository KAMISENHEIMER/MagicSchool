using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class Levitate : MonoBehaviour, ICastable
{
    private SpriteRenderer sr;
    private Transform spriteTransform;
    // [SerializeField] private Sprite sprite;

    public bool isLevitating = false;

    public Color magicColor { get; } = Color.blue;

    public float bobSpeed = 2f;
    public float bobHeight = 0.2f;
    private float startY;

    public GameObject shadowPrefab; 
    public float shadowOffsetY = -0.3f; 

    private GameObject currentShadowInstance;

    private float startTime;

    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        spriteTransform = sr.transform;

        startY = sr.transform.localPosition.y;

        if (sr.gameObject == this.gameObject)
        {
            SetupSpriteChild();
        }

        startY = spriteTransform.localPosition.y;
    }

    //move the sprite renderer into a child object
    private void SetupSpriteChild()
    {
        GameObject visualChild = new GameObject(gameObject.name + "_Sprite");
        visualChild.transform.SetParent(this.transform);
        visualChild.transform.localPosition = Vector3.zero;

        SpriteRenderer childSr = visualChild.AddComponent<SpriteRenderer>();
        childSr.sprite = sr.sprite;
        childSr.sortingOrder = sr.sortingOrder;

        spriteTransform = visualChild.transform;

        sr.enabled = false;
    }

    void Update()
    {
        if (isLevitating)
        {
            //calculate the height offset
            float newY = startY + Mathf.Sin((Time.time - startTime) * bobSpeed) * bobHeight + 0.3f;
            //TODO SMOOTH UP START AND STOP

            //apply to just the local Y axis
            spriteTransform.localPosition = new Vector3(
                spriteTransform.localPosition.x,
                newY,
                spriteTransform.localPosition.z
            );
        }
    }

    public void ToggleMagic(Vector2 position)
    {
        isLevitating = !isLevitating;
        if (isLevitating)
        {
            gameObject.tag = "pushables";

            //create shadow 
            currentShadowInstance = Instantiate(shadowPrefab);
            currentShadowInstance.transform.SetParent(this.transform, false);
            currentShadowInstance.transform.localPosition = new Vector3(0f, shadowOffsetY, 0f);
        
            startTime = Time.time;
        }
        else
        {
            gameObject.tag = "immovables";

            // reset position when levitation stops
            spriteTransform.localPosition = new Vector3(
                spriteTransform.localPosition.x,
                0f,
                spriteTransform.localPosition.z
            );

            //delete shadow
            Destroy(currentShadowInstance);
            currentShadowInstance = null;
        }
    }

}
