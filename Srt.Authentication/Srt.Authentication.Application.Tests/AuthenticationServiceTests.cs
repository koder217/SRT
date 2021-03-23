using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Srt.Authentication.Models;
using Moq;
namespace Srt.Authentication.Application.Tests
{
    public class Tests
    {
        private Mock<IUsersService> mock;
        [SetUp]
        public void Setup()
        {
            mock = new Mock<IUsersService>();

        }

        [Test]
        public async Task PassValidUsernameAndPassword_ReturnsValidToken()
        {
            mock.Setup(u => u.GetUser(It.IsAny<SrtUserCredentials>())).Returns(Task.FromResult(new SrtUser() { UserName = "Sai", Password = "Raja", Email = "fake@asg.com" }));

            //arrange
            var usefService = mock.Object;
            
            //act
            AuthenticationService svc = new AuthenticationService(usefService);
            var token = await svc.AuthenticateUser(new SrtUserCredentials(){ UserName = "Sai", Password = "Raja"});
            
            //assert
            Assert.IsNotNull(token);
            Assert.IsTrue(token.Expiry > DateTime.Now);
        }


        [Test]
        public async Task PassValidUsernameAndInValidPassword_ReturnsNull()
        {
            //arrange
            mock.Setup(u => u.GetUser(It.IsAny<SrtUserCredentials>())).Returns(Task.FromResult(new SrtUser() { UserName = "Sai", Password = "Raja", Email = "fake@asg.com" }));

            var usefService = mock.Object;
            
            //act
            AuthenticationService svc = new AuthenticationService(usefService);
            var token = await svc.AuthenticateUser(new SrtUserCredentials() { UserName = "Sai", Password = "Raja1" });
            
            //assert
            Assert.IsNull(token);
        }


        [Test]
        public async Task PassInValidUsernameAndInValidPassword_ReturnsNull()
        {
            //arrange
            mock.Setup(u => u.GetUser(It.IsAny<SrtUserCredentials>())).Returns(Task.FromResult(default(SrtUser)));
            var usefService = mock.Object;

            //act
            AuthenticationService svc = new AuthenticationService(usefService);
            var token = await svc.AuthenticateUser(new SrtUserCredentials() { UserName = "Sai1", Password = "Raja1" });

            //assert
            Assert.IsNull(token);
        }
    }
}