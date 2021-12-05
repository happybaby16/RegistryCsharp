using System;
using System.Threading;
using System.Windows.Forms; //Для вывода MessageBox`а с датой
using Microsoft.Win32; //Содержатся классы для работы с реестром
using Registry.Model.ConsoleSettings;
using Registry.View;
using Registry.ViewModel;

namespace Registry
{

    class Program
    {
        static void FirstEx()
        {
            RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser;
            //Путь в реестре HKEY_CURRENT_USER\MyKey\MySubKey
            //Создает параметр MyValue, где храниться текущее системное время


            currentUserKey.CreateSubKey("MyKey");
            currentUserKey = currentUserKey.OpenSubKey("MyKey", true);
            currentUserKey = currentUserKey.CreateSubKey("MySubKey");
            currentUserKey.SetValue(null, "Default value");//Для изменения значения по умолчанию первым параметром указывает null
            currentUserKey.SetValue("MyValue", DateTime.Now.ToString());
            object strDateTime = currentUserKey.GetValue("MyValue");
            MessageBox.Show((string)strDateTime, "Текущее время", MessageBoxButtons.OK, MessageBoxIcon.Information);
            currentUserKey.Close();
        }
        static void Main(string[] args)
        {
            FirstEx(); //Результат выполнения первого задания

            //!!!!!!!!!!    Пусть настроек цвета консоли в реестре HKEY_CURRENT_USER\ConsoleSettings   !!!!!!!!!!!!

            //Поток для создания меню управления классом, который назначает цвет

            //В последующем, когда будут определены все настройки данную функцию можно будет удалить, а чтобы применить настройки 
            //нужно будет создать экзепляр класса ConsoleSettings cs = new ConsoleSettings() после чего все настройки будут применены
            ConsoleSettingsMenu.Worker();


            Console.ReadLine();

        }
    }
}
