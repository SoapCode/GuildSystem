using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildSystem;

namespace MainLoop
{
    class Program
    {
        static void Main()
        {

            //Lets create a few gamers
            Gamer gamer = new Gamer(new GamerInfo{Name = "Ivan", LastName = "Ivanov",Age = 18,Country = "Russia",Gender = "male"});
            Gamer gamer2 = new Gamer(new GamerInfo { Name = "Jill", LastName = "Anderson", Age = 25, Country = "USA", Gender = "female" });

            Console.WriteLine("Gamers {0} and {1} were created.", gamer.PersonalInfo.Name, gamer2.PersonalInfo.Name);

            Console.WriteLine();Console.WriteLine("-------------------------------");

            //Lets create our guild
            MyGuild guild = MyGuild.CreateNewMyGuild("SomeGuild",gamer);

            Console.WriteLine("Guild {0} with {1} as it's master was created.",guild.GuildInfo.GuildName, gamer.PersonalInfo.Name);

            Console.WriteLine(); Console.WriteLine("-------------------------------");

            //Check if this unrelated player belongs to guild (spoiler: he doesn't)
            guild.CheckIfBelongToGuild(gamer2);

            Console.WriteLine("Player {0} is not yet in {1}.", gamer2.PersonalInfo.Name, guild.GuildInfo.GuildName);

            Console.WriteLine(); Console.WriteLine("-------------------------------");

            //Lets try and add unrelated player
            bool result = guild.TryAddMembers(gamer2);

            Console.WriteLine("We tried to add {0} to the guild, but he's not invited yet, so the result was {1}.", gamer2.PersonalInfo.Name, result);

            Console.WriteLine(); Console.WriteLine("-------------------------------");

            //Here goes logic to decide whether is player worthy enough, to be invited to join the guild
            Func<Gamer, bool> worthinessChecker = (x) => true;

            //Lets try to invite our player now, preliminarily checking he's worthiness
            result = guild.TryInviteNewMembers(worthinessChecker,gamer2);

            Console.WriteLine("We tried to invite {0} to the guild, and the result was {1}.", gamer2.PersonalInfo.Name, result);

            Console.WriteLine(); Console.WriteLine("-------------------------------");

            //Now we can add him
            result = guild.TryAddMembers(gamer2);

            Console.WriteLine("Now we can add {0} to the guild, aren't we? {1}.", gamer2.PersonalInfo.Name, result);

            Console.WriteLine(); Console.WriteLine("-------------------------------");

            //Lets check if he belongs now
            result = guild.CheckIfBelongToGuild(gamer2);

            Console.WriteLine("And finally {0} belongs to the guild! Am I right? {1}.", gamer2.PersonalInfo.Name, result);

            Console.Read();
        }
    }
}
