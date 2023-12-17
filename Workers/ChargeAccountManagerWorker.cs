using ChargeAccountManager.Entities;
using ChargeAccountManager.Handlers;
using System.Text.Json;

namespace ChargeAccountManager.Workers;

public class ChargeAccountManagerWorker : BackgroundService
{
    private readonly ILogger<ChargeAccountManagerWorker> _logger;

    public ChargeAccountManagerWorker(ILogger<ChargeAccountManagerWorker> logger)
    {
        _logger = logger;
    }

     protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var finished = StartAccountChargeCheck();

            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            if (finished) Environment.Exit(0);
            await Task.Delay(1000, stoppingToken);
        }
    }

    protected static bool StartAccountChargeCheck()
    {
        var chargeAccount = null as CustomerChargeAccount;
        var customers = GetCustomers();

        foreach (var customer in customers)
        {
            var checkDebtHandler = GetDefaultChargeHandler();
            
            chargeAccount = new CustomerChargeAccount
            {
                CustomerId = Guid.NewGuid().ToString(),
                Data = JsonSerializer.Serialize(customer)
            };
            checkDebtHandler.Handle(ref chargeAccount);
        }

        return chargeAccount != null && chargeAccount.Data.Contains("Customer without debt");
    }

    private static BaseChargeHandler GetDefaultChargeHandler()
    {
        var checkDebtHandler = new DebtCheckerHandler();
        var nextHandler = new ProductCheckerHandler();

        checkDebtHandler.SetNextHandler(nextHandler);
        
        return checkDebtHandler;
    }

    protected static CustomerChargeAccount[] GetCustomers()
    {
        return new CustomerChargeAccount[] {
            new() {
                Data = "",
                CustomerId = "Customer without debt",
                HasDebt = false
            }
        };
    }
}