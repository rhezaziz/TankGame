using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MapManager : MonoBehaviour
{
    public static MapManager instance;


    public Material Break, UnBreak, Tower;
    //public GameObject Wall, SideWall, spawnObject, Tower;
    public GameObject wall, ground;
    public static MapManager Instance { get { return instance; } }


    public GameObject overlayPrefab;
    public GameObject overlayContainer;
    public CharacterInfo character;
    //public Dictionary<Vector3Int, Wall> map;
    public List<Vector3Int> map;
    GameObject tempPrefabs;

    void Start()
    {
        var tileMaps = gameObject.transform.GetComponentsInChildren<Tilemap>().OrderByDescending(z => z.GetComponent<TilemapRenderer>().sortingOrder);
        //ObjectInteraction interaction = gameObject.transform.GetComponentInChildren<ObjectInteraction>();
        map = new List<Vector3Int>();
        //Debug.Log(tileMaps);
      //  Debug.Log(map);
        foreach (var tm in tileMaps)
        {
            BoundsInt bounds = tm.cellBounds;

            // Debug.Log(tm.cellBounds);
            for (int z = bounds.min.z; z < bounds.max.z; z++)
            {
                // Debug.Log("z = "+z);
                for (int y = bounds.min.y; y < bounds.max.y; y++)
                {
                    //Debug.Log("Y = " + y);
                    for (int x = bounds.min.x; x < bounds.max.x; x++)
                    {

                        // Debug.Log("X = " + x);
                        if (tm.HasTile(new Vector3Int(x, y, z)))
                        {

                            if (!map.Contains(new Vector3Int(x, y, z)))
                            {
                                if(tm.tag == "Ground")
                                {
                                    continue;
                                }
                                
                                var overlayTile = Instantiate(wall, overlayContainer.transform);
                                changeWall(overlayTile, tm.tag);
                                var cellWorldPosition = tm.GetCellCenterWorld(new Vector3Int(x, y, z));
                                overlayTile.AddComponent<Collider>();
                                overlayTile.transform.position = new Vector3(cellWorldPosition.x, cellWorldPosition.y, cellWorldPosition.z);
                            }
                        }
                    }
                }
            }
        }
        //character.getTile();
    }

    void changeWall(GameObject wall, string valueWall)
    {
        Material temp = null;
        switch (valueWall)
        {
            case "SideWall":
                temp = UnBreak;
                wall.AddComponent<Wall>();
                break;

            case "Tower":
                temp = Tower;
                break;

            case "BreakWall":
                temp = Break;
                break;

            case "Wall":
                bool isBreak = Random.Range(0, 1) == 1;
                temp = isBreak ? Break : UnBreak;
                wall.AddComponent<Wall>();
                break;

        }
        wall.GetComponent<MeshRenderer>().material = temp;
    }
}
