namespace ExamenOnlineGokken.Domain.Entities
{
    public class Bet
    {
        public string Outcome { get; set; }
        public decimal BetAmount { get; set; }
        //navigation props
        public long UserId { get; set; }
        public User User { get; set; }
        public long GameId { get; set; }
        public Game Game { get; set; }
    }
}