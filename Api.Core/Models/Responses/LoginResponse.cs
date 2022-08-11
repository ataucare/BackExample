using Api.Core.DTOs;

namespace Api.Core.Models.Responses
{
    public class LoginResponse
    {
        public Usuario Usuario { get; set; }
        public string Token { get; set; }
        public List<Menu> Menu { get; set; }
    }
}
