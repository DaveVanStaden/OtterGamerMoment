using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private List<GameObject> backgrounds;
    [SerializeField] private List<GameObject> collectableTemplates;
    [SerializeField] private Vector2 spawnPosition;

    [SerializeField] private float stopTime;
    private float startTime = 0f;
    private float scrollSpeed;

    private bool canSpawnItems = false;

    // Start is called before the first frame update
    void Start()
    {
        StaticVariableCheck();
        stopTime = StaticVariable.SpawnSpeed;
        scrollSpeed = StaticVariable.MovementSpeedSpawner;
        startTime += stopTime;
        SpawnBackground();
        spawnPosition = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*startTime += Time.deltaTime;
        if (startTime >= stopTime)
        {
            startTime = 0f;
        }*/
    }

    private void SpawnBackground()
    {
        var TempWall = Instantiate(backgrounds[Random.Range(0, backgrounds.Count)], spawnPosition, Quaternion.identity);
        var TempRigid = TempWall.GetComponent<Rigidbody2D>();
        TempRigid.velocity = new Vector2(-1f, 0) * scrollSpeed;

        if (canSpawnItems)
        {
            var TempCollect = Instantiate(collectableTemplates[Random.Range(0, collectableTemplates.Count)], spawnPosition, Quaternion.identity);
            var TempCollectBody = TempCollect.GetComponent<Rigidbody2D>();
            TempCollectBody.velocity = new Vector2(-1f, 0) * scrollSpeed;
        }
    }
    private void StaticVariableCheck()
    {
        if (StaticVariable.SpawnSpeed < 1f)
        {
            StaticVariable.SpawnSpeed = 1f;
        }
        if (StaticVariable.SpawnSpeed > 12f)
        {
            StaticVariable.SpawnSpeed = 12f;
        }
    }

    public void SpawnWall()
    {
        SpawnBackground();
        spawnPosition = new Vector2(19.584f, 0);
        canSpawnItems = true;
    }

}
