using FitnesApp.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnesApp.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height)
        {

            Gender gender = new Gender(genderName);
            User = new User(userName, gender, birthDate, weight, height);
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var fomatter = new BinaryFormatter();
            using(var fs = new FileStream("usres.dat", FileMode.OpenOrCreate))
            {
                fomatter.Serialize(fs, User);
            }
        }

        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns></returns>
        public UserController()
        {
            var fomatter = new BinaryFormatter();
            using (var fs = new FileStream("usres.dat", FileMode.OpenOrCreate))
            {
                if (fomatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                //TODO: Что делать если пользователя не прочитали.
            }
        }
    }
}
