using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Input;
using BeautyBookAdminApp.Models;
using BeautyBookAdminApp.Services;
using BeautyBookAdminApp.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BeautyBookAdminApp.ViewModels
{
    public class EditInformationProfileViewModel : BaseViewModel
    {
        readonly Database _firebase;
        private static string AccessToken { get; set; }
        public ICommand Save { get; }
        public IList<SalonInformationModel> SalonCollection { get; set; }
        private ObservableCollection<SalonInformationModel> _myprofile;
        private ObservableCollection<SalonInformationModel> _profile;
        
        public ObservableCollection<SalonInformationModel> MyProfile
        {
            get { return _myprofile; }
            set
            {
                _myprofile = value;
                OnPropertyChanged();
            }
        }
        
        public EditInformationProfileViewModel()
        {
            SetAccessToken();
            _firebase = new Database();
            Profile = new ObservableCollection<SalonInformationModel>();
            MyProfile = new ObservableCollection<SalonInformationModel>();
            Profile = _firebase.GetSalonProfile();
            Profile.CollectionChanged += Serviceschanged;
            Save = new Command(OnSave);

            SalonCollection = new ObservableCollection<SalonInformationModel>
            {
                new SalonInformationModel { SalonType = "Men's Salon" },
                new SalonInformationModel { SalonType = "Women's Salon" },
                new SalonInformationModel { SalonType = "Unisex Salon" }
            };
        }

        private async void SetAccessToken()
        {
            try
            {
                AccessToken = await SecureStorage.GetAsync("oauth_token");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public ObservableCollection<SalonInformationModel> Profile
        {
            get { return _profile; }
            set
            {
                _profile = value;
                OnPropertyChanged();
            }
        }

        private void Serviceschanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                SalonInformationModel profilePageModel = e.NewItems[0] as SalonInformationModel;

                if (profilePageModel.UserId == AccessToken)
                {
                    MyProfile.Remove(profilePageModel);
                    MyProfile.Add(profilePageModel);
                }
            }
        }

        private async void OnSave(object obj)
        {
            var control = obj as SalonInformationModel;

            await _firebase.UpdateProfile(control);
        }
    }
}
