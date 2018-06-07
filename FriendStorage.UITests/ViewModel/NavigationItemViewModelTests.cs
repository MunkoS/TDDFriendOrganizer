using System.Linq;
using Moq;
using Xunit;
using FriendStorage.Model;
using Prism.Events;

using FriendStorage.UI.Events;
using FriendStorage.UI.ViewModel;
namespace FriendStorage.UITests.ViewModel
{
    public class NavigationItemViewModelTests
    {
        [Fact]
        public void ShouldPublishOpenFriendEditViewEvent()
        {
            const int friendId = 7;
            var eventMock = new Mock<OpenFriendEditViewEvent>();
            var eventAggregatorMock = new Mock<IEventAggregator>();
            eventAggregatorMock
                .Setup(ea => ea.GetEvent<OpenFriendEditViewEvent>())
                .Returns(eventMock.Object);

            var viewModel = new NavigationItemViewModel(friendId,
                "Sergey",
                eventAggregatorMock.Object);
            viewModel.OpenFriendEditViewCommand.Execute(null);

            eventMock.Verify(e => e.Publish(friendId),Times.Once);

        }
    }
}
