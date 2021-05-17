using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Lab3
{
    class SQLAdapter
    {
        public void AddNewPlaylist()
        {
            Console.WriteLine();
            Console.Write("Enter the name for the Playlist: ");
            string valueMusic = Console.ReadLine();


            Playlist playlist = new Playlist();
            playlist.Name = valueMusic;


            using (everyloopContext context = new everyloopContext())
            {
                int ID = context.Playlists.OrderBy(x => x.PlaylistId).Last().PlaylistId + 1;
                playlist.PlaylistId = ID;

                context.Playlists.Add(playlist);
                context.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nThe playlist " + playlist.Name + " Has been added!\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                AddInstantTrack(playlist.PlaylistId);
            }

        }

        public void EditPlayList()
        {
            
            Console.WriteLine("\nAdd a track to a Playlist: 1  ");
            Console.WriteLine("Remove a track from a Playlist: 2  ");
            Console.WriteLine("Rename a Playlist: 3 ");
            Console.WriteLine("Delete Playlist: 4 ");
            Console.Write("Enter your choice: ");
            int answer = int.Parse(Console.ReadLine());

            if (answer == 1)
            {
                AddTrackToPlayList();
            }
            else if (answer == 2)
            {
                RemoveTrackInPlayList();

            }
            else if (answer == 3)
            {
                RenamePlayList();
            }
            else if (answer == 4)
            {
                DeletePlaylist();
            }


        }

        public void DeletePlaylist()
        {
            ShowPlayLists();

            Console.WriteLine();
            Console.Write("Enter the Id of the playlist you want to remove: ");
            int id = int.Parse(Console.ReadLine());
            using (everyloopContext context = new everyloopContext())
            {
                PlaylistTrack playlist = context.PlaylistTracks.FirstOrDefault(x => x.PlaylistId == id);



                var list = context.PlaylistTracks.Where(x => x.PlaylistId == playlist.PlaylistId);
                foreach (var PlaylistItem in list)
                {
                    context.PlaylistTracks.Remove(PlaylistItem);
                }

                context.SaveChanges();


                context.PlaylistTracks.Attach(playlist);
                context.PlaylistTracks.Remove(playlist);

                DeletePlaylist2(id);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The playlist " + playlist.PlaylistId + " was removed");
                Console.ForegroundColor = ConsoleColor.Gray;


            }
        
        }

        public void DeletePlaylist2(int id)
        {

            using (everyloopContext context = new everyloopContext())
            {
                Playlist playlist = context.Playlists.FirstOrDefault(x => x.PlaylistId == id);

                List<Playlist> playlists = context.Playlists.OrderBy(x => x.PlaylistId).ToList();
                if (!playlists.Contains(playlist))
                {
                    Console.WriteLine("The playlist does not exist!");
                    return;

                }
                context.SaveChanges();

                var list = context.Playlists.Where(x => x.PlaylistId == playlist.PlaylistId);
                foreach (var PlaylistItem in list)
                {
                    context.Playlists.Remove(PlaylistItem);
                }


                context.SaveChanges();

                context.Playlists.Attach(playlist);
                context.Playlists.Remove(playlist);
                                
            }
        }
        public void ShowTracks()
        {
            Console.WriteLine("\nAll songs \n");
            using (everyloopContext context = new everyloopContext())
            {
                List<Track> tracks = context.Tracks.ToList();
                foreach (var song in tracks)
                {
                    Console.WriteLine($"ID:{song.TrackId} {song.Name}");
                }
            }
        }

        public void ShowPlayLists()
        {
            Console.WriteLine("\nAll PlayLists \n");
            using (everyloopContext context = new everyloopContext())
            {
                List<Playlist> playlist = context.Playlists.ToList();
                foreach (var pl in playlist)
                {
                    Console.WriteLine($"ID:{pl.PlaylistId} {pl.Name}");
                }
            }
        }


        
        public void ShowTracksInPlayList(int id)
        {
            
            using (everyloopContext context = new everyloopContext())
            {                              

                var list = context.PlaylistTracks.Where(x => x.PlaylistId == id).AsNoTracking();

                Console.WriteLine($"\nTracks in playlistID {id}\n");
                                                                 
                foreach (var pl in list)
                {
                    
                    {
                        Console.WriteLine($"TrackID:{pl.TrackId}");
                    }
                    
                }
            }
            return;
        }
        

        public void RenamePlayList()
        {
            Console.WriteLine();
            ShowPlayLists();

            Console.Write("Enter the id of the playlist you want to rename: ");
            int chosenPlayListId = int.Parse(Console.ReadLine());

            using (everyloopContext context = new everyloopContext())
            {
                var result = context.Playlists.SingleOrDefault(playlist => playlist.PlaylistId == chosenPlayListId);
                if (result != null)
                {
                    Console.Write("Enter the new name of the playlist: ");
                    string newValue = Console.ReadLine();

                    result.Name = newValue;
                    context.SaveChanges();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nRenamed to: {newValue}\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.WriteLine("The playlist does not appear in the database");
                }

            }
        }

        public void RemoveTrackInPlayList()
        {
            ShowPlayLists();
            Console.Write("Type the id of the playlist you want to edit: ");
            int chosenPlayListId = int.Parse(Console.ReadLine());

            ShowTracksInPlayList(chosenPlayListId);

            Console.Write("Type the track Id you want to remove: ");
            int chosenTrackId = int.Parse(Console.ReadLine());

            using (everyloopContext context = new everyloopContext())
            {
                PlaylistTrack playlisttrack = context.PlaylistTracks.FirstOrDefault(x => x.TrackId == chosenTrackId && x.PlaylistId == chosenPlayListId);
                List<PlaylistTrack> PlayListId = context.PlaylistTracks.OrderBy(x => x.PlaylistId).ToList();
                List<PlaylistTrack> PlayListTrackId = context.PlaylistTracks.OrderBy(x => x.TrackId).ToList();

                if (!PlayListId.Contains(playlisttrack) && !PlayListTrackId.Contains(playlisttrack))
                {
                    Console.WriteLine("The track didn't exist in this playlist");
                    return;
                }

                var list = context.PlaylistTracks.Where(x => x.TrackId == playlisttrack.TrackId && x.PlaylistId == playlisttrack.PlaylistId);

                foreach (var item in list)
                {
                    context.PlaylistTracks.Remove(item);
                }

                context.SaveChanges();

                context.PlaylistTracks.Attach(playlisttrack);
                context.PlaylistTracks.Remove(playlisttrack);


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nTrackId {playlisttrack.TrackId} was removed\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                


            }

        }

        public void AddTrackToPlayList()
        {
            ShowPlayLists();
            Console.Write("\nType the Id of the playlist you want to edit: ");
            int chosenPlayListId = int.Parse(Console.ReadLine());

            Console.Write("Show list of tracks? Y/N: ");
            string yn = Console.ReadLine();
            if (yn == "Y" || yn == "y")
            {
                ShowTracks();
            }
            Console.Write("Type the track Id you want to add: ");
            int chosenTrackId = int.Parse(Console.ReadLine());

            PlaylistTrack playlisttrack = new PlaylistTrack();
            playlisttrack.TrackId = chosenTrackId;
            playlisttrack.PlaylistId = chosenPlayListId;

            using (everyloopContext context = new everyloopContext())
            {
                context.PlaylistTracks.Add(playlisttrack);
                context.SaveChanges();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nTrackId: {playlisttrack.TrackId} has been added\n");                 
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void AddInstantTrack(int id)
        {           

            Console.Write("Show list of tracks? Y/N: ");
            string yn = Console.ReadLine();
            if (yn == "Y" || yn == "y")
            {
                ShowTracks();
            }
            Console.Write("Type the track Id you want to add: ");
            int chosenTrackId = int.Parse(Console.ReadLine());

            PlaylistTrack playlisttrack = new PlaylistTrack();
            playlisttrack.TrackId = chosenTrackId;
            playlisttrack.PlaylistId = id;

            using (everyloopContext context = new everyloopContext())
            {
                context.PlaylistTracks.Add(playlisttrack);
                context.SaveChanges();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nTrackId: {playlisttrack.TrackId} has been added\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
