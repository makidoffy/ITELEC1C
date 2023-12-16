
using Microsoft.AspNetCore.Identity;

namespace QuiselITELEC1C.Data
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
