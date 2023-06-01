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
        // List<PaymentPlan> paymentPlanList = new List<PaymentPlan>();
        // List<WorkDaysMerc> workDaysMercList = new List<WorkDaysMerc>();
        // List<MobileComm> mobileCommList = new List<MobileComm>();
        List<EntryGrid> entryGridList = new List<EntryGrid>();
        //List<rpt_InfProfitabilityOVL> entriesDb = new List<rpt_InfProfitabilityOVL>();

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

        //public string[] Month = new string[] { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec };

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
            //MessageBox.Show("Selected Item Text: " + comboBox1.SelectedItem.ToString() + "\n" +
             //       "Index: " + comboBox1.SelectedIndex.ToString());
            //UpdateTable(0, comboBoxYear.SelectedItem.ToString());
            //dateTime.ToString(EntryDB.dateTime);

            entryGridList.Clear();
            //entriesDb.Clear();

            using (rpt_InfProfitabilityOVLContext db = new rpt_InfProfitabilityOVLContext())
            {
                //DataGrid Grid1 = new DataGrid();
                var entriesDb = db.rpt_InfProfitabilityOVL.ToList();
                // var entrys = new EntryGrid[] 
                // { 
                //     new EntryGrid("Артем"), 
                //     new EntryGrid("Белогорск"), 
                //     new EntryGrid("Биробиджан"), 
                //     new EntryGrid("Благовещенск"), 
                //     new EntryGrid("Владивосток"), 
                //     new EntryGrid("Дальнереченск"), 
                //     new EntryGrid("Елизово"), 
                //     new EntryGrid("Комсомольск-на-Амуре"), 
                //     new EntryGrid("Магадан"), 
                //     new EntryGrid("Михайловка"), 
                //     new EntryGrid("Находка"), 
                //     new EntryGrid("П-Камчатский"), 
                //     new EntryGrid("Свободный"), 
                //     new EntryGrid("Спасск-Дальний"), 
                //     new EntryGrid("Уссурийск"), 
                //     new EntryGrid("Хабаровск"),
                //     new EntryGrid("Южно-Сахалинск")
                // };
               
                //double[] value = new double[]{0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0};
                
                for (int i = entriesDb.Count - 1; i >= 0; i--)
                {
                    if (Convert.ToString(entriesDb[i].YearEntry) != comboBoxYear.SelectedItem.ToString()) entriesDb.RemoveAt(i);
                    else
                    {
                        int _city = entriesDb[i].City;
                        int _month = entriesDb[i].MonthEntry;
                        //value[_month] = entriesDb[i].PymtPlan; 
                        //EntryGrid entryGrid = new EntryGrid();
                        //EntryGrid entryGrid = new EntryGrid[j] {new EntryGrid(city[_city])};
                        entryGridList.Add(new EntryGrid(city[_city], entriesDb[i].PymtPlan, _month));
                        //entryGrid.City = city[_city];
                        //entryGrid.
                        //entryGrid.
                        //Array.Copy( value, value.GetLowerBound(0), entryGrid.ValueMonth, entryGrid.ValueMonth.GetLowerBound(0), 1 );
                        //entryGridList.Add(entryGrid);
                    }
                }

                Grid1.ItemsSource = entryGridList;
            }
        }
                //EntryGridView[] entryGridView;
                // for (int i = entryGridView.ValueMonth.Count - 1; i >= 0; i--)
                // {
                //     entryGridView.ValueMonth[i] = 0.0;
                // }
                
                // for (int i = entriesDb.Count - 1; i >= 0; i--)
                // {
                //     int _city = entriesDb[i].City;
                //     int _month = entriesDb[i].MonthEntry;
                //     //double value = 0;
                //     //Grid1.Rows.Add(city[j], valueentriesDb[i].YearEntry)
                //     entryGridView[_city].ValueMonth[_month] += entriesDb[i].PymtPlan;
                // }
                // // private CurrencyManager currencyManager=null;
                // // currencyManager = (CurrencyManager)dataGrid1.BindingContext[entryGridView];
                //Grid1.DataSource = entryGridView;

                
                // List<EntryGridView> list = entryGridView.ToList<EntryGridView>();
                // Grid1.ItemsSource = list;

                // for (int i = 0; i < entryGridView.Count; i++)
                // {
                //     Grid1.Rows.Add
                //     (
                //         entryGridView[i].City[i], 
                //         entryGridView[i].ValueMonth[0],
                //         entryGridView[i].ValueMonth[1],
                //         entryGridView[i].ValueMonth[2],
                //         entryGridView[i].ValueMonth[3],
                //         entryGridView[i].ValueMonth[4],
                //         entryGridView[i].ValueMonth[5],
                //         entryGridView[i].ValueMonth[6],
                //         entryGridView[i].ValueMonth[7],
                //         entryGridView[i].ValueMonth[8],
                //         entryGridView[i].ValueMonth[9],
                //         entryGridView[i].ValueMonth[10],
                //         entryGridView[i].ValueMonth[11]
                //     );
                // }




        private void comboBoxTypeInfo_SelectionChanged(object sender, SelectionChangedEventArgs e) // кнопка выбора параметра
        {
            // using (rpt_InfProfitabilityOVLContext db = new rpt_InfProfitabilityOVLContext())
            // {
            //     var entriesDb = db.rpt_InfProfitabilityOVL.ToList();

            //     for (int i = entriesDb.Count - 1; i >= 0; i--)
            //     {
            //         if (Convert.ToString(entriesDb[i].YearEntry) != comboBoxYear.SelectedItem.ToString()) entriesDb.RemoveAt(i);
            //     }
            //     Grid1.ItemsSource = entriesDb;
            // }
        }
        // {
        //     // MessageBox.Show("Selected Item Text: " + comboBox2.SelectedItem.ToString() + "\n" + "Index: " + comboBox2.SelectedIndex.ToString());
        //    // UpdateTable(1, comboBoxTypeInfo.SelectedIndex.ToString());
        //    if (comboBoxTypeInfo.SelectedIndex.ToString() == "0")
        //     {
        //         foreach (string с in city)
        //         {
        //             paymentPlanList.Add(new PaymentPlan() 
        //             { 
        //                 City = с, 
        //                 Jan = valueJan, 
        //                 Feb = valueFeb, 
        //                 Mar = valueMar, 
        //                 Apr = valueApr, 
        //                 May = valueMay, 
        //                 Jun = valueJun, 
        //                 Jul = valueJul, 
        //                 Aug = valueAug, 
        //                 Sep = valueSep, 
        //                 Oct = valueOct, 
        //                 Nov = valueNov, 
        //                 Dec = valueDec 
        //             });
        //         }
        //         //Grid1.ItemsSource = paymentPlanList;
        //     }
        //     else if (omboBoxTypeInfo.SelectedIndex.ToString() == "1")
        //     {
        //         foreach (string с in city)
        //         {
        //             workDaysMercList.Add(new WorkDaysMerc() { City = с, Jan = valueJan, Feb = valueFeb, Mar = valueMar, Apr = valueApr, May = valueMay, Jun = valueJun, Jul = valueJul, Aug = valueAug, Sep = valueSep, Oct = valueOct, Nov = valueNov, Dec = valueDec });
        //         }
        //         //Grid1.Columns.Clear();
        //         //Grid1.ItemsSource = null; // пока не работает
        //         //Grid1.Items.Refresh();
        //         Grid1.ItemsSource = workDaysMercList;
        //     }
        //     else if (omboBoxTypeInfo.SelectedIndex.ToString() == "2")
        //     {
        //         foreach (string с in city)
        //         {
        //             mobileCommList.Add(new MobileComm() { City = с, Jan = valueJan, Feb = valueFeb, Mar = valueMar, Apr = valueApr, May = valueMay, Jun = valueJun, Jul = valueJul, Aug = valueAug, Sep = valueSep, Oct = valueOct, Nov = valueNov, Dec = valueDec });
        //         }
        //         //Grid1.Columns.Clear();
        //         //Grid1.ItemsSource = null; // пока не работает
        //         //Grid1.Items.Refresh();
        //         Grid1.ItemsSource = mobileCommList;
        //     }
        // }

        private void Button_Click(object sender, RoutedEventArgs e) // подключение и добавление запеисей в БД
        {
            //EntryDB entryDB = new EntryDB();
            //entryDB.
            try
            {
                using (rpt_InfProfitabilityOVLContext db = new rpt_InfProfitabilityOVLContext())
                {
                    rpt_InfProfitabilityOVL user1 = new rpt_InfProfitabilityOVL { City = 0, DateEntry = Convert.ToDateTime("2019-12-01 00:00:00.000"), YearEntry = 2019,  MonthEntry = 12, PymtPlan = 5500,  WorkDaysMerc = 10, CommServ = 1300.85};
                    rpt_InfProfitabilityOVL user2 = new rpt_InfProfitabilityOVL { City = 1, DateEntry = Convert.ToDateTime("2019-12-01 00:00:00.000"), YearEntry = 2019,  MonthEntry = 12, PymtPlan = 2300,  WorkDaysMerc = 4, CommServ = 850.50};
                    rpt_InfProfitabilityOVL user3 = new rpt_InfProfitabilityOVL { City = 2, DateEntry = Convert.ToDateTime("2019-12-01 00:00:00.000"), YearEntry = 2019,  MonthEntry = 12, PymtPlan = 4000,  WorkDaysMerc = 8, CommServ = 780};
                    rpt_InfProfitabilityOVL user4 = new rpt_InfProfitabilityOVL { City = 0, DateEntry = Convert.ToDateTime("2020-01-01 00:00:00.000"), YearEntry = 2020,  MonthEntry = 1, PymtPlan = 7000,  WorkDaysMerc = 12, CommServ = 2500};
                    rpt_InfProfitabilityOVL user5 = new rpt_InfProfitabilityOVL { City = 1, DateEntry = Convert.ToDateTime("2020-01-01 00:00:00.000"), YearEntry = 2020,  MonthEntry = 1, PymtPlan = 4600,  WorkDaysMerc = 9, CommServ = 950.85};
                    rpt_InfProfitabilityOVL user6 = new rpt_InfProfitabilityOVL { City = 2, DateEntry = Convert.ToDateTime("2020-01-01 00:00:00.000"), YearEntry = 2020,  MonthEntry = 1, PymtPlan = 5500,  WorkDaysMerc = 10, CommServ = 850};
                    rpt_InfProfitabilityOVL user7 = new rpt_InfProfitabilityOVL { City = 0, DateEntry = Convert.ToDateTime("2020-02-01 00:00:00.000"), YearEntry = 2020,  MonthEntry = 2, PymtPlan = 6200,  WorkDaysMerc = 12, CommServ = 1500.50};
                    rpt_InfProfitabilityOVL user8 = new rpt_InfProfitabilityOVL { City = 1, DateEntry = Convert.ToDateTime("2020-02-01 00:00:00.000"), YearEntry = 2020,  MonthEntry = 2, PymtPlan = 3100,  WorkDaysMerc = 6, CommServ = 1000};
                    rpt_InfProfitabilityOVL user9 = new rpt_InfProfitabilityOVL { City = 2, DateEntry = Convert.ToDateTime("2020-02-01 00:00:00.000"), YearEntry = 2020,  MonthEntry = 2, PymtPlan = 3800,  WorkDaysMerc = 7, CommServ = 1250};
                    

                    //rpt_InfProfitabilityOVL user2 = new rpt_InfProfitabilityOVL { City = "Alice", DateEntry = Convert.ToDateTime("2019-01-02 00:00:00.000") };
                
                    // добавляем их в бд
                    db.rpt_InfProfitabilityOVL.AddRange(user1, user2, user3, user4, user5, user6, user7, user8, user9);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("добавляем их в бд:" + ex.ToString());
            }
            try
            {
                using (rpt_InfProfitabilityOVLContext db = new rpt_InfProfitabilityOVLContext())
                {
                    // получаем объекты из бд 
                    var users = db.rpt_InfProfitabilityOVL.ToList();
                    //MessageBox.Show($"object: {users[0].Id} {users[0].City} {users[0].DateEntry}");
                    //Console.WriteLine("Users list:");
                    //foreach (rpt_InfProfitabilityOVL u in users)
                    //{
                    //    MessageBox.Show("object: {u.Id} {u.City} {u.DateEntry}");
                    //}
                    MessageBox.Show("object: добавил");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("получаем объекты из бд:" + ex.ToString());
            }
           


            
        }

        // void UpdateTable() // подключение к БД
        // {
        //     //tring startYear = "2019";
        //     try
        //     {
        //         using (rpt_InfProfitabilityOVLContext db = new rpt_InfProfitabilityOVLContext())
        //         {
        //             // получаем объекты из бд 
        //             var entriesDb = db.rpt_InfProfitabilityOVL.ToList();
        //             //var entriesDbSort = entriesDb;
        //             WorkDaysMerc workDaysMerc = new WorkDaysMerc();
        //             for (int i = entriesDb.Count - 1; i >= 0; i--)
        //             {

        //                 // for (int j = 1; j<12; j++)
        //                 // {
        //                 //     if (entriesDb[i].MonthEntry == j) workDaysMerc.Jan += entriesDb[i].WorkDaysMerc;
        //                 // }
        //                 // switch (entriesDb[i].MonthEntry)
        //                 // {
        //                 //     case "январь":
        //                 //         workDaysMerc.Jan += entriesDb[i].WorkDaysMerc;
        //                 //         break;
        //                 // }
        //             }

        //             if (typeComboBox == 0)
        //             {
        //                 //MessageBox.Show($"object: {entriesDb[0].Id} {entriesDb[0].City} {entriesDb[0].DateEntry}");
        //                 //Console.WriteLine("Users list:");
        //                 for (int i = entriesDbSort.Count - 1; i >= 0; i--)
        //                 {
        //                     //DateTime yearEntry = entriesDbSort[i].DateEntry;
        //                     //if (Convert.ToString(yearEntry.Year) != info) entriesDbSort.RemoveAt(i);
        //                     //if (entriesDbSort[i].YearEntry != )
        //                     // EntrySort entrySort = new EntrySort 
        //                     // { 
        //                     //     City = entriesDbSort[i].City, 
        //                     //     Year = Convert.ToString(entriesDbSort[i].DateEntry.Year),
        //                     //     Month = Convert.ToString(entriesDbSort[i].DateEntry.Month) 
        //                     // };
        //                 }
        //                 // foreach (rpt_InfProfitabilityOVL u in entriesDb)
        //                 // {
        //                 //     DateTime yearEntry = u.DateEntry;
        //                 //     if (Convert.ToString(yearEntry.Year) == typeInfo)
        //                 //     {
        //                 //         var entriesDbSort = 
        //                 //     }
        //                 //    MessageBox.Show("object: {u.Id} {u.City} {u.DateEntry}");
        //                 // }
        //                 //MessageBox.Show("object: нет");


        //                 //Grid1.Rows.Clear();
        //                 //Grid1.Columns.Clear();
        //                 //Grid1.ItemsSource = null; // пока не работает
        //                 //Grid1.Items.Refresh();
        //             }
        //             else if (typeComboBox == 1)
        //             {
        //                 for (int i = entriesDbSort.Count - 1; i >= 0; i--)
        //                 {
        //                     DateTime yearEntry = entriesDbSort[i].DateEntry;
        //                     switch(info)
        //                     {
        //                         case "1":
        //                             paymentPlanList.Add(new PaymentPlan() 
        //                             { 
        //                                 City = entriesDbSort[i].City, 
        //                                 // Year = Convert.ToString(entriesDbSort[i].DateEntry.Year),
        //                                 // Month = Convert.ToString(entriesDbSort[i].DateEntry.Month) 
        //                                 //string j = Convert.ToString(entriesDbSort[i].DateEntry.Month); 
        //                             });
        //                             break;
        //                     }
        //                     //paymentPlanList.Add(new PaymentPlan() { PartName = "crank arm", PartId = 1234 });
        //                     // PaymentPlan paymentPlan = new PaymentPlan 
        //                     // { 
        //                     //     City = entriesDbSort[i].City, 
        //                     //     Year = Convert.ToString(entriesDbSort[i].DateEntry.Year),
        //                     //     Month = Convert.ToString(entriesDbSort[i].DateEntry.Month) 
        //                     // };
        //                     // if (Convert.ToString(yearEntry.Year) != info) entriesDbSort.RemoveAt(i);
        //                 }
        //             }

        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         MessageBox.Show("Не удалось обновить данные из БД:" + ex.ToString());
        //     }
            
        // }

    }
}
