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
        public ArrayList LoadData(string fileName)
        {
            string lineRead;
            string[] SeperatedLine;
            ArrayList names = new ArrayList();
            StreamReader sr = new StreamReader(fileLocation + fileName);//opens the student record file to start reading names
            lineRead = sr.ReadLine();
            while (lineRead != null)//loops through every record, adding names to an arraylist
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                names.Add(SeperatedLine[1]);
                lineRead = sr.ReadLine();
            }
            sr.Close();
            return names;
        }
        public void SaveData(ArrayList data, string fileName)
        {
            StreamWriter sw = new StreamWriter(fileLocation + fileName);
            for (int i = 0; i < data.Count; i++)
            {
                sw.WriteLine(i + "," + data[i]);
            }
            sw.Close();
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
    }
}
