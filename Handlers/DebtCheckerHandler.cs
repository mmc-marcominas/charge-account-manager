using System.Text.Json;
using ChargeAccountManager.Entities;
namespace ChargeAccountManager.Handlers;

public class DebtCheckerHandler : BaseChargeHandler
{
    public override void Handle(ref CustomerChargeAccount customer)
    {
        Console.WriteLine($"{Environment.NewLine}INFO: Starting a new validation.");
        customer.HasDebt = CheckCustomerDebt(customer.Data);

        if (customer.HasDebt)
        {
            Console.WriteLine("INFO: Customer has some kind of debt. Checking Product info.");
        }
        else
        {
            Console.WriteLine("INFO: No debt found, finishing.");
            nextHandler = null;
        }
        nextHandler?.Handle(ref customer);
    }

    private static bool CheckCustomerDebt(string data)
    {
        var customerData = JsonSerializer.Deserialize<CustomerChargeAccount>(data);
        return customerData is not null && customerData.HasDebt;
    }
}