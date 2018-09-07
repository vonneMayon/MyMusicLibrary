using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Storage.Streams;
using Windows.Storage;
using Windows.Media.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMusicLibrary
{
    /// <summary>
    /// A page allowing the user to manually upload mp3 files and album images
    /// </summary>
    public sealed partial class AddMusic : Page
    {

        public AddMusic() 
        {
            this.InitializeComponent();
        }

        //public class MediaPlayerElement : Control, IMediaPlayerElement
        private void TxtFilePath_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                TextBox tbPath = sender as TextBox;

                if (tbPath != null)
                {
                    LoadMediaFromString(tbPath.Text);
                }
            }
        }
        private void LoadMediaFromString(string path)
        {
            try
            {
                Uri pathUri = new Uri(path);
                //mediaPlayer.Source = MediaSource.CreateFromUri(pathUri);
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    // handle exception.
                    // For example: Log error or notify user problem with file
                }
            }
        }
        //Uploading Music File Button

        private async void UploadButton_Click(object sender, RoutedEventArgs e)
        {

            //Opening User's personal Music Library to select files
            var picker = new Windows.Storage.Pickers.FileOpenPicker
            {
                ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail,
                SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.MusicLibrary
            };

            //Accepted file type = mp3 (only mp3 files display for user selection)
            picker.FileTypeFilter.Add(".mp3");


            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file 

                //Storing File for future use
                Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.Add(file);

                // Open a stream for the selected file. 
                // The 'using' block ensures the stream is disposed 
                // after the music is loaded. 
                IRandomAccessStream fileStream =
                await file.OpenAsync(FileAccessMode.ReadWrite);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var album = new Album
            {
                AudioUrl = txtFilePath.Text
            };
            Album.WriteAlbums(album);

        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
