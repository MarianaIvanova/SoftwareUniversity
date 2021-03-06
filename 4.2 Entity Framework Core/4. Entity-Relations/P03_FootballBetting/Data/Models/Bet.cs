﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Bet
    {
        //BetId, Amount, Prediction, DateTime, UserId, GameId
        public int BetId { get; set; }
        public decimal Amount { get; set; }
        [Required]
        public double Prediction { get; set; }//Possible error in Judge???
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
