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
    public class TestUsersService
    {
        private readonly IUsersService _userService = new UsersService(null);

        [TestMethod]
        public void AddUserTest()
        {
            Task.WaitAll(Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _userService.CreateAsync(null)));

        }

        [TestMethod]
        public void GetSingleUserTest()
        {
            Task.WaitAll(Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _userService.GetSingle(-1), "Id must be > 0"));

        }

        [TestMethod]
        public void DeleteUserIdNegativeTest()
        {
            int Id = -1;
            Task.WaitAll(Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _userService.Delete(Id)));
        }

        [TestMethod]
        public void GetAllFilterByNameTest()
        {
            string filterByName = "Mic";
            Task.WaitAll(Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _userService.GetAll(filterByName)));
        }

        [TestMethod]
        public void UpdateUserNullUserTest()
        {
            UpdateUserDto updateUser = null;  

            int Id = 1;

            Task.WaitAll(Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _userService.UpdateAsync(Id, updateUser)));
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            UpdateUserDto updateUser = new UpdateUserDto();
            updateUser.Firstname = "Ethan";

            int Id = 2147483647;

            Task.WaitAll(Assert.ThrowsExceptionAsync<NullReferenceException>(() => _userService.UpdateAsync(Id,updateUser)));
        }
    }
}