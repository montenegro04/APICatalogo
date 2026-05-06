namespace APICatalogo.Logging;

public class CustomerLogger : ILogger
{
    readonly string loggerName;
    readonly CustomLoggerProviderConfiguration loggerconfig;
    public CustomerLogger(string name, CustomLoggerProviderConfiguration config)
    {
        loggerName = name;
        loggerconfig = config;
    }
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        throw new NotImplementedException();
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        string message = $"[{DateTime.Now}] - {logLevel} - {loggerName} - {formatter(state, exception)}";
        EscreverTextoNoArquivo(message);
    }
    private void EscreverTextoNoArquivo(string texto)
    {
        string caminhoArquivo = @"caminho/do/arquivo/log.txt";
        using (StreamWriter writer = new StreamWriter(caminhoArquivo, true))
        {
           try
            {
                writer.WriteLine(texto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao escrever no arquivo de log: {ex.Message}");
            }
        }
    }
}