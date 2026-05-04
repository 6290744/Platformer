using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [Header("Collectables")] [SerializeField]
    private ValueViewer _coinsViewer;

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
    [SerializeField] private Rotator _playerRotator;

    private CollectionHandler _collectionHandler;
    private PlayerMovementMediator _playerMovementMediator;

    private void Awake()
    {
        _collectionHandler = new CollectionHandler();
        _playerMovementMediator = new PlayerMovementMediator();

        _collectionHandler.Initialize(_itemsCollector, _coinsCounter);

        _playerMovementMediator.Initialize(_playerInputReader, _playerAnimator, _playerMover, _playerJumper,
            _playerRotator);

        _coinsViewer.Initialize(_coinsCounter);

        _coinSpawner.Initialize(_coinPrefab, spawnPoints);
    }

    private void OnDisable()
    {
        _collectionHandler?.Dispose();
        _playerMovementMediator?.Dispose();
    }
}