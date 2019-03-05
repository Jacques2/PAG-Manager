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
    class StudentLookup
    {
        private string fileLocation { get; set; }
        private ArrayList studentNames;
        private ArrayList namePosition;
        public bool LoadState { get; set; } = false;//This is used to stop auto colouring of cells when the table loads
        ArrayList fullNamePositions = new ArrayList();
        Dictionary<int, Dictionary<int, Dictionary<int, string>>> studentInfo = new Dictionary<int, Dictionary<int, Dictionary<int, string>>>();
        Dictionary<int, int> skillLookup = new Dictionary<int, int>();
        Dictionary<int, int> pagLookup = new Dictionary<int, int>();
        bool unsavedChanges = false;
        //tuple contains <studentID, pagID, date, int>
        ArrayList changes = new ArrayList();
        List<int> pagsWithData = new List<int>();
        public int ReversePagLookup(int position)
        {
            int pagID = pagLookup.FirstOrDefault(x => x.Value == position).Key;
            return pagID;
        }
        public int ReverseSkillLookup(int position)
        {
            int skillID = skillLookup.FirstOrDefault(x => x.Value == position).Key;
            return skillID;
        }
        public void SetUnsavedChanges(bool change)
        {
            unsavedChanges = change;
        }
        public bool GetUnsavedChanges()
        {
            return unsavedChanges;
        }
        public StudentLookup(string FileLocation)
        {
            fileLocation = FileLocation;
        }
        public ArrayList LoadNames()//This happens once at the start of the program
        {
            string lineRead;
            string[] SeperatedLine;
            ArrayList names = new ArrayList();
            StreamReader sr = new StreamReader(fileLocation + "StudentRecord.csv");//opens the student record file to start reading names
            lineRead = sr.ReadLine();
            while (lineRead != null)//loops through every record, adding names to an arraylist
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                names.Add(SeperatedLine[1] + " " + SeperatedLine[2] + " - " +  SeperatedLine[4]);
                fullNamePositions.Add(SeperatedLine[0]);
                lineRead = sr.ReadLine();
            }
            studentNames = names;
            namePosition = fullNamePositions;
            sr.Close();
            return names;
        }
        public ArrayList FilterNames(string filter)
        {
            ArrayList filteredNames = new ArrayList();
            ArrayList namePositions = new ArrayList();
            for (int i = 0; i < studentNames.Count; i++)//loops through every record, checking if the string specified matches the record
            {
                if (Convert.ToString(studentNames[i]).ToLower().Contains(filter.ToLower()))
                {
                    filteredNames.Add(studentNames[i]);
                    namePositions.Add(fullNamePositions[i]);//adds the index of each entry in a seperate arraylist
                }
            }
            namePosition = namePositions;
            return filteredNames;
        }
        public int GetStudentPosition(int posInList)
        {
            return Convert.ToInt32(namePosition[posInList]);
        }
        public void BuildLookupData()
        {
            //Builds Dictionary with key = skillID, value = Position - Used for LookupStudent()
            skillLookup.Clear();
            StreamReader skillReader = new StreamReader(fileLocation + "SkillList.csv");
            string[] seperatedLine;
            string skillLineRead = skillReader.ReadLine();
            int index = -1;
            while (skillLineRead != null)
            {
                seperatedLine = skillLineRead.Split(new[] { "," }, StringSplitOptions.None);//decomposes the line into seperate variables
                index++;
                skillLookup.Add(Convert.ToInt32(seperatedLine[0]), index);
                skillLineRead = skillReader.ReadLine();
            }
            //Builds Dictionary with key = pagID, value = Position - Used for LookupStudent()
            pagLookup.Clear();
            StreamReader pagReader = new StreamReader(fileLocation + "PagList.csv");
            string pagLineRead = pagReader.ReadLine();
            index = 0;
            pagLookup.Add(-999, 0);
            while (pagLineRead != null)
            {
                seperatedLine = pagLineRead.Split(new[] { "," }, StringSplitOptions.None);//decomposes the line into seperate variables
                index++;
                pagLookup.Add(Convert.ToInt32(seperatedLine[0]), index);
                pagLineRead = pagReader.ReadLine();
            }
            //Reads all skill and pag info into a relations dictionary with key = pagId, value = (sorted list with key = skill position value = skillID)
            Dictionary<int, SortedList<int, int>> relations = new Dictionary<int, SortedList<int, int>>();
            StreamReader relationReader = new StreamReader(fileLocation + "PagSkillRelation.csv");
            string relationLineRead;
            relationLineRead = relationReader.ReadLine();
            while (relationLineRead != null)
            {
                seperatedLine = relationLineRead.Split(new[] { "," }, StringSplitOptions.None);//decomposes the line into seperate variables
                int pagID = Convert.ToInt32(seperatedLine[0]);
                int skillID = Convert.ToInt32(seperatedLine[1]);
                int skillPosition = Convert.ToInt32(seperatedLine[2]);
                if (relations.ContainsKey(pagID) == false)//creates new entry for pag if no exist
                {
                    relations.Add(pagID, new SortedList<int, int>());
                }
                relations[pagID].Add(skillPosition, skillID);
                relationLineRead = relationReader.ReadLine();
            }
            //puts all student info into a dictionary with key = studentID value = (Dictionary key = PagID value = (Dictionary key = SkillID value = record))
            studentInfo.Clear();
            StreamReader studentReader = new StreamReader(fileLocation + "PagAchievement.csv");
            string studentLineRead;
            studentLineRead = studentReader.ReadLine();
            while (studentLineRead != null)
            {
                seperatedLine = studentLineRead.Split(new[] { "," }, StringSplitOptions.None);//decomposes the line into seperate variables
                int studentID = Convert.ToInt32(seperatedLine[0]);
                int pagID = Convert.ToInt32(seperatedLine[1]);
                string date = seperatedLine[2];
                string combinedSkills = seperatedLine[3];
                char[] seperatedSkills = combinedSkills.ToCharArray();
                if (studentInfo.ContainsKey(studentID) == false)//creates new entry for student if not exist
                {
                    studentInfo.Add(studentID,new Dictionary<int, Dictionary<int, string>>());
                }
                if (studentInfo[studentID].ContainsKey(pagID) == false)//creates new entry for pag within student if not exist
                {
                    studentInfo[studentID].Add(pagID,new Dictionary<int, string>());
                }
                for (int skill = 0; skill < seperatedSkills.Count(); skill++)
                {
                    string skillStatus;
                    switch (Convert.ToString(seperatedSkills[skill]))
                    {
                        case "0":
                            skillStatus = "Not Achieved";
                            break;
                        case "1":
                            skillStatus = "Achieved";
                            break;
                        case "2":
                            skillStatus = "Absent";
                            break;
                        default:
                            skillStatus = "?";
                            break;
                    }
                    studentInfo[studentID][pagID].Add(relations[pagID][skill],skillStatus);
                }
                studentInfo[studentID][pagID].Add(-999, date);
                studentLineRead = studentReader.ReadLine();
            }
        }
        public List<Tuple<int, int, string>> LookupStudent(int studentID)
        {
            List<Tuple<int, int, string>> lookupData = new List<Tuple<int, int, string>>();
            if (studentInfo.ContainsKey(studentID))
            {
                for (int record = 0; record < studentInfo[studentID].Count; record++)
                {
                    for (int skill = 0; skill < studentInfo[studentID].ElementAt(record).Value.Count; skill++)
                    {//adds skill position, pag position and text to list
                        lookupData.Add(new Tuple<int, int, string>(pagLookup[studentInfo[studentID].ElementAt(record).Value.ElementAt(skill).Key], pagLookup[studentInfo[studentID].ElementAt(record).Key], studentInfo[studentID].ElementAt(record).Value.ElementAt(skill).Value));
                    }
                }
            }
            return lookupData;
        }
        public int LevenshteinDistance(string s, string t)
        {//This works out the edit distance between two strings, how many insertions, deletions, modifications and swaps are required to make one string equal to another. Used for student lookup
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];
            if (n == 0)
            {
                return m;
            }
            if (m == 0)
            {
                return n;
            }
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }
            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),d[i - 1, j - 1] + cost);
                }
            }
            return d[n, m];
        }
        public void ResetChanges()
        {
            changes.Clear();
        }
        public void AddChange(int column)
        {
            if (changes.Contains(column) == false)
            {
                changes.Add(column);
            }
        }
        public ArrayList GetChanges()
        {
            return changes;
        }
        public void ClearPagsWithData()
        {
            pagsWithData.Clear();
        }
        public void AddPagWithData(int position)
        {
            if (pagsWithData.Contains(position) == false)
            {
                pagsWithData.Add(position);
            }
        }
        public bool DoesPagWithDataContain(int position)
        {
            if (pagsWithData.Contains(position))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
