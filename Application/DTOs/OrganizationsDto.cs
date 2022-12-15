using Application.ViewModels;

namespace Application.DTOs
{
    public class OrganizationsDto
    {
        public string Name { get; set; }
        public IEnumerable<OrganizationViewModel> Organizations { get; set; }

        public OrganizationsDto(IEnumerable<OrganizationViewModel> organizationsViewModels)
        {
            Organizations = organizationsViewModels;
        }
    }
}
