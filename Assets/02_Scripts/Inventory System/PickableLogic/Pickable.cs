using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pickable : MonoBehaviour
{
    [SerializeField] private InventoryItem itemToPick;
    [SerializeField] private SpriteRenderer itemSprite;
    Transform player;
    bool close;

    private void Awake()
    {
        //Since I'm using different assets, every icon has a different size (Need to adjust size of each pickable)
        //itemSprite.sprite = itemToPick.itemIcon;
    }
    private void Update()
    {
        if(close)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            transform.position = Vector2.Lerp(transform.position, player.position, Time.deltaTime);
            if(distance < 0.2f)
            {
                FindObjectOfType<InventoryManager>().GetItem(itemToPick);
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //make cool lerp effect ?
        player = collision.transform;
        close = true;
        

        
    }
}
