using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
namespace TagBot.Modules.General
{
    public class General : BaseCommandModule
    {
        [Command("Test")]
        public async Task TestAsync(CommandContext context)
        {
            await context.Channel.SendMessageAsync("Hi.");
        }
    }
}
