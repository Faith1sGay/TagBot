using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using System;
using TagBot.Services.Tags;
using LiteDB;
using System.Linq;
namespace TagBot.Modules.TagModule
{
    [Group("tag")]
    public class TagModule : BaseCommandModule
    {



        [Command("create")]
        [Aliases("add", "c", "make")]
        public async Task CreateAsync(CommandContext Context, string name, [RemainingText] string content = "")
        {
            string[] chars = { "A", "a", "B", "b", "C", "c", "D", "d", "E", "e", "F", "f", "G", "g", "H", "h", "I", "i", "J", "j", "K", "k", "L", "l", "M", "m", "N", "n", "O", "o", "P", "p", "Q", "q", "R", "r", "S", "s", "T", "t", "U", "u", "V", "v", "W", "w", "X", "x", "Y", "y", "Z", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            Random rnd = new Random();
            int RandomStringGen = rnd.Next(chars.Length * 6);
            var idk = chars[RandomStringGen];
            var Db = new LiteDatabase("./DataBase.db");
            var col = Db.GetCollection<Tags>("Tags");

            var T = new Tags
            {
                Id = idk,
                AuthorUser = Context.Member.Username,
                AuthorID = Context.Member.Id,
                TagName = name,
                Content = content
            };
            try
            {
                col.Insert(T);
                await Context.Channel.SendMessageAsync("h.");
            }
            catch (Exception E)
            {
                await Context.Channel.SendMessageAsync(E.ToString());
            }

        }
    }
}
