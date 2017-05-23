using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Moq;
using Newtonsoft.Json.Linq;

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
            var item = new User();
            mockTable
                .Setup(m => m.InsertAsync(item))
                .Returns(Task.FromResult(item));
            mockClient
                .Setup(m => m.GetTable<User>())
                .Returns(mockTable.Object);
        }

        public async Task addUser(string email, string name, string deviceId)
        {
            _userTable = mockClient.Object.GetTable<User>();

            await _userTable.InsertAsync(new User
            {
                Email = email,
                Name = name,
                DeviceId = deviceId
            });
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