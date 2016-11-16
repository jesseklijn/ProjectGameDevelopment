using UnityEngine;
using System.Collections;

public class TileGenerator : MonoBehaviour
{
    public float length;
    public GameObject tile;
    public int tilecount;
    public float rows;
    public float ldistance = 1.1F;
    public float bdistance = 0.7F;
    public bool hex = false;
    // Use this for initialization
    void Awake()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int f = 0; f < length; f++)
            {
                Instantiate(tile, new Vector3(f * ldistance, 1, i * bdistance), Quaternion.identity);
                if (hex)
                {
                    Instantiate(tile, new Vector3((f * ldistance) + 0.55F, 1, (i * bdistance) + 0.35F), Quaternion.identity);
                }
            }

        }

    }

}
