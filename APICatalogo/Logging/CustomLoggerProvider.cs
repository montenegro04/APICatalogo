using System.Collections.Concurrent;

namespace APICatalogo.Logging;

public class CustomerLoggerProvider : ILoggerProvider
{
    readonly CustomLoggerProviderConfiguration loggerconfig;
    readonly ConcurrentDictionary<string, CustomerLogger> loggers = new ConcurrentDictionary<string, CustomerLogger>();
    public CustomerLoggerProvider(CustomLoggerProviderConfiguration config)
    {
        loggerconfig = config;
    }
    public ILogger CreateLogger(string categoryName)
    {
        return loggers.GetOrAdd(categoryName, name => new CustomerLogger(name, loggerconfig));
    }
    public void Dispose()
    {
       loggers.Clear();
    }
}