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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace P_1
{
    public partial class MainWindow : Window
    {
        List<EntryGrid> entryGridList = new List<EntryGrid>();
        public string[] city = new string[] 
        {
            "Артем",                    //0
            "Белогорск",                //1
            "Биробиджан",               //2
            "Благовещенск",             //3
            "Владивосток",              //4
            "Дальнереченск",            //5
            "Елизово",                  //6
            "Комсомольск-на-Амуре",     //7
            "Магадан",                  //8
            "Михайловка",               //9
            "Находка",                  //10
            "П-Камчатский",             //11
            "Свободный",                //12
            "Спасск-Дальний",           //13
            "Уссурийск",                //14
            "Хабаровск",                //15
            "Южно-Сахалинск"            //16
        };

        public MainWindow()
        {
            InitializeComponent();

            int yearStart = 2019;
            List<int> Year = Enumerable.Range(yearStart, DateTime.Now.Year - (yearStart - 1)).ToList();
            foreach (var year in Year)
            {
                comboBoxYear.Items.Add(year);
            }

            string[] Parameter = new string[]
                {
                    "Оплата от клиентов, план",
                    "Раб. дни наёмника",
                    "Услуги связи (мобильная связь)"
                };
            foreach (var param in Parameter)
            {
                comboBoxTypeInfo.Items.Add(param);
            }

        }
        private void comboBoxYear_SelectionChanged(object sender, SelectionChangedEventArgs e) // кнопка выбора года
        {

        }               
        private void comboBoxTypeInfo_SelectionChanged(object sender, SelectionChangedEventArgs e) // кнопка выбора параметра
        {

        }
        private void ButtonUpdate_Click(object sender, RoutedEventArgs e) // обновление записей из БД в DataGrid
        {
            
            Grid1.ItemsSource = null;
            Grid1.Items.Refresh();
            entryGridList.Clear();

            using (rpt_InfProfitabilityOVLContext db = new rpt_InfProfitabilityOVLContext())
            {
                var entriesDb = db.rpt_InfProfitabilityOVL.ToList();                
                for (int i = entriesDb.Count - 1; i >= 0; i--)
                {
                    if (Convert.ToString(entriesDb[i].YearEntry) != comboBoxYear.SelectedItem.ToString()) entriesDb.RemoveAt(i);
                    else
                    {
                        int _city = entriesDb[i].City;
                        int _month = entriesDb[i].MonthEntry;
                        switch(comboBoxTypeInfo.SelectedIndex.ToString())
                        {
                            case "0":
                                entryGridList.Add(new EntryGrid(city[_city], entriesDb[i].PymtPlan, _month));
                                break;
                            case "1":
                                entryGridList.Add(new EntryGrid(city[_city], entriesDb[i].WorkDaysMerc, _month));
                                break;
                            case "2":
                                entryGridList.Add(new EntryGrid(city[_city], entriesDb[i].CommServ, _month));
                                break;
                        }
                    }
                }
                Grid1.ItemsSource = entryGridList;

            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e) // обновление записей из DataGrid в БД
        {
           // entryGridList = Grid1.ItemsSource.ToList();
            
        }

            




            //EntryDB entryDB = new EntryDB();
            //entryDB.
            // try
            // {
            //     using (rpt_InfProfitabilityOVLContext db = new rpt_InfProfitabilityOVLContext())
            //     {
            //         rpt_InfProfitabilityOVL user1 = new rpt_InfProfitabilityOVL { City = 0, DateEntry = Convert.ToDateTime("2019-12-01 00:00:00.000"), YearEntry = 2019,  MonthEntry = 12, PymtPlan = 5500,  WorkDaysMerc = 10, CommServ = 1300.85};
            //         rpt_InfProfitabilityOVL user2 = new rpt_InfProfitabilityOVL { City = 1, DateEntry = Convert.ToDateTime("2019-12-01 00:00:00.000"), YearEntry = 2019,  MonthEntry = 12, PymtPlan = 2300,  WorkDaysMerc = 4, CommServ = 850.50};
            //         rpt_InfProfitabilityOVL user3 = new rpt_InfProfitabilityOVL { City = 2, DateEntry = Convert.ToDateTime("2019-12-01 00:00:00.000"), YearEntry = 2019,  MonthEntry = 12, PymtPlan = 4000,  WorkDaysMerc = 8, CommServ = 780};
            //         rpt_InfProfitabilityOVL user4 = new rpt_InfProfitabilityOVL { City = 0, DateEntry = Convert.ToDateTime("2020-01-01 00:00:00.000"), YearEntry = 2020,  MonthEntry = 1, PymtPlan = 7000,  WorkDaysMerc = 12, CommServ = 2500};
            //         rpt_InfProfitabilityOVL user5 = new rpt_InfProfitabilityOVL { City = 1, DateEntry = Convert.ToDateTime("2020-01-01 00:00:00.000"), YearEntry = 2020,  MonthEntry = 1, PymtPlan = 4600,  WorkDaysMerc = 9, CommServ = 950.85};
            //         rpt_InfProfitabilityOVL user6 = new rpt_InfProfitabilityOVL { City = 2, DateEntry = Convert.ToDateTime("2020-01-01 00:00:00.000"), YearEntry = 2020,  MonthEntry = 1, PymtPlan = 5500,  WorkDaysMerc = 10, CommServ = 850};
            //         rpt_InfProfitabilityOVL user7 = new rpt_InfProfitabilityOVL { City = 0, DateEntry = Convert.ToDateTime("2020-02-01 00:00:00.000"), YearEntry = 2020,  MonthEntry = 2, PymtPlan = 6200,  WorkDaysMerc = 12, CommServ = 1500.50};
            //         rpt_InfProfitabilityOVL user8 = new rpt_InfProfitabilityOVL { City = 1, DateEntry = Convert.ToDateTime("2020-02-01 00:00:00.000"), YearEntry = 2020,  MonthEntry = 2, PymtPlan = 3100,  WorkDaysMerc = 6, CommServ = 1000};
            //         rpt_InfProfitabilityOVL user9 = new rpt_InfProfitabilityOVL { City = 2, DateEntry = Convert.ToDateTime("2020-02-01 00:00:00.000"), YearEntry = 2020,  MonthEntry = 2, PymtPlan = 3800,  WorkDaysMerc = 7, CommServ = 1250};
                    

            //         //rpt_InfProfitabilityOVL user2 = new rpt_InfProfitabilityOVL { City = "Alice", DateEntry = Convert.ToDateTime("2019-01-02 00:00:00.000") };
                
            //         // добавляем их в бд
            //         db.rpt_InfProfitabilityOVL.AddRange(user1, user2, user3, user4, user5, user6, user7, user8, user9);
            //         db.SaveChanges();
            //     }
            // }
            // catch (Exception ex)
            // {
            //     MessageBox.Show("добавляем их в бд:" + ex.ToString());
            // }
            // try
            // {
            //     using (rpt_InfProfitabilityOVLContext db = new rpt_InfProfitabilityOVLContext())
            //     {
            //         // получаем объекты из бд 
            //         var users = db.rpt_InfProfitabilityOVL.ToList();
            //         //MessageBox.Show($"object: {users[0].Id} {users[0].City} {users[0].DateEntry}");
            //         //Console.WriteLine("Users list:");
            //         //foreach (rpt_InfProfitabilityOVL u in users)
            //         //{
            //         //    MessageBox.Show("object: {u.Id} {u.City} {u.DateEntry}");
            //         //}
            //         MessageBox.Show("object: добавил");
            //     }
            // }
            // catch (Exception ex)
            // {
            //     MessageBox.Show("получаем объекты из бд:" + ex.ToString());
            // }
           


            
        
    }
}
