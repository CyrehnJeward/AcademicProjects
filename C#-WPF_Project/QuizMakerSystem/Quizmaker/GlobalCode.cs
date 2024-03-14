using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finals_Machine_Problem
{
    internal class GlobalCode
    {
        public static DataClassesDataContext DCCDDC = new DataClassesDataContext(Properties.Settings.Default.BT3MP1_TrialConnectionString);
        public static string nQuizNum = "";
        public static List <string> listItems = new List <string>();    
        public static Dictionary<string, string[]> Questionnaire = new Dictionary<string, string[]>(); // Questionnaire
        public static string[] STemp = new string[] { };
        public static string line = "";

        public static void Questionnares()
        {
            var ActiveQuiz = (from s in DCCDDC.viewQuestionAnswers where s.QuizID == Int32.Parse(GlobalCode.nQuizNum) select s);
            foreach (viewQuestionAnswer x in ActiveQuiz)
            {
                if (x.UserTypeID == 1)
                {
                    string[] a = { x.UserFirstName, x.UserLastName, x.QQuestion, x.QOne, x.QTwo, x.QThree, x.QFour, x.QAnswer};
                    foreach (string ar in a)
                    {
                        listItems.Add(ar);
                    }

                    listItems.Add(line);
                    STemp = line.Split(',');
                    

                    if (STemp.Length < 1)
                    {
                        break;
                    }
                    else
                    {
                        Questionnaire.Add(STemp[0], STemp);
                    }
                }
              
            }



        }
    }
}
