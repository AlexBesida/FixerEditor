﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AtlassEditor.FileEditors
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditSettings : Page
    {
        public EditSettings()
        {
            this.InitializeComponent();

            var full = (ApplicationView.GetForCurrentView().IsFullScreenMode);
            var left = 12 + (full ? 0 : Windows.ApplicationModel.Core.CoreApplication.GetCurrentView().TitleBar.SystemOverlayLeftInset);
            AppTitle.Margin = new Thickness(left, 8, 0, 0);
            AppTitle.Text = "File Settings";

            FileName.Text = AppVar.FileNameEdit;
            if (AppVar.FileTypeEdit == FileTypes.HtmlFile)
                FileType.SelectedIndex = 1;
            else
                FileType.SelectedIndex = 0;

        }

        private async void BackButton(object sender, RoutedEventArgs e)
        {
            AppVar.FileNameEdit = FileName.Text;
            string FileTypeString;
            if (FileType.SelectedIndex == 1)
            {
                AppVar.FileTypeEdit = FileTypes.HtmlFile;
                FileTypeString = ".html";
            }
            else
            {
                AppVar.FileTypeEdit = FileTypes.TextFile;
                FileTypeString = ".txt";
            }

            if (LaterCheckBox.IsChecked == false)
            {
                //Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                //Windows.Storage.StorageFile NewFile = await storageFolder.CreateFileAsync(AppVar.FileNameEdit + FileTypeString, Windows.Storage.CreationCollisionOption.ReplaceExisting);
                await HtmlFile.File.RenameAsync(AppVar.FileNameEdit + FileTypeString);
            }
            Frame.Navigate(typeof(HtmlFile));
        }
        
    }
}
