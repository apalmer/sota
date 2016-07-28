using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace test._web.Domain
{
    public class SubjectTests
    {
        [Fact]
        public void ThingGetsObjectValFromNumber()
        {
            Assert.Equal(42, new web.Domain.Subject().Get(42));
        }
    }
}
