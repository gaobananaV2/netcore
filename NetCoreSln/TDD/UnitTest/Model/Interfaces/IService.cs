using MockAndInject.DTO;

namespace MockAndInject.ViewModel
{
    public interface IService
    {
        UserDTO getCurrentUser();
        UserDTO postValidateUser(string userName, string passWord);
    }
}