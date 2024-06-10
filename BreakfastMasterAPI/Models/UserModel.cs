namespace BreakfastMasterAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property für die Gruppe
        public int GroupId { get; set; }
        public virtual GroupModel Group { get; set; }

        // Navigation property für die BreadRolls
        public virtual ICollection<UserBreadRollModel> UserBreadRolls { get; set; }
    }
}
