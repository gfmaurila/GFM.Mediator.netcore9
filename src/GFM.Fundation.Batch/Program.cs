using GFM.Fundation.Batch.Application.Commands.User;
using GFM.Fundation.Batch.CrossCutting.InjecaoDependencia;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GFM.Fundation.Batch;

[Command("GFM.Fundation.Batch")]
[Subcommand(typeof(UserBatchCommand))]
public class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            Console.WriteLine($"***************************************************************");
            Console.WriteLine($"Program > Inicio > {DateTime.Now}");
            var services = new ServiceCollection();

            // Adiciona logging necessário para ILogger<T>
            services.AddLogging(config => config.AddConsole());

            services.AddMediator()
                    .BuildServiceProvider();

            var serviceProvider = services.BuildServiceProvider();

            // Configuração do aplicativo de linha de comando
            var app = new CommandLineApplication<Program>();
            app.Conventions
                .UseDefaultConventions()
                .UseConstructorInjection(serviceProvider);

#if DEBUG
            // Define argumentos padrão no modo de depuração
            string[] setv = { "User" };
            args = setv;
#endif

            // Executa a aplicação de linha de comando
            app.Execute(args);
            Console.WriteLine($"Program > Fim > {DateTime.Now}");
            Console.WriteLine($"***************************************************************");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"***************************************************************");
            Console.WriteLine($"Program > Erro > {DateTime.Now}");
            Console.WriteLine($"{ex.Message}");
            Console.WriteLine($"***************************************************************");
        }
    }
}
