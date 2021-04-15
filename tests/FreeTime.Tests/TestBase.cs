using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeTime.Application.UnitTests
{
    using static TestFixture;
    public class TestBase
    {
        [SetUp]
        public async Task Setup()
        {
           await ResetState();
        }
    }
}
