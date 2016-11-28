using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;


public class ItemDatabase : MonoBehaviour
{
    [SerializeField]
    public List<Objects> inventory = new List<Objects>();
    [SerializeField]
    public List<Objects> itemData;
    //private JsonData itemData;

    void Start()
    {
        //Objects item = new Objects();
        //Item item = new Item(0, "Sword", 5);
        //inventory.Add(item);
        //Debug.Log(database[0].Title);
        //itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/items.json"));
        ConstructItemDatabse();

        Debug.Log(inventory[0].objectVal.itemName);
        Debug.Log(FetchItemByID(0));
        // Item item = new Item();
    }

    public Objects FetchItemByID(int id)
    {
        for (int i = 0; i < inventory.Count; i++)

            if (inventory[i].objectVal.identityNumber == id)
                return inventory[i];

        return null;

    }

    void ConstructItemDatabse()
    {
        for (int i = 0; i < itemData.Count; i++)
       
        {
           // inventory.Add(new )
            //database.Add(new itemTest())
            //inventory.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), (int)itemData[i]["value"], itemData[i]["slug"].ToString()));
        }
    }
}


//public class Item
//{
//    public int ID { get; set; }
//    public string Title { get; set; }
//    public int Value { get; set; }
//    public string Slug { get; set; }
//    public Sprite Sprite { get; set; }
//    public string itemName { get; internal set; }

//    public Item(int id, string title, int value, string slug)
//    {
//        this.ID = id;
//        this.Title = title;
//        this.Value = value;
//        this.Slug = slug;
//        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + Slug);
//    }

//    public Item()
//    {
//        this.ID = -1;
    

//    }
//}