using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MyMusicLibrary
{
    public static class LibraryHelper
    {
        public static async void ChooseMusicAsync()
        {
           //Music Library is opened on user's computer and displays all available mp3 files

                var picker = new Windows.Storage.Pickers.FileOpenPicker
                {
                    ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail,
                    SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.MusicLibrary
                };

                picker.FileTypeFilter.Add(".mp3");
                picker.FileTypeFilter.Add(".mp4");
                picker.FileTypeFilter.Add(".m4a");

            var file = await picker.PickSingleFileAsync();
            var folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                //put file in future access list so it can be accessed when application is closed and reopened
                Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.Add(file);
                //File is copied to local folder for use in music library
                if (folder != null && file != null)
                {
                    await file.CopyAsync(folder, file.Name, NameCollisionOption.GenerateUniqueName);
                }
        }


    }
}
