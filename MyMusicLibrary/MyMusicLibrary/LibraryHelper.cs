using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicLibrary
{
    public static class LibraryHelper
    {
           public static async void ChooseMusic()
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
            var folder = ApplicationData.Current.LocalFolder;
                //put file in future access list so it can be accessed when application is closed and reopened
                Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.Add(file);
                //File is copied to local folder for use in music library
                if (folder != null && file != null)
                {
                    await file.CopyAsync(folder, file.Name, NameCollisionOption.GenerateUniqueName);
                }
        }
        
        //public static async void StoreMusic()
        
        //{
        //(TO DO)
        //create folder accessible to app
        //system checks if folder is already there and doesn't recreate folder if it already exists
        //move mp3 file chosen from filepicker into folder
        
        //}
        
        //public static async void GetID3Tags()
        //{
        // (TO DO)
        //definition: function to extract ID3 tags: Title, Artist, Album Name from mp3 file
        //return Title, Artist, Album Name to be used on page displaying all stored music
        //}

    }
}
