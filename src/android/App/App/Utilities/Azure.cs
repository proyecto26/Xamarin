using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Moq;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace App.Utilities
{
    public class ServiceHelper
    {
        private IMobileServiceTable<User> _userTable;
        //MobileServiceClient client = new MobileServiceClient(@"http://my-website.azurewebsites.net/");
        private Mock<IMobileServiceClient> mockClient;
        private Mock<IMobileServiceTable<User>> mockTable;

        public ServiceHelper()
        {
            mockClient = new Mock<IMobileServiceClient>(MockBehavior.Loose);
            mockTable = new Mock<IMobileServiceTable<User>>(MockBehavior.Loose);
            var item = new User();
            mockTable
                .Setup(m => m.InsertAsync(item))
                .Returns(() =>
                {
                    Thread.Sleep(10000);
                    return Task.CompletedTask;
                });
            mockClient
                .Setup(m => m.GetTable<User>())
                .Returns(mockTable.Object);
        }

        public async Task<bool> addUser(string email, string name, string deviceId)
        {
            try
            {
                _userTable = mockClient.Object.GetTable<User>();

                await _userTable.InsertAsync(new User
                {
                    Email = email,
                    Name = name,
                    DeviceId = deviceId
                });
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
    }
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string DeviceId { get; set; }

    }
}