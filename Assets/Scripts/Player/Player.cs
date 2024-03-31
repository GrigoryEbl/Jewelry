using UnityEngine;

[RequireComponent (typeof(Wallet))]
[RequireComponent (typeof(MoneyCollector))]
public class Player : MonoBehaviour
{
    [SerializeField] private JoystickInput _joystickInput;

    private Wallet _wallet;
    private MoneyCollector _moneyCollector;

    public Wallet Wallet => _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
        _moneyCollector = GetComponent<MoneyCollector>();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            _wallet.TakeMoney(100000);      //DELETE
        }
    }

    private void OnEnable() => _moneyCollector.MoneyCatched += OnMoneyCatch;

    private void OnDisable() => _moneyCollector.MoneyCatched -= OnMoneyCatch;

    public bool TryToPay(float price)
    {
        if (Wallet.Money >= price)
            return true;

        return false;
    }

    private void OnMoneyCatch(uint value)
    {
        _wallet.TakeMoney(value);
    }

}
