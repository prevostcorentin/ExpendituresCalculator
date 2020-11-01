using ExpendituresCalculator.Models;
using ExpendituresCalculator.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpendituresCalculatorTest
{
    public class Tests
    {
        private List<Expenditure> _expenditures;

        [Test]
        public void TestStrictIn()
        {
            _expenditures = new List<Expenditure>
            {
                new Expenditure { ExpenditureId = new Guid(), Name = "In", Amount = 0 },
                new Expenditure { ExpenditureId = new Guid(), Name = "In", Amount = 1 },
                new Expenditure { ExpenditureId = new Guid(), Name = "Out", Amount = 0 },
                new Expenditure { ExpenditureId = new Guid(), Name = "Out", Amount = 1 }
            };

            IEnumerable<FilterCriteria> criterias = new List<FilterCriteria>()
            {
                new FilterCriteria { Name = "Name", Value = "In" }
            };
            IFilter<Expenditure> filter = FilterFactory<Expenditure>.Create(criterias);
            filter.Data = _expenditures;

            AssertFiltered(filter.Result);
        }

        [Test]
        public void TestOnlyMax()
        {
            _expenditures = new List<Expenditure>
            {
                new Expenditure { ExpenditureId = new Guid(), Amount = 501F, Name = "Out" },
                new Expenditure { ExpenditureId = new Guid(), Amount = 500F, Name = "In" },
                new Expenditure { ExpenditureId = new Guid(), Amount = 1F, Name = "In" }
            };

            IEnumerable<FilterCriteria> criterias = new List<FilterCriteria>
            {
                new FilterCriteria { Name = "MaxAmount", Value = 500.0F}
            };
            IFilter<Expenditure> filter = FilterFactory<Expenditure>.Create(criterias);
            filter.Data = _expenditures;

            AssertFiltered(filter.Result);
        }

        [Test]
        public void TestOnlyMin()
        {
            _expenditures = new List<Expenditure>
            {
                new Expenditure { ExpenditureId = new Guid(), Amount = 501F, Name = "Out" },
                new Expenditure { ExpenditureId = new Guid(), Amount = 500F, Name = "In" },
                new Expenditure { ExpenditureId = new Guid(), Amount = 1F, Name = "In" }
            };

            IEnumerable<FilterCriteria> criterias = new List<FilterCriteria>
            {
                new FilterCriteria { Name = "MinAmount", Value = 500F }
            };
            IFilter<Expenditure> filter = FilterFactory<Expenditure>.Create(criterias);
            filter.Data = _expenditures;

            AssertFiltered(filter.Result);
        }

        [Test]
        public void TestMinMax()
        {
            _expenditures = new List<Expenditure>
            {
                new Expenditure { ExpenditureId = new Guid(), Amount = 501F, Name = "Out" },
                new Expenditure { ExpenditureId = new Guid(), Amount = 500F, Name = "In" },
                new Expenditure { ExpenditureId = new Guid(), Amount = 1F, Name = "In" }
            };

            IEnumerable<FilterCriteria> criterias = new List<FilterCriteria>
            {
                new FilterCriteria { Name = "MaxAmount", Value = 500F },
                new FilterCriteria { Name = "MinAmount", Value = 2F }
            };
            IFilter<Expenditure> filter = FilterFactory<Expenditure>.Create(criterias);
            filter.Data = _expenditures;

            AssertFiltered(filter.Result);
        }

        [Test]
        public void TestStrictAndIntervalled()
        {
            _expenditures = new List<Expenditure>
            {
                new Expenditure { ExpenditureId = new Guid(), Amount = 501F, Name = "Out" },
                new Expenditure { ExpenditureId = new Guid(), Amount = 500F, Name = "In" },
                new Expenditure { ExpenditureId = new Guid(), Amount = 500F, Name = "Out" },
                new Expenditure { ExpenditureId = new Guid(), Amount = 501F, Name = "Out" },
                new Expenditure { ExpenditureId = new Guid(), Amount = 1F, Name = "Out" }
            };

            IEnumerable<FilterCriteria> criterias = new List<FilterCriteria>
            {
                new FilterCriteria { Name = "MaxAmount", Value = 500F },
                new FilterCriteria { Name = "MinAmount", Value = 2F },
                new FilterCriteria { Name = "Name", Value = "In" }
            };
            IFilter<Expenditure> filter = FilterFactory<Expenditure>.Create(criterias);
            filter.Data = _expenditures;

            AssertFiltered(filter.Result);
        }

        private void AssertFiltered(IEnumerable<Expenditure> filtered)
        {
            IEnumerable<Expenditure> ins = _expenditures.Where(e => e.Name == "In");
            IEnumerable<Expenditure> outs = _expenditures.Except(ins);
            Assert.AreEqual(ins.Count(), filtered.Count());
            Assert.AreEqual(0, filtered.Intersect(outs).Count());
        }
    }
}