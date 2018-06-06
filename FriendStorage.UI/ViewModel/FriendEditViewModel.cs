using FriendStorage.DataAccess;
using System;

namespace FriendStorage.UI.ViewModel
{
    public interface IFriendEditViewModel
    {
        void Load(int friendId);
    }

    public class FriendEditViewModel : ViewModelBase, IFriendEditViewModel
    {
        public FriendEditViewModel()
        {
            //FileDataService
        }
        public void Load(int friendId)
        {
            throw new NotImplementedException();
        }
    }
}
