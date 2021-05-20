using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("==================== WELCOME TO LOTTRY ====================\n" +
                       "Please first enter the username then the numbers of each user.\n" +
                       "Once you finish from entering the usernames and numbers\n" +
                       "In name entry please hit <Enter> twice! to get the rsults!\n" +
                       "Let's Go! GoodLuck!\n");

            Lotto();



            //Console.ReadLine();

        }


        public static void Lotto()
        {
            bool loop = true;
            try
            {
                string username;
                List<int> numlistinput = new List<int>();
                List<int> numlist = new List<int>();
                Random lotto = new Random();
                var lottolist = new List<int>();
                List<int> lottomatch = new List<int>();
                const string v = "";
                string usernamerow;
                string lottorow;
                string numlistrow;
                string lottomatchrow;
                string Result;
                string path = @"C:\lotto\LottoResult.txt";

                while (loop)
                {
                    numlist.Clear();
                    lottolist.Clear();
                   
                    Console.Write("Please Enter The Name: ");
                    username = Console.ReadLine();
                    if (username == v)
                    {
                        
                        break;
                    }

                    Console.Write("Chose 7 numbers Ex. 1,22,65,4 etc..: ");
                    numlistinput = Console.ReadLine().Split(',').Select(int.Parse).ToList();

                    foreach(var item in numlistinput)
                    {

                        numlist.Add(item);

                    }
                    numlist.Sort();


                    for (int i = 1; i <= 11; i++)
                    {
                        int lottonums = lotto.Next(1, 100);

                        lottolist.Add(lottonums);
                    }
                    lottolist.Sort();

                    foreach (int x in numlist)
                        foreach (int z in lottolist)
                            if (x == z)
                            {
                                lottomatch.Add(x);
                            }



                    lottorow = "\nCorrect Row!: " + String.Join(",", lottolist) + "\n";
                    usernamerow = "\n" + username + ", ";
                    numlistrow = String.Join(",", numlist) + "\t";
                    lottomatchrow = Convert.ToString(lottomatch.Count() + " Right");
                    Result = $"{lottorow} {usernamerow} {numlistrow} {lottomatchrow}";

                    
                    using (StreamWriter addTofile = new StreamWriter(path,true))
                    {
                        addTofile.WriteLine(Result + "\n==================");
                    }

                    
                    

                }
                


                using (StreamReader ReadFile = new StreamReader(path))
                {
                    Console.WriteLine(ReadFile.ReadToEnd());
                    ReadFile.Close();
                }

               

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please Enter Number (1,2..) Format!");
                return;
            }
            

            




        }

        




    }




}


