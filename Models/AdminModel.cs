namespace AtlasControl.Models
{
    public class AdminModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int AdminLevelId { get; set; }
        public AdminLevelModel AdminLevel { get; set; }

    }
}
