using System.Text;

using Microsoft.Azure.ServiceBus;
using Moq;
using Newtonsoft.Json;
using Xunit;

using DotNetCoreKatas.Command.Adapter.Contracts;
using DotNetCoreKatas.Command.Contracts;
using DotNetCoreKatas.Core.Interfaces.Commanding;

namespace DotNetCoreKatas.Command.Adapter.UnitTests.Adapters
{
    public class AzureServiceBusCommandAdapterUnitTests
    {
        private static class Factory
        {
            internal static AzureServiceBusCommandAdapter New()
            {
                Mock<IQueueClient> queueClient = new Mock<IQueueClient>();
                return new AzureServiceBusCommandAdapter(queueClient.Object);
            }
        }

        [Fact]
        public void BooksCommandAdapter_ShouldDispatch()
        {
            // Arrange
            Mock<IQueueClient> queueClient = new Mock<IQueueClient>();
            ICommand command = new RegisterBookCommand();
            var payload = JsonConvert.SerializeObject(command);
            var messageBytes = Encoding.UTF8.GetBytes(payload);
            //queueClient.Setup(_ => _.SendAsync(It.IsAny<Message>()));
            queueClient.Setup(_ => _.SendAsync(It.Is<Message>(m => m.Body.Length == messageBytes.Length)));
            IAzureServiceBusCommandAdapter commandAdapter = new AzureServiceBusCommandAdapter(queueClient.Object);
            
            // Act
            commandAdapter.Dispatch(command);

            // Assert
            queueClient.VerifyAll();
        }
    }
}
