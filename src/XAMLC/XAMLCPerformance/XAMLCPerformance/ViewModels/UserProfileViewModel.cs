using Xamarin.Forms;
using XAMLCPerformance.Models;
using XAMLCPerformance.Services;

namespace XAMLCPerformance.ViewModels
{
    public class UserProfileViewModel : BindableObject
    {
        private Profile _profile;

        public UserProfileViewModel()
        {
            Profile = ProfileService.Instance.GetProfile();
        }

        public Profile Profile
        {
            get { return _profile; }
            set
            {
                _profile = value;
                OnPropertyChanged();
            }
        }
    }
}