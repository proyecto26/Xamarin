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
            mockClient = new Mock<IMobileServiceClient>(MockBehavior.Strict);
            mockTable = new Mock<IMobileServiceTable<User>>(MockBehavior.Strict);

            mockTable
                .Setup(m => m.InsertAsync(It.IsAny<User>()))
                .Returns(Task.Delay(5000));
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

                return true;
            }
            catch
            {
                return false;
            }
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