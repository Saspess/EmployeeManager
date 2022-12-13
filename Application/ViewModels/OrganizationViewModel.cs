namespace Application.ViewModels
{
    public class OrganizationViewModel
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public string DirectorName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
