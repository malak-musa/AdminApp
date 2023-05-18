using BeautyBookAdminApp.Models;
using BeautyBookAdminApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BeautyBookAdminApp.ViewModels
{
    public class AddServicesViewModel
    {
        ObservableCollection<Service> services;
        Service service;
        SalonInformationModel salonModel = new SalonInformationModel();
        Database _userDB = new Database();

        public AddServicesViewModel() 
        {
            
        }

    }
}
