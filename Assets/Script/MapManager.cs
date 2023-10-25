using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MapManager : MonoBehaviour
{
    public static MapManager instance;


    public GameObject SideWall, Break, UnBreak, Tower, temp;
    //public GameObject Wall, SideWall, spawnObject, Tower;
    public GameObject wall, ground;
    public static MapManager Instance { get { return instance; } }


    public GameObject overlayPrefab;
    public GameObject overlayContainer;
    public CharacterInfo character;
    //public Dictionary<Vector3Int, Wall> map;
    public List<Vector3Int> map;
    GameObject tempPrefabs;
    public int jml;
    void Start()
    {
        var tileMaps = gameObject.transform.GetComponentsInChildren<Tilemap>().OrderByDescending(x => x.GetComponent<TilemapRenderer>().sortingOrder);
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
                            Debug.Log(tm.tag);
                            if (!map.Contains(new Vector3Int(x, y, z)))
                            {
                                jml += 1;
                                if(tm.tag == "Ground")
                                {
                                    var temp = tm.GetCellCenterWorld(new Vector3Int(x, y, z));

                                    if (SpawnManager.instance.spawnPosition.Contains(temp))
                                        SpawnManager.instance.spawnPosition.Remove(temp);
                                    else
                                        SpawnManager.instance.spawnPosition.Add(temp);
                                    
                                    continue;
                                }
                                
                                var overlayTile = Instantiate(prefabs(tm.tag), overlayContainer.transform);
                                //changeWall(overlayTile, tm.tag);
                                var cellWorldPosition = tm.GetCellCenterWorld(new Vector3Int(x, y, z));
                                SpawnManager.instance.spawnPosition.Remove(cellWorldPosition);
                                //Debug.Log(cellWorldPosition);
                                SpawnManager.instance.spawnPosition.Add(cellWorldPosition);
                                if (overlayTile.GetComponent<Collider>() == null)
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

    GameObject prefabs(string valueWall)
    {
        if(valueWall == "SideWall")
        {
            temp = SideWall;
        }
        else if(valueWall == "Tower")
        {
            temp = Tower;
        }

        else if(valueWall == "BreakWall")
        {
            temp = Break;
        }

        else if(valueWall == "UnBreak")
        {
            temp = UnBreak;
        }

        return temp;
    }
}
