using ChargeAccountManager.Workers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<ChargeAccountManagerWorker>();
    })
    .Build();

host.Run();
