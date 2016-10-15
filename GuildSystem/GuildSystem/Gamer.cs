using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingUtility;

namespace GuildSystem
{

    public class GamerInfo
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
    }

    public class Gamer
    {
        public GamerInfo PersonalInfo { get; private set; }

        public Gamer(GamerInfo personalInfo)
        {
            NullGuard.ThrowIfNull(personalInfo);

            PersonalInfo = personalInfo;
        }
    }
}
