using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MapManager : MonoBehaviour
{
    public static MapManager instance;


    public Material Break, UnBreak;
    public GameObject Wall, SideWall, spawnObject;

    public static MapManager Instance { get { return instance; } }


    public GameObject overlayPrefab;
    public GameObject overlayContainer;
    public CharacterInfo character;
    public Dictionary<Vector3Int, Wall> map;

    GameObject tempPrefabs;

    void Start()
    {
        var tileMaps = gameObject.transform.GetComponentsInChildren<Tilemap>().OrderByDescending(z => z.GetComponent<TilemapRenderer>().sortingOrder);
        //ObjectInteraction interaction = gameObject.transform.GetComponentInChildren<ObjectInteraction>();
        map = new Dictionary<Vector3Int, Wall>();
        Debug.Log(tileMaps);
        Debug.Log(map);
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

                            if (!map.ContainsKey(new Vector3Int(x, y, z)))
                            {

                                if (tm.tag == "SideWall")
                                {
                                    tempPrefabs = SideWall;
                                }
                                else if (tm.tag == "Wall")
                                {
                                    tempPrefabs = Wall;
                                    
                                }
                                else
                                {
                                    continue;
                                }


                                var overlayTile = Instantiate(tempPrefabs, overlayContainer.transform);
                                var cellWorldPosition = tm.GetCellCenterWorld(new Vector3Int(x, y, z));
                                overlayTile.AddComponent<Collider>();
                                overlayTile.transform.position = new Vector3(cellWorldPosition.x, cellWorldPosition.y, cellWorldPosition.z);
                                //overlayTile.GetComponent<SpriteRenderer>().sortingOrder = tm.GetComponent<TilemapRenderer>().sortingOrder;
                              //  overlayTile.gameObject.GetComponent<Wall>().gridLocation = new Vector3Int(x, y, z);


                            }
                        }
                    }
                }
            }
        }
        //character.getTile();
    }
}
