using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using BeautyBookAdminApp.Models;
using BeautyBookAdminApp.Services;
using BeautyBookAdminApp.ViewModel;
using Xamarin.Essentials;

namespace BeautyBookAdminApp.ViewModels
{
    public class EditInformationProfileViewModel: BaseViewModel
    {
        Database _firebase;
        private ObservableCollection<SalonInformationModel> _profile;
        private static string _accessToken { get; set; }

        public EditInformationProfileViewModel()
        {
            AccessToken();
            _firebase = new Database();
            Profile = new ObservableCollection<SalonInformationModel>();
            Profile = _firebase.getSalonProfile();
            Profile.CollectionChanged += Serviceschanged;
        }
        private async void AccessToken()
        {
            try
            {
                _accessToken = await SecureStorage.GetAsync("oauth_token");
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
                if (profilePageModel.UserId==_accessToken)
                {
                      Profile.Add(profilePageModel);
                }
            }
        }
    }



}
