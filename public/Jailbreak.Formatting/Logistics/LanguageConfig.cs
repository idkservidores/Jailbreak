﻿using Microsoft.Extensions.DependencyInjection;

namespace Jailbreak.Formatting.Logistics;

public class LanguageConfig<TDialect> where TDialect : IDialect {
  private readonly IServiceCollection collection;

  public LanguageConfig(IServiceCollection collection) {
    this.collection = collection;
  }

  public void Configure(Dictionary<Type, Type> serviceMap) {
    foreach (var (service, implementation) in serviceMap) {
      var method = typeof(IServiceCollection).GetMethod("AddSingleton")
      ?.MakeGenericMethod(service, implementation);
      method?.Invoke(collection, null);
    }
  }
}

public static class ServiceCollectionExtensions {
  public static void AddLanguage<TDialect>(this IServiceCollection services,
    Action<LanguageConfig<TDialect>> configure)
    where TDialect : class, IDialect {
    var config = new LanguageConfig<TDialect>(services);
    configure(config);
  }
}