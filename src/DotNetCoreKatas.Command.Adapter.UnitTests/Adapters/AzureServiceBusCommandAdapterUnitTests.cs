using Xunit;

using DotNetCoreKatas.Command.Adapter.Contracts;
using DotNetCoreKatas.Command.Contracts;
using DotNetCoreKatas.Core.Interfaces.Commanding;
//using Microsoft.ServiceBus.Messaging;

namespace DotNetCoreKatas.Command.Adapter.UnitTests.Adapters
{
    public class AzureServiceBusCommandAdapterUnitTests
    {
        private static class Factory
        {
            internal static AzureServiceBusCommandAdapter New()
            {
                //QueueClient queueClient = new QueueClient();
                return new AzureServiceBusCommandAdapter();
            }
        }

        [Fact]
        public void BooksCommandAdapter_ShouldDispatch()
        {
            // Arrange
            //IAzureServiceBusCommandAdapter commandAdapter = new AzureServiceBusCommandAdapter();
            IAzureServiceBusCommandAdapter commandAdapter = Factory.New();
            ICommand command = new RegisterBookCommand();

            // Act
            commandAdapter.Dispatch(command);

            // Assert
        }
    }
}
