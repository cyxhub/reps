using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFPro.Models
{
    public class Players
    {
        public Players()
        {
            gamePlayers = new List<GamePlayer>();
        }
        public int id { get; set; }
        [Required,MaxLength(20)]
        public string name { get; set; }
        [Column(TypeName ="date")]
        public DateTime birthDay { get; set; }
        public List<GamePlayer> gamePlayers { get; set; }
        public int resumeid { get; set; }
        public Resume resume { get; set; }
    }
    public class League
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
    }
    public class Club
    {
        public Club()
        {
            players = new List<Players>();
        }
        public int id { get; set; }
        public string name { get; set; }
        public League league { get; set; }
        public List<Players> players { get; set; }
    }
    public class GamePlayer
    {
        public int playerid { get; set; }
        public int gameid { get; set; }
        public Game game { get; set; }
        public Players player { get; set; }
    }
    public class Game
    {
        public Game()
        {
            gamePlayers = new List<GamePlayer>();
        }
        public int id { get; set; }
        public string round { get; set; }
        public DateTime? startTime { get; set; }
        public List<GamePlayer> gamePlayers { get; set; }
    }
    public class Resume
    {
        public int id { get; set; }
        public string description { get; set; }
        public int playerid { get; set; }
        public Players players { get; set; }
    }
}
