using System;
using System.Threading.Tasks;
using Epsic_Cave_A_Vin_Ethan.Exceptions;
using Epsic_Cave_A_Vin_Ethan.Models;
using Epsic_Cave_A_Vin_Ethan.Services;
using Epsic_Cave_A_Vin_Ethan.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epsic_Cave_A_Vin_Ethan.Tests
{
    [TestClass]
    public class TestBottlesService
    {
        private readonly IBottlesService _bottleService = new BottlesService(null);

        [TestMethod]
        public void AddBottleTest()
        {
            Task.WaitAll(Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _bottleService.CreateAsync(null)));
        }

        [TestMethod]
        public void GetSingleBottleTest()
        {
            Task.WaitAll(Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _bottleService.GetSingle(-1), "Id must be > 0"));
        }

        [TestMethod]
        public void DeleteBottleIdNegativeTest()
        {
            int Id = -1;
            Task.WaitAll(Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _bottleService.Delete(Id)));
        }

        [TestMethod]
        public void GetAllFilterByNameTest()
        {
            string filterByName = "Upt";
            Task.WaitAll(Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _bottleService.GetAll(filterByName)));
        }

        [TestMethod]
        public void UpdateBottleNullBottleTest()
        {
            UpdateBottleDto updateBottle = null;  

            int Id = 1;

            Task.WaitAll(Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _bottleService.UpdateAsync(Id, updateBottle)));
        }

        [TestMethod]
        public void UpdateBottleTest()
        {
            UpdateBottleDto updateBottle = new UpdateBottleDto();
            updateBottle.Name = "Champ";

            int Id = 2147483647;

            Task.WaitAll(Assert.ThrowsExceptionAsync<NullReferenceException>(() => _bottleService.UpdateAsync(Id,updateBottle)));
        }
    }
}