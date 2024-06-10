namespace BreakfastMasterAPI.Models
{
    public class UserBreadRollModel
    {
        public int UserId { get; set; }
        public virtual UserModel User { get; set; }

        public int BreadRollId { get; set; }
        public virtual BreadRollModel BreadRoll { get; set; }

        public int Count { get; set; }
    }
}
