public class CollectionHandler
{
    private ItemsCollector _itemsCollector;
    private ICounter _coinsCounter;

    public void Initialize(ItemsCollector itemsCollector,  ICounter counter)
    {
        _itemsCollector = itemsCollector;
        _coinsCounter = counter;

        _itemsCollector.Collected += OnCollect;
    }

    public void Dispose()
    {
        if (_itemsCollector != null)
        {
            _itemsCollector.Collected -= OnCollect;
        }
    }

    private void OnCollect(ICollectable item)
    {
        switch (item)
        {
            case Coin:
            {
                _coinsCounter.Add(item);
                break;
            }
        }
    }
}
