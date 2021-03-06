﻿using MyWalletProject.Infrastructure;
using MyWalletProject.Interface;
using MyWalletProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyWalletProject.ViewModel
{
    class HistoryViewModel : Notifier
    {
        public IService<History> historyService;
        ObservableCollection<History> histories = new ObservableCollection<History>();
        private bool isRefresh = false;
        public HistoryViewModel(IService<History> historyService)
        {
            this.historyService = historyService;
            GetDate();
            RefreshData = new Command(() => { GetDate(); IsRefresh = false; });
            RemoveHistory = new Command(() => { ClearAll(); Histories = null; });
        }


        #region methods
        private async void GetDate()
        {
            Histories = (await historyService.GetAll()).ToObservableCollection();
        }
        private void ClearAll()
        {
            foreach (var res in Histories)
            {
                historyService.Delete(res);
                historyService.Save();
            }
        }
        #endregion

        #region properties
        public ObservableCollection<History> Histories
        {
            get => histories;
            set
            {

                histories = value;
                Notify();

            }
        }

        public bool IsRefresh
        {
            get => isRefresh;
            set
            {
                if (value != isRefresh)
                {
                    isRefresh = value;

                    Notify();
                }

            }

        }

        #endregion

        #region commands
        public ICommand RefreshData { private set; get; }

        public ICommand RemoveHistory { private set; get; }
        #endregion



    }
}
