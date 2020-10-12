using Api.DTO;
using Api.Models;
using Api.Repositories.Interfaces;
using Api.Services;
using Api.Services.Interfaces;
using Api.UnitTests.MockData;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace Api.UnitTests.Services
{
    [TestClass]
    public class UserServiceTests
    {
        #region Test Variables
        private IUserService _userService;
        private Mock<IUserRepository> _mockUserRepository;
        private IMapper _mapper;
        #endregion

        #region Test Init
        [TestInitialize]
        public void TestSetUp()
        {

            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
            _mockUserRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mockUserRepository.Object, _mapper);
        }
        #endregion


        #region Unit Tests
        [DataTestMethod]
        [DataRow("", 1, 2)]
        [TestCategory("Unit Test"), TestCategory("Users"), TestCategory("Success")]
        public void GetUsers_WithSearchString_ReturnsListOfUsers(string searchString, int pageIndex, int pageSize)
        {
            // Arrange
            var users = UserMocks.GetUsers();
            var searchParams = new SearchUsersParams()
            {
                SearchString = searchString,
                PageIndex = pageIndex,
                PageSize  = pageSize
            };
            var result = new Page<User>()
            {
                Items = users,
                PageCount = 1,
                TotalCount = 1,
                CurrentPage = 1
            };

            var searchParamsDto = new SearchUserParamsDto()
            {
                SearchString = searchString,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            _ = _mockUserRepository.Setup(x => x.GetUsers(It.IsAny<SearchUsersParams>())).ReturnsAsync(result);

            // Act
            var response =  _userService.GetUsers(searchParamsDto).Result;
            var items = response.Items.ToList();

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(items[0].Name, "John");
            Assert.AreEqual(result.Items.Count(), users.Count());
        }

        [DataTestMethod]
        [DataRow(2)]
        [TestCategory("Unit Test"), TestCategory("Users"), TestCategory("Success")]
        public void GetUser_ById_ReturnsUser(int userId)
        {
            // Arrange
            var users = UserMocks.GetUsers();

            _ = _mockUserRepository.Setup(x => x.GetUser(It.IsAny<int>())).ReturnsAsync(users[1]);

            // Act
            var response = _userService.GetUser(userId).Result;

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Surname, "Santana");
        }

        [TestMethod]
        [TestCategory("Unit Test"), TestCategory("Users"), TestCategory("Success")]
        public void CreateUser_ReturnsCreatedUser()
        {
            // Arrange
            var userData = new UserDto
            {
                Name = "TestName",
                Surname = "TestSurname",
                BirthDate = DateTime.Parse("1982-7-20"),
                UserTypeId = 1,
                UserTitleId = 1,
                EmailAddress = "testuser@example.com",
                IsActive = true
            };

            var newUser = new User
            {
                Name = "TestName",
                Surname = "TestSurname",
                BirthDate = DateTime.Parse("1982-7-20"),
                UserTypeId = 1,
                UserTitleId = 1,
                EmailAddress = "testuser@example.com",
                IsActive = true
            };

            _ = _mockUserRepository.Setup(x => x.CreateUser(It.IsAny<User>())).ReturnsAsync(newUser);

            // Act
            var response = _userService.CreateUser(userData).Result;

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Surname, "TestSurname");
        }

        [TestMethod]
        [TestCategory("Unit Test"), TestCategory("Users"), TestCategory("fail")]
        public void CreateUser_WithNullData_ThrowsArgumentNullException()
        {
            // Arrange
            UserDto userData = null;

            // Act
            var ex = Assert.ThrowsExceptionAsync<ArgumentNullException>(
              () => _userService.CreateUser(userData));

            // Assert
            _ = ex.Result.Should().BeOfType(typeof(ArgumentNullException));
        }

        #endregion
    }
}
