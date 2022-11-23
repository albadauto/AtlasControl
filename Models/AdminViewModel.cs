namespace AtlasControl.Models
{
    public class AdminViewModel
    {
        public List<AdminLevelModel> Level { get; set; }
        public AdminModel Admin { get; set; }
        public string AdminLevelName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

    }
}
