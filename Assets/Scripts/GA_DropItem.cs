using UnityEngine;
using System.Collections.Generic;

public class GA_DropItem : MonoBehaviour
{
    public List<DropTableItem> dropTable;
    private float[] CDA;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FillCDA()
    {
        // Create our Cumulative Density Array
        CDA = new float[dropTable.Count];

        // Set first CDA value to the weight of our first item in the drop table
        CDA[0] = dropTable[0].weight;

        // Set each additional value to the additive total weight of all the objects before it
        for (int i=1; i<dropTable.Count; i++)
        {
            CDA[i] = CDA[i - 1] + dropTable[i].weight;
        }
    }

    public void DropItem()
    {
        Instantiate(GetItemToDrop(), transform.position, transform.rotation);
    }

    public GameObject GetItemToDrop()
    {
        /* Method 1 - Percent based
        float randomPercent = Random.value * 100; // 0 to 1
        float currentPercent = 0.0f;

        foreach (DropTableItem item in dropTable)
        {
            currentPercent += item.percentChance;
            if (randomPercent < currentPercent)
            {
                return item.itemToDrop;
            }
        }*/


        // Choose a random number up to our highest density
        
        float randomValue = Random.value * CDA[CDA.Length - 1];

        /*
        for (int i = 0; i < CDA.Length; i++)
        {
            if (randomValue < CDA[i])
            {
                return dropTable[i].itemToDrop;
            }
        }*/

        // Find where that value is in the CDA ( Faster Way! )
        int selectedIndex = System.Array.BinarySearch(CDA, randomValue);
        if (selectedIndex < 0)
        {
            // Use the bitwise NOT to find one index higher
            selectedIndex = ~selectedIndex;
        }

        // Now, we can send back the object at our selected index
        return possibleItems[selectedIndex].itemToDrop;
    }
}

[System.Serializable]
public struct DropTableItem
{
    public GameObject itemToDrop;
    public float weight;
}
