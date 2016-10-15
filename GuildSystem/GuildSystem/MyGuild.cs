using ProgrammingUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildSystem
{
    public class MyGuild : Guild
    {
        List<Gamer> _invitedGamers = new List<Gamer>();

        public MyGuild(GuildInfo guildInfo, GuildHierarchy guildHierarchy) : base(guildInfo, guildHierarchy) { }

        #region Telescoping factory methods

        //Some factory methods to make MyGuild creation easier
        public static MyGuild CreateNewMyGuild(string guildName, Gamer guildMaster)
        {
            return CreateNewMyGuild(guildMaster, new GuildInfo() { GuildName = guildName, GuildBanner = "" }, 0,0);
        }

        public static MyGuild CreateNewMyGuild(Gamer guildMaster, GuildInfo guildInfo, int maxMemberQuantity, int maxOfficerQuantity)
        {
            return CreateNewMyGuild(guildMaster, null, null, guildInfo, maxMemberQuantity, maxOfficerQuantity);
        }

        //TODO: Too many parameters, bad sign. Parameters container?
        public static MyGuild CreateNewMyGuild(Gamer guildMaster, List<Gamer> guildOfficers, List<Gamer> guildMembers, GuildInfo guildInfo, int maxMemberQuantity, int maxOfficerQuantity)
        {
            return new MyGuild(guildInfo, new GuildHierarchy(guildMaster, maxMemberQuantity, maxOfficerQuantity, guildMembers, guildOfficers));
        }

        #endregion

        public bool TryInviteNewMembers(Func<Gamer, bool> conditionToMeet, params Gamer[] gamers)
        {

            if (!falseIfNull(conditionToMeet,gamers))
                return false;

            if (!validateGamers(conditionToMeet, gamers))
                return false;

            return tryAddGamersToContainer(_invitedGamers,gamers);
        }

        bool falseIfNull(params object[] objs)
        {
            return NullGuard.FalseIfNull(objs);
        }

        bool validateGamers(Func<Gamer, bool> validator, params Gamer[] gamers)
        {
            foreach (Gamer gamr in gamers)
            {
                if (!validator(gamr))
                    return false;
            }
            return true;
        }

        bool tryAddGamersToContainer(List<Gamer> container, params Gamer[] gamers)
        {
            try
            {
                container.AddRange(gamers);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool TryAddMembers(params Gamer[] gamers)
        {
            if (!falseIfNull(gamers))
                return false;

            if (!validateGamers((x) => _invitedGamers.Contains(x), gamers))
                return false;

            return tryAddGamersToContainer(Hierarchy.Members, gamers);
            
        }
        public override bool CheckIfBelongToGuild(params Gamer[] gamers)
        {

            if (!falseIfNull(gamers))
                return false;

            if (!validateGamers((x) => Hierarchy.Members.Contains(x), gamers))
                return false;

            return true;

        }
    }
}
