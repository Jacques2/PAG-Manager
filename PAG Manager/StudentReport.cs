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
        public StudentReport(string inputFileLocation)
        {
            fileLocation = inputFileLocation;
        }
        public void LoadGroupInformation()
        {
            groupInfo.Clear();
            string lineRead;
            string[] SeperatedLine;
            StreamReader sr = new StreamReader(fileLocation + fileName);
            lineRead = sr.ReadLine();
            while (lineRead != null)
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                int groupID = Convert.ToInt32(SeperatedLine[0]);
                string groupName = SeperatedLine[1];
                List<int> listOfPags = new List<int>();
                for (int i = 2; i < SeperatedLine.Count(); i++)
                {
                    listOfPags.Add(Convert.ToInt32(SeperatedLine[i]));
                }
                groupInfo.Add(groupID, new Tuple<string, List<int>>(groupName, listOfPags));
                lineRead = sr.ReadLine();
            }
            sr.Close();
        }
        public Dictionary<int, Tuple<string, List<int>>> GetGroupInfo()
        {
            return groupInfo;
        }
    }
}
