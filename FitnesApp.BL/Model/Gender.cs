using System;

namespace FitnesApp.BL.Model
{
    [Serializable]
    /// <summary>
    /// Пол.
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Название пола.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name"> Название пола. </param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя пола не может пыть пустым!", nameof(name));
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
