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
            string[] seperatedLine;
            pagList.Clear();
            skillList.Clear();
            //reading pags
            StreamReader pagReader = new StreamReader(fileLocation + "PagList.csv");//opens the pag record file to start reading names
            lineRead = pagReader.ReadLine();
            while (lineRead != null)//loops through every record, adding names to an arraylist
            {
                seperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                pagList.Add(Convert.ToInt32(seperatedLine[0]),seperatedLine[1]);
                lineRead = pagReader.ReadLine();
            }
            pagReader.Close();
            //reading skills
            StreamReader skillReader = new StreamReader(fileLocation + "SkillList.csv");//opens the skill record file to start reading names
            lineRead = skillReader.ReadLine();
            while (lineRead != null)//loops through every record, adding names to an arraylist
            {
                seperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                skillList.Add(Convert.ToInt32(seperatedLine[0]), seperatedLine[1]);
                lineRead = skillReader.ReadLine();
            }
            skillReader.Close();
        }
        public SortedList<int, string> GetPagList()//gets a list of all pags
        {
            return pagList;
        }
        public SortedList<int, string> GetSkillList()//gets a list of all skills
        {
            return skillList;
        }
        public int GetSkillPositionFromID(int ID)//gets the position of a skill from its id
        {
            int position = skillList.IndexOfKey(ID);
            return position;
        }
        public int GetPagPositionFromID(int ID)//gets the position of a pag from its id
        {
            int position = pagList.IndexOfKey(ID);
            return position;
        }
        public void RemovePagFromPosition(int position)//removes the pag from the specified position
        {
            try
            {
                pagList.RemoveAt(position);
            }
            catch (Exception)
            {

            }
        }
        public void RemoveSkillFromPosition(int position)//removes the skill from the specified position
        {
            try
            {
                skillList.RemoveAt(position);
            }
            catch (Exception)
            {

            }
        }
        public void AddPag()//adds a pag to the list
        {
            pagList.Add(pagList.ElementAt(pagList.Count - 1).Key + 1, "New PAG");
        }
        public void AddSkill()//adds a skill to the list
        {
            skillList.Add(skillList.ElementAt(skillList.Count - 1).Key + 1, "New Skill");
        }
        public void RenamePag(int position, string newName)//renames a pag
        {
            int ID = pagList.ElementAt(position).Key;
            pagList[ID] = newName;
        }
        public void RenameSkill(int position, string newName)//renames a skill
        {
            int ID = skillList.ElementAt(position).Key;
            skillList[ID] = newName;
        }
        public void SavePagData()//saves updated pag data
        {
            StreamWriter sw = new StreamWriter(fileLocation + "PagList.csv");
            for (int i = 0; i < pagList.Count; i++)
            {
                sw.WriteLine(pagList.ElementAt(i).Key + "," + pagList.ElementAt(i).Value);
            }
            sw.Close();
        }
        public void SaveSkillData()//saves updated skill data
        {
            StreamWriter sw = new StreamWriter(fileLocation + "SkillList.csv");
            for (int i = 0; i < skillList.Count; i++)
            {
                sw.WriteLine(skillList.ElementAt(i).Key + "," + skillList.ElementAt(i).Value);
            }
            sw.Close();
        }
        HashSet<int> pagsInUse = new HashSet<int>();
        public void BuildPagsInUse()//builds a list of pags that are awarded to students
        {
            pagsInUse.Clear();
            string lineRead;
            string[] seperatedLine;
            StreamReader sr = new StreamReader(fileLocation + "PagAchievement.csv");
            lineRead = sr.ReadLine();
            while (lineRead != null)
            {
                seperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                pagsInUse.Add(Convert.ToInt32(seperatedLine[1]));//adds the pag id to the set
                lineRead = sr.ReadLine();
            }
            sr.Close();
        }
        HashSet<int> skillsInUse = new HashSet<int>();
        public void BuildSkillsInUse()//builds a list of skills that have been awarded to students
        {
            skillsInUse.Clear();
            for (int pag = 0; pag < pagsInUse.Count; pag++)
            {
                string lineRead;
                string[] seperatedLine;
                StreamReader sr = new StreamReader(fileLocation + "PagSkillRelation.csv");
                lineRead = sr.ReadLine();
                while (lineRead != null)
                {
                    seperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                    if (pagsInUse.Contains(Convert.ToInt32(seperatedLine[0])))//check if the pag is in use
                    {
                        skillsInUse.Add(Convert.ToInt32(seperatedLine[1]));//if so, then add the skill to the set
                    }
                    lineRead = sr.ReadLine();
                }
                sr.Close();
            }
        }
        public bool IsPagInUse(int pagID)//checks the pag set for the input id
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
        public bool IsSkillInUse(int skillID)//checks the skill set for the input id
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
        public int GetPagId(int position)//gets the id of a pag from is position
        {
            return pagList.ElementAt(position).Key;
        }
        public int GetSkillId(int position)//gets the id of a skill from is position
        {
            return skillList.ElementAt(position).Key;
        }
        public string GetPagName(int PagID)//gets the name of a pag from is id
        {
            if (pagList.ContainsKey(PagID))
            {
                return pagList[PagID];
            }
            else
            {
                return "";
            }
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
            String[] seperatedLine;
            string lineRead = requirementReader.ReadLine();
            while (lineRead != null)//loops through every record, adding numbers to an arraylist
            {
                seperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                requirementNumbers.Add(seperatedLine[1]);
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
        public void BuildStudentInformation()//builds all student data
        {
            //dictionary has key = studentID, value = tuple(FirstName,LastName,Year,Class)
            studentInfo.Clear();
            StreamReader studentReader = new StreamReader(fileLocation + "StudentRecord.csv");
            string studentRead = studentReader.ReadLine();
            string[] seperatedLine;
            while (studentRead != null)
            {
                seperatedLine = studentRead.Split(new[] { "," }, StringSplitOptions.None);
                studentInfo.Add(Convert.ToInt32(seperatedLine[0]), Tuple.Create(seperatedLine[1], seperatedLine[2], seperatedLine[3], seperatedLine[4]));
                studentRead = studentReader.ReadLine();
            }
            studentReader.Close();
        }
        public SortedList<int, Tuple<string, string, string, string>> GetStudentInformation()//gets all student data
        {
            return studentInfo;
        }
        public Tuple<string, string, string, string> GetInformation(int position)//gets information about a student from its position
        {
            return studentInfo.ElementAt(position).Value;
        }
        public void DeleteStudent(int position)//deletes a student
        {
            studentInfo.RemoveAt(position);
        }
        public void ModifyStudent(int position, string fName, string lName, string year, string theClass)//modifys the student record
        {
            int key = studentInfo.ElementAt(position).Key;
            studentInfo.Remove(key);
            studentInfo.Add(key, new Tuple<string, string, string, string>(fName, lName, year, theClass));
        }
        public void AddStudent()//adds a new student
        {
            int lastKey = studentInfo.ElementAt(studentInfo.Count-1).Key;
            studentInfo.Add(lastKey + 1, new Tuple<string, string, string, string>("New", "Student", "Year", "Class"));
        }
        public void SaveStudentData()//saves all student information
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
                        if (outputItem == "Archive")//if destination is archive, then students need to have year and class changed to archive
                        {
                            theClass = "Archive";
                        }
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
                        if (outputItem == "Archive")//if destination is archive, then students need to have year and class changed to archive
                        {
                            year = "Archive";
                        }
                        studentInfo.Remove(key);
                        studentInfo.Add(key, new Tuple<string, string, string, string>(fName, lName, year, outputItem));
                    }
                }
            }
        }
        public void DirectoryCopy(string oldDir, string newDir, bool isPreset)//copys files from one directory to another
        {
            Directory.CreateDirectory(newDir);
            List<string> files = new List<string>();
            if (isPreset)//if managing presets, 2 files are not copied
            {
                List<string> filesToCopy = new List<string>() { "PagGroup.csv", "PagList.csv", "PagSkillRelation.csv", "SkillList.csv", "SkillRequirement.csv" };
                files = filesToCopy;
            }
            else
            {
                List<string> filesToCopy = new List<string>() { "PagAchievement.csv", "PagGroup.csv", "PagList.csv", "PagSkillRelation.csv", "SkillList.csv", "SkillRequirement.csv", "StudentRecord.csv" };
                files = filesToCopy;
            }
            for (int file = 0; file < files.Count; file++)//loops through files to copy
            {
                try
                {
                    File.Copy(oldDir + files[file], newDir + files[file], true);//copy file, and overwrite
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error copying file." + Environment.NewLine + Environment.NewLine + ex.Message);
                }
            }
        }
        Dictionary<int, HashSet<int>> skillRelation = new Dictionary<int, HashSet<int>>();
        public void BuildSkillRelationList()//this builds a list of skills and the pags that contain them for validation when deleting them
        {
            skillRelation.Clear();
            string lineRead;
            string[] seperatedLine;
            StreamReader sr = new StreamReader(fileLocation + "PagSkillRelation.csv");
            lineRead = sr.ReadLine();
            while (lineRead != null)
            {
                seperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                if (skillRelation.ContainsKey(Convert.ToInt32(seperatedLine[1])) == false)
                {
                    skillRelation.Add(Convert.ToInt32(seperatedLine[1]), new HashSet<int>());
                }
                skillRelation[Convert.ToInt32(seperatedLine[1])].Add(Convert.ToInt32(seperatedLine[0]));
                lineRead = sr.ReadLine();
            }
            sr.Close();
        }
        public HashSet<int> GetAllPagsForSkill(int ID)//gets all the pags for a skill
        {
            if (skillRelation.ContainsKey(ID))
            {
                return skillRelation[ID];
            }
            else
            {
                return new HashSet<int>();
            }
        }
        public void RemoveDuplicatePagAwards()
        {
            bool corrections = false;
            List<string> noDupePagList = new List<string>();
            //dictionary has key = studentID, value = hashset(pagsCompleted)
            Dictionary<int, HashSet<int>> pagAwards = new Dictionary<int, HashSet<int>>();
            string[] seperatedLine;
            string[] linesRead = File.ReadAllLines(fileLocation + "PagAchievement.csv");
            for (int item = linesRead.Count()-1; item > 0; item--)//loops from the end backward
            {
                seperatedLine = linesRead[item].Split(new[] { "," }, StringSplitOptions.None);
                int studentID = Convert.ToInt32(seperatedLine[0]);
                int pagID = Convert.ToInt32(seperatedLine[1]);
                if (!pagAwards.ContainsKey(studentID))//loops through every record, adding data to a list
                {
                    pagAwards.Add(studentID, new HashSet<int>());
                }
                if (pagAwards[studentID].Contains(pagID))//check if the pag record exists for student
                {
                    corrections = true;
                }
                else
                {
                    pagAwards[studentID].Add(pagID);
                    noDupePagList.Add(linesRead[item]);
                }
            }
            if (corrections == true)//check if corrections have been made
            {
                MessageBox.Show("Duplicate PAG records found, overwriting older records with new ones", "PAG Manager");
                StreamWriter sw = new StreamWriter(fileLocation + "PagAchievement.csv");
                for (int line = noDupePagList.Count-1; line > 0; line--)
                {
                    sw.WriteLine(noDupePagList[line]);
                }
                sw.Close();
            }
        }
    }
}
