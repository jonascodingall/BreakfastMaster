namespace BreakfastMasterAPI.Models
{
    public class BreadRollModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }

        // Navigation property für die User
        public virtual ICollection<UserBreadRollModel> UserBreadRolls { get; set; }
    }
}
