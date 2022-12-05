using FastType_Koshevoi_Chernenkov.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace FastType_Koshevoi_Chernenkov.AppData
{
    class UserSession
    {
        public static void CheckRegistration(TextBox name, TextBox email, PasswordBox password)
        {
            // 1.Создать объект (на основе таблицы куда нужно добавить запись)
            Users user = new Users()
            {
                Name = name.Text,
                Email = email.Text,
                Password = password.Password
            };

            // 2. Добвавить объект в таблицу
            ModelHelper.GetContext().Users.Add(user);

            // 3. Сохранить изменения (из модели в БД)

            ModelHelper.GetContext().SaveChanges();

            // 4. Оповестить пользователя о добавлении его в БД (регистрации)

            MessageBox.Show("Пользователь зарегестрирован");
        }
    }
}
