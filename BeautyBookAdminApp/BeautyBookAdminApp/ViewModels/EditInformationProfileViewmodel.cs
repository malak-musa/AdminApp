﻿using System;
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
    public class EditInformationProfileViewModel: BaseViewModel
    {
        Database _firebase;

        private static string _accessToken { get; set; }

        public ICommand save { get; }

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
            AccessToken();
            _firebase = new Database();
            Profile = new ObservableCollection<SalonInformationModel>();
            MyProfile = new ObservableCollection<SalonInformationModel>();

            Profile = _firebase.getSalonProfile();
            Profile.CollectionChanged += Serviceschanged;
            save = new Command(onSave);
        }
        private async void AccessToken()
        {
            try{

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
                    MyProfile.Remove(profilePageModel);
                      MyProfile.Add(profilePageModel);

                }
            }
        }


        private async void onSave(object obj)
        {
            var control = obj as SalonInformationModel;
           
            await _firebase.updateProfile(control);

        }

    }



}
