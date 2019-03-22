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
    class Admin
    {
        private string fileLocation { get; set; }
        //sorted list has key = studentID, value = tuple<FName, LName, Year, Class>
        SortedList<int, Tuple<string, string, string, string>> studentInfo = new SortedList<int, Tuple<string, string, string, string>>();
        public Admin(string FileLocation)
        {
            fileLocation = FileLocation;
        }
        SortedList<int, string> pagList = new SortedList<int, string>();
        SortedList<int, string> skillList = new SortedList<int, string>();
        public void LoadData()
        {
            string lineRead;
            string[] SeperatedLine;
            pagList.Clear();
            skillList.Clear();
            //reading pags
            StreamReader pagReader = new StreamReader(fileLocation + "PagList.csv");//opens the student record file to start reading names
            lineRead = pagReader.ReadLine();
            while (lineRead != null)//loops through every record, adding names to an arraylist
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                pagList.Add(Convert.ToInt32(SeperatedLine[0]),SeperatedLine[1]);
                lineRead = pagReader.ReadLine();
            }
            pagReader.Close();
            //reading skills
            StreamReader skillReader = new StreamReader(fileLocation + "SkillList.csv");//opens the student record file to start reading names
            lineRead = skillReader.ReadLine();
            while (lineRead != null)//loops through every record, adding names to an arraylist
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                skillList.Add(Convert.ToInt32(SeperatedLine[0]), SeperatedLine[1]);
                lineRead = skillReader.ReadLine();
            }
            skillReader.Close();
        }
        public SortedList<int, string> GetPagList()
        {
            return pagList;
        }
        public SortedList<int, string> GetSkillList()
        {
            return skillList;
        }
        public void RemovePagFromPosition(int position)
        {
            try
            {
                pagList.RemoveAt(position);
            }
            catch (Exception)
            {

            }
        }
        public void RemoveSkillFromPosition(int position)
        {
            try
            {
                skillList.RemoveAt(position);
            }
            catch (Exception)
            {

            }
        }
        public void AddPag()
        {
            pagList.Add(pagList.ElementAt(pagList.Count - 1).Key + 1, "New PAG");
        }
        public void AddSkill()
        {
            skillList.Add(skillList.ElementAt(skillList.Count - 1).Key + 1, "New Skill");
        }
        public void RenamePag(int position, string newName)
        {
            int ID = pagList.ElementAt(position).Key;
            pagList[ID] = newName;
        }
        public void RenameSkill(int position, string newName)
        {
            int ID = skillList.ElementAt(position).Key;
            skillList[ID] = newName;
        }
        public void SavePagData()
        {
            StreamWriter sw = new StreamWriter(fileLocation + "PagList.csv");
            for (int i = 0; i < pagList.Count; i++)
            {
                sw.WriteLine(pagList.ElementAt(i).Key + "," + pagList.ElementAt(i).Value);
            }
            sw.Close();
        }
        public void SaveSkillData()
        {
            StreamWriter sw = new StreamWriter(fileLocation + "SkillList.csv");
            for (int i = 0; i < skillList.Count; i++)
            {
                sw.WriteLine(skillList.ElementAt(i).Key + "," + skillList.ElementAt(i).Value);
            }
            sw.Close();
        }
        HashSet<int> pagsInUse = new HashSet<int>();
        public void BuildPagsInUse()
        {
            pagsInUse.Clear();
            string lineRead;
            string[] SeperatedLine;
            StreamReader sr = new StreamReader(fileLocation + "PagAchievement.csv");
            lineRead = sr.ReadLine();
            while (lineRead != null)
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                pagsInUse.Add(Convert.ToInt32(SeperatedLine[1]));
                lineRead = sr.ReadLine();
            }
            sr.Close();
        }
        HashSet<int> skillsInUse = new HashSet<int>();
        public void BuildSkillsInUse()
        {
            skillsInUse.Clear();
            for (int pag = 0; pag < pagsInUse.Count; pag++)
            {
                string lineRead;
                string[] SeperatedLine;
                StreamReader sr = new StreamReader(fileLocation + "PagSkillRelation.csv");
                lineRead = sr.ReadLine();
                while (lineRead != null)
                {
                    SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                    if (pagsInUse.Contains(Convert.ToInt32(SeperatedLine[0])))
                    {
                        skillsInUse.Add(Convert.ToInt32(SeperatedLine[1]));
                    }
                    lineRead = sr.ReadLine();
                }
                sr.Close();
            }
        }
        public bool IsPagInUse(int pagID)
        {
            if (pagsInUse.Contains(pagID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsSkillInUse(int skillID)
        {
            if (skillsInUse.Contains(skillID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetPagId(int position)
        {
            return pagList.ElementAt(position).Key;
        }
        public int GetSkillId(int position)
        {
            return skillList.ElementAt(position).Key;
        }
        public void BuildSkillRequirementIfEmpty()
        {
            StreamReader requirementReader = new StreamReader(fileLocation + "SkillRequirement.csv");//reads the first line from file to check if its empty
            string firstLine = requirementReader.ReadLine();
            requirementReader.Close();
            if (firstLine == null)
            {
                StreamReader skillReader = new StreamReader(fileLocation + "SkillList.csv");//opens skill list to start reading skills
                StreamWriter requirementWriter = new StreamWriter(fileLocation + "SkillRequirement.csv");//opens skill requirement to start writing skills
                string skillLine = skillReader.ReadLine();
                Int32 lineNumber = 0;
                while (skillLine != null)
                {
                    requirementWriter.WriteLine(Convert.ToString(lineNumber) + ",1");
                    skillLine = skillReader.ReadLine();
                    lineNumber++;
                }
                requirementWriter.Close();
                skillReader.Close();
            }
        }
        public ArrayList LoadSkillRequirementNumber()
        {
            ArrayList requirementNumbers = new ArrayList();
            StreamReader requirementReader = new StreamReader(fileLocation + "SkillRequirement.csv");//reads the first line from file to check if its empty
            String[] SeperatedLine;
            string lineRead = requirementReader.ReadLine();
            while (lineRead != null)//loops through every record, adding numbers to an arraylist
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                requirementNumbers.Add(SeperatedLine[1]);
                lineRead = requirementReader.ReadLine();
            }
            requirementReader.Close();
            return requirementNumbers;
        }
        public ArrayList LoadStudentCSV(string filename)
        {
            ArrayList csvLines = new ArrayList();
            StreamReader csvReader = new StreamReader(filename);
            string lineRead = csvReader.ReadLine();
            while (lineRead != null)//loops through every record, adding each line to an arraylist
            {
                csvLines.Add(lineRead);
                lineRead = csvReader.ReadLine();
            }
            return csvLines;
        }
        public void BuildStudentInformation()
        {
            //dictionary has key = studentID, value = tuple(FirstName,LastName,Year,Class)
            studentInfo.Clear();
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
        }
        public SortedList<int, Tuple<string, string, string, string>> GetStudentInformation()
        {
            return studentInfo;
        }
        public Tuple<string, string, string, string> GetInformation(int position)
        {
            return studentInfo.ElementAt(position).Value;
        }
        public void DeleteStudent(int position)
        {
            studentInfo.RemoveAt(position);
        }
        public void ModifyStudent(int position, string fName, string lName, string year, string theClass)
        {
            int key = studentInfo.ElementAt(position).Key;
            studentInfo.Remove(key);
            studentInfo.Add(key, new Tuple<string, string, string, string>(fName, lName, year, theClass));
        }
        public void AddStudent()
        {
            int lastKey = studentInfo.ElementAt(studentInfo.Count-1).Key;
            studentInfo.Add(lastKey + 1, new Tuple<string, string, string, string>("New", "Student", "Year", "Class"));
        }
        public void SaveStudentData()
        {
            StreamWriter sw = new StreamWriter(fileLocation + "StudentRecord.csv");
            for (int i = 0; i < studentInfo.Count; i++)
            {
                string id = Convert.ToString(studentInfo.ElementAt(i).Key);
                string fName = studentInfo.ElementAt(i).Value.Item1;
                string lName = studentInfo.ElementAt(i).Value.Item2;
                string year = studentInfo.ElementAt(i).Value.Item3;
                string theClass = studentInfo.ElementAt(i).Value.Item4;
                sw.WriteLine(id + "," + fName + "," + lName + "," + year + "," + theClass);
            }
            sw.Close();
        }
        public HashSet<string> GetAllEntries(string type)
        {
            //type accepts "class" or "year"
            HashSet<string> entries = new HashSet<string>();
            for (int entry = 0; entry < studentInfo.Count; entry++)
            {
                if (type == "class")
                {
                    entries.Add(studentInfo.ElementAt(entry).Value.Item4);
                }
                else
                {
                    entries.Add(studentInfo.ElementAt(entry).Value.Item3);
                }
            }
            return entries;
        }
        public void FindAndReplace(string inputType, string inputItem, string outputItem)
        {
            if (inputType == "Year")//checks if years or classes need to be moved
            {
                for (int student = 0; student < studentInfo.Count; student++)//loops through each student
                {
                    int key = studentInfo.ElementAt(student).Key;
                    if (studentInfo[key].Item3 == inputItem)//checks if student is part of input year
                    {
                        string fName = studentInfo[key].Item1;
                        string lName = studentInfo[key].Item2;
                        string theClass = studentInfo[key].Item4;
                        studentInfo.Remove(key);
                        studentInfo.Add(key, new Tuple<string, string, string, string>(fName, lName, outputItem, theClass));
                    }
                }
            }
            else
            {
                for (int student = 0; student < studentInfo.Count; student++)//loops through each student
                {
                    int key = studentInfo.ElementAt(student).Key;
                    if (studentInfo[key].Item4 == inputItem)//checks if student is part of input class
                    {
                        string fName = studentInfo[key].Item1;
                        string lName = studentInfo[key].Item2;
                        string year = studentInfo[key].Item3;
                        studentInfo.Remove(key);
                        studentInfo.Add(key, new Tuple<string, string, string, string>(fName, lName, year, outputItem));
                        MessageBox.Show(Convert.ToString(1));
                    }
                }
            }
        }
        public void DirectoryCopy(string oldDir, string newDir)
        {
            Directory.CreateDirectory(newDir);
            List<string> files = new List<string>() { "PagAchievement.csv", "PagGroup.csv", "PagList.csv", "PagSkillRelation.csv", "SkillList.csv", "SkillRequirement.csv", "StudentRecord.csv" };
            for (int file = 0; file < files.Count; file++)
            {
                File.Copy(oldDir + files[file], newDir + files[file]);
            }
        }
    }
}
