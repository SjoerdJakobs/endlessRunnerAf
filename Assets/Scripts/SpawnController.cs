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
/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour
{
    [Header("Chunk prefabs")]
    public List<GameObject> m_chunks = new List<GameObject>();

    //screen width in game unit
    private float m_screenWidthGameUnits;
    public int maxLvl = 4;
    public int minLvl = 0;
    private List<GameObject> m_chunkClones = new List<GameObject>();

    void Awake()
    {
        this.m_screenWidthGameUnits = this.getHalfScreenWidth();
    }

    void Start()
    {
        for (int i = 0; i < 3; i++)//spawn 3 chunks
        {
            m_chunkClones.Add(getRandomChunk(Vector3.zero));
        }

        m_chunkClones[0].transform.position = new Vector3(0 - m_screenWidthGameUnits, 0);//zet de eerste chunk links van het scherm

        sortChunks(m_chunkClones);//sorteer de chunks

        //maak alle chunks aan
        //sorteer de nieuwe chunk zo dat ze het scherm volledig vullen
    }

    void Update()
    {

        foreach (var chunk in m_chunkClones)//beweeg alle chunks doormiddel van een foreach loop
        {
            moveChunk(chunk, 15f);//beweeg de chunks
        }

        for (int i = 0; i < m_chunkClones.Count; i++)//loop door de chunks om te checken of ze out of bound zijn
        {
            if (checkBoundsChunk(m_chunkClones[i]))//check out of bound
            {
                Destroy(m_chunkClones[i]);//destroy game object
                m_chunkClones.RemoveAt(i);//verwijder array element
                m_chunkClones.Add(getRandomChunk(Vector3.zero));//voeg nieuw array element toe aan het einde van de list
            }
        }
        sortChunks(m_chunkClones);//sorteer de chunks
        //check of alle chunks nog binne scherm zijn
        //delete de chunks die buiten het scherm zijn
        //beweeg alle chunks
    }


    /// <summary>
    /// Sorteer de chunk achter elkaar
    /// </summary>
    /// <param name="_chunks">List van chunks die gesorteerd moeten worden</param>
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

    /// <summary>
    /// Check of de chunk aan de linker kant uit het scherm is
    /// </summary>
    /// <param name="_chunk">chunk die we gaan checken</param>
    /// <returns>True = uit scherm, False = binnen scherm</returns>
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

    /// <summary>
    /// Beweeg een chunk
    /// </summary>
    /// <param name="_chunk">Chunk dat bewongen moet worden</param>
    /// <param name="_speed">Snelheid van bewegen</param>
    private void moveChunk(GameObject _chunk, float _speed)
    {
        _chunk.transform.position -= new Vector3(_speed * Time.deltaTime, 0);
    }

    /// <summary>
    /// Haal een random chunk op
    /// </summary>
    /// <param name="_position">positie van game object</param>
    /// <returns>chunk clone gameobject</returns>
    private GameObject getRandomChunk(Vector3 _position)
    {
        return spawnChunk(m_chunks[Random.Range(minLvl, maxLvl)], _position);
    }

    /// <summary>
    /// Spawn een chunk
    /// </summary>
    /// <param name="_chunk">chunk game object</param>
    /// <param name="_position">position van game object</param>
    /// <returns>chunk clone</returns>
    private GameObject spawnChunk(GameObject _chunk, Vector3 _position)
    {
        return (GameObject)Instantiate(_chunk, _position, Quaternion.identity);
    }

    /// <summary>
    /// Haal de breete op van de chunk
    /// </summary>
    /// <param name="_chunk">chunk game object</param>
    /// <returns>breete in float</returns>
    private float getChunkWidth(GameObject _chunk)
    {
        return _chunk.GetComponent<BoxCollider2D>().size.x;
    }

    /// <summary>
    /// Haal de helft van de schermbreete op in game units
    /// </summary>
    /// <returns>game with in game units</returns>
    private float getHalfScreenWidth()
    {
        return (Camera.main.orthographicSize / Camera.main.pixelHeight * Camera.main.pixelWidth);
    }
}*/
