﻿using System;
using Test.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            NavigationPage navigation = new NavigationPage(new OperacionesView());

            MainPage = new MasterDetailPage {
                Master = new MenuView(),
                Detail = navigation
             };


            //MainPage = new MenuView();

            //MainPage = new TabbedPage().Children.Add(new MenuView();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}