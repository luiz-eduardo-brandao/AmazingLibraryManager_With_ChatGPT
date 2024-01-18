using AmazingLibraryManager.Users.Application.InputModels;
using AmazingLibraryManager.Users.Core.Entities;

namespace AmazingLibraryManager.Users.Application.MappingExtensions
{
    public static class UserExtensions
    {
        public static User ToUser(this AddUserInputModel addUserInputModel) 
        {
            ArgumentNullException.ThrowIfNull(addUserInputModel);

            return new User(addUserInputModel.Name, addUserInputModel.Email, addUserInputModel.PhoneNumber);
        }

        public static AddUserInputModel ToAddUserInputModel(this User user) 
        {
            ArgumentNullException.ThrowIfNull(user);

            return new AddUserInputModel {
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}