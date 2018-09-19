using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _161114_MVC_HelloWorld.Models
{

    // Model : Sadece View'ın ihtyaçlarını karşılamak için gereklidir. Entity'de hepsi varken, Model'de sadece çekmek istediklerimiz var.
    public class DummyData
    {

        static DummyData()
        {
            _players = new List<Player>();

            _players.Add(new Player() 
            { 
                Id = 1,
                FirstName = "Tsubasa",
                LastName = "Ozara" ,
                ShirtNumber = 10
            });

            _players.Add(new Player()
            {
                Id = 2,
                FirstName = "Misaki",
                LastName = "Taro",
                ShirtNumber = 8
            });

            _players.Add(new Player()
            {
                Id = 3,
                FirstName = "Hyuga",
                LastName = "Kojiro",
                ShirtNumber = 9
            });

            _players.Add(new Player()
            {
                Id = 4,
                FirstName = "Masao",
                LastName = "Tachibana",
                ShirtNumber = 6
            });

            _players.Add(new Player()
            {
                Id = 5,
                FirstName = "Kazuo",
                LastName = "Tachibana",
                ShirtNumber = 7
            });

            _players.Add(new Player()
            {
                Id = 6,
                FirstName = "Ken",
                LastName = "Wakashimazu",
                ShirtNumber = 1
            });
        }


        private static List<Player> _players;
        public static List<Player> Players
        {
            get
            {
                return _players;
            }
        }
    }
}