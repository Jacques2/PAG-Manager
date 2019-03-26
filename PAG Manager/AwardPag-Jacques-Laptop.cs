using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace PAG_Manager
{
    class AwardPag
    {
        private Dictionary<int, List<int>> relation = new Dictionary<int, List<int>>();
        private string fileLocation;
        private bool relationImported = false;

        Dictionary<int, string> yearDictionary = new Dictionary<int, string>();//These store the order in which the year tree view is built
        List<List<string>> classListSorted = new List<List<string>>();
        List<List<string>> studentListSorted = new List<List<string>>();

        Dictionary<int, List<int>> pagTreeID = new Dictionary<int, List<int>>();//These store the order for how the PAGs are built
        Dictionary<int, string> pagList = new Dictionary<int, string>();//This will contain every pag/skill name
        Dictionary<int, string> skillList = new Dictionary<int, string>();

        List<List<List<int>>> studentIDList = new List<List<List<int>>>();//The student ID list is stored here to avoid using global variables on the main class.

        public AwardPag(string inputFileLocation)
        {
            fileLocation = inputFileLocation;
        }
        public void ImportRelation(Dictionary<int, List<int>> inputRelation)
        {
            relation = inputRelation;
            relationImported = true;
        }
        public string PagLookup(int ID)
        {
            return pagList[ID];
        }
        public string SkillLookup(int ID)
        {
            return skillList[ID];
        }
        public void BuildClassTreeDictionary()
        {
            if (relationImported)
            {
                yearDictionary.Clear();
                classListSorted.Clear();
                studentListSorted.Clear();

                string lineRead;
                string[] SeperatedLine;
                ArrayList year = new ArrayList();
                List<List<string>> group = new List<List<string>>();
                List<List<string>> classList = new List<List<string>>();
                List<List<string>> studentList = new List<List<string>>();

                StreamReader sr = new StreamReader(fileLocation + "StudentRecord.csv");//opens the student record file to start reading classes and years
                lineRead = sr.ReadLine();
                while (lineRead != null)//loops through every record, adding years and classes to an arraylist
                {
                    SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                    if (year.Contains(SeperatedLine[3]) == false)//checking if value already exsists
                    {
                        year.Add(SeperatedLine[3]);
                    }
                    group.Add(new List<string> { SeperatedLine[3], SeperatedLine[4] });//build a list of lists of classes within years
                    studentList.Add(new List<string> { SeperatedLine[0], SeperatedLine[3], SeperatedLine[4], SeperatedLine[1] + " " + SeperatedLine[2] });//build a list of all students
                    lineRead = sr.ReadLine();
                }
                sr.Close();
                year.Sort();//sorting results from file alphabetically
                //Year Dictionary [Key: Position in dictionary, year value]
                for (int i = 0; i < year.Count; i++)//builds a dictionary for year group
                {
                    yearDictionary.Add(i, Convert.ToString(year[i]));
                }
                //Class 2d List [year dictionary key, class value]
                for (int i = 0; i < group.Count; i++)//builds a 2d list of all results [[year dictionary id, class]]
                {
                    var key = yearDictionary.FirstOrDefault(x => x.Value == group[i][0]).Key;//reverse dictionary lookup
                    classList.Add(new List<string> {Convert.ToString(key) , group[i][1] });
                }
                for (int i = 0; i < yearDictionary.Count; i++)//builds a blank 2d list to add
                {
                    classListSorted.Add(new List<string> { });
                }
                for (int i = 0; i < classList.Count; i++)//loops through every classList record, adding them to the sorted 2d list if they havent already been added
                {
                    if (classListSorted[Convert.ToInt32(classList[i][0])].Contains(classList[i][1]) == false)
                    {
                        classListSorted[Convert.ToInt32(classList[i][0])].Add(classList[i][1]);
                    }
                }
                for (int i = 0; i < classListSorted.Count; i++)//sorts all the class records alphabetically
                {
                    classListSorted[i].Sort();
                }
                //student 2d list [studentID, year dictionary key, class dictionary key, student name]
                for (int i = 0; i < studentList.Count; i++)
                {
                    var key = yearDictionary.FirstOrDefault(x => x.Value == studentList[i][1]).Key;//reverse dictionary lookup
                    var classPositionWithinYear = classListSorted[key].FindIndex(x => x == studentList[i][2]);//finds tree ID within 
                    studentListSorted.Add(new List<string> { studentList[i][0], Convert.ToString(key), Convert.ToString(classPositionWithinYear), studentList[i][3] });
                }
            }
        }
        public Dictionary<int, string> GetYearDictionary()
        {
            return yearDictionary;
        }
        public List<List<string>> GetClassList()
        {
            return classListSorted;
        }
        public List<List<string>> GetStudentList()
        {
            return studentListSorted;
        }
        public void BuildPagTreeDictionary()
        {
            pagList.Clear();
            skillList.Clear();

            //Reading from files and adding to arraylists
            string lineRead;
            string[] SeperatedLine;
            StreamReader sr1 = new StreamReader(fileLocation + "PagList.csv");
            lineRead = sr1.ReadLine();
            while (lineRead != null)
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                pagList.Add(Convert.ToInt32(SeperatedLine[0]), SeperatedLine[1]);
                lineRead = sr1.ReadLine();
            }
            sr1.Close();

            lineRead = "";

            StreamReader sr2 = new StreamReader(fileLocation + "SkillList.csv");
            lineRead = sr2.ReadLine();
            while (lineRead != null)
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                skillList.Add(Convert.ToInt32(SeperatedLine[0]), SeperatedLine[1]);
                lineRead = sr2.ReadLine();
            }
            sr2.Close();
            //creates blank PagID List
            pagTreeID.Clear();
            //loops through every PAG, adding it as a key to the dictionary
            for (int pag = 0; pag < pagList.Count; pag++)
            {
                if (pagTreeID.ContainsKey(pagList.ElementAt(pag).Key) == false)
                {
                    pagTreeID.Add(pagList.ElementAt(pag).Key, new List<int>());
                }
            }
            //loops through every relation adding it to the pag tree            
            for (int i = 0; i < relation.Count; i++)//i = current pag id
            {
                int pagID = relation.ElementAt(i).Key;
                for (int j = 0; j < relation.ElementAt(i).Value.Count; j++)//j = skill within a pag
                {
                    pagTreeID[pagID].Add(relation[pagID][j]);//adds the id to the ID list
                }
            }
        }
        public Dictionary<int, List<int>> GetPagTreeID()
        {
            return pagTreeID;
        }
        public Dictionary<int, string> GetPagList()
        {
            return pagList;
        }
        public void SetStudentID(List<List<List<int>>> ImportedList)
        {
            studentIDList = ImportedList;
        }
        public List<List<List<int>>> GetStudentID()
        {
            return studentIDList;
        }
        public ArrayList GetSkillPositions(int pagID)
        {
            ArrayList skillPositions = new ArrayList();
            //Creating blank array list
            for (int i = 0; i < relation[pagID].Count(); i++)
            {
                skillPositions.Add("");
            }
            string lineRead;
            string[] SeperatedLine;
            StreamReader sr = new StreamReader(fileLocation + "PagSkillRelation.csv");
            lineRead = sr.ReadLine();
            while (lineRead != null)
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                if (Convert.ToInt32(SeperatedLine[0]) == pagID)
                {
                    skillPositions[Convert.ToInt32(SeperatedLine[2])] = Convert.ToInt32(SeperatedLine[1]);
                }
                lineRead = sr.ReadLine();
            }
            sr.Close();
            return skillPositions;
        }
        public void AddPagAwards(ArrayList studentIDs, ArrayList pagsCompleted, DateTime dateCompleted, List<List<int>> skillsFailed)
        {
            //Building the skill completion colnums first so they can be easily obtained later
            ArrayList skillsCompleted = new ArrayList();
            ArrayList skillPositions = new ArrayList();
            skillsCompleted.Clear();
            for (int pag = 0; pag < pagsCompleted.Count; pag++)//loops through every PAG that has been ticked for completion
            {
                skillPositions = GetSkillPositions(Convert.ToInt32(pagsCompleted[pag]));
                skillsCompleted.Add("");
                for (int skill = 0; skill < skillPositions.Count; skill++)//loops through every skill in the list checking if it is the skills failed 2d list
                {
                    if (skillsFailed[Convert.ToInt32(pagsCompleted[pag])].Contains(Convert.ToInt32(skillPositions[skill])))
                    {
                        skillsCompleted[pag] += "1";
                    }
                    else
                    {
                        skillsCompleted[pag] += "0";
                    }
                }

                //MessageBox.Show(Convert.ToString(skillsCompleted[pag]));
            }
            //writing (appending) every record to file
            StreamWriter pagAwardFile = new StreamWriter(fileLocation + "PagAchievement.csv", append: true);
            int alreadyExist = 0;
            for (int student = 0; student < studentIDs.Count; student++)//loops through every student, adding every selected pag to the student
            {
                for (int pag = 0; pag < pagsCompleted.Count; pag++)
                {
                    if (DoesStudentHavePag(Convert.ToInt32(studentIDs[student]),Convert.ToInt32(pagsCompleted[pag])) == false)
                    {
                        pagAwardFile.WriteLine(studentIDs[student] + "," + pagsCompleted[pag] + "," + dateCompleted.Day + "/" + dateCompleted.Month + "/" + dateCompleted.Year + "," + skillsCompleted[pag]);
                    }
                    else
                    {
                        alreadyExist++;
                    }
                }
            }
            pagAwardFile.Close();
            //Message box to show it completed sucessesfully
            if (alreadyExist > 0)
            {
                MessageBox.Show("PAG Awarded.\n\n" + Convert.ToString(alreadyExist) + " students already have this PAG, their records have not been modified", "PAG Manager");
            }
            else
            {
                MessageBox.Show("PAG Awarded.", "PAG Manager");
            }
        }
        public void AddPagAbsence(ArrayList studentIDs, ArrayList pagAbsent)
        {
            //Building the skill completion colnums first so they can be easily obtained later
            ArrayList skillsAbsent = new ArrayList();
            ArrayList skillPositions = new ArrayList();
            skillsAbsent.Clear();
            for (int pag = 0; pag < pagAbsent.Count; pag++)//loops through every PAG that has been ticked for completion
            {
                skillPositions = GetSkillPositions(Convert.ToInt32(pagAbsent[pag]));
                skillsAbsent.Add("");
                for (int skill = 0; skill < skillPositions.Count; skill++)//loops through every skill in the list checking if it is the skills failed 2d list
                {
                    skillsAbsent[pag] += "2";
                }
            }
            //writing (appending) every record to file
            StreamWriter pagAwardFile = new StreamWriter(fileLocation + "PagAchievement.csv", append: true);
            for (int student = 0; student < studentIDs.Count; student++)//loops through every student, adding every selected pag to the student
            {
                for (int pag = 0; pag < pagAbsent.Count; pag++)
                {
                    pagAwardFile.WriteLine(studentIDs[student] + "," + pagAbsent[pag] + ",Absent," + skillsAbsent[pag]);
                }
            }
            pagAwardFile.Close();
        }
        //dictionary has key = pagID, value = list(studentID)
        Dictionary<int, List<int>> pagAwardList = new Dictionary<int, List<int>>();
        public void BuildPagAwardList()
        {
            pagAwardList.Clear();
            string lineRead;
            string[] SeperatedLine;
            StreamReader sr = new StreamReader(fileLocation + "PagAchievement.csv");
            lineRead = sr.ReadLine();
            while (lineRead != null)
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                int studentID = Convert.ToInt32(SeperatedLine[0]);
                int pagID = Convert.ToInt32(SeperatedLine[1]);
                if (pagAwardList.ContainsKey(pagID) == false)
                {
                    pagAwardList.Add(pagID, new List<int>());
                }
                if (pagAwardList[pagID].Contains(studentID) == false)
                {
                    pagAwardList[pagID].Add(studentID);
                }
                lineRead = sr.ReadLine();
            }
            sr.Close();
        }
        public bool DoesStudentHavePag(int studentID, int pagID)
        {
            bool containsPag = false;
            if (pagAwardList.ContainsKey(pagID))
            {
                if (pagAwardList[pagID].Contains(studentID))
                {
                    containsPag = true;
                }
            }
            return containsPag;
        }
    }
}
