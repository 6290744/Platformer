using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour, ICollectable
{
    private SpawnPoint[] _spawnPoints;
    private ObjectPool<T> _itemsPool;
    private List<int> _freeSpawnPointsIndeces;
    private bool _isSpawning;
    private float _spawnInterval;

    public void Initialize(T itemPrefab, SpawnPoint[] spawnPoints)
    {
        _spawnPoints = spawnPoints;
        _isSpawning = true;
        _spawnInterval = 3;
        _freeSpawnPointsIndeces = new List<int>();
        _itemsPool = new ObjectPool<T>(
            createFunc: () => Instantiate(itemPrefab),
            actionOnGet: (coin) => OnGetFromPool(coin),
            actionOnRelease: coin => OnReleaseToPool(coin),
            actionOnDestroy: coin => Destroy(coin.gameObject),
            collectionCheck: true,
            defaultCapacity: _spawnPoints.Length,
            maxSize: _spawnPoints.Length);

        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        T item;
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnInterval);

        while (_isSpawning)
        {
            if (IsMaximalCapacityReached() == false && TryGetFreeSpawnPoint(out SpawnPoint point))
            {
                item = _itemsPool.Get();

                SetCoinPosition(item, point.Position);

                OccupySpawnPoint(point, item);
            }

            yield return waitForSeconds;
        }
    }

    private bool TryGetFreeSpawnPoint(out SpawnPoint point)
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            if (_spawnPoints[i].IsOccupied == false)
            {
                _freeSpawnPointsIndeces.Add(i);
            }
        }

        if (_freeSpawnPointsIndeces.Count > 0)
        {
            point = _spawnPoints[_freeSpawnPointsIndeces[Random.Range(0, _freeSpawnPointsIndeces.Count)]];
            
            _freeSpawnPointsIndeces.Clear();
            
            return true;
        }

        point = null;

        return false;
    }

    private void OnGetFromPool(T item)
    {
        item.Collected += OnCoinCollected;

        item.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(T item)
    {
        item.Collected -= OnCoinCollected;

        item.gameObject.SetActive(false);
    }

    private void OnCoinCollected(ICollectable item)
    {
        if (item is T poolItem)
        {
            _itemsPool.Release(poolItem);
        }
    }

    private bool IsMaximalCapacityReached()
    {
        return _itemsPool.CountActive >= _spawnPoints.Length;
    }

    private void OccupySpawnPoint(SpawnPoint point, ICollectable item)
    {
        point.Occupy(item);
    }

    private void SetCoinPosition(T item, Vector3 position)
    {
        item.transform.position = position;
    }
}