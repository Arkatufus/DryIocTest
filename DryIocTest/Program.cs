using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using DryIocTest;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var container = new Container();
container.Register<IMyService, MyService>(serviceKey: nameof(MyService));
container.Register<IDependentService, MyDependentService>();

var diFactory = new DryIocServiceProviderFactory(container);

var hostBuilder = new HostBuilder();
hostBuilder.UseServiceProviderFactory(diFactory);

var host = hostBuilder.Build();
await host.StartAsync();

var provider = host.Services;

// This does not work
// var dependentService = provider.GetRequiredService<IDependentService>();

// neither does this
// var dependentService = ActivatorUtilities.CreateInstance<MyDependentService>(provider);

// neither does this
/*
using (var scope = provider.CreateScope())
{
    var dependentService = scope.ServiceProvider.GetRequiredService<IDependentService>();
}
*/

// neither does this
var dependentService = ActivatorUtilities.CreateInstance(provider, typeof(InjectedCtor), "injectedName");