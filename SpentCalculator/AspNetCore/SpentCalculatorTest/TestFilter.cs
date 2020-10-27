using SpentCalculator.Models;
using SpentCalculator.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace SpentCalculatorTest
{
    public class Tests
    {
        [Test]
        public void TestIn()
        {
            List<Spent> spents = new List<Spent>
            {
                new Spent { SpentId = new Guid(), Name = "In", Amount = 0 },
                new Spent { SpentId = new Guid(), Name = "In", Amount = 1 },
                new Spent { SpentId = new Guid(), Name = "Out", Amount = 0 },
                new Spent { SpentId = new Guid(), Name = "Out", Amount = 1 }
            };
            IEnumerable<FilterCriteria> criterias = new List<FilterCriteria>()
            {
                new FilterCriteria { Name = "Name", Value = "In" }
            };
            IFilter<Spent> filter = FilterFactory<Spent>.Create(criterias);
            filter.Data = spents;
            Spent[] filterResult = filter.Result.ToArray();

            Assert.AreEqual(spents[0].SpentId, filterResult[0].SpentId);
            Assert.AreEqual(spents[1].SpentId, filterResult[1].SpentId);
            Assert.AreEqual(2, filterResult.Length);
        }

        [Test]
        public void TestMax()
        {
            List<Spent> spents = new List<Spent>
            {
                new Spent { SpentId = new Guid(), Amount = 501, Name = "Out" },
                new Spent { SpentId = new Guid(), Amount = 500, Name = "In" },
                new Spent { SpentId = new Guid(), Amount = 1, Name = "In" }
            };
            IEnumerable<FilterCriteria> criterias = new List<FilterCriteria>
            {
                new FilterCriteria { Name = "MaxAmount", Value = 500 }
            };
            IFilter<Spent> filter = FilterFactory<Spent>.Create(criterias);
            filter.Data = spents;
            Spent[] filterResult = filter.Result.ToArray();

            Assert.AreEqual(spents[1].SpentId, filterResult[0].SpentId);
            Assert.AreEqual(spents[2].SpentId, filterResult[1].SpentId);
            Assert.AreEqual(2, filterResult.Length);
        }

        [Test]
        public void TestMin()
        {
            List<Spent> spents = new List<Spent>
            {
                new Spent { SpentId = new Guid(), Amount = 501, Name = "In" },
                new Spent { SpentId = new Guid(), Amount = 500, Name = "In" },
                new Spent { SpentId = new Guid(), Amount = 1, Name = "Out" }
            };
            IEnumerable<FilterCriteria> criterias = new List<FilterCriteria>
            {
                new FilterCriteria { Name = "MinAmount", Value = 500 }
            };
            IFilter<Spent> filter = FilterFactory<Spent>.Create(criterias);
            filter.Data = spents;
            Spent[] filterResult = filter.Result.ToArray();

            Assert.AreEqual(spents[0].SpentId, filterResult[0].SpentId);
            Assert.AreEqual(spents[1].SpentId, filterResult[1].SpentId);
            Assert.AreEqual(2, filterResult.Length);
        }

        [Test]
        public void TestMinMax()
        {
            List<Spent> spents = new List<Spent>
            {
                new Spent { SpentId = new Guid(), Amount = 501, Name = "In" },
                new Spent { SpentId = new Guid(), Amount = 500, Name = "In" },
                new Spent { SpentId = new Guid(), Amount = 1, Name = "Out" }
            };

            IEnumerable<FilterCriteria> criterias = new List<FilterCriteria>
            {
                new FilterCriteria { Name = "MaxAmount", Value = 500 },
                new FilterCriteria { Name = "MinAmount", Value = 2 }
            };
            IFilter<Spent> filter = FilterFactory<Spent>.Create(criterias);
            filter.Data = spents;
            Spent[] filterResult = filter.Result.ToArray();

            Assert.AreEqual(spents[0].SpentId, filterResult[0].SpentId);
            Assert.AreEqual(spents[1].SpentId, filterResult[1].SpentId);
            Assert.AreEqual(2, filterResult.Length);
        }

        [Test]
        public void TestStrictAndIntervalled()
        {
            List<Spent> spents = new List<Spent>
            {
                new Spent { SpentId = new Guid(), Amount = 501, Name = "In" },
                new Spent { SpentId = new Guid(), Amount = 500, Name = "In" },
                new Spent { SpentId = new Guid(), Amount = 500, Name = "Out" },
                new Spent { SpentId = new Guid(), Amount = 501, Name = "Out" },
                new Spent { SpentId = new Guid(), Amount = 1, Name = "Out" }
            };

            IEnumerable<FilterCriteria> criterias = new List<FilterCriteria>
            {
                new FilterCriteria { Name = "MaxAmount", Value = 500 },
                new FilterCriteria { Name = "MinAmount", Value = 2 },
                new FilterCriteria { Name = "Name", Value = "In" }
            };
            IFilter<Spent> filter = FilterFactory<Spent>.Create(criterias);
            filter.Data = spents;
            Spent[] filterResult = filter.Result.ToArray();

            Assert.AreEqual(spents[0].SpentId, filterResult[0].SpentId);
            Assert.AreEqual(spents[1].SpentId, filterResult[1].SpentId);
            Assert.AreEqual(2, filterResult.Length);
        }
    }
}