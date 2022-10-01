using Atata;
using AutomationTask2.Tests.PageModels;
using NUnit.Framework;
using System.Threading;

namespace AutomationTask2.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class UITestFixture
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            AtataContext.Configure().Build();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            AtataContext.Current?.CleanUp();
        }
    }
}
