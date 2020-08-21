using ExpendituresCalculator.Models;
using ExpendituresCalculator.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpentCalculatorTest
{
    public class Tests
    {
        private List<Spent> spents;

        [SetUp]
        public void Setup()
        {
            spents = new List<Spent>
            {
                new Spent { SpentId = new Guid(), Name = "In", Amount = 0 },
                new Spent { SpentId = new Guid(), Name = "In", Amount = 1 },
                new Spent { SpentId = new Guid(), Name = "Out", Amount = 0 },
                new Spent { SpentId = new Guid(), Name = "Out", Amount = 1 }
            };
        }

        [Test]
        public void TestIn()
        {
            Filter<Spent> filter = new Filter<Spent>
            {
                Criterias = new List<FilterCriteria>()
                {
                    new FilterCriteria { Name = "Name", Value = "In" }
                },
                Data = spents
            };

            Spent[] filterResult = filter.Result.ToArray();

            Assert.AreEqual(spents[0].SpentId, filterResult[0].SpentId);
            Assert.AreEqual(spents[1].SpentId, filterResult[1].SpentId);
            Assert.AreEqual(filterResult.Length, 2);
        }
    }
}