using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingUtility;

namespace GuildSystem
{
    
    public class GuildInfo
    {
        public string GuildName { get; set; }
        public string GuildBanner { get; set; }
    }

    public class GuildHierarchy
    {
        public Gamer GuildMaster { get; set; }
        public List<Gamer> Officers { get; set; }
        public List<Gamer> Members { get; set; }
        public int MaxMemberQuantity { get; set; }
        public int MaxOfficerQuantity { get; set; }

        public GuildHierarchy(Gamer guildMaster, int maxMemberQuantity, int maxOfficerQuantity) : this(guildMaster, maxMemberQuantity, maxOfficerQuantity, null, null)
        {

        }

        public GuildHierarchy(Gamer guildMaster, int maxMemberQuantity, int maxOfficerQuantity, List<Gamer> guildMembers = null, List<Gamer> guildOfficers = null)
        {
            NullGuard.ThrowIfNull(guildMaster);

            GuildMaster = guildMaster;

            //TODO: looks like nasty repetition, get rid of it
            if (NullGuard.FalseIfNull(guildMembers) && guildMembers.Count <= MaxMemberQuantity)
                Members = guildMembers;
            else
                Members = new List<Gamer>();

            if (NullGuard.FalseIfNull(guildOfficers) && guildOfficers.Count <= MaxOfficerQuantity)
                Officers = guildOfficers;
            else
                Officers = new List<Gamer>();
        }
    }
}
