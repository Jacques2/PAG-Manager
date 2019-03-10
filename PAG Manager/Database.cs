using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace PAG_Manager
{
    class Database
    {
        protected string fileLocation;
        protected ArrayList headers = new ArrayList();
        public Database()
        {
            fileLocation = AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\";
        }
        protected virtual string fileName
        {
            get
            {
                return null;
            }
        }
        public ArrayList LoadHeaders()
        {
            string lineRead;
            string[] SeperatedLine;
            headers.Clear();
            StreamReader sr = new StreamReader(fileLocation + fileName);
            lineRead = sr.ReadLine();
            while (lineRead != null)
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                headers.Add(SeperatedLine[1]);
                lineRead = sr.ReadLine();
            }
            sr.Close();
            return headers;
        }
        public ArrayList GetHeaders()
        {
            return headers;
        }
    }

    internal class SkillsDatabase : Database
    {
        protected override string fileName
        {
            get
            {
                return "SkillList.csv";
            }
        }
        public ArrayList LoadSkillData()
        {
            ArrayList tableData = new ArrayList();
            //Load every skill into a dictionary with key = skill id value = position in table
            string lineRead;
            string[] SeperatedLine;
            Dictionary<int, int> skillID = new Dictionary<int, int>();
            StreamReader sr = new StreamReader(fileLocation + fileName);
            int currentIndex = 0;//position of the column within the table
            lineRead = sr.ReadLine();
            while (lineRead != null)
            {
                currentIndex++;
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                skillID.Add(Convert.ToInt32(SeperatedLine[0]), currentIndex);
                lineRead = sr.ReadLine();
            }
            sr.Close();
            //load all student information into dictionary with key = student id value = FName LName Year Class
            Dictionary<int, Tuple<string, string, string, string>> studentInfo = new Dictionary<int, Tuple<string, string, string, string>>();
            StreamReader studentReader = new StreamReader(fileLocation + "StudentRecord.csv");
            string studentRead = studentReader.ReadLine();
            while (studentRead != null)
            {
                SeperatedLine = studentRead.Split(new[] { "," }, StringSplitOptions.None);
                studentInfo.Add(Convert.ToInt32(SeperatedLine[0]), Tuple.Create(SeperatedLine[1], SeperatedLine[2], SeperatedLine[3], SeperatedLine[4]));
                studentRead = studentReader.ReadLine();
            }
            studentReader.Close();
            //load all psr data into dictionary key = pag id value = sorted list(key = pos in dictionary value = skill ID)
            Dictionary<int, SortedList<int, int>> psrData = new Dictionary<int, SortedList<int, int>>();
            StreamReader psrReader = new StreamReader(fileLocation + "PagSkillRelation.csv");
            string psrRead = psrReader.ReadLine();
            int pagID;
            while (psrRead != null)
            {
                SeperatedLine = psrRead.Split(new[] { "," }, StringSplitOptions.None);
                pagID = Convert.ToInt32(SeperatedLine[0]);
                if (psrData.ContainsKey(pagID) == false)//Does relation already contain pag data
                {
                    psrData.Add(pagID, new SortedList<int, int>());
                }
                psrData[pagID].Add(Convert.ToInt32(SeperatedLine[2]), Convert.ToInt32(SeperatedLine[1]));
                psrRead = psrReader.ReadLine();
            }
            psrReader.Close();
            //Load all pag achivement data into a dictionary with key = student id value = Sorted list(key = skill id value = times achieved)
            Dictionary<int, SortedList<int, int>> pagRecord = new Dictionary<int, SortedList<int, int>>();
            string recordRead;
            StreamReader recordReader = new StreamReader(fileLocation + "PagAchievement.csv");
            recordRead = recordReader.ReadLine();
            while (recordRead != null)
            {
                SeperatedLine = recordRead.Split(new[] { "," }, StringSplitOptions.None);
                int currentStudentID = Convert.ToInt32(SeperatedLine[0]);
                int currentPagID = Convert.ToInt32(SeperatedLine[1]);
                string currentSkillID = SeperatedLine[3];
                if (pagRecord.ContainsKey(currentStudentID) == false)//creating student record if not exsist
                {
                    pagRecord.Add(currentStudentID, new SortedList<int, int>());
                }
                char[] skillSplit = currentSkillID.ToCharArray();
                for (int skill = 0; skill < skillSplit.Count(); skill++)//goes through each skill
                {
                    if (Convert.ToInt32(skillSplit[skill]) == Convert.ToChar('0'))//checks if skill is complete
                    {
                        if (pagRecord[currentStudentID].ContainsKey(psrData[currentPagID][skill]) == false)
                        {
                            pagRecord[currentStudentID][psrData[currentPagID][skill]] = 0;
                        }
                        pagRecord[currentStudentID][psrData[currentPagID][skill]]++;
                        //psrData[currentPagID][skill] <- the current skill
                    }
                }
                recordRead = recordReader.ReadLine();
            }
            recordReader.Close();
            //build pag data into tableData
            string lineToWriteToTable;
            for (int student = 0; student < studentInfo.Count; student++)
            {
                lineToWriteToTable = studentInfo.ElementAt(student).Key + "," + studentInfo.ElementAt(student).Value.Item1 + ',' + studentInfo.ElementAt(student).Value.Item2 + ',' + studentInfo.ElementAt(student).Value.Item3 + ',' + studentInfo.ElementAt(student).Value.Item4;
                int studentID = studentInfo.ElementAt(student).Key;
                if (pagRecord.ContainsKey(studentID))
                {
                    SortedList<int, int> skillPositionList = new SortedList<int, int>();
                    for (int i = 0; i < pagRecord[studentID].Count(); i++)
                    {
                        skillPositionList.Add(skillID[pagRecord[studentID].ElementAt(i).Key], pagRecord[studentID].ElementAt(i).Value);
                    }
                    int previousNo = 0;
                    for (int i = 0; i < skillPositionList.Count; i++)
                    {
                        int commasToAdd = skillPositionList.ElementAt(i).Key - previousNo;
                        for (int comma = 0; comma < commasToAdd; comma++)
                        {
                            lineToWriteToTable += ',';
                        }
                        previousNo = skillPositionList.ElementAt(i).Key;
                        lineToWriteToTable += skillPositionList.ElementAt(i).Value;
                    }
                    //LAST LINE IN FOR LOOP
                }
                tableData.Add(lineToWriteToTable);
            }
            //LAST LINE \/
            return tableData;
        }
    }
    internal class PagDatabase : Database
    {
        protected override string fileName
        {
            get
            {
                return "PagList.csv";
            }
        }
        public ArrayList LoadPagData()
        {
            //This converts every students pag data into an arraylist line by line, then written to a table. This is a complicated multi step process that you dont want to debug
            //STEP 1: Read every students info and put into a dictionary with key= student ID and value = (FName, LName, Year, Class)
            ArrayList tableData = new ArrayList();
            Dictionary<int, Tuple<string,string,string,string>> studentNames = new Dictionary<int, Tuple<string, string, string, string>>();//Gets every students name, year and class
            StreamReader nameReader = new StreamReader(fileLocation + "StudentRecord.csv");
            string nameRead = nameReader.ReadLine();
            string[] seperatedLine;
            while (nameRead != null)//loops reading names from file and adding them to a dictionary
            {
                seperatedLine = nameRead.Split(new[] { "," }, StringSplitOptions.None);
                studentNames.Add(Convert.ToInt32(seperatedLine[0]), Tuple.Create(seperatedLine[1], seperatedLine[2], seperatedLine[3], seperatedLine[4]));
                nameRead = nameReader.ReadLine();
            }
            nameReader.Close();
            //STEP 2: Read every pag record and store in dictionary with key = student ID and value = (dictionary with key = pag id and value = pag completion date)
            //loops reading pag dates and adding them to an list of dictionaries contained in a dictionary. very simple
            Dictionary<int, Dictionary<int,string>> pagData = new Dictionary<int, Dictionary<int, string>>();
            StreamReader pagReader = new StreamReader(fileLocation + "PagAchievement.csv");
            string pagRead = pagReader.ReadLine();
            while (pagRead != null)
            {
                seperatedLine = pagRead.Split(new[] { "," }, StringSplitOptions.None);
                if (pagData.ContainsKey(Convert.ToInt32(seperatedLine[0])) == false)//checks if the student ID key has already been added
                {
                    pagData.Add(Convert.ToInt32(seperatedLine[0]), new Dictionary<int, string>());
                }
                //modifys record to add pag achivement
                pagData[Convert.ToInt32(seperatedLine[0])].Add(Convert.ToInt32(seperatedLine[1]),seperatedLine[2]);
                //read next line
                pagRead = pagReader.ReadLine();
            }
            pagReader.Close();
            //STEP 3: Reading pag IDs from list and adding them to a dictionary, with their column position within the table
            string lineRead;
            string[] SeperatedLine;
            Dictionary<int, int> pagID = new Dictionary<int, int>();
            StreamReader sr = new StreamReader(fileLocation + fileName);
            int currentIndex = 0;//position of the column within the table
            lineRead = sr.ReadLine();
            while (lineRead != null)
            {
                currentIndex++;
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                pagID.Add(Convert.ToInt32(SeperatedLine[0]),currentIndex);
                lineRead = sr.ReadLine();
            }
            sr.Close();
            //STEP 4: building table of students into arraylist to return
            for (int student = 0; student < studentNames.Count; student++)
            {
                if (pagData.ContainsKey(studentNames.ElementAt(student).Key))
                {
                    //STEP 4A: build list of pags on record for a student
                    SortedList<int, int> pagsOnRecord = new SortedList<int, int>();
                    pagsOnRecord.Clear();
                    for (int record = 0; record < pagData[studentNames.ElementAt(student).Key].Count; record++)
                    {
                        pagsOnRecord.Add(pagID[pagData[studentNames.ElementAt(student).Key].ElementAt(record).Key],pagData[studentNames.ElementAt(student).Key].ElementAt(record).Key);
                        //pagData[studentNames.ElementAt(student).Key].ElementAt(record) <- gets pag id and date
                    }
                    //STEP 4B: Prepare the main student data to write to the table
                    string dataToWriteToTable = "";//writing student info before the rest of the pag logic
                    dataToWriteToTable += (Convert.ToString(studentNames.ElementAt(student).Key) + "," + studentNames.ElementAt(student).Value.Item1 + "," + studentNames.ElementAt(student).Value.Item2 + "," + studentNames.ElementAt(student).Value.Item3 + "," + studentNames.ElementAt(student).Value.Item4);
                    //STEP 4C: Loop through every sorted pag on record, adding them to the data to write
                    int previousNo = 0;
                    for (int i = 0; i < pagsOnRecord.Count; i++)
                    {
                        //STEP 4D: Adds additional commas if there is a gap in pag records
                        int commasToAdd = pagsOnRecord.ElementAt(i).Key - previousNo;//adds extra commas to skip over pags without a record.
                        for (int comma = 0; comma < commasToAdd; comma++)
                        {
                            dataToWriteToTable += ",";
                        }
                        previousNo = pagsOnRecord.ElementAt(i).Key;
                        //STEP 4E: Adds the dates to the dataToWriteTable
                        dataToWriteToTable += pagData[studentNames.ElementAt(student).Key][pagsOnRecord.ElementAt(i).Value];
                    }
                    //STEP 4F: Finally writes the line of data to the tabledata variable
                    tableData.Add(dataToWriteToTable);
                }
                else
                {
                    //STEP 4X: If no pag data is found, just write main student data
                    tableData.Add(Convert.ToString(studentNames.ElementAt(student).Key) + "," + studentNames.ElementAt(student).Value.Item1 + "," + studentNames.ElementAt(student).Value.Item2 + "," + studentNames.ElementAt(student).Value.Item3 + "," + studentNames.ElementAt(student).Value.Item4);//adds 5 main values without any pag info, as none is found
                }
                //studentNames.ElementAt(student).Key <- gets the current student id
            }
            return tableData;
        }
    }
}