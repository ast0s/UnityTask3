using UnityEngine;
using UnityEngine.UI;

public class ParticleSpawnerButton : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private int _spawnCount = 1;
    
    public void RequestSpawnParticle()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            FindObjectOfType<ParticleSpawner>().Spawn(_index);
        }
    }

    private void OnValidate()
    {
        _index = transform.GetSiblingIndex();
        GetComponentInChildren<Text>().text = _index.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0 + _index))
        {
            RequestSpawnParticle();
        }
    }
}