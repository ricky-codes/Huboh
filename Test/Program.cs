using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huboh.Domain.Repository;
using Huboh.Domain.Services;
using Huboh.EntityFramework.Models;
using Huboh.FolderWatcher.Watcher;

namespace Test
{
    class Program
    {

        static async Task Main(string[] args)
        {


            //FolderActivity folderActivity = new FolderActivity();
            //DatabaseActivity databaseActivity = new DatabaseActivity();

            SystemWatcher systemWatcher = new SystemWatcher("C:\\Users\\ricar\\Music\\Música", "*.mp3");

            

            //databaseActivity.DeleteSongsDb();

            //Task insertTask = databaseActivity.InsertSongsDB(folderActivity.GetFilesFromDirectory());

            //var updateTasks = new List<Task> { insertTask };
            //while (updateTasks.Count > 0)
            //{
            //    Task finishedTask = await Task.WhenAny(updateTasks);
            //    if (finishedTask == insertTask)
            //    {
            //        Console.WriteLine("Completed!!!!!!!");
            //    }
            //    updateTasks.Remove(finishedTask);
            //}

            

            //folderActivity.ChangesInFolder();
            //Displays all songs
            //foreach (var item in unitOfWork.SongRepository.GetAll())
            //{
            //    Console.WriteLine(item.musicCompletePath);
            //    //Console.WriteLine(item.artist + "   --   " + item.title);
            //}

            //Console.WriteLine("\n\n\n");


            ////Displays all playlists
            //foreach (var item in unitOfWork.PlaylistRepository.GetAll())
            //{
            //    Console.WriteLine(item.playlistName + "   --   " + item.playlistMusicCount);
            //}


            //Console.WriteLine(inserted.ToString());
            //Console.WriteLine(saved.ToString());

            Console.ReadLine();
        }
    }
}











//song songSearched = unitOfWork.SongRepository.GetByID(2).Result;
//playlist playlistToInsert = unitOfWork.PlaylistRepository.GetByID(2).Result;

//songToInsert.fileIndex = 300;
//songToInsert.title = "novoTitulo";
//songToInsert.artist = "novoArtist";
//songToInsert.albumName = "novoAlbum";
//songToInsert.sourceDirectory = "C:/";
//songToInsert.musicFilename = "esta";
//songToInsert.musicCompletePath = "C:/esta";
//songToInsert.playlist = null;

//bool inserted = unitOfWork.SongRepository.Insert(songToInsert).Result;
//bool saved = unitOfWork.Save().Result;