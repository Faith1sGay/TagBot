using DSharpPlus;
using Newtonsoft.Json;
using System.IO;
using DSharpPlus.CommandsNext;
using TagBot.Modules.TagModule;
using System.Threading.Tasks;
using TagBot.Modules.General;
using TagBot.Services.Config;
namespace TagBot
{
    class Program
    {
        public static Config Config = null;
        public static Services.Tags.Tags Tag = null;
        static int Main()
        {
            MainAsync().GetAwaiter().GetResult();
            return 0;
        }

        static async Task MainAsync()
        {
            Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(@"../../../Config.json"));

            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = Config.Token,
                TokenType = TokenType.Bot
            });
            var _commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                CaseSensitive = false,
                StringPrefixes = new[] { Config.Prefix }
            });
            _commands.RegisterCommands<General>();
            _commands.RegisterCommands<TagModule>();
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
