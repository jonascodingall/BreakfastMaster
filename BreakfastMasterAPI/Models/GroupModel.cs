namespace BreakfastMasterAPI.Models
{
    public class GroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property für die User
        public virtual ICollection<UserModel> Users { get; set; }
    }
}
