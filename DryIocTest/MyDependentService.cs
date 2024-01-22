// -----------------------------------------------------------------------
//   <copyright file="MyDependentService.cs" company="Petabridge, LLC">
//     Copyright (C) 2015-2024 .NET Petabridge, LLC
//   </copyright>
// -----------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;

namespace DryIocTest;

public class MyDependentService: IDependentService
{
    private readonly IMyService _myService;

    public MyDependentService([FromKeyedServices(nameof(MyService))] IMyService myService)
    {
        _myService = myService;
    }
}