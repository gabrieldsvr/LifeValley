using System.Collections;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField] Item pickUpDrop;
    [SerializeField] private int dropCount = 5;
    [SerializeField] private float spread = 1f;
    [SerializeField] public float dropForce = 0.01f;

    public bool setDestroy = false;

    public override void Hit()
    {
        StartCoroutine(FarmTree());
    }
    
   
    IEnumerator FarmTree(){
        yield return new WaitForSeconds(1); 
        while (dropCount > 0)
        {
            dropCount--;

            Vector3 position = transform.position;
            position.x += spread * Random.value - spread / 2;
            position.y += spread * Random.value - spread / 2;
            
            // Item item = GameManager.instace.ItemManager.GetItemByName("TreeLogs");
            Item go = Instantiate(pickUpDrop, position, Quaternion.identity);
            go.transform.position = position;
            go.rb2d.AddForce(position * dropForce, ForceMode2D.Impulse);
        }
        Destroy(gameObject);
    }
   
}