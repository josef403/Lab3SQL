using Lab3.Models;
using System;




namespace Lab3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Menu();

        }


        public void Menu()
        {
            Boolean menu = true;
            while (menu)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("--        MusicDataBase          --");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Here you can Add/Edit/Remove Playlists!");
                Console.WriteLine("Add Playlist: 1  ");
                Console.WriteLine("Edit Playlist: 2 ");
                Console.WriteLine("Delete Playlist: 3 ");
                Console.WriteLine("Show Tracks: 4 ");
                Console.WriteLine("Quit: -1");
                Console.WriteLine("");
                Console.Write("Enter your  choice: ");
                int value = int.Parse(Console.ReadLine());
                SQLAdapter sQlAdapter = new SQLAdapter();
                switch (value)
                {
                    case 1:
                        sQlAdapter.AddNewPlaylist();
                        break;
                    case 2:
                        sQlAdapter.EditPlayList();
                        break;
                    case 3:
                        sQlAdapter.DeletePlaylist();
                        break;
                    case 4:
                        sQlAdapter.ShowTracks();
                        break;
                    case -1:
                        menu = false;
                        break;
                }
            }
        }



        

    }
}



