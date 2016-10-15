using GuildSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GuildSystemTests.GuildSystemTests
{
    public class MyGuildTests
    {
        MyGuild _testGuild;

        public MyGuildTests()
        {
            _testGuild = MyGuild.CreateNewMyGuild("TestGuild", new Gamer(new GamerInfo { Name = "Ivan", LastName = "Ivanov", Age = 18, Country = "Russia", Gender = "male" }));
        }

        [Fact]
        public void TryAddMembersNullArgsTest()
        {
            Assert.False(_testGuild.TryAddMembers(null));
        }

        [Fact]
        public void TryAddUninvitedMembersTest()
        {
            Gamer someGamer = new Gamer(new GamerInfo { Name = "Jill", LastName = "Anderson", Age = 25, Country = "USA", Gender = "female" });

            Assert.False(_testGuild.TryAddMembers(someGamer));
        }

        [Fact]
        public void TryAddInvitedMembersTest()
        {
            Gamer someGamer = new Gamer(new GamerInfo { Name = "Jill", LastName = "Anderson", Age = 25, Country = "USA", Gender = "female" });

            _testGuild.TryInviteNewMembers((x) => true,someGamer);

            Assert.True(_testGuild.TryAddMembers(someGamer));
        }
    }
}
