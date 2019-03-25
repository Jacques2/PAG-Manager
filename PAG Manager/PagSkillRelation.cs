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
    class PagSkillRelation
    {
        private Dictionary<int, List<int>> relation = new Dictionary<int, List<int>>();
        private string fileLocation;
        private int inclusion;
        public PagSkillRelation(string FileLocation)
        {
            fileLocation = FileLocation;
        }
        public void ClearRelations()
        {
            relation.Clear();
        }
        public void SetRelation(int pagID, int skillID)
        {
            if (relation.ContainsKey(pagID) == false)//checks if data for pag already exists
            {
                relation.Add(pagID, new List<int>());
            }
            relation[pagID].Add(skillID);
        }
        public void RemoveRelation(int pagID, int skillID)
        {
            if (relation.ContainsKey(pagID))//checks if data for pag already exists
            {
                if (relation[pagID].Contains(skillID))
                {
                    relation[pagID].Remove(skillID);
                }
            }
        }
        public List<int> GetRelations(int PagID)
        {
            try
            {
                return relation[PagID];
            }
            catch (Exception)
            {
                return new List<int>();
            }
        }
        public Dictionary<int, List<int>> GetAllRelations()
        {
            return relation;
        }
        public void BuildFromScratch()
        {
            File.Delete(fileLocation + "PagSkillRelation.csv");
            StreamWriter sw = new StreamWriter(fileLocation + "PagSkillRelation.csv");//overwrites exsisting data
            for (int pag = 0; pag < relation.Count; pag++)
            {
                List<int> listOfSkills = new List<int>(relation.ElementAt(pag).Value);
                int pagID = relation.ElementAt(pag).Key;
                for (int skillID = 0; skillID < listOfSkills.Count; skillID++)//This loops through every record in the dictionary to write to the file
                {
                    sw.WriteLine(pagID + "," + listOfSkills[skillID] + "," + skillID);
                }
            }
            sw.Close();
        }
        public bool SaveRelations()
        {
            bool success = true; //if the update fails, the program needs to switch tabs
            //replaces or adds new data into the pag achievement data file
            string[] array = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagSkillRelation.csv");
            List<string> arrLine = new List<string>(array);
            //copies the file in case the editing goes wrong
            File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagSkillRelation.csv", AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagSkillRelation.temp", true);
            //loops through every record, erasing psr data for modified pags
            for (int record = 0; record < arrLine.Count; record++)
            {
                string[] seperatedLine = arrLine[record].Split(new[] { "," }, StringSplitOptions.None);
                if (modifiedPAGs.Contains(Convert.ToInt32(seperatedLine[0])))//checks if pags need to be deleted and marks with a "D" if so
                {
                    arrLine[record] = "D";
                }
            }
            bool containsD = true;
            while (containsD)//loops deleting all records to be deleted
            {
                if (arrLine.Contains("D"))
                {
                    arrLine.Remove("D");
                }
                else
                {
                    containsD = false;
                }
            }
            //adds new psr data to the end of the array
            for (int pag = 0; pag < modifiedPAGs.Count; pag++)
            {
                int index = -1;
                int pagID = modifiedPAGs.ElementAt(pag);
                List<int> skillsInPag = new List<int>();
                skillsInPag = GetRelations(pagID);
                for (int skill = 0; skill < skillsInPag.Count; skill++)
                {
                    index++;
                    string skillID = Convert.ToString(skillsInPag[skill]);
                    arrLine.Add(pagID + "," + skillID + "," + Convert.ToString(index));
                }
            }
            //writing the new psr data to file
            File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagSkillRelation.csv", arrLine);
            //checking if edit failed and reverting if so
            string pagData = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagSkillRelation.csv");
            if (pagData == "")
            {
                File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagSkillRelation.temp", AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagSkillRelation.csv", true);
                MessageBox.Show("Student edit failed. Reverting to previous student data", "Alert");
                success = false;
            }
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagSkillRelation.temp");
            return success;
        }
        public void LoadRelationFromFile()
        {
            StreamReader sr = new StreamReader(fileLocation + "PagSkillRelation.csv");
            string lineRead;
            string[] SeperatedLine;
            lineRead = sr.ReadLine();
            while (lineRead != null)//loops through every record, adding relations to the 2d list
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                SetRelation(Convert.ToInt32(SeperatedLine[0]), Convert.ToInt32(SeperatedLine[1]));
                lineRead = sr.ReadLine();
            }
            sr.Close();
        }
        public void SetInclusion(int value)
        {
            inclusion = value;
        }
        public ArrayList ReverseRelationLookup(ArrayList skillIDs)
        {
            //Inclusion Types:
            //0 = PAG contains at least 1 skillID
            //1 = PAG must contain all skillID
            ArrayList matchingPag = new ArrayList();
            if (inclusion == 0)
            {
                for (int i = 0; i < relation.Count; i++)//Loops through every PAG
                {
                    for (int j = 0; j < skillIDs.Count; j++)//Loops through every skill inputed
                    {
                        if (relation.ElementAt(i).Value.Contains(Convert.ToInt32(skillIDs[j])))//checks if the pag contains the skill
                        {
                            if (matchingPag.Contains(i) == false)//Check if matchingPag does not already contain the value
                            {
                                matchingPag.Add(relation.ElementAt(i).Key);
                            }
                        }
                    }
                }
            }
            else//inclusion = 1
            {
                for (int i = 0; i < relation.Count; i++)
                {
                    matchingPag.Add(relation.ElementAt(i).Key);
                }
                for (int i = 0; i < relation.Count; i++)//Loops through every PAG
                {
                    for (int j = 0; j < skillIDs.Count; j++)//Loops through every skill inputed
                    {
                        if (relation.ElementAt(i).Value.Contains(Convert.ToInt32(skillIDs[j])) == false)//checks if the pag does not contain the skill
                        {
                            if (matchingPag.Contains(relation.ElementAt(i).Key) == true)//Check if matchingPag does not already contain the value
                            {
                                matchingPag.Remove(relation.ElementAt(i).Key);
                            }
                        }
                    }
                }
            }
            return matchingPag;
        }
        HashSet<int> modifiedPAGs = new HashSet<int>();
        public void AddModifiedPag(int pagID)
        {
            modifiedPAGs.Add(pagID);
        }
        public void ClearModifiedPags()
        {
            modifiedPAGs.Clear();
        }
    }
}
