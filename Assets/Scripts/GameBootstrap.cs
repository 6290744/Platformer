
using UnityEngine;


public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private ValueViewer _coinsViewer;
    [SerializeField] private CoinsCounter _coinsCounter;
    [SerializeField] private ItemsCollector _itemsCollector;
    [SerializeField] private CoinsSpawner _coinSpawner;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private SpawnPoint[] spawnPoints;
    
    private CollectionHandler _collectionHandler;

    private void Awake()
    {
        _collectionHandler = new CollectionHandler();

        _collectionHandler.Initialize(_itemsCollector, _coinsCounter);
        
        _coinsViewer.Initialize(_coinsCounter);
        
        _coinSpawner.Initialize(_coinPrefab, spawnPoints);
    }

    private void OnDisable()
    {
        _collectionHandler?.Dispose();
    }
}