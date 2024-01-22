// -----------------------------------------------------------------------
//   <copyright file="InjectedCtor.cs" company="Petabridge, LLC">
//     Copyright (C) 2015-2024 .NET Petabridge, LLC
//   </copyright>
// -----------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;

namespace DryIocTest;

public class InjectedCtor
{
    private readonly IMyService _myService;
    private readonly string _name;

    public InjectedCtor(
        [FromKeyedServices(nameof(MyService))] IMyService myService,
        string name)
    {
        _myService = myService;
        _name = name;
    }
}