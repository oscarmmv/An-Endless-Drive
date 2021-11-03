using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundZone;
    Vector3 nextSpawnPoint;

    public void SpawnZone (bool spawnItems) {
        GameObject temp = Instantiate(groundZone, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if(spawnItems) {
            temp.GetComponent<GroundTile>().SpawnObsticle();
        }
    }
    void Start() {
        for(int i=0; i<15; i++) {
            if(i < 2) {
                SpawnZone(false);
            } else {
                SpawnZone(true);
            }
        }
    }

}
