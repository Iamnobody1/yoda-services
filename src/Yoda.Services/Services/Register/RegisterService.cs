// using Yoda.Services.Data;
// using Yoda.Services.Models;

// namespace Yoda.Services.Services.Register
// {
//     public class RegisterService : IRegisterService
//     {
//         public Guid Register(RegisterModel register){
//             var user = new UserModel()
//             {
//                 ID = Guid.NewGuid(),
//                 UserName = register.UserName,
//                 Password = register.Password,
//                 DisplayName = register.DisplayName,
//                 Avatar = register.Avatar
//             };
//             if(UserData.Infos == null)
//                 UserData.Infos = new List<UserModel>();


//             UserData.Infos?.Add(user);
//             return user.ID;
//         }
//     }
// }
