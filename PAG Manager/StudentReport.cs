using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace PAG_Manager
{
    class StudentReport
    {
        private string fileLocation;
        //group info: Dictionary(key = groupID, value = tuple(t1 = group text, t2 = list(pagsInGroup)))
        Dictionary<int, Tuple<string, List<int>>> groupInfo = new Dictionary<int, Tuple<string, List<int>>>();
        string fileName = "PagGroup.csv";
        List<int> groupIdPosition = new List<int>();
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
    }
}
