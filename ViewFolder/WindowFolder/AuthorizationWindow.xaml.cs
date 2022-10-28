using Authorization.ModelFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Authorization.ViewFolder.WindowFolder
{
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            AppConnectClass.DataBase = new DBEntities(); // Подключаем БД к этуму окну
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == "" &&
                PasswordPasswordBox.Password == "")
            {
                MessageBox.Show("!ПОЛЯ НЕ ДОЛЖНЫ БЫТЬ ПУСТЫМИ");
            } // Проверка полей на пустоту
            else
            {
                try // метод, если мы хотим делать проверку по "LoginUser" и "PasswordUser"
                {
                    var user = AppConnectClass.DataBase.UserTable.FirstOrDefault(
                        data => data.LoginUser == LoginTextBox.Text &&
                                data.PasswordUser == PasswordPasswordBox.Password);
                    // Производим проверку введённых данных по атрибутам "LoginUser" и "PasswordUser"

                    if (user == null)
                    {
                        MessageBox.Show("Вас нет в системе");
                    }
                    // Если нет не одного пользователя с таким логином и паролем
                    else
                    {
                        switch (user.RoleUser) // Проверяем какая роль у пользователя
                        {
                            case 1: // Если ID роли 1 ТО:
                                MessageBox.Show("Добро пожаловать АДМИНИСТАТОР");
                                break;
                            case 2: // Если ID роли 2 ТО:
                                MessageBox.Show("Добро пожаловать ПОЛЬЗОВАТЕЛЬ");
                                break;

                            default: //Если роли нет или она другая то:
                                MessageBox.Show("У вас нет доступа в эту систему");
                                break;
                        }
                    }
                }
                catch (Exception ex) // Проверка на ошибки Ex
                {
                    MessageBox.Show("ERROR EX");
                }

                /// try   // метод, если мы хотим делать проверку по "IdUser" и ...
                /// {
                ///   int _id = Convert.ToInt32(LoginTextBox.Text);
                ///   var user = AppConnectClass.DataBase.UserTable.FirstOrDefault(
                ///       data => data.IdUser == _id &&
                ///       data.PasswordUser == PasswordPasswordBox.Password);
                ///   // Производим проверку введённых данных по атрибутам "IdUser" и "PasswordUser"

                ///  if (user == null)
                ///  {
                ///     MessageBox.Show("Вас нет в системе");
                ///  } // Если нет не одного пользователя с таким логином и паролем
                ///  else
                ///  {
                ///    switch (user.RoleUser) // Проверяем какая роль у пользователя
                ///     {
                ///            case 1: // Если ID роли 1 ТО:
                ///                 MessageBox.Show("Добро пожаловать АДМИНИСТАТОР");
                ///             break;
                ///            case 2: // Если ID роли 2 ТО:
                ///                 MessageBox.Show("Добро пожаловать ПОЛЬЗОВАТЕЛЬ");
                ///             break;
                ///
                ///            default: //Если роли нет или она другая то:
                ///                 MessageBox.Show("У вас нет доступа в эту систему");
                ///             break;
                ///             
                ///     }
                ///  }
                ///  catch (Exception ex)
                ///   {
                ///      MessageBox.Show("ERROR EX");
                ///   }
}
        }
    }
}
