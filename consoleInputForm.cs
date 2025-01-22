using System;
using System.Collections.Generic;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace testWinForms
{
    public partial class BaseForm : Form
    {

        static Dictionary<string, string> availableIp = new Dictionary<string, string>()
        {
            {"192sber", "сбер аккаунт богатого папика"},
            {"1488shop", "счёт интернет магазина wiberize"},
            {"42bank", "счёт интернет банка Omejka" }
        };

        static Dictionary<string, int> availableItems = new Dictionary<string, int>()
        {
            {"фрукты", 5000},
            {"микроволновка", 10000},
            {"легенда", 15000},
        };

        static string selIp = "192sber";

        public int money = 0;
        static int trueHacks = 0;
        public BaseForm()
        {
            InitializeComponent();
            button1.Click += button1_click;
            Console.WriteLine("help  для получения доступных команд");
            Console.Title = "hakerConsole";
        }

        private void button1_click(object sender, EventArgs e)

        {
            if (textBox1.Text != "")
            {
                Console.Clear();
                Console.WriteLine(textBox1.Text);
                if (hacking)
                {
                    if (hack.confirmHack(textBox1.Text))
                    {
                        Console.WriteLine("взлом завершен! Деньги добавлены на счёт");
                        hacking = false;
                        trueHacks++;
                        money += 10000;
                        availableIp.Remove(selIp);
                        selIp = "";
                    }
                }
                else consoleInputHandler(textBox1.Text);
                textBox1.Text = "";
            }
        }

        //обработчик ввода в консоль
        private void consoleInputHandler(string input)
        {
            Console.WriteLine("-------------------");
            input = input.Replace(" ", "");

            //делаем массив чаров из ввода
            char[] arr = [];
            List<char> list = new List<char>(arr);
            foreach (char c in input)
            {
                list.Add(c);
            }
            arr = list.ToArray();

            if (input.Length > 2)
            {
                //собираем команду из массива
                char[] arrCharsCom = new char[3];
                Array.Copy(arr, arrCharsCom, 3);
                string com = new string(arrCharsCom);

                //если команда была - sel, то пытаемся сменить ip
                if (com == "sel")
                {
                    char[] arrCharsIp = arr.Skip(3).ToArray();
                    string ip = new string(arrCharsIp);
                    foreach (string val in availableIp.Keys)
                    {
                        if (val == ip)
                        {
                            setIp(ip);
                            return;
                        }
                    }
                    Console.WriteLine("неизвестный ip");
                    void setIp(string newIp)
                    {
                        selIp = newIp;
                        Console.WriteLine($"следующуй ip для взлома - {newIp}");
                    }
                }

                //если команда была - buy, то пытаемся купить товар
                else if (com == "buy")
                {
                    char[] arrCharsItem = arr.Skip(3).ToArray();
                    string item = new string(arrCharsItem);
                    foreach (string val in availableItems.Keys)
                    {
                        if (val == item)
                        {
                            buyItem(item);
                            return;
                        }
                    }
                    Console.WriteLine("неизвестный предмет");
                }

                //в остальных случаях пытаемся выводить другие команды
                else switch (input)
                    {
                        case "data": printData(); break;
                        case "hack": startHack(); break;
                        case "help": printHelp(); break;
                        case "avaip": printIp(); break;
                        case "shop": printTtems(); break;
                        default: printError(); break;
                    }
            }
            else printError();
        }

        private void printError()
        {
            Console.WriteLine("не известная команда, help для информации");
        }

        private void printHelp()
        {
            Console.WriteLine("data получить информацию о себе");
            Console.WriteLine("shop зайти в магазин");
            Console.WriteLine("avaip получить доступные ip для взлома");
            Console.WriteLine("hack для начала взлома");
        }

        private void printData()
        {
            Console.WriteLine($"ip следующего взлома: {selIp}");
            Console.WriteLine($"успешных взломов: {trueHacks}");
            Console.WriteLine($"денег на счету: {money}$");
        }

        private void printIp()
        {
            Console.WriteLine("доступные ip:");
            foreach (KeyValuePair<string, string> entry in availableIp)
            {
                Console.WriteLine(entry);
            }
            Console.WriteLine("для выбора ip прописать - sel нужный ip");
        }
        private void printTtems()
        {
            Console.WriteLine("доступные предметы:");
            foreach (KeyValuePair<string, int> entry in availableItems)
            {
                Console.WriteLine(entry);
            }
            Console.WriteLine("для покупки прописать - buy нужный предмет");
        }

        private void buyItem(string item)
        {
            foreach (KeyValuePair<string, int> entry in availableItems)
            {
                if (entry.Key == item)
                {
                    if (entry.Value <= money)
                    {
                        money -= entry.Value;
                        availableItems.Remove(entry.Key);
                        Console.WriteLine($"вы купили {item}, можете посмотреть в документах!");
                        createItem(item);
                    }
                    else 
                    {
                        Console.WriteLine("нет денег. Иди работай, бездарь!");
                    }
                }
            }
        }

        private void createItem(string item)
        {
            switch (item)
            {
                case "легенда": hacksClasses.CreateFile("legend.txt", "1111111111111111111111___1¶¶¶¶¶¶¶¶¶¶1__11111111111\r\n1111111111111__111111__2¶¶¶¶¶¶¶¶¶¶¶¶¶¶__1111111111\r\n111111________1_11111_2¶¶6¶¶¶¶¶¶¶¶¶¶¶¶6_1111111111\r\n11111______16¶¶1_1111_¶¶2__¶¶¶¶¶¶¶¶¶¶¶¶__111111111\r\n1111__¶2_6¶¶¶¶¶8_1111_1¶1_____16¶¶¶¶¶¶¶6_111111111\r\n111__6¶¶¶¶¶¶¶¶¶1111111_2¶¶¶2¶¶¶¶¶¶¶¶¶¶¶¶2_11111111\r\n111_1_¶¶¶1111___1111111_8¶2_61_12¶¶¶¶¶¶¶¶1_1111111\r\n1111_2¶¶¶_____1111111111_1__¶¶_2¶¶¶¶¶¶¶¶1_11111111\r\n11___¶¶¶¶6_1___111111111_6¶¶¶¶¶8¶¶¶¶¶¶¶6__11111111\r\n____1¶¶¶¶¶_1111__111111___111¶¶1¶¶¶¶¶¶¶¶2__1111111\r\n__18¶¶¶¶¶¶1228¶¶__16122221_1112¶¶¶¶¶¶¶¶2¶2___11111\r\n16¶¶¶¶¶¶¶6___1¶¶¶111268888¶¶¶¶¶¶¶¶¶¶¶6__2¶¶1__1111\r\n¶¶8¶¶¶6¶11___121111__126686682¶¶¶¶¶¶_111118¶¶__111\r\n¶¶¶¶¶¶61_8¶¶¶8¶¶¶¶¶111122621212266868¶¶¶886¶¶¶__11\r\n68¶¶862¶¶¶¶¶¶¶¶¶¶¶¶11__186_12222686212666¶¶¶¶¶6_11\r\n16¶¶¶¶¶¶8116¶¶¶¶¶¶¶1__126_166262111____1228¶6¶¶2_1\r\n1__12¶¶¶¶¶¶¶¶¶¶¶¶¶¶61111__66661__________6¶¶¶¶¶¶8_\r\n1111___28¶¶¶¶¶¶¶¶¶¶¶¶21_1211____221111___6¶¶¶¶¶¶¶_\r\n11111111_____1_____2¶¶686211_116¶¶¶888626¶¶¶¶¶¶¶¶_\r\n1111111111111111111_6¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶8¶¶¶¶¶¶¶8¶¶¶_\r\n11111111111111111111_6¶¶¶¶¶¶¶¶¶¶¶¶¶¶11______1¶¶¶¶¶\r\n111111111111111111111_1_1¶¶¶¶¶¶¶¶2112___111_18¶¶¶¶\r\n1111111111111111111111221_________122__2111_288¶¶¶\r\n11111111111111111111118¶81_____1211121_6121_18¶¶¶¶\r\n11111111121111111111112¶¶6___126262_8868161_1¶¶¶¶¶\r\n11111111112111111111111¶8¶6_121128¶8¶¶¶2_26_6¶¶¶¶¶\r\n111111111111111111111111¶¶¶¶6268¶¶¶¶21____128¶8¶¶¶\r\n11111111111111111111211_8¶2666¶¶¶¶611228¶¶¶¶86¶¶¶6\r\n11111111111111111111111111111111_____1¶¶¶¶81_8¶¶¶2\r\n21111111111111111111111111__________12622211¶¶¶¶¶_\r\n111111111111111111111111_____1288¶¶¶¶¶¶¶¶¶¶¶¶¶¶6_1\r\n111111111111111121211181_2¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶6___11\r\n111111111111111211111281__¶¶¶¶¶¶¶¶¶¶¶__111__111111\r\n212121211121112111112¶¶___¶¶¶¶¶¶¶¶¶¶¶¶_11111112111\r\n1212111122111212112¶¶¶¶¶¶866¶¶¶¶¶¶¶¶¶¶211111111111\r\n212122226662666666¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶_1111111121\r\n666666666666666628¶¶21___8¶¶¶¶¶¶¶¶¶¶¶¶¶12266666666\r\n866666666666666628¶¶_1___1¶¶¶¶¶¶¶¶¶¶¶¶¶16666666266\r\n66266666686866688281_1__18¶¶__6¶¶¶¶¶¶¶826666666666\r\n86662686112166626111_11168¶86111¶¶¶¶¶¶266666626662\r\n2611211126668826122___1686688668¶¶¶¶¶1121122126¶86\r\n2228¶¶88¶¶¶¶¶8¶6122____11_16¶¶¶¶¶¶¶¶11122268216886\r\n¶¶¶¶¶¶866¶886881161____1__16¶¶¶¶¶¶6_66662888686888\r\n8888882188866861662__1111126¶¶¶¶¶¶68888868628888¶6\r\n8868862688688862682111111116¶¶¶¶¶¶6886826¶26888661\r\n66888228¶6888862886112112226¶¶¶¶¶¶8886626266862111\r\n6668826¶688868616¶61161122268¶¶¶¶¶¶88888218¶612212\r\n688882¶8686666611¶6226226666¶¶¶¶¶¶¶688¶812¶61_1118\r\n888¶668¶¶88¶8862_¶8626226628¶¶¶¶¶¶¶886886¶6___6¶¶¶\r\n88¶¶888666¶¶8¶82_2¶66666668¶¶¶¶¶¶¶¶¶8688¶¶6112¶¶¶¶\r\n866616862888682111¶86662268¶¶¶¶¶¶¶66166861__¶¶¶¶66"); break;
                case "микроволновка": hacksClasses.CreateFile("microwave.txt", "+===================================================+\r\n[---------------------------------------------------]\r\n[-----------/===========================\\-----------]\r\n[-----------|...........................|-----------]\r\n[---[]------|.........__________........|-----------]\r\n[---[]------|........{::::::::::}.......|-----------]\r\n[-----------|.........{________}........|-----------]\r\n[-----------\\===========================/-----------]\r\n[---------------------------------------------------]\r\n+===================================================+"); break;
                case "фрукты": hacksClasses.CreateFile("fruits.txt", "_______________________$$$$$$\r\n______________________$$$$$$\r\n______________________$$$$\r\n______________________$$\r\n_________$$$$$$$$$$$$$_$$$$$$$$$$$$$\r\n______$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n____$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n___$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n__$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n_$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n_$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n_$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n_$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n__$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n___$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n____$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n_____$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n______$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n________$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n__________$$$$$$$$$$$$$$$$$$$$$$$$$\r\n____________$$$$$$$$$$$$$$$$$$$$$\r\n______________$$$$$$$$__$$$$$$$"); break;
            }
        }

        hacksClasses hack;
        private bool hacking = false;
        private void startHack()
        {
            if (selIp != "")
            {
                hacking = true;
                hack = new hacksClasses(selIp);
                hack.createHack();
            }
            else
            {
                Console.WriteLine("выберите ip для взлома (avaip)");
            }
        }
    }
}
