using ChargeAccountManager.Entities;

namespace ChargeAccountManager.Handlers;

public abstract class BaseChargeHandler
{
    protected BaseChargeHandler? nextHandler;
    public void SetNextHandler(BaseChargeHandler handler)
    {
        nextHandler = handler;
    }

    public abstract void Handle(ref CustomerChargeAccount customer);
}