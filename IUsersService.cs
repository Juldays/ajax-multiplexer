using Models.Domain;
using Models.Requests;
using System.Collections.Generic;

namespace Services
{
    public interface IUsersService
    {
        bool LogIn(UserLogInRequest model);
        List<User> GetAll();
        int Create(UserCreateRequest model);
        void Update(UserUpdateRequest model);
        void Delete(int id);
        User GetById(int id);
        UserWithRole GetCurrentUser(int id);
        string GetProfileById(int id, int viewersUserId);
        void UpdateProfile(UserProfileUpdateRequest model);
        void LogOut();
        bool GoogleLogin(GoogleLogInRequest model);
        Dictionary<int, UserAvatarResponse> GetUserAvatarsByIds(int[] ids);
        void UpdateUserTypeId(UserTypeUpdateRequest model);
        void UpdateAvatarUrl(int id, UsersUpdateAvatarUrlRequest url);
        bool UpdatePassword(UserPasswordUpdateRequest model);
        void CreatePassword(UserPasswordUpdateRequest model);
        bool PasswordNullCheck(int userId);
        void UpdateBasicInfo(UserUpdateBasicInfoRequest model);
    }
}