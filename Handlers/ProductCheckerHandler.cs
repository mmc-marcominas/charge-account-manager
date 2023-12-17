using ChargeAccountManager.Enums;
using ChargeAccountManager.Entities;
using System.Text.Json;

namespace ChargeAccountManager.Handlers;

public class ProductCheckerHandler : BaseChargeHandler
{
    public override void Handle(ref CustomerChargeAccount customer)
    {
        customer.ProductType = CheckCustomerProductType(customer.Data);
        if (customer.ProductType == ProductType.CreditCard)
        {
            Console.WriteLine("INFO: Customer has Credit Card debt. Sendig to account status checker step.");
        }
        else if (customer.ProductType == ProductType.PersonalLoan)
        {
            Console.WriteLine("INFO: Customer has Personal Loan debt. Sendig to debt value checker step.");
        }
        else
        {
            Console.WriteLine("ERROR: Unknown product type, finishing.");
        }
        nextHandler?.Handle(ref customer);
    }

    private static ProductType? CheckCustomerProductType(string data)
    {
        var customerData = JsonSerializer.Deserialize<CustomerChargeAccount>(data);
        return customerData?.ProductType;
    }
}