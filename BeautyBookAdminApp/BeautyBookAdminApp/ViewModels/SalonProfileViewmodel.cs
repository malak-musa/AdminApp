using BeautyBookAdminApp.Services;
using BeautyBookAdminApp.Models;
using BeautyBookAdminApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using Xamarin.Essentials;

namespace BeautyBookAdminApp.ViewModels
{
    public class SalonProfileViewModel : BaseViewModel
    {
        readonly Database _firebase;
        private ObservableCollection<SalonInformationModel> _profile;
        private static string AccessToken { get; set; }

        private string _salonName;
        public string SalonName
        {
            get { return _salonName; }
            set
            {
                _salonName = value;
                OnPropertyChanged();
            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        private string _daysOff;
        public string DaysOff
        {
            get { return _daysOff; }
            set
            {
                _daysOff = value;
                OnPropertyChanged();
            }
        }

        private string _opeingHoures;
        public string OpeingHoures
        {
            get { return _opeingHoures; }
            set
            {
                _opeingHoures = value;
                OnPropertyChanged();
            }
        }

        private string _salonType;
        public string SalonType
        {
            get { return _salonType; }
            set
            {
                _salonType = value;
                OnPropertyChanged();
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

        public SalonProfileViewModel()
        {
            SetAccessToken();
            _firebase = new Database();
            Profile = new ObservableCollection<SalonInformationModel>();
            Profile = _firebase.GetSalonProfile();
            Profile.CollectionChanged += Serviceschanged;
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
                    SalonName = profilePageModel.SalonName;
                    Address = profilePageModel.Address;
                    OpeingHoures = profilePageModel.OpeningHour;
                    SalonType = profilePageModel.SalonType;
                    PhoneNumber = profilePageModel.PhoneNumber;
                }
            }
        }
    }
}
