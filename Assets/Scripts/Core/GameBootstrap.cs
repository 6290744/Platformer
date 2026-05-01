
using UnityEngine;


public class GameBootstrap : MonoBehaviour
{
    [Header("Collectables")]
    [SerializeField] private ValueViewer _coinsViewer;
    [SerializeField] private CoinsCounter _coinsCounter;
    [SerializeField] private ItemsCollector _itemsCollector;
    [SerializeField] private CoinsSpawner _coinSpawner;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private SpawnPoint[] spawnPoints;
    
    [Header("Player")]
    [SerializeField] private PlayerInputReader _playerInputReader;
    [SerializeField] private PlayerJumper _playerJumper;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimator _playerAnimator;
    
    private CollectionHandler _collectionHandler;
    private PlayerMediator _playerMediator;

    private void Awake()
    {
        _collectionHandler = new CollectionHandler();
        _collectionHandler.Initialize(_itemsCollector, _coinsCounter);
        
        _playerMediator  = new PlayerMediator();
        _playerMediator.Initialize(_playerInputReader, _playerAnimator, _playerMover,  _playerJumper);
        
        _coinsViewer.Initialize(_coinsCounter);
        
        _coinSpawner.Initialize(_coinPrefab, spawnPoints);
    }

    private void OnDisable()
    {
        _collectionHandler?.Dispose();
        _playerMediator?.Dispose();
    }
}