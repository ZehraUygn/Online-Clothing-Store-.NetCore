using AutoMapper;
using Project.Model;

namespace Project.Mappings
{
    public class UserProfile :  Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserDto>();
        }
        /* public UserProfile()
    {
       CreateMap<User, UserDTO>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
    }  */
    }
}
