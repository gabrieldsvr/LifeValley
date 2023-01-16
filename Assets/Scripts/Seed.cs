using System.Text.RegularExpressions;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Seed : MonoBehaviour
{
    [SerializeField] private CropData cropData;
    [SerializeField] private SeedData seedData;
    [HideInInspector] public  Rigidbody2D rb2d;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public static bool HasSeed(string world)
    {
        return world.ToUpper().Contains("SEED");
    }

    public static string RemoveSeedAndIdentifyType(string world)
    {
        return world.Replace("SEED","").ToUpper();
    }

    //GET & SET

    public string GetName()
    {
        return seedData.GetName();
    }
    
    public CropData GetCropData()
    {
        return cropData;
    }
    

    //ACTIONS 

    /// <summary>
    ///   <para>Faz com que a semente seja plantada</para>
    /// </summary>
    public void Sow(Vector3Int position)
    {
        GameManager.instace.CropsManager.Sow(position, this);
    }

    /// <summary>
    ///   <para>Faz a semente ser colhida</para>
    /// </summary>
    public void Harvest(Vector3Int playerPositon)
    {
        for (int i = 0; i < cropData.GetNumberOfDroppedItems(); i++)
        {
            Vector3 position = playerPositon;
            position.x += 2f * Random.value - 1f / 2;
            position.y += 2f * Random.value - 1f / 2;

            Item instantiate = Instantiate(cropData.GetItemDropped(), position, Quaternion.identity);
            instantiate.transform.position = position;
            instantiate.rb2d.AddForce(position * .1f, ForceMode2D.Impulse);
        }
    }
}