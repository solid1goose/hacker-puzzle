using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testWinForms
{
    public partial class hacksClasses(string ip)
    {
        public void createHack()
        {
            switch (ip)
            {
                case "192sber": PersonalAccount = new personalAccount(); break;
                case "1488shop": OnlineStore = new onlineStore(); break;
                case "42bank": Bank = new bank(); break;
                default: break;
            }
            nowHack = ip;
        }
        public bool confirmHack(string answer)
        {
            bool anserCheck = false;
            switch (nowHack)
            {
                case "192sber": anserCheck = PersonalAccount.nextStep(answer); break;
                case "1488shop":; anserCheck = OnlineStore.nextStep(answer); break;
                case "42bank":; anserCheck = Bank.nextStep(answer); break;
                default: break;
            }
            if (anserCheck == true) return true;
            else return false;
        }
        public static void CreateFile(string fileName, string fileText)
        {
            // Получаем путь к рабочему столу
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Путь к создаваемому файлу
            string filePath = Path.Combine(desktopPath, fileName);

            try
            {
                // Создаем файл и записываем в него текст
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    writer.Write(fileText);
                }

                Console.WriteLine($"Файл успешно создан по пути: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании файла: {ex.Message}");
            }
        }


        private string nowHack;

        //ВИДЫ ВЗЛОМА


        //АККАУНТ==============================================
        private personalAccount PersonalAccount;
        private class personalAccount
        {
            private int correctHacks = 0;
            private List<char> letterList = new List<char> {'a', 'b', 'c', 'd', 'e'};
            private List<char> letterShuffleList = new List<char> { };

            private List<int> encryptionListTwo = new List<int> { 1, 1, 1, 1, 1 };
            private List<int> encryptionList = new List<int> {1, 1, 1, 1, 1 };

            private List<int> trueAnswerList = new List<int> { 1, 1, 1, 1, 1 };
            public personalAccount()
            {
                newEncryption();
            }
            public static List<T> ShuffleList<T>(List<T> list)
            {
                List<T> shuffledList = new List<T>(list);
                Random rng = new Random();
                int n = shuffledList.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    T value = shuffledList[k];
                    shuffledList[k] = shuffledList[n];
                    shuffledList[n] = value;
                }
                return shuffledList;
            }

            //новая кодировка
            private void newEncryption()
            {
                Random random = new Random();

                List<int> createEncryption(List<int> list){
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i] = random.Next(4);
                    }
                    return list;
                }

                //создаем кодировки
                createEncryption(encryptionList);
                if (correctHacks == 1) createEncryption(encryptionListTwo);
 
                letterShuffleList = ShuffleList(letterList);
                Print();

                //получаем правильный ответ
                for (int i = 0; i < letterShuffleList.Count; i++)
                {
                    char letter = letterShuffleList[i];
                    for (int j = 0; j < letterList.Count; j++)
                    {
                        if (letter == letterList[j])
                        {
                            if (correctHacks == 1) encryptionList[j] += encryptionListTwo[j];
                            trueAnswerList[i] = encryptionList[j];
                        }
                    }
                }
            }

            //выводит в консоль условия кодировки
            private void Print()
            {
                void PrintList<T>(List<T> list){
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.Write(list[i]);
                    }
                }
                Console.WriteLine("шифр пароля:");
                PrintList(letterList);
                Console.Write(":");
                PrintList(encryptionList);
                if (correctHacks > 0)
                {
                    Console.Write("+"); 
                    PrintList(encryptionListTwo);
                }
                Console.WriteLine("");
                PrintList(letterShuffleList);
                Console.Write(":?????");
            }

            //проверка ответа пользователя
            public bool nextStep(string answer)
            {
                List<int> answerList = answer.ToList().Select(c => Convert.ToInt32(c - '0')).ToList();
                if (answerList.Count == 5)
                {
                    int trueNum = 0;
                    for (int i = 0; i < answerList.Count; i++)
                    {
                        if (answerList[i] == trueAnswerList[i]) trueNum++;
                    }
                    if (trueNum == 5)
                    {
                        correctHacks++;
                        if (correctHacks == 2)
                        {
                            return true;
                        }
                        Console.WriteLine($"{correctHacks}/2 успешно!");
                        newEncryption();
                        
                        return false;
                    }
                    else
                    {
                        Console.WriteLine($"{correctHacks}/2 ошибка пароля");
                        newEncryption();
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine($"{correctHacks}/2 ошибка пароля");
                    newEncryption();
                    return false;
                };
            }
        }
        //АККАУНТ==============================================|

        //ИНТЕРНЕТ МАГАЗИН=====================================
        private onlineStore OnlineStore;
        private class onlineStore
        {
            private int correctHacks = 0;

            HackForm ShopHackForm;
            private string trueAnswer = "";

            public onlineStore()
            {
                Console.WriteLine("файл с декодировкой отправлен вам!");
                hacksClasses.CreateFile("decod.txt", "yellow: delete ll and convert w to vv\r\nblue: convert b to p and convert e to i\r\nred: plus ut and delete r");
                CreateNewForm();
                Console.WriteLine("пароль:");
            }

            private void CreateNewForm()
            {
                ShopHackForm = new HackForm();
                if (correctHacks == 0)
                {
                    trueAnswer = "yeovv";
                    ShopHackForm.BackColor = Color.Yellow;
                }
                if (correctHacks == 1)
                {
                    trueAnswer = "plui";
                    ShopHackForm.BackColor = Color.Blue;
                }
                else if (correctHacks == 2)
                {
                    trueAnswer = "edut";
                    ShopHackForm.BackColor = Color.Red;
                }
                ShopHackForm.Show();
            }

            public bool nextStep(string answer)
            {
                ShopHackForm.Close();
                if (answer == trueAnswer)
                {
                    correctHacks++;
                    if (correctHacks == 3) return true;
                    CreateNewForm();
                    Console.WriteLine($"{correctHacks}/3 успешно!");
                }
                else
                {
                    CreateNewForm();
                    Console.WriteLine($"{correctHacks}/3 ошибка пароля");
                }
                return false;
            }
        }
        //ИНТЕРНЕТ МАГАЗИН=====================================|


        //БАНК=================================================
        private bank Bank;
        private class bank
        {
            private List<HackForm> forms = new List<HackForm>();
            private List<string> symbolsList = new List<string> { "g", "b", "k", "5", "7" };

            private List<string> encryptionList = new List<string> { "а", "г", "к", "п", "ц" };
            private List<string> encryptionListTwo = new List<string> { "cos0", "7", "3^2", "6+6.4", "900"};

            int correctHacks = 0;
            string trueAnswer = "";
            public bank()
            {
                Console.WriteLine("шифр отобразился в виде окон!");
                StartNew();
                Console.WriteLine("пароль:");
            }
            private void StartNew()
            {
                symbolsList = personalAccount.ShuffleList(symbolsList);
                trueAnswer = "";
                if (correctHacks == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        HackForm form1 = new HackForm();
                        form1.Text = i.ToString();
                        form1.panelLabel.Text = symbolsList[i];
                        forms.Add(form1);
                        trueAnswer += symbolsList[i];
                    }
                }
                else if (correctHacks == 1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        HackForm form1 = new HackForm();
                        form1.Text = encryptionList[i];
                        form1.panelLabel.Text = symbolsList[i];
                        forms.Add(form1);
                        trueAnswer += symbolsList[i];
                    }
                }
                else if (correctHacks == 2)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        HackForm form1 = new HackForm();
                        form1.Text = encryptionListTwo[i];
                        form1.panelLabel.Text = symbolsList[i];
                        forms.Add(form1);
                        trueAnswer += symbolsList[i];
                    }
                }

                forms = personalAccount.ShuffleList(forms);
                foreach (HackForm form in forms) form.Show();

            }
            public bool nextStep(string answer)
            {
                if (forms.Count > 0)
                {
                    foreach (HackForm form in forms) form.Close();
                    forms.Clear();
                }
                if (answer == trueAnswer)
                {
                    correctHacks++;
                    if (correctHacks == 3) return true;
                    StartNew();
                    Console.WriteLine($"{correctHacks}/3 успешно!");
                }
                else
                {
                    StartNew();
                    Console.WriteLine($"{correctHacks}/3 ошибка пароля");
                }
                return false;
            }
        }
        //БАНК=================================================]
    }
}
