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
        ArrayList studentNames = new ArrayList();
        ArrayList namePosition = new ArrayList();
        public bool LoadState { get; set; } = false;//This is used to stop auto colouring of cells when the table loads
        ArrayList fullNamePositions = new ArrayList();
        Dictionary<int, Dictionary<int, Tuple<Dictionary<int, string>,int>>> studentInfo = new Dictionary<int, Dictionary<int, Tuple<Dictionary<int, string>, int>>>();
        Dictionary<int, int> skillLookup = new Dictionary<int, int>();
        Dictionary<int, int> pagLookup = new Dictionary<int, int>();
        Dictionary<int, SortedList<int, int>> relations = new Dictionary<int, SortedList<int, int>>();
        bool unsavedChanges = false;
        //tuple contains <studentID, pagID, date, int>
        ArrayList changes = new ArrayList();
        List<int> pagsWithData = new List<int>();
        int currentStudentID;
        public StudentLookup(string FileLocation)//class inititalisation
        {
            fileLocation = FileLocation;
        }
        public int ReversePagLookup(int position)//gets the id of a pag when given the position within the list
        {
            int pagID = pagLookup.FirstOrDefault(x => x.Value == position).Key;
            return pagID;
        }
        public int ReverseSkillLookup(int position)//gets the id of a skill when given the position within the list
        {
            int skillID = skillLookup.FirstOrDefault(x => x.Value == position).Key;
            return skillID;
        }
        public int LookupSkill(int id)//gets the position of the skill when given the id
        {
            return skillLookup[id];
        }
        public int LookupPagPosition(int id)//gets the position of the pag when given the id
        {
            return pagLookup[id];
        }
        public void SetUnsavedChanges(bool change)//sets wether there are saved changes or not
        {
            unsavedChanges = change;
        }
        public bool GetUnsavedChanges()//gets wether there are saved changes or not 
        {
            return unsavedChanges;
        }
        public ArrayList LoadNames()//This happens when all data is reloaded
        {
            string lineRead;
            string[] seperatedLine;
            fullNamePositions.Clear();
            namePosition.Clear();
            ArrayList names = new ArrayList();
            StreamReader sr = new StreamReader(fileLocation + "StudentRecord.csv");//opens the student record file to start reading names
            lineRead = sr.ReadLine();
            while (lineRead != null)//loops through every record, adding names to an arraylist
            {
                seperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                names.Add(seperatedLine[1] + " " + seperatedLine[2] + " - " +  seperatedLine[4]);
                fullNamePositions.Add(seperatedLine[0]);
                lineRead = sr.ReadLine();
            }
            studentNames = names;
            namePosition = fullNamePositions;
            sr.Close();
            return names;
        }
        public ArrayList FilterNames(string filter)//filter the list of names and return them as an arraylist
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
        public int GetStudentPosition(int posInList)//gets the student id when given the position in the list
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
            skillReader.Close();
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
            pagReader.Close();
            //Reads all skill and pag info into a relations dictionary with key = pagId, value = (sorted list with key = skill position value = skillID)
            relations.Clear();
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
            relationReader.Close();
            //puts all student info into a dictionary with key = studentID value = (Dictionary key = PagID value = tuple(Dictionary key = SkillID value = record), fileLine)
            studentInfo.Clear();
            StreamReader studentReader = new StreamReader(fileLocation + "PagAchievement.csv");
            string studentLineRead;
            studentLineRead = studentReader.ReadLine();
            int currentLine = 0;
            while (studentLineRead != null)
            {
                currentLine++;
                seperatedLine = studentLineRead.Split(new[] { "," }, StringSplitOptions.None);//decomposes the line into seperate variables
                int studentID = Convert.ToInt32(seperatedLine[0]);
                int pagID = Convert.ToInt32(seperatedLine[1]);
                string date = seperatedLine[2];
                string combinedSkills = seperatedLine[3];
                char[] seperatedSkills = combinedSkills.ToCharArray();
                if (studentInfo.ContainsKey(studentID) == false)//creates new entry for student if not exist
                {
                    studentInfo.Add(studentID,new Dictionary<int, Tuple<Dictionary<int, string>, int>>());
                }
                if (studentInfo[studentID].ContainsKey(pagID) == false)//creates new entry for pag within student if not exist
                {
                    studentInfo[studentID].Add(pagID,new Tuple<Dictionary<int, string>, int>(new Dictionary<int, string>(),currentLine));
                }
                for (int skill = 0; skill < seperatedSkills.Count(); skill++)
                {
                    string skillStatus;
                    switch (Convert.ToString(seperatedSkills[skill]))
                    {
                        case "0":
                            skillStatus = "Achieved";
                            break;
                        case "1":
                            skillStatus = "Not Achieved";
                            break;
                        case "2":
                            skillStatus = "Absent";
                            break;
                        default:
                            skillStatus = "";
                            break;
                    }
                    if (studentInfo[studentID][pagID].Item1.ContainsKey(relations[pagID][skill]) == false)
                    {
                        studentInfo[studentID][pagID].Item1.Add(relations[pagID][skill], skillStatus);
                    }
                }
                if (studentInfo[studentID][pagID].Item1.ContainsKey(-999) == false)
                {
                    studentInfo[studentID][pagID].Item1.Add(-999, date);
                }
                studentLineRead = studentReader.ReadLine();
            }
            studentReader.Close();
        }
        public List<Tuple<int, int, string>> LookupStudent(int studentID)//getsall the data for a specified student
        {
            List<Tuple<int, int, string>> lookupData = new List<Tuple<int, int, string>>();
            if (studentInfo.ContainsKey(studentID))
            {
                for (int record = 0; record < studentInfo[studentID].Count; record++)
                {
                    for (int skill = 0; skill < studentInfo[studentID].ElementAt(record).Value.Item1.Count; skill++)
                    {//adds skill position, pag position and text to list
                        lookupData.Add(new Tuple<int, int, string>(pagLookup[studentInfo[studentID].ElementAt(record).Value.Item1.ElementAt(skill).Key], pagLookup[studentInfo[studentID].ElementAt(record).Key], studentInfo[studentID].ElementAt(record).Value.Item1.ElementAt(skill).Value));
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
        public void ResetChanges()//resets all the list columns that have been modified
        {
            changes.Clear();
        }
        public void AddChange(int column)//adds a column that has been modified
        {
            if (changes.Contains(column) == false)
            {
                changes.Add(column);
            }
        }
        public ArrayList GetChanges()//get a list of all modified columns
        {
            return changes;
        }
        public void ClearPagsWithData()//clear the list of pags with existing data
        {
            pagsWithData.Clear();
        }
        public void AddPagWithData(int position)//adds a pag to the list of pags with exsiting data
        {
            if (pagsWithData.Contains(position) == false)
            {
                pagsWithData.Add(position);
            }
        }
        public bool DoesPagWithDataContain(int position)//check if a item is in the list of pags with exisiting data
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
        public void SetCurrentStudentID(int id)//sets the current student id
        {
            currentStudentID = id;
        }
        public int GetCurrentStudentID()//gets the current student id
        {
            return currentStudentID;
        }
        public ArrayList GetSkillOrder(int pagId)//gets the order of skills for a specified pag
        {
            ArrayList skillOrder = new ArrayList();
            for (int position = 0; position < relations[pagId].Count; position++)
            {
                skillOrder.Add(relations[pagId].ElementAt(position).Value);
            }
            return skillOrder;
        }
        public bool UpdateStudentData(Dictionary<int,string> newData)//updates data for a modified student
        {
            bool success = true; //if the update fails, the program needs to switch tabs
            //replaces or adds new data into the pag achievement data file
            string[] array = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagAchievement.csv");
            List<string> arrLine = new List<string>(array);
            //copies the file in case the editing goes wrong
            File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagAchievement.csv", AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagAchievement.temp", true);
            for (int record = 0; record < newData.Count; record++)
            {
                int column = newData.ElementAt(record).Key;
                string dataLine = newData.ElementAt(record).Value;
                if (pagsWithData.Contains(column))//checks if the data has to be overwritten or replaced
                {
                    string[] seperatedLine = newData.ElementAt(record).Value.Split(new[] { "," }, StringSplitOptions.None);//decomposes the line into seperate variables
                    int studentID = Convert.ToInt32(seperatedLine[0]);
                    int pagID = Convert.ToInt32(seperatedLine[1]);
                    int lineToReplace = studentInfo[studentID][pagID].Item2;
                    if (seperatedLine[2] == "D")//this means the record needs to be deleted
                    {
                        arrLine[lineToReplace - 1] = "D";//marks record for deletion
                    }
                    else
                    {
                        arrLine[lineToReplace - 1] = dataLine;
                    }
                }
                else//data does not exist in database
                {
                    if (dataLine.Contains("D") == false)
                    {
                        arrLine.Add(dataLine);
                    }
                }
            }
            bool containsD = true;
            while (containsD)//loops through every record marked for deletion
            {
                if (arrLine.Contains("D"))
                {
                    arrLine.Remove("D");//deletes records that are marked for deletion
                }
                else
                {
                    containsD = false;
                }
            }
            //writing the new pag achievement to file
            File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagAchievement.csv", arrLine);
            //checking if edit failed and reverting if so
            string pagData = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagAchievement.csv");
            if (pagData == "")//checks if file was unsuccessfully modified
            {
                File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagAchievement.temp", AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagAchievement.csv", true);
                MessageBox.Show("Student edit failed. Reverting to previous student data", "Alert");//reverts to previous file
                success = false;
            }
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagAchievement.temp");//deletes temporary file
            return success;
        }
    }
}
