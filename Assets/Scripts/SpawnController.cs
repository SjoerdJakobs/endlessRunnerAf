using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour
{
    [Header("Chunk prefabs")]
    public List<GameObject> m_chunks = new List<GameObject>();

    //screen width in game unit
    private float m_screenWidthGameUnits;
    private int maxLvl = 3;
    private int minLvl = 0;
    private float timer;
    private float timerSpeed = 0.80f;
    private List<GameObject> m_chunkClones = new List<GameObject>();

    void Awake()
    {
        this.m_screenWidthGameUnits = this.getHalfScreenWidth();
    }

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            m_chunkClones.Add(getRandomChunk(Vector3.zero));
        }

        m_chunkClones[0].transform.position = new Vector3(0 - m_screenWidthGameUnits, 0);

        sortChunks(m_chunkClones);
    }

    void Update()
    {
        if (timer <= 40) timer += (Time.deltaTime * timerSpeed);
        else
        {
            if (maxLvl < 5)
            {
                maxLvl++;
                minLvl++;
            }
            timer = 0;
            timerSpeed += 0.06f;
        }

        foreach (var chunk in m_chunkClones)
        {
            moveChunk(chunk, 15f);
        }

        for (int i = 0; i < m_chunkClones.Count; i++)
        {
            if (checkBoundsChunk(m_chunkClones[i]))
            {
                Destroy(m_chunkClones[i]);
                m_chunkClones.RemoveAt(i);
                m_chunkClones.Add(getRandomChunk(Vector3.zero));
            }
        }
        sortChunks(m_chunkClones);
    }

    private void sortChunks(List<GameObject> _chunks)
    {
        if (_chunks.Count < 1)
        {
            Debug.Log("Error sort chunk! list heeft geen elementen");
            return;
        }
        //get first chunk position
        var l_firstChunkV3 = _chunks[0].transform.position;
        //sort chunks
        for (int i = 0; i < _chunks.Count; i++)
        {
            _chunks[i].transform.position = new Vector3(l_firstChunkV3.x + (getChunkWidth(_chunks[i]) * i), 0);
        }
    }

    private bool checkBoundsChunk(GameObject _chunk)
    {
        if (_chunk.transform.position.x < 0 - (m_screenWidthGameUnits + getChunkWidth(_chunk) / 2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void moveChunk(GameObject _chunk, float _speed)
    {
        _chunk.transform.position -= new Vector3(_speed * Time.deltaTime, 0);
    }

    private GameObject getRandomChunk(Vector3 _position)
    {
        return spawnChunk(m_chunks[Random.Range(minLvl, maxLvl)], _position);
    }

    private GameObject spawnChunk(GameObject _chunk, Vector3 _position)
    {
        return (GameObject)Instantiate(_chunk, _position, Quaternion.identity);
    }

    private float getChunkWidth(GameObject _chunk)
    {
        return _chunk.GetComponent<BoxCollider2D>().size.x;
    }

    private float getHalfScreenWidth()
    {
        return (Camera.main.orthographicSize / Camera.main.pixelHeight * Camera.main.pixelWidth);
    }
}
