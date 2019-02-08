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
        private List<List<int>> relation = new List<List<int>>();
        private string fileLocation;
        private int inclusion;
        public PagSkillRelation(string FileLocation)
        {
            fileLocation = FileLocation;
        }
        public void StartNewRelation(int size)
        {
            relation.Clear();
            for (int i = 0; i < size; i++)
            {
                relation.Add(new List<int> {});
            }
        }
        public void SetRelation(int pagID, int skillID)
        {
            relation[pagID].Add(skillID);
        }
        public void RemoveRelation(int pagID, int skillID)
        {
            relation[pagID].Remove(skillID);
        }
        public List<int> GetRelations(int PagID)
        {
            try
            {
                return relation[PagID];
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return null;
            }
        }
        public List<List<int>> GetAllRelations()
        {
            return relation;
        }
        public void BuildFromScratch()
        {
            File.Delete(fileLocation + "PagSkillRelation.csv");
            StreamWriter sw = new StreamWriter(fileLocation + "PagSkillRelation.csv");//overwrites exsisting data
            for (int pagID = 0; pagID < relation.Count; pagID++)
            {
                for (int skillID = 0; skillID < relation[pagID].Count; skillID++)//This loops through every record in the 2d list to write to the file
                {
                    sw.WriteLine(pagID + "," + relation[pagID][skillID] + "," + skillID);
                }
            }
            sw.Close();
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
                        if (relation[i].Contains(Convert.ToInt32(skillIDs[j])))//checks if the pag contains the skill
                        {
                            if (matchingPag.Contains(i) == false)//Check if matchingPag does not already contain the value
                            {
                                matchingPag.Add(i);
                            }
                        }
                    }
                }
            }
            else//inclusion = 1
            {
                for (int i = 0; i < relation.Count; i++)
                {
                    matchingPag.Add(i);
                }
                for (int i = 0; i < relation.Count; i++)//Loops through every PAG
                {
                    for (int j = 0; j < skillIDs.Count; j++)//Loops through every skill inputed
                    {
                        if (relation[i].Contains(Convert.ToInt32(skillIDs[j])) == false)//checks if the pag does not contain the skill
                        {
                            if (matchingPag.Contains(i) == true)//Check if matchingPag does not already contain the value
                            {
                                matchingPag.Remove(i);
                            }
                        }
                    }
                }
            }
            return matchingPag;
        }
    }
}
