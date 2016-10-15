using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingUtility;

namespace GuildSystem
{ 

    public abstract class Guild
    {
        public GuildInfo GuildInfo { get; private set; }
        public GuildHierarchy Hierarchy { get; private set; }

        public Guild(GuildInfo guildInfo, GuildHierarchy guildHierarchy)
        {
            NullGuard.ThrowIfNull(guildInfo, guildHierarchy);

            GuildInfo = guildInfo;
            Hierarchy = guildHierarchy;
        }

        public abstract bool TryAddMembers(params Gamer[] gamers);
        public abstract bool CheckIfBelongToGuild(params Gamer[] gamers);

    }
}
