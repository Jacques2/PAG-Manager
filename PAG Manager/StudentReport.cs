using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace PAG_Manager
{
    class StudentReport
    {
        private string fileLocation;
        //group info: Dictionary(key = groupID, value = tuple(t1 = group text, t2 = list(pagsInGroup)))
        Dictionary<int, Tuple<string, List<int>>> groupInfo = new Dictionary<int, Tuple<string, List<int>>>();
        List<int> studentOrder = new List<int>();
        string fileName = "PagGroup.csv";
        List<int> groupIdPosition = new List<int>();
        public void ClearStudentOrder()
        {
            studentOrder.Clear();
        }
        public void AddToStudentOrder(int ID)
        {
            studentOrder.Add(ID);
        }
        public int getStudentOrder(int index)
        {
            try
            {
                return studentOrder[index];
            }
            catch (Exception)
            {
                return new int();
            }
        }
        public StudentReport(string inputFileLocation)
        {
            fileLocation = inputFileLocation;
        }
        public void LoadGroupInformation()
        {
            groupInfo.Clear();
            groupIdPosition.Clear();
            string lineRead;
            string[] SeperatedLine;
            StreamReader sr = new StreamReader(fileLocation + fileName);
            lineRead = sr.ReadLine();
            while (lineRead != null)
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                int groupID = Convert.ToInt32(SeperatedLine[0]);
                groupIdPosition.Add(groupID);
                string groupName = SeperatedLine[1];
                List<int> listOfPags = new List<int>();
                for (int i = 2; i < SeperatedLine.Count(); i++)
                {
                    try//try and add value to list, catches if there is no value
                    {
                        listOfPags.Add(Convert.ToInt32(SeperatedLine[i]));
                    }
                    catch (Exception)
                    {
                        
                    }
                }
                groupInfo.Add(groupID, new Tuple<string, List<int>>(groupName, listOfPags));
                lineRead = sr.ReadLine();
            }
            sr.Close();
        }
        public int GetGroupId(int position)
        {
            return groupIdPosition[position];
        }
        public List<int> GetGroupPagList(int groupID)
        {
            try
            {
                return groupInfo[groupID].Item2;
            }
            catch (Exception)
            {
                return new List<int>();
            }
        }
        public void AddPagToGroup(int groupID, int pagID)
        {
            if (groupInfo[groupID].Item2.Contains(pagID) == false)//checking if it already exists
            {
                groupInfo[groupID].Item2.Add(pagID);
            }
        }
        public void RemovePagFromGroup(int groupID, int pagID)
        {
            if (groupInfo[groupID].Item2.Contains(pagID) == true)//checking if it already exists
            {
                groupInfo[groupID].Item2.Remove(pagID);
            }
        }
        public Dictionary<int, Tuple<string, List<int>>> GetGroupInfo()
        {
            return groupInfo;
        }
        public void WritePagGroupInfo()
        {
            StreamWriter sw = new StreamWriter(fileLocation + fileName);
            for (int group = 0; group < groupInfo.Count; group++)
            {
                string lineToWrite = "";
                lineToWrite += groupInfo.ElementAt(group).Key;
                lineToWrite += ",";
                lineToWrite += groupInfo.ElementAt(group).Value.Item1;
                lineToWrite += ",";
                for (int pag = 0; pag < groupInfo.ElementAt(group).Value.Item2.Count; pag++)
                {
                    lineToWrite += groupInfo.ElementAt(group).Value.Item2.ElementAt(pag);
                    if (pag < groupInfo.ElementAt(group).Value.Item2.Count-1)//adds commas to all but last value
                    {
                        lineToWrite += ",";
                    }
                }
                sw.WriteLine(lineToWrite);
            }
            sw.Close();
        }
        public void AddGroup()//adds a group with the id 1 higher than the last group
        {
            int newID;
            try
            {
                newID = groupIdPosition[groupIdPosition.Count - 1] + 1;
            }
            catch (Exception)
            {
                newID = 0;
            }
            groupIdPosition.Add(newID);
            groupInfo.Add(newID, new Tuple<string, List<int>>("New Group", new List<int>()));
        }
        public void RenameGroup(int groupID, string name)
        {
            groupInfo[groupID] = new Tuple<string, List<int>>(name, groupInfo[groupID].Item2);
        }
        public void DeleteGroup(int position)
        {
            groupInfo.Remove(GetGroupId(position));
            groupIdPosition.RemoveAt(position);
        }
        public int GetNumberOfStudents()
        {
            string[] array = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\StudentRecord.csv");
            return array.Count();
        }
        //---------------------------------Below functions are for report generation--------------------------------
        // dictionary has key = studentID, value = list(pags)
        Dictionary<int, List<int>> studentPagData = new Dictionary<int, List<int>>();
        //dictionary has key = groupID, value = list(pags)
        Dictionary<int, List<int>> groupData = new Dictionary<int, List<int>>();
        //dictionary with key = student id value = Sorted list(key = skill id value = times achieved)
        Dictionary<int, SortedList<int, int>> pagRecord = new Dictionary<int, SortedList<int, int>>();
        //dictionary with key = pagID, value = time required to achieve
        Dictionary<int, int> skillRequirement = new Dictionary<int, int>();
        public void BuildPagList()
        {
            string lineRead;
            string[] SeperatedLine;
            StreamReader sr = new StreamReader(fileLocation + "PagAchievement.csv");
            lineRead = sr.ReadLine();
            while (lineRead != null)
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                if (SeperatedLine[3] != "Absent")//checks to see if pag actually was achived
                {
                    int studentID = Convert.ToInt32(SeperatedLine[0]);
                    int pagID = Convert.ToInt32(SeperatedLine[1]);
                    if (studentPagData.ContainsKey(studentID) == false)//checks if student has been added so far
                    {
                        studentPagData.Add(studentID, new List<int>());
                    }
                    studentPagData[studentID].Add(pagID);
                }
                lineRead = sr.ReadLine();
            }
            sr.Close();
        }
        public ArrayList GetMissingGroups(int studentID)
        {
            ArrayList groupsFailed = new ArrayList();
            for (int group = 0; group < groupInfo.Count; group++)
            {
                List<int> pagsInGroup = new List<int>(groupInfo.ElementAt(group).Value.Item2);
                bool hasPassed = false;
                if (studentPagData.ContainsKey(studentID))
                {
                    for (int pag = 0; pag < pagsInGroup.Count; pag++)
                    {
                        int pagID = pagsInGroup[pag];
                        if (studentPagData[studentID].Contains(pagID))
                        {
                            hasPassed = true;
                        }
                    }
                }
                if (hasPassed == false)
                {
                    groupsFailed.Add(groupInfo.ElementAt(group).Value.Item1);
                }
            }
            return groupsFailed;
        }
        public Dictionary<int, Tuple<string, string, string, string>> GetAllStudentInformation()
        {
            Dictionary<int, Tuple<string, string, string, string>> studentInfo = new Dictionary<int, Tuple<string, string, string, string>>();
            StreamReader studentReader = new StreamReader(fileLocation + "StudentRecord.csv");
            string studentRead = studentReader.ReadLine();
            string[] SeperatedLine;
            while (studentRead != null)
            {
                SeperatedLine = studentRead.Split(new[] { "," }, StringSplitOptions.None);
                studentInfo.Add(Convert.ToInt32(SeperatedLine[0]), Tuple.Create(SeperatedLine[1], SeperatedLine[2], SeperatedLine[3], SeperatedLine[4]));
                studentRead = studentReader.ReadLine();
            }
            studentReader.Close();
            return studentInfo;
        }
        public void BuildSkillInformation()
        {
            //before building skill information, skill requirement data is obtained
            skillRequirement.Clear();
            string lineRead;
            string[] SeperatedLine;
            StreamReader requirementReader = new StreamReader(fileLocation + "SkillRequirement.csv");
            lineRead = requirementReader.ReadLine();
            while (lineRead != null)
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                int readSkillID = Convert.ToInt32(SeperatedLine[0]);
                int requirement = Convert.ToInt32(SeperatedLine[1]);
                skillRequirement[readSkillID] = requirement;
                lineRead = requirementReader.ReadLine();
            }
            requirementReader.Close();
            //starts building skill information
            pagRecord.Clear();
            ArrayList tableData = new ArrayList();
            //Load every skill into a dictionary with key = skill id value = position in table
            Dictionary<int, int> skillID = new Dictionary<int, int>();
            StreamReader sr = new StreamReader(fileLocation + "SkillList.csv");
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
                    }
                }
                recordRead = recordReader.ReadLine();
            }
            recordReader.Close();
        }
        public ArrayList GetMissingSkills(int studentID)
        {
            ArrayList missingSkills = new ArrayList();
            for (int skill = 0; skill < skillRequirement.Count; skill++)
            {
                int currentSkill = skillRequirement.ElementAt(skill).Key;
                int timesRequired = skillRequirement.ElementAt(skill).Value;
                if (pagRecord.ContainsKey(studentID))//checks if student exists in database
                {
                    if (pagRecord[studentID].ContainsKey(currentSkill))//checks if skill exists for student
                    {
                        if (pagRecord[studentID][currentSkill] < timesRequired)//checks if the skill has not been met enough
                        {
                            missingSkills.Add(currentSkill);
                        }
                    }
                    else
                    {
                        missingSkills.Add(currentSkill);
                    }
                }
                else
                {
                    missingSkills.Add(currentSkill);
                }
            }
            return missingSkills;
        }
        public HashSet<int> BuildUniverse(int studentID)
        {
            HashSet<int> universe = new HashSet<int>();
            ArrayList missingSkills = new ArrayList();
            missingSkills = GetMissingSkills(studentID);
            for (int i = 0; i < missingSkills.Count; i++)
            {
                universe.Add(Convert.ToInt32(missingSkills[i]));
            }
            return universe;
        }
        public List<int> FindPagsToComplete(HashSet<int> universe, List<HashSet<int>> subsets)
        {
            //This is a greedy set cover algorithum, which calculates the smallest number of subsets that contain every element in the universe.
            List<int> subsetIndex = new List<int>();
            for (int i = 0; i < subsets.Count; i++)
            {
                subsetIndex.Add(i);
            }
            HashSet<int> listCombined = new HashSet<int>();
            for (int i = 0; i < subsets.Count; i++)
            {
                listCombined.UnionWith(subsets.ElementAt(i));
            }
            if (universe.IsSubsetOf(listCombined) == false)
            {
                MessageBox.Show(Convert.ToString(false)); //check if actually possible
            }
            HashSet<int> covered = new HashSet<int>();
            var remaining = new HashSet<int>(universe);
            List<int> subListsToUse = new List<int>();
            while (universe.IsSubsetOf(covered) == false)
            {
                SortedList<int, int> subsetEff = new SortedList<int, int>();
                for (int set = 0; set < subsets.Count; set++)
                {
                    subsetEff.Add(set, new HashSet<int>(remaining.Except(subsets.ElementAt(set))).Count);
                }
                var ordered = subsetEff.OrderBy(x => x.Value);
                int bestIndex = ordered.ElementAt(0).Key;
                subListsToUse.Add(subsetIndex[bestIndex]);
                subsetIndex.RemoveAt(bestIndex);
                covered.UnionWith(subsets.ElementAt(bestIndex));
                remaining.Except(subsets.ElementAt(bestIndex));
                subsets.RemoveAt(bestIndex);
            }
            return subListsToUse;
        }
        Dictionary<int, HashSet<int>> pagSubset = new Dictionary<int, HashSet<int>>();
        public void BuildPagSubsets()
        {
            pagSubset.Clear();
            StreamReader relationReader = new StreamReader(fileLocation + "PagSkillRelation.csv");
            string relationLineRead;
            relationLineRead = relationReader.ReadLine();
            string[] seperatedLine;
            while (relationLineRead != null)
            {
                seperatedLine = relationLineRead.Split(new[] { "," }, StringSplitOptions.None);//decomposes the line into seperate variables
                int pagID = Convert.ToInt32(seperatedLine[0]);
                int skillID = Convert.ToInt32(seperatedLine[1]);
                if (pagSubset.ContainsKey(pagID) == false)//creates new entry for pag if no exist
                {
                    pagSubset.Add(pagID, new HashSet<int>());
                }
                pagSubset[pagID].Add(skillID);
                relationLineRead = relationReader.ReadLine();
            }
            relationReader.Close();
        }
        public List<HashSet<int>> GetSubsetList()
        {
            List<HashSet<int>> subsets = new List<HashSet<int>>();
            for (int i = 0; i < pagSubset.Count; i++)
            {
                subsets.Add(pagSubset.ElementAt(i).Value);
            }
            return subsets;
        }
        public int GetPagID(int index)
        {
            return pagSubset.ElementAt(index).Key;
        }
        Dictionary<int, string> skillList = new Dictionary<int, string>();
        Dictionary<int, string> pagList = new Dictionary<int, string>();
        public void BuildLists()
        {
            skillList.Clear();
            pagList.Clear();
            string lineRead;
            string[] SeperatedLine;
            StreamReader sr = new StreamReader(fileLocation + "PagList.csv");
            lineRead = sr.ReadLine();
            while (lineRead != null)
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                pagList.Add(Convert.ToInt32(SeperatedLine[0]), SeperatedLine[1]);
                lineRead = sr.ReadLine();
            }
            sr.Close();
            StreamReader skillReader = new StreamReader(fileLocation + "SkillList.csv");
            lineRead = skillReader.ReadLine();
            while (lineRead != null)
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                skillList.Add(Convert.ToInt32(SeperatedLine[0]), SeperatedLine[1]);
                lineRead = skillReader.ReadLine();
            }
            skillReader.Close();
        }
        public string GetSkillName(int ID)
        {
            try
            {
                return skillList[ID];
            }
            catch (Exception)
            {
                return "";
            }
        }
        public string GetPagName(int ID)
        {
            try
            {
                return pagList[ID];
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
