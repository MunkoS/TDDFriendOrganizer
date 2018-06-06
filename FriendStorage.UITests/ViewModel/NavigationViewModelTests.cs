using FriendStorage.UI.DataProvider;
using FriendStorage.UI.ViewModel;

using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using FriendStorage.Model;
using Prism.Events;

namespace FriendStorage.UITests.ViewModel
{
    public class NavigationViewModelTests
    {
        private NavigationViewModel _viewModel;

        public NavigationViewModelTests()
        {
            var eventAggregatorMock = new Mock<IEventAggregator>();
            var navigationDataProviderMoq = new Mock<INavigationDataProvider>();
            navigationDataProviderMoq.Setup(dp => dp.GetAllFriends())
                .Returns(new List<LookupItem>()
                {
                 new LookupItem { Id = 1, DisplayMember = "Julia" },
                new LookupItem { Id = 2, DisplayMember = "Thomas" }
            });
            _viewModel = new NavigationViewModel(
            navigationDataProviderMoq.Object,
            eventAggregatorMock.Object);
        }

        [Fact]
        public void ShouldLoadFriends()
        {
            var navigationDataProviderMoq = new Mock<INavigationDataProvider>();
            navigationDataProviderMoq.Setup(dp => dp.GetAllFriends())
                .Returns(new List<LookupItem>()
                {
                 new LookupItem { Id = 1, DisplayMember = "Julia" },
                new LookupItem { Id = 2, DisplayMember = "Thomas" }
        });
        


            _viewModel.Load();

            Assert.Equal(2, _viewModel.Friends.Count);

            var friend = _viewModel.Friends.SingleOrDefault(f => f.Id == 1);
            Assert.NotNull(friend);
            Assert.Equal("Julia", friend.DisplayMember);

            friend = _viewModel.Friends.SingleOrDefault(f => f.Id == 2);
            Assert.NotNull(friend);
            Assert.Equal("Thomas", friend.DisplayMember);
        }

        [Fact]
        public void ShouldLoadFriendsOnlyOnce()
        {
         

            _viewModel.Load();
            _viewModel.Load();

            Assert.Equal(2, _viewModel.Friends.Count);
        }
    }
  
}
