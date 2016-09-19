using MockAndInject.ViewModel;
using System;
using MockAndInject.DTO;
using Moq;
using System.Security.Principal;

namespace MockAndInject.Mock
{
    // Refer to https://github.com/Moq/moq4/wiki/Quickstart
    public class ServiceMock : IService
    {
        
        Mock<IService> _service { get; set; }

        public ServiceMock()
        {
            _service = new Mock<IService>();

            // Case 1) Use a private method of the Mock class to compute the logic 
            // Whenever the  IService.getCurrentUser()  is called, it returns what the  ServiceMock.getCurrentIdentity()  tells to
            _service.Setup(x => x.getCurrentUser()).Returns(getCurrentIdentity());

            // Case 2) Setup Mock according to the possible scenarios 
            // 
            //  - The password entered is "MoqAndNinject":  return an authenticated User, whose name is the same entered
            _service
                .Setup(x => x.postValidateUser(It.IsAny<string>(), 
                                               It.Is<string>(w => w.Equals("MoqAndNinject") )) )
                .Returns((string userName, string password) => 
                {
                    return new UserDTO(userName, true);
                });

            //  - The password entered is not "MoqAndNinject":  return a non authenticated User, whose name is "DontTryToHackMe"
            _service
                .Setup(x => x.postValidateUser(It.IsAny<string>(), 
                                               It.Is<string>(w => !w.Equals("MoqAndNinject"))))
                .Returns((string userName, string password) => 
                {
                    return new UserDTO("DontTryToHackMe", false);
                });
        }

        #region MOQ methods

        // Those methods basically tells that who ever calls the ServiceMock methods, they will return what has been setup in the  Mock<IService> class in the constructor
        public UserDTO getCurrentUser()
        {
            return _service.Object.getCurrentUser();
        }

        public UserDTO postValidateUser(string userName, string passWord)
        {
            return _service.Object.postValidateUser(userName, passWord);
        }

        #endregion

        // Private method handling the current identity retrieval
        private UserDTO getCurrentIdentity()
        {            
            return new UserDTO(WindowsIdentity.GetCurrent().Name, true);
        }

        
    }
}
