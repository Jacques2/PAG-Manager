using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PAG_Manager
{
    public partial class FormMain : Form //This class manages everything related to interacting with the form or any of its elements. As there is a lot of interaction with the form, this class is very big.
    {
        protected string FILELOC = (AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\");
        //Setting up all class instances to be used throughout the program
        StudentLookup sl = new StudentLookup(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\");
        Admin ad = new Admin(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\");
        PagSkillRelation psr = new PagSkillRelation(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\");
        AwardPag ap = new AwardPag(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\");
        StudentReport sr = new StudentReport(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\");

        public FormMain()//Initialising the form 
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)//All first time setup for non-admin features. Admin setup appears later
        {
            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\") == false)
            {
                DirectoryInfo di = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\");
            }
            // CREATE FILES IF NOT EXSIST
            StreamWriter setupPag = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagList.csv");
            setupPag.Close();
            StreamWriter setupPagSkillRelation = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagSkillRelation.csv");
            setupPagSkillRelation.Close();
            StreamWriter setupSkill = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\SkillList.csv");
            setupSkill.Close();
            StreamWriter setupStudentRecord = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\StudentRecord.csv");
            setupStudentRecord.Close();
            StreamWriter setupPagAchievement = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagAchievement.csv");
            setupPagAchievement.Close();
            StreamWriter setupSkillRequirement = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\SkillRequirement.csv");
            setupSkillRequirement.Close();
            StreamWriter setupPagGroup = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagGroup.csv");
            setupPagGroup.Close();
            StreamWriter setupSettings = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\settings.dat");
            setupSettings.Close();
            // HIDING ADMIN TAB
            tabControlMain.TabPages.Remove(tabAdmin); //This line may be disabled while testing admin features, do not delete!
            ReloadAllSettings();
            // ACTIVITY/CONTENT SELECTION
            // LOAD ALL DATA
            ReloadAllData(false);
        }
        private void ReloadAllSettings()
        {
            string lineRead;
            string[] seperatedLine;
            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\settings.dat");//opens the student record file to start reading names
            lineRead = sr.ReadLine();
            if (lineRead != "" && lineRead != null)
            {
                seperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                if (seperatedLine[1] == "true")
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                sr.Close();
            }
        }
        private void ReloadAllData(bool admin)//Reloads all data into the program when big changes are made
        {//The parameter decides if the admin stuff will be reloaded. This saves processing power if the user does not need admin functions.
            ad.RemoveDuplicatePagAwards();//removes duplicate pag awards, as this causes issues throughout the program
            ad.LoadData();
            SortedList<int, string> pagList = new SortedList<int, string>();
            pagList = ad.GetPagList();
            SortedList<int, string> skillList = new SortedList<int, string>();
            skillList = ad.GetSkillList();
            //Admin stuff and pag relations
            //Load group information for student reports
            sr.LoadGroupInformation();
            if (admin)
            {
                listBoxPagList.Items.Clear();//Clears all items from boxes before re-adding them
                listBoxPagRelation.Items.Clear();
                listBoxSkillList.Items.Clear();
                listBoxGroupList.Items.Clear();
                dataGridViewSkillRequirement.Rows.Clear();
                checkedListBoxSkillRelation.Items.Clear();
                checkedListBoxPagList.Items.Clear();
                psr.ClearModifiedPags();
                for (int i = 0; i < pagList.Count; i++)//giving each entry a number
                {
                    listBoxPagList.Items.Add(pagList.ElementAt(i).Value);
                    listBoxPagRelation.Items.Add(pagList.ElementAt(i).Value);
                    checkedListBoxPagList.Items.Add(pagList.ElementAt(i).Value);
                }
                for (int i = 0; i < skillList.Count; i++)//giving each entry a number
                {
                    listBoxSkillList.Items.Add(skillList.ElementAt(i).Value);
                    checkedListBoxSkillRelation.Items.Add(skillList.ElementAt(i).Value);
                    dataGridViewSkillRequirement.Rows.Add(skillList.ElementAt(i).Value);
                }
                ad.BuildSkillRequirementIfEmpty();//build skill requirement table
                ArrayList skillRequirement = new ArrayList();
                skillRequirement = ad.LoadSkillRequirementNumber();
                for (int skill = 0; skill < skillRequirement.Count; skill++)
                {
                    dataGridViewSkillRequirement.Rows[skill].Cells[1].Value = Convert.ToString(skillRequirement[skill]);
                }
                //builds group table
                Dictionary<int, Tuple<string, List<int>>> groupInfo = new Dictionary<int, Tuple<string, List<int>>>();
                groupInfo = sr.GetGroupInfo();
                for (int group = 0; group < groupInfo.Count; group++)
                {
                    listBoxGroupList.Items.Add(groupInfo.ElementAt(group).Value.Item1);
                }
                //student information tab 
                ad.BuildStudentInformation();
                ad.ClearStudentsToDelete();
                listBoxStudentManagementList.Items.Clear();
                comboBoxInputType.SelectedIndex = -1;
                SortedList<int, Tuple<string, string, string, string>> studentInfo = new SortedList<int, Tuple<string, string, string, string>>(ad.GetStudentInformation());
                for (int i = 0; i < studentInfo.Count; i++)
                {
                    string fName = studentInfo.ElementAt(i).Value.Item1;
                    string lName = studentInfo.ElementAt(i).Value.Item2;
                    string theClass = studentInfo.ElementAt(i).Value.Item4;
                    listBoxStudentManagementList.Items.Add(fName + " " + lName + " - " + theClass);
                }
                //disabling things that should not be edited straight away
                checkedListBoxPagList.Enabled = false;
                checkedListBoxSkillRelation.Enabled = false;
                //referential integrity 
                ad.BuildPagsInUse();
                ad.BuildSkillsInUse();
                ad.BuildSkillRelationList();
            }
            //pag skill relations
            psr.ClearRelations();
            psr.LoadRelationFromFile();
            // STUDENT LOOKUP NAMES LIST
            checkBoxArchives.CheckState = CheckState.Unchecked;
            textBoxLookupName.Text = "";
            listBoxStudentNames.Items.Clear();
            ArrayList studentNames = sl.LoadNames(false);
            for (int i = 0; i < studentNames.Count; i++)
            {
                listBoxStudentNames.Items.Add(studentNames[i]);
            }
            sl.BuildLookupData();
            //Loading activity/content selection
            checkedListBoxActivitySelectionPag.Items.Clear();//Clears all items before re-adding them
            dataGridViewContentSelectionPag.Rows.Clear();
            dataGridViewActivitySelectionSkills.Rows.Clear();
            checkedListBoxContentSelectionSkill.Items.Clear();
            for (int i = 0; i < pagList.Count; i++)
            {
                checkedListBoxActivitySelectionPag.Items.Add(pagList.ElementAt(i).Value);
                dataGridViewContentSelectionPag.Rows.Add(pagList.ElementAt(i).Value);
            }
            for (int i = 0; i < skillList.Count; i++)
            {
                dataGridViewActivitySelectionSkills.Rows.Add(skillList.ElementAt(i).Value);
                checkedListBoxContentSelectionSkill.Items.Add(skillList.ElementAt(i).Value);
            }
            dataGridViewActivitySelectionSkills.AutoResizeColumns();

            //Skill and pag table clear
            while (dataGridViewSkills.Columns.Count > 5)
            {
                dataGridViewSkills.Columns.RemoveAt(5);
            }
            while (dataGridViewPag.Columns.Count > 5)
            {
                dataGridViewPag.Columns.RemoveAt(5);
            }
            dataGridViewSkills.Rows.Clear();
            dataGridViewPag.Rows.Clear();

            // SKILLS TABLE
            //AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\"
            SkillsDatabase sd = new SkillsDatabase();
            ArrayList skillHeaders = sd.LoadHeaders();
            for (int i = 0; i < skillHeaders.Count; i++)
            {
                dataGridViewSkills.Columns.Add("Skill" + Convert.ToString(i), Convert.ToString(skillHeaders[i]));
            }
            ArrayList skillData = new ArrayList();
            skillData = sd.LoadSkillData();
            for (int row = 0; row < skillData.Count; row++)
            {
                string[] seperatedLine = Convert.ToString(skillData[row]).Split(new[] { "," }, StringSplitOptions.None);
                if (seperatedLine[3] != "Archive")
                {
                    dataGridViewSkills.Rows.Add(seperatedLine);
                }
            }
            dataGridViewSkills.Columns[0].Visible = false;
            // PAG DATES TABLE
            PagDatabase pd = new PagDatabase();
            ArrayList pagHeaders = pd.LoadHeaders();
            for (int i = 0; i < pagHeaders.Count; i++)
            {
                dataGridViewPag.Columns.Add("Pag" + Convert.ToString(i), Convert.ToString(pagHeaders[i]));
            }
            ArrayList tableData = new ArrayList();
            tableData = pd.LoadPagData();
            for (int row = 0; row < tableData.Count; row++)
            {
                string[] seperatedLine = Convert.ToString(tableData[row]).Split(new[] { "," }, StringSplitOptions.None);
                if (seperatedLine[3] != "Archive")
                {
                    dataGridViewPag.Rows.Add(seperatedLine);
                }
            }
            dataGridViewPag.Columns[0].Visible = false;
            //Tree view - Years, classes and students
            treeViewYearSelect.Nodes.Clear();
            ap.ImportRelation(psr.GetAllRelations());

            Dictionary<int, string> yearDictionary = new Dictionary<int, string>();//building and retriving nodes
            List<List<string>> classList = new List<List<string>>();
            List<List<string>> studentList = new List<List<string>>();
            List<List<List<int>>> studentIDList = new List<List<List<int>>>();//This 3d list has to be built along with the tree diagram, so it cannot be done within an external class
            // ^This 3d array studentID[1][2][3] = year id 1, class id 2, student id 3
            ap.BuildClassTreeDictionary();//builds the lists

            yearDictionary = ap.GetYearDictionary();//retrieves the generated lists
            classList = ap.GetClassList();
            studentList = ap.GetStudentList();//0 = id, 1 = yearid, 2 = classid, 3 = full name

            for (int i = 0; i < yearDictionary.Count; i++)//adding top level nodes
            {
                treeViewYearSelect.Nodes.Add(yearDictionary[i]);
            }
            for (int i = 0; i < classList.Count; i++)//adding class nodes
            {
                for (int j = 0; j < classList[i].Count; j++)
                {
                    treeViewYearSelect.Nodes[i].Nodes.Add(classList[i][j]);
                }
            }
            //building studentID
            studentIDList.Clear();
            for (int year = 0; year < yearDictionary.Count; year++)
            {
                studentIDList.Add(new List<List<int>> { });
                for (int myClass = 0; myClass < classList[year].Count; myClass++)
                {
                    studentIDList[year].Add(new List<int> { });
                }
            }
            for (int i = 0; i < studentList.Count; i++)//adds students to classes and studentIDList
            {
                treeViewYearSelect.Nodes[Convert.ToInt32(studentList[i][1])].Nodes[Convert.ToInt32(studentList[i][2])].Nodes.Add(studentList[i][3]);
                studentIDList[Convert.ToInt32(studentList[i][1])][Convert.ToInt32(studentList[i][2])].Add(Convert.ToInt32(studentList[i][0]));
            }
            ap.SetStudentID(studentIDList);
            //Tree view- Pags and skills
            treeViewPagSelect.Nodes.Clear();
            ap.BuildPagTreeDictionary();
            Dictionary<int, List<int>> pagTreeID = ap.GetPagTreeID();
            Dictionary<int, string> awardPagList = ap.GetPagList();
            for (int i = 0; i < pagTreeID.Count; i++)//adding class nodes
            {
                int pagID = pagTreeID.ElementAt(i).Key;
                string pagName = ap.PagLookup(pagID);
                treeViewPagSelect.Nodes.Add(Convert.ToString(pagName));
                for (int j = 0; j < pagTreeID[pagID].Count; j++)
                {
                    int skillID = pagTreeID[pagID][j];
                    string skillName = ap.SkillLookup(skillID);
                    if (skillName != null)//checks if the skill is valid
                    {
                        treeViewPagSelect.Nodes[i].Nodes.Add(skillName);
                    }
                }
            }
            for (int node = 0; node < treeViewYearSelect.Nodes.Count; node++)//expands all the year nodes for ease of use
            {
                treeViewYearSelect.Nodes[node].Expand();
            }
            ap.BuildPagAwardList();
            UpdateSelectedPagLabel();
            UpdateSelectedStudentLabel();
            //student report
            sr.BuildPagSubsets();
            sr.BuildLists();
            sr.BuildPagList();
            sr.BuildSkillInformation();
        }

        private void radioButtonAdmin_CheckedChanged(object sender, EventArgs e)//ADMIN: Allows advanced database editing
        {
            dataGridViewSkills.ReadOnly = false;
        }

        private void button1_Click(object sender, EventArgs e)//ADMIN: opens file explorer to the main directory as well as shows a messagebox with the directory
        {
            MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory, "Main Save Directory");
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory);
        }

        public int FindNextIndex(string fileName)//finds the next available student index
        {
            string lineRead;
            string[] seperatedLine;
            int highestNumber = 0;
            StreamReader sr = new StreamReader(fileName);
            lineRead = sr.ReadLine();
            while (lineRead != null)
            {
                seperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);//goes through each line, to find the highest index
                int newNumber = Convert.ToInt32(seperatedLine[0]) + 1;
                if (newNumber > highestNumber)
                {
                    highestNumber = newNumber;
                }
                lineRead = sr.ReadLine();
                if (lineRead == null)
                {
                    sr.Close();
                    return highestNumber;
                }
            }
            sr.Close();
            return -1;
        }

        private void textBoxLookupName_TextChanged(object sender, EventArgs e)//Student lookup search
        {
            ReplaceCommas(sender);
            LookupUpdate();
        }

        private void LookupUpdate()//Student lookup search
        {
            ArrayList studentNames = sl.FilterNames(textBoxLookupName.Text);
            listBoxStudentNames.Items.Clear();
            for (int i = 0; i < studentNames.Count; i++)
            {
                listBoxStudentNames.Items.Add(studentNames[i]);
            }
        }

        private void listBoxStudentNames_SelectedIndexChanged(object sender, EventArgs e)//Student Lookup get student
        {
            if (listBoxStudentNames.SelectedIndex != -1)
            {
                buttonLookupSubmitModifications.Enabled = true;
            }
            else
            {
                buttonLookupSubmitModifications.Enabled = false;
            }
            dataGridViewStudentLookup.RowHeadersVisible = false;
            dataGridViewStudentLookup.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            List<string> times = new List<string>();
            Stopwatch t = new Stopwatch();
            t.Start();
            bool unsavedChanges = false;
            if (sl.GetUnsavedChanges() && listBoxStudentNames.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("You have unsaved changes, do you wish to proceed and lose these changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)//asks the user if they wish to proceed and lose changes
                {
                    sl.SetUnsavedChanges(false);
                }
                else
                {
                    unsavedChanges = true;
                    listBoxStudentNames.SelectedIndex = -1;
                }
            }
            if (listBoxStudentNames.SelectedIndex != -1 && unsavedChanges == false)
            {
                sl.ResetChanges();
                sl.ClearPagsWithData();//clears all pags containing data as it needs to be rebuilt for the new student
                //stops user interaction whilst data loads
                dataGridViewStudentLookup.Enabled = false;
                sl.LoadState = true;//stops auto colouring of cells
                //gets student report for current student
                int currentStudentID = sl.GetStudentPosition(listBoxStudentNames.SelectedIndex);
                //MessageBox.Show(Convert.ToString(currentStudentID));//shows student id to user - used for debugging
                t.Stop(); times.Add(Convert.ToString(t.ElapsedMilliseconds)); t.Restart();//WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
                ArrayList missingGroups = sr.GetMissingGroups(currentStudentID, false);
                int numMissingGroups = missingGroups.Count;
                int totalGroups = sr.GetNumberOfGroups();
                int totalSkills = dataGridViewStudentLookup.RowCount - 1;
                ArrayList missingSkills = sr.GetMissingSkills(currentStudentID);
                int numMissingSkills = missingSkills.Count;
                dataGridViewStudentLookup.Columns[0].HeaderText = Convert.ToString(listBoxStudentNames.SelectedItem + "\n " + Convert.ToString(totalGroups - numMissingGroups) + "/" + Convert.ToString(totalGroups) + " Groups Completed \n " + Convert.ToString(totalSkills - numMissingSkills) + "/" + Convert.ToString(totalSkills) + " Skills Completed");
                //clears every cell

                t.Stop(); times.Add(Convert.ToString(t.ElapsedMilliseconds)); t.Restart();//WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
                for (int column = 1; column < dataGridViewStudentLookup.ColumnCount; column++)
                {
                    dataGridViewStudentLookup.Rows[0].Cells[column].Value = null;
                    List<int> skillsInPag = new List<int>();
                    skillsInPag = psr.GetRelations(sl.ReversePagLookup(column));
                    for (int row = 0; row < dataGridViewStudentLookup.RowCount - 1; row++)
                    {
                        if (skillsInPag.Contains(sl.ReverseSkillLookup(row)) && dataGridViewStudentLookup.Rows[row + 1].Cells[column].Value != null)
                        {
                            dataGridViewStudentLookup.Rows[row + 1].Cells[column].Style.BackColor = Color.White;
                            dataGridViewStudentLookup.Rows[row + 1].Cells[column].Value = null;
                        }
                    }
                }

                t.Stop(); times.Add(Convert.ToString(t.ElapsedMilliseconds)); t.Restart();//WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
                //gets every record and adds to table
                List<Tuple<int, int, string>> lookupData = new List<Tuple<int, int, string>>();
                lookupData = sl.LookupStudent(sl.GetStudentPosition(listBoxStudentNames.SelectedIndex));
                sl.SetCurrentStudentID(sl.GetStudentPosition(listBoxStudentNames.SelectedIndex));
                for (int record = 0; record < lookupData.Count; record++)
                {
                    dataGridViewStudentLookup.Rows[lookupData[record].Item1].Cells[lookupData[record].Item2].Value = lookupData[record].Item3;
                    sl.AddPagWithData(lookupData[record].Item2);
                }
            }

            t.Stop(); times.Add(Convert.ToString(t.ElapsedMilliseconds)); t.Restart();//WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
            //colouring cells
            for (int row = 1; row < dataGridViewStudentLookup.RowCount; row++)
            {
                for (int cell = 0; cell < dataGridViewStudentLookup.ColumnCount; cell++)
                {
                    if (Convert.ToString(dataGridViewStudentLookup.Rows[row].Cells[cell].Value) != "")
                    {
                        if (Convert.ToString(dataGridViewStudentLookup.Rows[row].Cells[cell].Value) == "Achieved")//checks if value is achieved
                        {
                            dataGridViewStudentLookup.Rows[row].Cells[cell].Style.BackColor = Color.LawnGreen;
                        }
                        if (Convert.ToString(dataGridViewStudentLookup.Rows[row].Cells[cell].Value) == "Not Achieved")//checks if value is not achieved
                        {
                            dataGridViewStudentLookup.Rows[row].Cells[cell].Style.BackColor = Color.FromArgb(241, 130, 48);
                        }
                        if (Convert.ToString(dataGridViewStudentLookup.Rows[row].Cells[cell].Value) == "Absent")//checks if value is absent
                        {
                            dataGridViewStudentLookup.Rows[row].Cells[cell].Style.BackColor = Color.Yellow;
                        }
                    }
                }
            }
            for (int cell = 1; cell < dataGridViewStudentLookup.ColumnCount; cell++)
            {
                dataGridViewStudentLookup.Rows[0].Cells[cell].Style.BackColor = Color.White;
                if (dataGridViewStudentLookup.Rows[0].Cells[cell].Value != null)
                {
                    if (Convert.ToString(dataGridViewStudentLookup.Rows[0].Cells[cell].Value) == "Absent")//checks if date entry is absent
                    {
                        dataGridViewStudentLookup.Rows[0].Cells[cell].Style.BackColor = Color.Yellow;
                    }
                    else
                    {
                        dataGridViewStudentLookup.Rows[0].Cells[cell].Style.BackColor = Color.SkyBlue;//colours date entry blue
                    }
                }
            }
            dataGridViewStudentLookup.Enabled = true;
            sl.LoadState = false;//allows auto colouring of cells
            t.Stop();
            for (int i = 0; i < times.Count; i++)
            {
                //MessageBox.Show(Convert.ToString(times[i]));
            }
            dataGridViewStudentLookup.RowHeadersVisible = true;
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)//Enables and disables the admin tab; does NOT initiate first time admin load
        {
            if (tabControlMain.TabPages.Contains(tabAdmin))
            {
                tabControlMain.TabPages.Remove(tabAdmin);
                adminToolStripMenuItem.Text = "Enable Admin";
                MessageBox.Show("Admin mode has been disabled.", "PAG Manager");
            }
            else
            {
                tabControlMain.TabPages.Add(tabAdmin);
                adminToolStripMenuItem.Text = "Disable Admin";
                MessageBox.Show("Admin mode has been enabled.\nDo not change anything unless you know what you are doing.", "PAG Manager");
            }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)//This sorts out individual tab loads
        {
            if (sl.GetUnsavedChanges() && Convert.ToString(tabControlMain.SelectedTab) != "TabPage: {Student Lookup}")
            {
                DialogResult result = MessageBox.Show("You have unsaved changes, do you wish to proceed and lose these changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No)//checks if user want to lose changes
                {
                    tabControlMain.SelectedTab = tabLookup;
                }
                else
                {
                    sl.SetUnsavedChanges(false);
                }
            }
            if (Convert.ToString(tabControlMain.SelectedTab) == "TabPage: {Activity Selection}")
            {
                dataGridViewActivitySelectionSkills.AutoResizeColumns();
            }
            if (Convert.ToString(tabControlMain.SelectedTab) == "TabPage: {Specification Content Selection}")
            {
                dataGridViewContentSelectionPag.AutoResizeColumns();
                listBoxContentSelectionInclusion.SelectedIndex = 0;
                psr.SetInclusion(0);
            }
            if (Convert.ToString(tabControlMain.SelectedTab) == "TabPage: {Admin}")//This handles all the first time admin-only load only when the admin tab is first opened
            {
                ReloadAllData(true);
            }
            if (Convert.ToString(tabControlMain.SelectedTab) == "TabPage: {PAG View}")
            {
                for (int row = 0; row < dataGridViewPag.RowCount; row++)//loops through every row
                {
                    for (int cell = 5; cell < dataGridViewPag.ColumnCount; cell++)//loops through every column
                    {
                        if (Convert.ToString(dataGridViewPag.Rows[row].Cells[cell].Value) == "Absent")//checks if student is absent
                        {
                            dataGridViewPag.Rows[row].Cells[cell].Style.BackColor = Color.OrangeRed;//colours red if absent
                        }
                        else if (Convert.ToString(dataGridViewPag.Rows[row].Cells[cell].Value) != "")
                        {
                            dataGridViewPag.Rows[row].Cells[cell].Style.BackColor = Color.Gold;//colours gold if completed
                        }
                    }
                }
            }
            if (Convert.ToString(tabControlMain.SelectedTab) == "TabPage: {Student Lookup}" && sl.GetUnsavedChanges() == false)
            {
                listBoxStudentNames.SelectedIndex = -1;
                dataGridViewStudentLookup.Enabled = false;
                textBoxLookupName.Text = "";
                //Prepares first time use of student lookup tab
                dataGridViewStudentLookup.Columns.Clear();
                dataGridViewStudentLookup.Rows.Clear();
                //Load all pags and put into columns
                PagDatabase pd = new PagDatabase();
                ArrayList pagHeaders = pd.LoadHeaders();
                dataGridViewStudentLookup.Columns.Add("0", "");//Loads first column as skill
                dataGridViewStudentLookup.Columns[0].ReadOnly = true;
                dataGridViewStudentLookup.Columns[0].Width = 300;
                for (int i = 0; i < pagHeaders.Count; i++)
                {
                    dataGridViewStudentLookup.Columns.Add(Convert.ToString(i + 1), Convert.ToString(pagHeaders[i]));
                }
                //load all skills and put into rows
                SkillsDatabase sd = new SkillsDatabase();
                ArrayList skillHeaders = sd.LoadHeaders();
                dataGridViewStudentLookup.Rows.Add("Date Completed");
                for (int i = 0; i < skillHeaders.Count; i++)
                {
                    dataGridViewStudentLookup.Rows.Add(skillHeaders[i]);
                }
                dataGridViewStudentLookup.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                listBoxStudentNames.SelectedIndex = -1;//deselects anything currently selected from the list box
                //locks sorting the columns
                foreach (DataGridViewColumn column in dataGridViewStudentLookup.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                //locks all the cells that are not relevent to the skill
                for (int column = 1; column < dataGridViewStudentLookup.ColumnCount; column++)
                {
                    List<int> skillsInPag = new List<int>();
                    skillsInPag = psr.GetRelations(sl.ReversePagLookup(column));
                    for (int row = 0; row < dataGridViewStudentLookup.RowCount - 1; row++)
                    {
                        if (skillsInPag.Contains(sl.ReverseSkillLookup(row)) == false)
                        {
                            dataGridViewStudentLookup.Rows[row + 1].Cells[column].ReadOnly = true;
                            dataGridViewStudentLookup.Rows[row + 1].Cells[column].Style.BackColor = Color.FromArgb(200, 200, 200);
                        }
                    }
                }
                //freezes the first column
                dataGridViewStudentLookup.Columns[0].Frozen = true;
            }
        }

        private void tabControlAdmin_Resize(object sender, EventArgs e)//ADMIN: This resizes the text boxes when the form is resized when PAG/Skill tab is active. Very CPU intensive
        {
            pagListToolStripTextBox.Size = new Size((tabControlAdmin.Size.Width / 2) - 148, 25);
            skillListToolStripTextBox.Size = new Size((tabControlAdmin.Size.Width / 2) - 148, 25);
            pagGroupToolStripTextBox.Size = new Size((tabControlAdmin.Size.Width / 2) - 148, 25);
        }

        private void listBoxPagList_SelectedIndexChanged(object sender, EventArgs e)//ADMIN: Sets the text box text to the selected list box value
        {
            if (listBoxPagList.SelectedIndex != -1)
            {
                pagListToolStripTextBox.Text = (Convert.ToString(listBoxPagList.SelectedItem));
            }
        }

        private void pagListToolStripTextBox_TextChanged(object sender, EventArgs e)//ADMIN: Changes the list box selected value to the user modified value in the text box
        {
            ReplaceCommas(sender);
            if (listBoxPagList.SelectedIndex != -1)
            {
                ad.RenamePag(listBoxPagList.SelectedIndex, pagListToolStripTextBox.Text);
                listBoxPagList.Items[listBoxPagList.SelectedIndex] = pagListToolStripTextBox.Text;
            }
        }

        private void listBoxSkillList_SelectedIndexChanged(object sender, EventArgs e)//ADMIN: Sets the text box text to the selected list box value
        {
            if (listBoxSkillList.SelectedIndex != -1)
            {
                skillListToolStripTextBox.Text = (Convert.ToString(listBoxSkillList.SelectedItem));
            }
        }

        private void skillListToolStripTextBox_TextChanged(object sender, EventArgs e)//ADMIN: Changes the list box selected value to the user modified value in the text box
        {
            ReplaceCommas(sender);
            if (listBoxSkillList.SelectedIndex != -1)
            {
                ad.RenameSkill(listBoxSkillList.SelectedIndex, skillListToolStripTextBox.Text);
                listBoxSkillList.Items[listBoxSkillList.SelectedIndex] = skillListToolStripTextBox.Text;
            }
        }

        private void pagListToolStripButtonAddRecord_Click(object sender, EventArgs e)//ADMIN: creates a new pag and selects the text for instant renaming
        {
            ad.AddPag();
            listBoxPagList.Items.Add("New PAG");
            listBoxPagList.SelectedIndex = listBoxPagList.Items.Count - 1;
            pagListToolStripTextBox.Focus();
            pagListToolStripTextBox.SelectAll();
        }

        private void skillListToolStripButtonAddRecord_Click(object sender, EventArgs e)//ADMIN: creates a new skill and selects the text for instant renaming
        {
            ad.AddSkill();
            listBoxSkillList.Items.Add("New Skill");
            listBoxSkillList.SelectedIndex = listBoxSkillList.Items.Count - 1;
            skillListToolStripTextBox.Focus();
            skillListToolStripTextBox.SelectAll();
        }

        private void pagListToolStripButtonRemovePag_Click(object sender, EventArgs e)//ADMIN: removes the selected list box index
        {
            if (listBoxPagList.SelectedIndex != -1)//checks if an object is selected
            {
                int pagID = ad.GetPagId(listBoxPagList.SelectedIndex);
                bool inUse = ad.IsPagInUse(pagID);
                if (inUse == false)//checks if the pag has been awarded to a student
                {
                    List<int> relations = new List<int>();
                    relations = psr.GetRelations(pagID);
                    if (relations.Count == 0)//checks if there are any relations for this pag
                    {
                        ad.RemovePagFromPosition(listBoxPagList.SelectedIndex);
                        listBoxPagList.Items.RemoveAt(listBoxPagList.SelectedIndex);
                    }
                    else if (relations.Count == 1)
                    {
                        MessageBox.Show("This PAG has 1 skill assigned to it and cannot be deleted. Unassign this skill before deleting.");
                    }
                    else
                    {
                        MessageBox.Show("This PAG has " + Convert.ToString(relations.Count) + " assigned to it and cannot be deleted. Unassign these skills before deleting.");
                    }
                }
                else
                {
                    MessageBox.Show("This PAG has been awarded to at least one student and cannot be removed. Remove this PAG from all students with it to be able to delete it", "PAG Manager");
                }
            }
        }

        private void skillListToolStripButtonRemovePag_Click(object sender, EventArgs e)//ADMIN: removes the selected list box index
        {
            if (listBoxSkillList.SelectedIndex != -1)//checks valid selection
            {
                int skillID = ad.GetSkillId(listBoxSkillList.SelectedIndex);
                bool inUse = ad.IsSkillInUse(skillID);
                if (inUse == false)//checks if skill has been awarded to a student
                {
                    HashSet<int> pagsRequired = new HashSet<int>();
                    pagsRequired = ad.GetAllPagsForSkill(skillID);
                    if (pagsRequired.Count == 0)//checks that it is not required for other items
                    {
                        ad.RemoveSkillFromPosition(listBoxSkillList.SelectedIndex);
                        listBoxSkillList.Items.RemoveAt(listBoxSkillList.SelectedIndex);
                    }
                    else
                    {
                        string errorMessage = "This skill is assigned to the following PAG's and cannot be removed. Remove the relations to delete this skill: " + Environment.NewLine + Environment.NewLine;
                        for (int i = 0; i < pagsRequired.Count; i++)//loops through evert required pag
                        {
                            string pagName = ad.GetPagName(pagsRequired.ElementAt(i));
                            errorMessage += pagName + Environment.NewLine;
                        }

                        MessageBox.Show(Convert.ToString(errorMessage), "PAG Manager");
                    }
                }
                else
                {
                    MessageBox.Show("This skill has been awarded to at least one student and cannot be removed", "PAG Manager");
                }
            }
        }

        private void buttonLoadDefaults_Click(object sender, EventArgs e)//ADMIN: Writes defaults saved internally within the program into external files that can be used/modified by the program
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagList.csv", (PAG_Manager.Properties.Resources.PagList));
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\SkillList.csv", (PAG_Manager.Properties.Resources.SkillList));
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagSkillRelation.csv", (PAG_Manager.Properties.Resources.PagSkillRelation));
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagGroup.csv", (PAG_Manager.Properties.Resources.PagGroup));
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\SkillRequirement.csv", (PAG_Manager.Properties.Resources.SkillRequirement));
            MessageBox.Show("Defaults successfully loaded", "PAG Manager");
            ReloadAllData(true);
        }

        private void pagListToolStripButtonSave_Click(object sender, EventArgs e)//ADMIN: Saves all PAG Data
        {
            ad.SavePagData();
            ReloadAllData(true);
            MessageBox.Show("PAG names saved", "PAG Manager");
        }

        private void skillListToolStripButtonSave_Click(object sender, EventArgs e)//ADMIN: Saves all Skill Data
        {
            ad.SaveSkillData();
            ReloadAllData(true);
            MessageBox.Show("Skill names saved", "PAG Manager");
        }

        private void ClearTickBoxes()//ADMIN: Clears all check boxes from skill relations
        {
            for (int i = 0; i < checkedListBoxSkillRelation.Items.Count; i++)
            {
                checkedListBoxSkillRelation.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void listBoxPagRelation_SelectedIndexChanged(object sender, EventArgs e)//ADMIN: Clears all check boxes and reticks new boxes for the selected PAG
        {
            ClearTickBoxes();
            if (listBoxPagRelation.SelectedIndex != -1)//checks if anything is selected
            {
                int pagID = ad.GetPagId(listBoxPagRelation.SelectedIndex);
                bool inUse = ad.IsPagInUse(pagID);//checks if the pag has been awarded to anyone
                if (inUse == false)
                {
                    checkedListBoxSkillRelation.Enabled = true; // enableing editing as input is valid
                    checkedListBoxSkillRelation.SelectedIndex = -1;
                    List<int> boxesToTick = psr.GetRelations(pagID);
                    if (boxesToTick != null)
                    {
                        for (int i = 0; i < boxesToTick.Count; i++)
                        {
                            int position = ad.GetSkillPositionFromID(boxesToTick[i]);
                            checkedListBoxSkillRelation.SetItemCheckState(position, CheckState.Checked);
                        }
                    }
                }
                else//pag has been awarded to a student
                {
                    checkedListBoxSkillRelation.Enabled = false;
                    listBoxPagRelation.SelectedIndex = -1;
                    MessageBox.Show("This PAG has been awarded to at least one student and cannot be modified", "PAG Manager");
                }
            }
        }

        private void checkedListBoxSkillRelation_ItemCheck(object sender, ItemCheckEventArgs e)//ADMIN: Sets or removes a relation when the checked list box is modified
        {
            if (listBoxPagRelation.SelectedIndex != -1)
            {
                if (checkedListBoxSkillRelation.SelectedIndex != -1)
                {
                    int skillID = ad.GetSkillId(checkedListBoxSkillRelation.SelectedIndex);
                    int pagID = ad.GetPagId(listBoxPagRelation.SelectedIndex);
                    psr.AddModifiedPag(pagID);
                    if (checkedListBoxSkillRelation.GetItemChecked(checkedListBoxSkillRelation.SelectedIndex) == false) //Checking if the checked box is checked or unchecked
                    {//checked
                        psr.SetRelation(pagID, skillID);
                    }
                    else//unchecked
                    {
                        psr.RemoveRelation(pagID, skillID);
                    }
                }
            }
        }

        private void buttonBuildPagSkillRelation_Click(object sender, EventArgs e)//ADMIN: rewrites all relations to file
        {
            psr.SaveRelations();
            ReloadAllData(true);
        }

        private void dataGridViewActivitySelectionSkills_SelectionChanged(object sender, EventArgs e)//Stops selection of the activity selection skills list
        {
            dataGridViewActivitySelectionSkills.ClearSelection();
        }

        private void RecolourActivitySelection()//Uncolours all cells, then cycles through each cell and colouring if nesessary 
        {
            for (int i = 0; i < dataGridViewActivitySelectionSkills.RowCount; i++)
            {
                dataGridViewActivitySelectionSkills.Rows[i].Cells[0].Style.BackColor = Color.White;
            }
            for (int i = 0; i < checkedListBoxActivitySelectionPag.Items.Count; i++)//Goes through each selected box highlighting all the matching skills
            {
                if ((checkedListBoxActivitySelectionPag.GetItemChecked(i) && checkedListBoxActivitySelectionPag.SelectedIndex != i) || (checkedListBoxActivitySelectionPag.SelectedIndex == i && checkedListBoxActivitySelectionPag.GetItemChecked(checkedListBoxActivitySelectionPag.SelectedIndex) == false))//checks if the box is ticked
                {
                    int pagID = ad.GetPagId(i);
                    List<int> skillsToHighlight = psr.GetRelations(pagID);//gets all related skills
                    if (skillsToHighlight != null)//checks if skills have been returned
                    {
                        for (int j = 0; j < skillsToHighlight.Count; j++)//loops colouring in all skills
                        {
                            dataGridViewActivitySelectionSkills.Rows[ad.GetSkillPositionFromID(skillsToHighlight[j])].Cells[0].Style.BackColor = Color.Yellow;
                        }
                    }
                }
            }

        }
        private CheckState ChangeCheckState(CheckState checkForCheck)//Returns the opposite CheckState to what has been entered
        {
            if (checkForCheck == CheckState.Checked)
            {
                return CheckState.Unchecked;
            }
            else
            {
                return CheckState.Checked;
            }
        }

        private void buttonActivitySelectResetSelection_Click(object sender, EventArgs e)//Clears all of the activity selection and then recolours
        {
            for (int i = 0; i < checkedListBoxActivitySelectionPag.Items.Count; i++)
            {
                checkedListBoxActivitySelectionPag.SetItemCheckState(i, CheckState.Unchecked);
            }
            checkedListBoxActivitySelectionPag.SelectedIndex = -1;
            RecolourActivitySelection();
        }

        private void checkedListBoxActivitySelectionPag_ItemCheck(object sender, ItemCheckEventArgs e)//recolours when item is about to be checked
        {
            RecolourActivitySelection();
        }

        private void buttonContentSelectionSelectionReset_Click(object sender, EventArgs e)//Clears all of the content selection and then recolours
        {
            checkedListBoxContentSelectionSkill.SelectedIndex = -1;
            for (int i = 0; i < checkedListBoxContentSelectionSkill.Items.Count; i++)
            {
                checkedListBoxContentSelectionSkill.SetItemCheckState(i, CheckState.Unchecked);
            }
            ArrayList BLANKARRAYLIST = new ArrayList();
            RecolourContentSelection();
        }

        private void dataGridViewContentSelectionPag_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewContentSelectionPag.ClearSelection();
        }

        private void checkedListBoxContentSelectionSkill_ItemCheck(object sender, ItemCheckEventArgs e)//reverse lookups pags to skills
        {
            RecolourContentSelection();
        }
        private void RecolourContentSelection()//recolours the content selection 
        {
            ArrayList list = new ArrayList();
            list.Clear();//clears list
            for (int i = 0; i < checkedListBoxContentSelectionSkill.Items.Count; i++)//Step 1: build a list of all checked/about to be checked items
            {//Below if statement evals (A & B) | (¬A & c)
                if ((checkedListBoxContentSelectionSkill.SelectedIndex == i && checkedListBoxContentSelectionSkill.GetItemChecked(checkedListBoxContentSelectionSkill.SelectedIndex) == false) || (checkedListBoxContentSelectionSkill.SelectedIndex != i && checkedListBoxContentSelectionSkill.GetItemChecked(i)))
                {
                    int skillId = ad.GetSkillId(i);
                    list.Add(skillId);
                }
            }
            for (int i = 0; i < dataGridViewContentSelectionPag.RowCount; i++)//Step 2: Clear all excisiting colours 
            {
                dataGridViewContentSelectionPag.Rows[i].Cells[0].Style.BackColor = Color.White;
            }
            if (list.Count > 0)//Checks the list is not empty
            {
                ArrayList matchingPag = psr.ReverseRelationLookup(list);//Step 3: calculate and recolour required cells
                for (int i = 0; i < matchingPag.Count; i++)
                {
                    int pagPosition = ad.GetPagPositionFromID(Convert.ToInt32(matchingPag[i]));
                    if (pagPosition != -1)
                    {
                        dataGridViewContentSelectionPag.Rows[pagPosition].Cells[0].Style.BackColor = Color.Yellow;
                    }
                }
            }
        }

        private void listBoxContentSelectionInclusion_SelectedIndexChanged(object sender, EventArgs e)//inclusion index changed
        {
            if (listBoxContentSelectionInclusion.SelectedIndex != 0 && listBoxContentSelectionInclusion.SelectedIndex != 1)//checks that a valid selection has been made
            {
                listBoxContentSelectionInclusion.SelectedIndex = 0;//invalid selection, so selection is set to default
            }
            else
            {
                psr.SetInclusion(listBoxContentSelectionInclusion.SelectedIndex);//sets inclusion
                checkedListBoxContentSelectionSkill.SelectedIndex = -1;//clears selected skill 
                RecolourContentSelection();//recolours with new inclusion setting
            }
        }

        // Updates all child tree nodes recursively
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)//loops through each node in the treen
            {
                node.Checked = nodeChecked;//sets the node checkstate
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);//recursivly checks all child nodes
                }
            }
        }

        private void treeViewYearSelect_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)//checks if the tree has been changed
            {
                if (e.Node.Nodes.Count > 0)//If it has child nodes, then check them
                {
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
                UpdateSelectedStudentLabel();
            }
        }

        private void UpdateSelectedStudentLabel()//updates student label amount of student absent and number that will get the pag
        {
            int selectedStudents = 0;
            int absentStudents = 0;
            for (int yearID = 0; yearID < treeViewYearSelect.Nodes.Count; yearID++)
            {
                for (int classID = 0; classID < treeViewYearSelect.Nodes[yearID].Nodes.Count; classID++)
                {
                    for (int studentID = 0; studentID < treeViewYearSelect.Nodes[yearID].Nodes[classID].Nodes.Count; studentID++)//searches every student box to check if it has been ticked or not
                    {
                        if (treeViewYearSelect.Nodes[yearID].Nodes[classID].Nodes[studentID].Checked)//checks if student selected
                        {
                            selectedStudents++;
                        }
                        else if (treeViewYearSelect.Nodes[yearID].Nodes[classID].Checked)//checks if class is selected
                        {
                            absentStudents++;
                        }
                    }
                }
            }
            labelAwardPagSelectedStudents.Text = "You have selected " + Convert.ToString(selectedStudents) + " student";
            if (selectedStudents != 1)
            {
                labelAwardPagSelectedStudents.Text += "s";
            }
            labelAwardPagSelectedAbsent.Text = Convert.ToString(absentStudents) + " students within the selected class will be marked as absent";
        }

        private void treeViewPagSelect_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)//checks if the tree has been changed
            {
                if (e.Node.Nodes.Count > 0)//If it has child nodes, then check them
                {
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
                UpdateSelectedPagLabel();
            }
        }

        private void UpdateSelectedPagLabel()//updates labels with information about pag award
        {
            int selectedPags = 0;
            int failedSkills = 0;
            for (int pag = 0; pag < treeViewPagSelect.Nodes.Count; pag++)//searches each pag to check if its ticked
            {
                if (treeViewPagSelect.Nodes[pag].Checked)
                {
                    selectedPags++;
                    for (int skill = 0; skill < treeViewPagSelect.Nodes[pag].Nodes.Count; skill++)//searched through each skill within the pag to see if its not checked
                    {
                        if (treeViewPagSelect.Nodes[pag].Nodes[skill].Checked == false)
                        {
                            failedSkills++;
                        }
                    }
                }
            }
            if (selectedPags == 1)//checks if one or multiple pags are being awarded
            {
                labelAwardPagSelectedPag.Text = "You are awarding " + Convert.ToString(selectedPags) + " PAG";
            }
            else
            {
                labelAwardPagSelectedPag.Text = "You are awarding " + Convert.ToString(selectedPags) + " PAG's";
            }
            if (failedSkills == 1)
            {
                labelAwardPagSelectedFailedSkills.Text = Convert.ToString(failedSkills) + " skill within the selected PAG's will be marked as failed";
            }
            else
            {
                labelAwardPagSelectedFailedSkills.Text = Convert.ToString(failedSkills) + " skills within the selected PAG's will be marked as failed";
            }
        }

        private void dateTimePickerAwardPag_ValueChanged(object sender, EventArgs e)//award pag date change
        {
            if (dateTimePickerAwardPag.Value.Date > DateTime.Now)//checks if date is in the future
            {
                MessageBox.Show("The selected date is in the future. Change the value if you did not mean to select a future date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonAwardPag_Click(object sender, EventArgs e)//Prepare execution of -> AddPagAwards(ArrayList studentID, ArrayList pagsCompleted, DateTime dateCompleted, List<List<int>> skillsFailed)
        {
            List<List<List<int>>> studentIDList = ap.GetStudentID();
            //Part 1: ArrayList studentID
            ArrayList studentsToAwardPag = new ArrayList();
            ArrayList absentStudents = new ArrayList();
            for (int yearID = 0; yearID < treeViewYearSelect.Nodes.Count; yearID++)//getting students to award pag to.
            {
                for (int classID = 0; classID < treeViewYearSelect.Nodes[yearID].Nodes.Count; classID++)
                {
                    for (int studentID = 0; studentID < treeViewYearSelect.Nodes[yearID].Nodes[classID].Nodes.Count; studentID++)
                    {
                        if (treeViewYearSelect.Nodes[yearID].Nodes[classID].Nodes[studentID].Checked)//check is node is checked
                        {
                            studentsToAwardPag.Add(studentIDList[yearID][classID][studentID]);
                        }
                        else if (treeViewYearSelect.Nodes[yearID].Nodes[classID].Checked)//if node is not checked student is absent
                        {
                            absentStudents.Add(studentIDList[yearID][classID][studentID]);
                        }
                    }
                }
            }
            //Part 4 Preperation - Getting pag id tree list
            Dictionary<int, List<int>> pagTreeID = ap.GetPagTreeID();
            Dictionary<int, List<int>> skillsFailed = new Dictionary<int, List<int>>();
            //Part 2: ArrayList pagsCompleted
            ArrayList pagsCompletedByStudents = new ArrayList();
            for (int pag = 0; pag < treeViewPagSelect.Nodes.Count; pag++)//searches each pag to check if its ticked
            {
                if (treeViewPagSelect.Nodes[pag].Checked)
                {
                    int pagID = ap.GetPagTreeIDFromPosition(pag);
                    skillsFailed.Add(pagID, new List<int>());//Part 4 preperation, creating new blank entrys to be modified
                    pagsCompletedByStudents.Add(pagID);
                    for (int skill = 0; skill < treeViewPagSelect.Nodes[pag].Nodes.Count; skill++)//Part 4: searches through each skill within each checked pag to see if its not checked
                    {
                        if (treeViewPagSelect.Nodes[pag].Nodes[skill].Checked == false)
                        {
                            skillsFailed[pagID].Add(pagTreeID[pagID][skill]);
                        }
                    }
                }
            }
            //Part 3: Date
            DateTime dateCompleted = new DateTime();
            dateCompleted = dateTimePickerAwardPag.Value;
            if (absentStudents.Count != 0)//check if there is any need to add absenses
            {
                ap.AddPagAbsence(absentStudents, pagsCompletedByStudents);//The pags are the same for students that were absent, so the pags completed by student list works fine
            }
            ap.AddPagAwards(studentsToAwardPag, pagsCompletedByStudents, dateCompleted, skillsFailed);
            ReloadAllData(false);
        }

        private void buttonAwardPagClearSelection_Click(object sender, EventArgs e)//clears all selected items for award pag
        {
            for (int yearID = 0; yearID < treeViewYearSelect.Nodes.Count; yearID++)//loops through each year
            {
                treeViewYearSelect.Nodes[yearID].Checked = false;
                for (int classID = 0; classID < treeViewYearSelect.Nodes[yearID].Nodes.Count; classID++)//loops through each class
                {
                    treeViewYearSelect.Nodes[yearID].Nodes[classID].Checked = false;
                    for (int studentID = 0; studentID < treeViewYearSelect.Nodes[yearID].Nodes[classID].Nodes.Count; studentID++)//loops through each student
                    {
                        if (treeViewYearSelect.Nodes[yearID].Nodes[classID].Nodes[studentID].Checked)
                        {
                            treeViewYearSelect.Nodes[yearID].Nodes[classID].Nodes[studentID].Checked = false;
                        }
                    }
                }
            }
            UpdateSelectedStudentLabel();
            for (int pag = 0; pag < treeViewPagSelect.Nodes.Count; pag++)//unchecks all pag and skill nodes
            {
                treeViewPagSelect.Nodes[pag].Checked = false;
                for (int skill = 0; skill < treeViewPagSelect.Nodes[pag].Nodes.Count; skill++)//loops through each skill
                {
                    treeViewPagSelect.Nodes[pag].Nodes[skill].Checked = false;
                }
            }
        }

        private void buttonSaveSkillRequirement_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\SkillRequirement.csv");
            for (int skill = 0; skill < dataGridViewSkillRequirement.Rows.Count; skill++)//loops through every skill, adding its id and requirement to a file
            {
                sw.WriteLine(skill + "," + dataGridViewSkillRequirement.Rows[skill].Cells[1].Value);
            }
            sw.Close();
            MessageBox.Show("Skill Requirements saved", "PAG Manager");
        }

        private void buttonImportCSV_Click(object sender, EventArgs e)
        {
            openFileDialogImportCSV.ShowDialog();//When the user clicks the import csv button
        }

        private void openFileDialogImportCSV_FileOk(object sender, CancelEventArgs e)
        {//Only happens when the user clicks OK
            ArrayList csvLines = new ArrayList();
            csvLines = ad.LoadStudentCSV(openFileDialogImportCSV.FileName);
            dataGridViewStudentImport.Rows.Clear();//Clearing the table in case there is already stuff there
            dataGridViewStudentImport.Columns.Clear();
            string[] seperatedLine;
            int columns = 0;
            for (int line = 0; line < csvLines.Count; line++)
            {
                seperatedLine = Convert.ToString(csvLines[line]).Split(new[] { "," }, StringSplitOptions.None);
                while (columns < seperatedLine.Count())
                {
                    dataGridViewStudentImport.Columns.Add(Convert.ToString(columns), "");
                    columns++;
                }
                dataGridViewStudentImport.Rows.Add(seperatedLine);
            }
            buttonAddStudentRecord.Enabled = true;
        }

        private void openFileDialogImportCSV_HelpRequest(object sender, EventArgs e)
        {//The help button within the dialog
        }

        private void Button1_Click_1(object sender, EventArgs e)//add records to list
        {
            if (dataGridViewStudentImport.ColumnCount >= 4)
            {
                ArrayList columnOrder = new ArrayList();
                ArrayList orderedCSV = new ArrayList();
                int index = FindNextIndex(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\StudentRecord.csv");
                for (int column = 0; column < dataGridViewStudentImport.Columns.Count; column++)
                {
                    columnOrder.Add(dataGridViewStudentImport.Columns[column].DisplayIndex);//goes though every column getting the user sorted index
                }
                for (int rows = 0; rows < dataGridViewStudentImport.Rows.Count; rows++)
                {//adds every cell in order they have been arranged to a csv
                    orderedCSV.Add(Convert.ToString(dataGridViewStudentImport.Rows[rows].Cells[columnOrder.IndexOf(0)].Value) + "," + Convert.ToString(dataGridViewStudentImport.Rows[rows].Cells[columnOrder.IndexOf(1)].Value) + "," + Convert.ToString(dataGridViewStudentImport.Rows[rows].Cells[columnOrder.IndexOf(2)].Value) + "," + Convert.ToString(dataGridViewStudentImport.Rows[rows].Cells[columnOrder.IndexOf(3)].Value));
                }
                StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\StudentRecord.csv");
                string csvQuoteRemoved;
                for (int line = 0; line < orderedCSV.Count - 1; line++)//writes every line to file
                {
                    csvQuoteRemoved = Convert.ToString(orderedCSV[line]).Replace("\"", "");//removes " if they exsist
                    sw.WriteLine(Convert.ToString(index) + "," + csvQuoteRemoved);
                    index++;
                }
                sw.Close();
                ReloadAllData(true);
                MessageBox.Show("Records added", "PAG Manager");
            }
            else
            {
                MessageBox.Show("There must be at least 4 columns to add data to the list", "Alert");
            }
        }

        private void hidePagViewColumnsWithoutPAGDataToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)//shrinks pag columns with no data
        {
            for (int column = 5; column < dataGridViewPag.Columns.Count; column++)//loops through columns, starting from the first pag column
            {
                dataGridViewPag.Columns[column].Width = 100;//sets width to default width
                if (hidePagViewColumnsWithoutPAGDataToolStripMenuItem.CheckState == CheckState.Checked)//checks if item checked
                {
                    bool flag = false;
                    for (int row = 0; row < dataGridViewPag.Rows.Count; row++)//loops through each row checking for data
                    {
                        if (Convert.ToString(dataGridViewPag.Rows[row].Cells[column].Value) != "")//check for data
                        {
                            row = dataGridViewPag.Rows.Count;//data found
                            flag = true;
                        }
                    }
                    if (flag == false)//if no data found then shrink column
                    {
                        dataGridViewPag.Columns[column].Width = 10;
                    }
                }
            }
        }

        private void checkBoxShowStudentID_CheckedChanged(object sender, EventArgs e)//ADMIN: show student id in tables - debugging
        {
            if (checkBoxShowStudentID.CheckState == CheckState.Checked)//checks if check box is checked
            {
                dataGridViewPag.Columns[0].Visible = true;//shows all id columns
                dataGridViewSkills.Columns[0].Visible = true;
                dataGridViewStudentReport.Columns[0].Visible = true;
            }
            else
            {
                dataGridViewPag.Columns[0].Visible = false;//hides all id columns
                dataGridViewSkills.Columns[0].Visible = false;
                dataGridViewStudentReport.Columns[0].Visible = false;
            }
        }

        private void DataGridViewStudentLookup_CellEndEdit(object sender, DataGridViewCellEventArgs e)//cell has finished being edited
        {
            //This big case statment changes the value of what the user has typed to Achieved, Not achieved or absent, whichever is closest
            string contents;
            try
            {
                contents = dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value.ToString();//trys to get the value of what has been entered
            }
            catch (Exception)
            {
                contents = "";//if value cannot be obtained, set to blank
            }
            if (contents == "" && e.RowIndex == 0)//check if there the value is blank and row is date row
            {
                List<int> skillIDs = new List<int>();
                skillIDs = psr.GetRelations(sl.ReversePagLookup(e.ColumnIndex));//gets all the skills for the pag
                for (int skill = 0; skill < skillIDs.Count; skill++)//loops through every skill in the pag
                {
                    int position = sl.LookupSkill(skillIDs[skill]);
                    dataGridViewStudentLookup.Rows[position + 1].Cells[e.ColumnIndex].Value = null;//clears value for pag
                }
            }
            if (contents != "" && e.RowIndex != 0 && contents != null)//checks if data has been entered into the main part of the student lookup table
            {
                switch (dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value.ToString())//this section determines what the user has entered
                {
                    case ""://first checks if user has entered exactly what is required
                        break;
                    case "Achieved":
                        break;
                    case "Not Achieved":
                        break;
                    case "Absent":
                        break;
                    default:
                        List<int> bestFit = new List<int>();//gets levenshtien distance for the 3 allowed values
                        string userInput = dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value.ToString();
                        bestFit.Add(sl.LevenshteinDistance(userInput, "Achieved"));
                        bestFit.Add(sl.LevenshteinDistance(userInput, "Not Achiev"));//reduced because otherwise its too long to ever be selected
                        bestFit.Add(sl.LevenshteinDistance(userInput, "Absent"));
                        int bestIndex = bestFit.IndexOf(bestFit.Min());//gets the closest value
                        if (userInput.ToLower().Contains("yes") || userInput.ToLower().Contains("pass"))//overwrites closest value if contains keywords
                        {
                            bestIndex = 0;
                        }
                        if (userInput.ToLower().Contains("no") || userInput.ToLower().Contains("fail"))//overwrites closest value if contains keywords
                        {
                            bestIndex = 1;
                        }
                        switch (Convert.ToString(bestIndex))//turns the index into the word
                        {
                            case "0"://achieved skill
                                dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value = "Achieved";
                                try
                                {
                                    if (dataGridViewStudentLookup.Rows[0].Cells[e.ColumnIndex].Value.ToString() == "Absent")//if date is absent, set it to the current date
                                    {
                                        dataGridViewStudentLookup.Rows[0].Cells[e.ColumnIndex].Value = System.DateTime.Today.ToString("dd/MM/yyyy");
                                    }
                                }
                                catch (Exception)
                                {
                                }
                                break;
                            case "1"://not achieved skill
                                dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value = "Not Achieved";//if date is absent, set it to the current date
                                try
                                {
                                    if (dataGridViewStudentLookup.Rows[0].Cells[e.ColumnIndex].Value.ToString() == "Absent")
                                    {
                                        dataGridViewStudentLookup.Rows[0].Cells[e.ColumnIndex].Value = System.DateTime.Today.ToString("dd/MM/yyyy");
                                    }
                                }
                                catch (Exception)
                                {

                                }
                                break;
                            case "2"://absent for skill
                                dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value = "Absent";
                                break;
                            default:
                                dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value = "";
                                break;
                        }
                        break;
                }
            }
            else if (contents != "" && e.RowIndex == 0)//check if data has been entered in the date row
            {
                DateTime inputDate = new DateTime();
                bool absent = false;
                if (DateTime.TryParse(dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value.ToString(), out inputDate))//check for valid datetime
                {
                    dataGridViewStudentLookup[e.ColumnIndex, 0].Value = inputDate.ToString("dd/MM/yyyy");//if the input is a valid date, format to dd-mm-yyyy
                }
                else//user did not enter valid date
                {
                    if (dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value.ToString().ToLower().Contains("a"))//check if user entered a for absent
                    {
                        dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value = "Absent";//set value to absent
                        absent = true;
                        List<int> skillID = new List<int>();
                        skillID = psr.GetRelations(sl.ReversePagLookup(e.ColumnIndex));//get all related skills for pag
                        for (int skill = 0; skill < skillID.Count; skill++)//loop through each skill
                        {
                            int position = sl.LookupSkill(skillID[skill]);
                            dataGridViewStudentLookup.Rows[position + 1].Cells[e.ColumnIndex].Value = "Absent";//set skill to absent
                        }
                    }
                    else
                    {
                        dataGridViewStudentLookup[e.ColumnIndex, 0].Value = System.DateTime.Today.ToString("dd/MM/yyyy");//if no valid date and not absent, fill with current date
                    }
                }
                if (absent == false)//check if the value is not absent
                {
                    List<int> skillIDs = new List<int>();
                    skillIDs = psr.GetRelations(sl.ReversePagLookup(e.ColumnIndex));//gets all skills for pag
                    for (int skill = 0; skill < skillIDs.Count; skill++)//loops through every skill
                    {
                        int position = sl.LookupSkill(skillIDs[skill]);
                        dataGridViewStudentLookup.Rows[position + 1].Cells[e.ColumnIndex].Value = "Achieved";//sets skill to achieved
                    }
                }
            }
            if (Convert.ToString(dataGridViewStudentLookup[e.ColumnIndex, 0].Value) == "" && e.RowIndex != 0 && contents != "")
            {
                dataGridViewStudentLookup[e.ColumnIndex, 0].Value = System.DateTime.Today.ToString("dd/MM/yyyy");
            }
            //add a change to the change log
            sl.AddChange(e.ColumnIndex);
            sl.SetUnsavedChanges(true);
        }

        private void dataGridViewStudentLookup_CellValueChanged(object sender, DataGridViewCellEventArgs e)//cell value changed within student lookup
        {
            try//recolouring modified cells
            {
                if (e.RowIndex == 0)//checks if the row is the date row as that has different colour scheme
                {
                    if (Convert.ToString(dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value) != null && Convert.ToString(dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value) != "")//checks if the value is emplty
                    {
                        if (Convert.ToString(dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value) == "Absent")//checks if student was absent
                        {
                            dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Yellow;//sets colour to yellow if student absent
                        }
                        else
                        {
                            dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.SkyBlue;//sets colour to blue if student not absent
                        }
                    }
                    else
                    {
                        dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;//sets colour to white
                        List<int> skillIDs = new List<int>();
                        skillIDs = psr.GetRelations(sl.ReversePagLookup(e.ColumnIndex));
                        for (int skill = 0; skill < skillIDs.Count; skill++)
                        {
                            int position = sl.LookupSkill(skillIDs[skill]);
                            dataGridViewStudentLookup.Rows[position + 1].Cells[e.ColumnIndex].Value = null;
                        }
                    }
                }
                else
                {
                    if (Convert.ToString(dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value) == "Achieved")//checks if skill has been achieved
                    {
                        dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LawnGreen;//sets colour to green
                    }
                    else if (Convert.ToString(dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value) == "Not Achieved")//checks if skill has not been achieved
                    {
                        dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.FromArgb(241, 130, 48);//sets colour to orange
                    }
                    else if (Convert.ToString(dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value) == "Absent")//checks if student was absent
                    {
                        dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Yellow;//sets colour to yellow
                    }
                    else
                    {
                        dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;//sets colour to white if no data
                    }
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                //This stops exceptions for when the program tries to colour cells that dont exist, when the table is being loaded
            }
        }

        private void dataGridViewStudentLookup_KeyDown(object sender, KeyEventArgs e)//key pressed in student lookup
        {
            if (e.KeyValue == (char)Keys.Delete)//checks if the delete key was pressed
            {
                if (dataGridViewStudentLookup.CurrentCell.ColumnIndex != 0)//checks that the column is not the list of skills
                {
                    dataGridViewStudentLookup[dataGridViewStudentLookup.CurrentCell.ColumnIndex, dataGridViewStudentLookup.CurrentCell.RowIndex].Value = null;//clears the value of the cell
                    sl.AddChange(dataGridViewStudentLookup.CurrentCell.ColumnIndex);//sets the change within the student lookup class
                }
            }
        }

        private void startMaximisedToolStripMenuItem_Click(object sender, EventArgs e)//set start on maximised option
        {
            if (startMaximisedToolStripMenuItem.Checked)
            {

            }
        }

        private void buttonLookupSubmitModifications_Click(object sender, EventArgs e)//submit student lookup modifications
        {
            //first builds a new arraylist to store all the new data to be written to file
            Dictionary<int, string> newData = new Dictionary<int, string>();
            string dataString = "";
            ArrayList changes = new ArrayList(sl.GetChanges());//gets the list of changes
            List<int> skills = new List<int>();
            int studentID = sl.GetCurrentStudentID();
            for (int change = 0; change < changes.Count; change++)//loops through the list of changed columns
            {
                string dateCompleted = Convert.ToString(dataGridViewStudentLookup[Convert.ToInt32(changes[change]), 0].Value);//gets date completed
                int column = Convert.ToInt32(changes[change]);
                int pagID = sl.ReversePagLookup(Convert.ToInt32(changes[change]));
                if (dateCompleted != null && dateCompleted != "")//check if there is any pag data to write by looking if there is a date
                {
                    dataString = studentID.ToString();//starts building string of data to be sent to the file for appending/overwriting
                    dataString += ",";
                    dataString += Convert.ToString(pagID);
                    dataString += ",";
                    dataString += dateCompleted;
                    dataString += ",";
                    skills = psr.GetRelations(sl.ReversePagLookup(Convert.ToInt32(changes[change])));
                    ArrayList skillOrder = new ArrayList(sl.GetSkillOrder(pagID));
                    for (int skill = 0; skill < skillOrder.Count; skill++)
                    {
                        //loops through every skill, setting cellContents to the contents of the skill, then translating that to skill
                        int skillValue;
                        string cellContents = "Not Achieved";
                        try
                        {
                            cellContents = dataGridViewStudentLookup[Convert.ToInt32(changes[change]), sl.ReverseSkillLookup(Convert.ToInt32(skillOrder[skill])) + 1].Value.ToString();
                        }
                        catch
                        {
                            cellContents = "Not Achieved";//if there is no value it assumes skill has not been achievd
                            dataGridViewStudentLookup[Convert.ToInt32(changes[change]), sl.ReverseSkillLookup(Convert.ToInt32(skillOrder[skill])) + 1].Value = "Not Achieved";
                        }
                        switch (cellContents)
                        {
                            case "Achieved":
                                skillValue = 0;
                                break;
                            case "Not Achieved":
                                skillValue = 1;
                                break;
                            case "Absent":
                                skillValue = 2;
                                break;
                            default:
                                //invalid contents so writing 9 which will get picked up later by the student lookup modify record
                                skillValue = 9;
                                break;
                        }
                        dataString += skillValue.ToString();
                    }
                    newData.Add(column, dataString);
                }
                else//record needs to be deleted
                {
                    newData.Add(column, Convert.ToString(studentID) + "," + Convert.ToString(pagID) + ",D");
                }
            }
            bool isSuccess = sl.UpdateStudentData(newData);//updates the student data and returns wether it succeded or not
            sl.ResetChanges();
            sl.SetUnsavedChanges(false);
            //changes tab if update fails so that fresh copy can be reloaded
            tabControlMain.SelectedIndex = 0;
            if (isSuccess == true)
            {
                tabControlMain.SelectedIndex = 1;
            }
            ReloadAllData(false);
        }

        private void checkBoxArchives_CheckedChanged(object sender, EventArgs e)
        {
            //check archives button clicked in student lookup
            bool isChecked;
            if (checkBoxArchives.CheckState == CheckState.Checked)//sets the value isChecked, depending on if the value is checked or not
            {
                isChecked = true;
            }
            else
            {
                isChecked = false;
            }
            listBoxStudentNames.Items.Clear();
            ArrayList studentNames = sl.LoadNames(isChecked);
            for (int i = 0; i < studentNames.Count; i++)
            {
                listBoxStudentNames.Items.Add(studentNames[i]);
            }
            LookupUpdate();//refilters the list
        }

        private void pagGroupToolStripButtonAdd_Click(object sender, EventArgs e)
        {//adds a new item, highlights it and adds an id for it in student report
            listBoxGroupList.Items.Add("New Group");
            sr.AddGroup();
            listBoxGroupList.SelectedIndex = listBoxGroupList.Items.Count - 1;
            pagGroupToolStripTextBox.Focus();//focuses on the text box
            pagGroupToolStripTextBox.SelectAll();//selects all text so it can be immediatly edited
        }

        private void pagGroupToolStripRemove_Click(object sender, EventArgs e)//remove pag group
        {
            if (listBoxGroupList.SelectedIndex != -1)//checks there is a valid group selection
            {
                sr.DeleteGroup(listBoxGroupList.SelectedIndex);//deletes the group internally
                listBoxGroupList.Items.RemoveAt(listBoxGroupList.SelectedIndex);//removes the group from the list
            }
        }

        private void pagGroupToolStripTextBox_TextChanged(object sender, EventArgs e)//pag group name changed
        {
            ReplaceCommas(sender);//replaces any commas in the name
            if (listBoxGroupList.SelectedIndex != -1)//checks if there is a valid selection
            {
                listBoxGroupList.Items[listBoxGroupList.SelectedIndex] = pagGroupToolStripTextBox.Text;//renames the item in the list
                sr.RenameGroup(sr.GetGroupId(listBoxGroupList.SelectedIndex), pagGroupToolStripTextBox.Text);//renames the item internally
            }
        }

        private void listBoxGroupList_SelectedIndexChanged(object sender, EventArgs e)//different group selected
        {
            if (listBoxGroupList.SelectedIndex != -1)//checks a valid group has been selected
            {
                checkedListBoxPagList.Enabled = true;
                //uncheck every box
                for (int item = 0; item < checkedListBoxPagList.Items.Count; item++)//loops through every checked list box item and unchecks
                {
                    checkedListBoxPagList.SetItemCheckState(item, CheckState.Unchecked);
                }
                pagGroupToolStripTextBox.Text = (Convert.ToString(listBoxGroupList.SelectedItem));
                //gets list of pags for each group
                List<int> pagsInGroup = new List<int>();
                pagsInGroup = sr.GetGroupPagList(sr.GetGroupId(listBoxGroupList.SelectedIndex));//gets pags in the selected group
                for (int i = 0; i < pagsInGroup.Count; i++)//loops through every selected pag, checking it
                {
                    checkedListBoxPagList.SetItemCheckState(sl.LookupPagPosition(pagsInGroup[i]) - 1, CheckState.Checked);
                }
            }
            else
            {
                checkedListBoxPagList.Enabled = false;//disables the pag list as no valid group is selected
            }
        }

        private void checkedListBoxPagList_ItemCheck(object sender, ItemCheckEventArgs e)//pag check box ticked in groups
        {
            if (checkedListBoxPagList.SelectedIndex != -1)//checks that a group has been selected
            {
                int groupID = sr.GetGroupId(listBoxGroupList.SelectedIndex);//gets the group id
                if (e.NewValue == CheckState.Checked)//checks if check box has been checked or unchecked
                {
                    sr.AddPagToGroup(groupID, sl.ReversePagLookup(checkedListBoxPagList.SelectedIndex + 1));//adds pag to the group
                }
                else
                {
                    sr.RemovePagFromGroup(groupID, sl.ReversePagLookup(checkedListBoxPagList.SelectedIndex + 1));//removes pag from the group
                }
                checkedListBoxPagList.SelectedIndex = -1;//deselects any pag if it is selected
            }
        }

        private void pagGroupToolStripSave_Click(object sender, EventArgs e)//save group info button clicked
        {
            sr.WritePagGroupInfo();//saves all group info to file
            ReloadAllData(true);
        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)//generate report button clicked
        {
            dataGridViewStudentReport.Rows.Clear();//clears all the report rows
            sr.ClearStudentOrder();
            int studentAmount = sr.GetNumberOfStudents();
            progressBarStudentReport.Maximum = studentAmount;
            //pre individual student processing
            Dictionary<int, Tuple<string, string, string, string>> studentInfo = new Dictionary<int, Tuple<string, string, string, string>>();
            studentInfo = sr.GetAllStudentInformation();//gets all the student information
            int index = -1;
            for (int student = 0; student < studentInfo.Count; student++)//loops through every student
            {
                index++;
                int currentStudentID = studentInfo.ElementAt(student).Key;
                sr.AddToStudentOrder(currentStudentID);
                string studentFName = studentInfo.ElementAt(student).Value.Item1;//gets basic student information
                string studentSName = studentInfo.ElementAt(student).Value.Item2;
                string studentClass = studentInfo.ElementAt(student).Value.Item3;
                string studentYear = studentInfo.ElementAt(student).Value.Item4;
                if (studentClass != "Archive")
                {
                    //get missing skills for student
                    ArrayList missingSkills = new ArrayList();
                    missingSkills = sr.GetMissingSkills(currentStudentID);//gets missing skills
                    string missingSkillString = "";
                    for (int i = 0; i < missingSkills.Count; i++)
                    {
                        string skillName = sr.GetSkillName(Convert.ToInt32(missingSkills[i]));//combines all missing skills into a string to be displayed to the user
                        missingSkillString += skillName;
                        if (i + 1 != missingSkills.Count)
                        {
                            missingSkillString += ", ";
                        }
                    }
                    //get missing groups for student
                    ArrayList missingGroups = new ArrayList();
                    missingGroups = sr.GetMissingGroups(currentStudentID, true);//gets all missing groups
                    string missingGroupString = "";
                    for (int i = 0; i < missingGroups.Count; i++)
                    {
                        missingGroupString += missingGroups[i];//combines all missing groups into a string to be displayed to the user
                        if (i + 1 != missingGroups.Count)
                        {
                            missingGroupString += ", ";
                        }
                    }
                    if (missingGroupString == "")//adding column data, depending on result
                    {
                        if (missingSkillString == "")
                        {
                            dataGridViewStudentReport.Rows.Add(index, studentFName, studentSName, studentClass, studentYear, "Student has passed");//no missing skills or groups
                            dataGridViewStudentReport.Rows[dataGridViewStudentReport.Rows.Count - 1].Cells[5].Style.BackColor = Color.LawnGreen;
                        }
                        else
                        {
                            dataGridViewStudentReport.Rows.Add(index, studentFName, studentSName, studentClass, studentYear, "Missing Skills: " + missingSkillString);//no missing groups but missing skills
                            dataGridViewStudentReport.Rows[dataGridViewStudentReport.Rows.Count - 1].Cells[5].Style.BackColor = Color.Yellow;
                        }
                    }
                    else
                    {
                        dataGridViewStudentReport.Rows.Add(index, studentFName, studentSName, studentClass, studentYear, "Missing PAG's from: " + missingGroupString);//missing groups - skills irrelevent
                        dataGridViewStudentReport.Rows[dataGridViewStudentReport.Rows.Count - 1].Cells[5].Style.BackColor = Color.Yellow;
                    }
                    //increment progress bar
                    progressBarStudentReport.Value++;
                }
            }
            progressBarStudentReport.Value = 0;
            dataGridViewStudentReport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            radioButtonReportAll.Enabled = true;//enables filters
            radioButtonReportComplete.Enabled = true;
            radioButtonReportNotComplete.Enabled = true;
            List<List<string>> table = new List<List<string>>();
            for (int row = 0; row < dataGridViewStudentReport.RowCount; row++)//builds table into 2d list to be backup for filtering
            {
                table.Add(new List<string>());
                for (int column = 0; column < dataGridViewStudentReport.ColumnCount; column++)
                {
                    table[row].Add(Convert.ToString(dataGridViewStudentReport[column, row].Value));
                }
            }
            sr.SetReport(table);//backs up the table
        }

        private void dataGridViewStudentReport_CellEnter(object sender, DataGridViewCellEventArgs e)// a cell within the table has been selected
        {
            if (e.ColumnIndex == 5)//checks if condition column has been selected
            {
                int studentIndex = Convert.ToInt32(dataGridViewStudentReport.Rows[e.RowIndex].Cells[0].Value);
                int studentID = sr.GetStudentOrder(studentIndex);//gets id of selected student, using the hidden column
                HashSet<int> universe = new HashSet<int>();
                universe = sr.BuildUniverse(studentID);//builds a universe of missing skills for the student, which will be used in the greedy set cover algorithm.
                List<HashSet<int>> subsets = new List<HashSet<int>>();
                subsets = sr.GetSubsetList();//gets the list of already generated subsets
                List<int> requiredSubsets = new List<int>();
                requiredSubsets = sr.FindPagsToComplete(universe, subsets);//greedy set cover algorithm to determine the pags required to complete all skills
                string pagString = "";
                int index1 = 0;
                for (int i = 0; i < requiredSubsets.Count; i++)//loops through each required subset
                {
                    int pagID = sr.GetPagID(requiredSubsets.ElementAt(i));
                    string pagName = sr.GetPagName(pagID);//adds the pag name to a string
                    pagString += pagName;
                    if (i + 1 != requiredSubsets.Count)
                    {
                        pagString += Environment.NewLine;
                    }
                    index1++;
                }
                if (pagString != "")//returns the string of pags required to the user
                {
                    MessageBox.Show("PAG's Required to complete all skills: " + Environment.NewLine + Environment.NewLine + Convert.ToString(pagString), "PAG Report for " + dataGridViewStudentReport[1, e.RowIndex].Value + " " + dataGridViewStudentReport[2, e.RowIndex].Value);
                }
            }
        }

        private void radioButtonReportComplete_CheckedChanged(object sender, EventArgs e)//complete filter has been selected
        {
            List<List<string>> report = new List<List<string>>();
            report = sr.GetFilteredReport("passed");//gets all the entries that contain "passed" in the condition columns
            dataGridViewStudentReport.Rows.Clear();//clears all the rows in the table for rebuilding
            for (int i = 0; i < report.Count; i++)//loops through every report line
            {
                string[] data = report[i].ToArray();//splits up the line list into a line array to write to table
                dataGridViewStudentReport.Rows.Add(data);//adds the array to the table
                dataGridViewStudentReport.Rows[i].Cells[5].Style.BackColor = Color.LawnGreen;// colours the condition cell green, as all students in this filter have passed
            }
        }

        private void radioButtonReportNotComplete_CheckedChanged(object sender, EventArgs e)//not complete filter has been selected
        {
            List<List<string>> report = new List<List<string>>();
            report = sr.GetFilteredReport("Missing");//gets all entries that contain "missing" in the condition column
            dataGridViewStudentReport.Rows.Clear();
            for (int i = 0; i < report.Count; i++)//loops through each entry
            {
                string[] data = report[i].ToArray();//splits up the line list to an array
                dataGridViewStudentReport.Rows.Add(data);//adds the array as a line in the table
                dataGridViewStudentReport.Rows[i].Cells[5].Style.BackColor = Color.Yellow;//colours condition as yellow, as all students in this list have not passed
            }
        }

        private void radioButtonReportAll_CheckedChanged(object sender, EventArgs e)//all filter has been clicked
        {
            List<List<string>> report = new List<List<string>>();
            report = sr.GetReport();//program gets all records
            dataGridViewStudentReport.Rows.Clear();//clears report table to rebuild
            for (int i = 0; i < report.Count; i++)//loops through each line of the report
            {
                string[] data = report[i].ToArray();//splits up the line list to an array
                dataGridViewStudentReport.Rows.Add(data);//adds the data to a row in the table
                if (Convert.ToString(dataGridViewStudentReport.Rows[i].Cells[5].Value).Contains("passed"))//checks if the user has passed
                {
                    dataGridViewStudentReport.Rows[i].Cells[5].Style.BackColor = Color.LawnGreen;//colours cell green if they have passed
                }
                else
                {
                    dataGridViewStudentReport.Rows[i].Cells[5].Style.BackColor = Color.Yellow;//colours cell yellow if they have not passed
                }
            }
        }

        private void buttonExportReport_Click(object sender, EventArgs e)//export as excel file clicked
        {
            try
            {
                File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"EPPlus.dll", (PAG_Manager.Properties.Resources.EPPlusDll));//copies required dll files to the base directory in case they have been deleted
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"EPPlus.xml", (PAG_Manager.Properties.Resources.EPPlusXml));
                saveFileDialogExportReport.FileName = "PAG Manager Student Report " + DateTime.Today.ToString("dd-MM-yyyy");//fills in the name as the date by default
                saveFileDialogExportReport.ShowDialog();//shows the save location dialog
            }
            catch (Exception ex)
            {
                MessageBox.Show("The program does not have the permission to write the required libraries to the directory of the program, or the report could not be properly formed. Try restarting the program.", "PAG Manager");

                MessageBox.Show(ex.Message);
            }
        }

        private void saveFileDialogExportReport_FileOk(object sender, CancelEventArgs e)//export pag dialog fully validated
        {
            string location = saveFileDialogExportReport.FileName;//gets the location to save to
            sr.ExcelExport(location);//exports as excel document
            try
            {
                System.Diagnostics.Process.Start(location);//opens excel document
            }
            catch (Exception)
            {
                MessageBox.Show("Could not open excel file", "PAG Manager");
            }
        }

        private void listBoxStudentManagementList_SelectedIndexChanged(object sender, EventArgs e)//a new student has been selected
        {
            if (listBoxStudentManagementList.SelectedIndex != -1)//checks a valid student has been selected
            {
                string fName = ad.GetInformation(listBoxStudentManagementList.SelectedIndex).Item1;//gets the information about the student and fills in the text boxes
                string lName = ad.GetInformation(listBoxStudentManagementList.SelectedIndex).Item2;
                string year = ad.GetInformation(listBoxStudentManagementList.SelectedIndex).Item3;
                string theClass = ad.GetInformation(listBoxStudentManagementList.SelectedIndex).Item4;
                textBoxStudentFName.Text = fName;
                textBoxStudentLName.Text = lName;
                textBoxStudentYear.Text = year;
                textBoxStudentClass.Text = theClass;
            }
        }

        private void StudentDataModified()//updates the student data within the class
        {
            if (listBoxStudentManagementList.SelectedIndex != -1)//checks that a student is currently selected
            {
                ad.ModifyStudent(listBoxStudentManagementList.SelectedIndex, textBoxStudentFName.Text, textBoxStudentLName.Text, textBoxStudentYear.Text, textBoxStudentClass.Text);//modifies the student
                string fName = textBoxStudentFName.Text;
                string lName = textBoxStudentLName.Text;
                string theClass = textBoxStudentClass.Text;
                listBoxStudentManagementList.Items[listBoxStudentManagementList.SelectedIndex] = fName + " " + lName + " - " + theClass;//modifies the list box entry for the student
            }
        }

        private void textBoxStudentFName_TextChanged(object sender, EventArgs e)//text box modified
        {
            ReplaceCommas(sender);//replaces commas with semi colons
            StudentDataModified();//updates records within the class
        }

        private void textBoxStudentLName_TextChanged(object sender, EventArgs e)//text box modified
        {
            ReplaceCommas(sender);//replaces commas with semi colons
            StudentDataModified();//updates records within the class
        }

        private void textBoxStudentYear_TextChanged(object sender, EventArgs e)//text box modified
        {
            ReplaceCommas(sender);//replaces commas with semi colons
            if (textBoxStudentYear.Text.ToLower() == "archive" && textBoxStudentYear.Text != "Archive")//checks if any form of archive has been incorrectly spelt
            {
                textBoxStudentYear.Text = "Archive";
            }
            if (textBoxStudentYear.Text == "Archive")//updates class value with archive
            {
                textBoxStudentClass.Text = "Archive";
            }
            StudentDataModified();//updates records within the class
        }

        private void textBoxStudentClass_TextChanged(object sender, EventArgs e)//text box modified
        {
            ReplaceCommas(sender);//replaces commas with semi colons
            if (textBoxStudentClass.Text.ToLower() == "archive" && textBoxStudentClass.Text != "Archive")//checks if any form of archive has been incorrectly spelt
            {
                textBoxStudentClass.Text = "Archive";
            }
            if (textBoxStudentClass.Text == "Archive")//updates year value with archive
            {
                textBoxStudentYear.Text = "Archive";
            }
            StudentDataModified();//updates records within the class
        }

        private void ReplaceCommas(object sender)//used for all text boxes to replace commas with semi colons to avoid messing with the csv files
        {
            if (sender.GetType().ToString() == "System.Windows.Forms.TextBox")//checks if the item type is a text box, which is recognised sepereatly than a text box within a tool strip
            {
                TextBox tb = sender as TextBox;
                int location;//used to remember where the cursor was
                if (tb.Text.Contains(","))//filters out all commas and replaces them with semi-colons to avoid messing with the CSV files
                {
                    location = tb.SelectionStart;
                    tb.Text = tb.Text.Replace(",", ";");//replaces all instances of commas with semi colons
                    tb.SelectionStart = location;//resets cursor position to what it was before comma replacement
                }
            }
            else if (sender.GetType().ToString() == "System.Windows.Forms.ToolStripTextBox")
            {
                ToolStripTextBox tb = sender as ToolStripTextBox;
                int location;
                if (tb.Text.Contains(","))//filters out all commas and replaces them with semi-colons to avoid messing with the CSV files
                {
                    location = tb.SelectionStart;
                    tb.Text = tb.Text.Replace(",", ";");//replaces all instances of commas with semi colons
                    tb.SelectionStart = location;//resets cursor position to what it was before comma replacement
                }
            }
        }

        private void buttonStudentManagementDeleteStudent_Click(object sender, EventArgs e)//delete student button pressed
        {
            if (listBoxStudentManagementList.SelectedIndex != -1)//checks if student has been selected
            {
                ad.DeleteStudent(listBoxStudentManagementList.SelectedIndex);//deletes student from class
                listBoxStudentManagementList.Items.RemoveAt(listBoxStudentManagementList.SelectedIndex);//removes student from list
                textBoxStudentFName.Text = "";//clears text boxes
                textBoxStudentLName.Text = "";
                textBoxStudentYear.Text = "";
                textBoxStudentClass.Text = "";
            }
        }

        private void buttonStudentManagementAddStudent_Click(object sender, EventArgs e)//add student button clicked
        {
            ad.AddStudent();//adds a student within the class
            listBoxStudentManagementList.Items.Add("New Student - Class");//adds student to list
            listBoxStudentManagementList.SelectedIndex = listBoxStudentManagementList.Items.Count - 1;//selects the student within the list
            textBoxStudentFName.Focus();//focuses on the student
        }

        private void buttonStudentManagementSaveChanges_Click(object sender, EventArgs e)//save changes button clicked
        {
            ad.DeleteStudentRelations();
            ad.SaveStudentData();//saves modified student data
            ReloadAllData(true);
        }

        private void comboBoxInputType_SelectedIndexChanged(object sender, EventArgs e)// the combo box input type has been modified
        {
            HashSet<string> selectableObjects = new HashSet<string>();
            comboBoxInputName.Items.Clear();//clears combo boxes
            comboBoxOutputName.Items.Clear();
            if (comboBoxInputType.SelectedIndex == 0)//user selected year
            {
                selectableObjects = ad.GetAllEntries("year");//gets all years
                comboBoxOutputName.Items.Add("New Year");
            }
            else if (comboBoxInputType.SelectedIndex == 1)
            {//user selected class
                selectableObjects = ad.GetAllEntries("class");//gets all classes
                comboBoxOutputName.Items.Add("New Class");
            }
            comboBoxOutputName.Items.Add("Archive");
            for (int i = 0; i < selectableObjects.Count; i++)//loops through all selectable items
            {
                string name = selectableObjects.ElementAt(i);
                comboBoxInputName.Items.Add(name);//adds items to both combo boxes
                if (name != "Archive")
                {
                    comboBoxOutputName.Items.Add(name);
                }
            }
        }

        private void comboBoxOutputName_SelectedIndexChanged(object sender, EventArgs e)//combo box for destination name has been modified
        {
            if (comboBoxOutputName.SelectedIndex == 0)//user has selected the new... option
            {
                string inputName = Microsoft.VisualBasic.Interaction.InputBox("Enter the Name of the new " + comboBoxInputType.SelectedItem + " to add.");//uses a visual basic input box to ask the user for the name of the class
                inputName = inputName.Replace(",", ";");//removes any commas and replaces with semi colons
                labelNewItem.Text = inputName;
            }
            else
            {
                labelNewItem.Text = "";//sets label to blank as user has not selected new.. option
            }
        }

        private void buttonMoveStudents_Click(object sender, EventArgs e)//moves students from one year/class to another
        {
            string inputType = Convert.ToString(comboBoxInputType.SelectedItem);//gets combo box inputs
            string inputItem = Convert.ToString(comboBoxInputName.SelectedItem);
            string outputItem = Convert.ToString(comboBoxOutputName.SelectedItem);
            if (inputType != "" && inputItem != "" && outputItem != "")//checks if any values are blank
            {
                if (comboBoxOutputName.SelectedIndex == 0)//checks if new.. option has been selected
                {
                    outputItem = labelNewItem.Text;//sets the output item to the value of the label (what the user has named the new class)
                }
                ad.FindAndReplace(inputType, inputItem, outputItem);
                //rebuilds the listbox with new information
                listBoxStudentManagementList.Items.Clear();//clears the list of students for rebuilding
                SortedList<int, Tuple<string, string, string, string>> studentInfo = new SortedList<int, Tuple<string, string, string, string>>(ad.GetStudentInformation());//gets updated student information
                for (int i = 0; i < studentInfo.Count; i++)//loops through every student
                {
                    string fName = studentInfo.ElementAt(i).Value.Item1;
                    string lName = studentInfo.ElementAt(i).Value.Item2;
                    string theClass = studentInfo.ElementAt(i).Value.Item4;
                    listBoxStudentManagementList.Items.Add(fName + " " + lName + " - " + theClass);//adds record to the list of students
                }
                textBoxStudentFName.Text = "";//clears all text boxes
                textBoxStudentLName.Text = "";
                textBoxStudentYear.Text = "";
                textBoxStudentClass.Text = "";
                comboBoxInputType.SelectedIndex = -1;//deselects any selected students
                labelNewItem.Text = "";//clears the new.. label
            }
            else
            {
                MessageBox.Show("Please fill in all the options", "Alert");
            }
        }

        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)//backup menu item opened
        {

        }

        private void toolStripTextBoxBackupName_TextChanged(object sender, EventArgs e)//changes the create backup button with the text box text
        {
            backupWithNameToolStripMenuItem.Text = "Backup With Name: " + toolStripTextBoxBackupName.Text;
        }

        private void backupDataToolStripMenuItem_DropDownOpened(object sender, EventArgs e)//create backup menu item was selected
        {
            toolStripTextBoxBackupName.Focus();//backup name text box is brought into focus
            toolStripTextBoxBackupName.Text = System.DateTime.Today.ToString("dd-MM-yyyy");
            toolStripTextBoxBackupName.SelectAll();//selects all text for immediate editing
        }

        private void backupWithNameToolStripMenuItem_Click(object sender, EventArgs e)//creates a new backup
        {
            string fileName = toolStripTextBoxBackupName.Text;
            if (!string.IsNullOrEmpty(fileName) && fileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0 && fileName != "Current")//checks if the name is valid (not called "current", null, empty, or have invalid file name chars)
            {
                string newDir = AppDomain.CurrentDomain.BaseDirectory + @"SaveData\" + fileName + @"\";
                string oldDir = AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\";
                ad.DirectoryCopy(oldDir, newDir, false);//copies current directory to specified directory
                MessageBox.Show(Convert.ToString("Backup \"" + toolStripTextBoxBackupName.Text + "\" Created"), "PAG Manager");
            }
            else
            {
                MessageBox.Show(Convert.ToString("Please enter a valid backup name"), "PAG Manager");//an invalid name was entered
            }
        }

        private void restoreDataToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)//restores data from a backup
        {
            DialogResult result = MessageBox.Show("Are you sure you want to restore this backup?\n\n" + e.ClickedItem, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)//asks the user if they are sure they want to restore data
            {
                string fileName = Convert.ToString(e.ClickedItem);
                string oldDir = AppDomain.CurrentDomain.BaseDirectory + @"SaveData\" + fileName + @"\";
                string newDir = AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\";
                ad.DirectoryCopy(oldDir, newDir, false);//copies the directories
                MessageBox.Show(Convert.ToString("Restored data from backup \"" + e.ClickedItem + "\""), "PAG Manager");
                ReloadAllData(true);//reloads all data
                tabControlMain.SelectedIndex = 0;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)//shows the about box when the about option is selected
        {
            AboutBox a = new AboutBox();//creates a new about box class
            a.Show();//shows the form
        }

        private void deleteBackupToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)//deletes selected backup
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this backup?\n\n" + e.ClickedItem, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)//asks the user if they are sure they want to delete the backup
            {
                string fileName = Convert.ToString(e.ClickedItem);
                string dir = AppDomain.CurrentDomain.BaseDirectory + @"SaveData\" + fileName + @"\";
                Directory.Delete(dir, true);//deletes the directory recursivly, deleting all folders and subfolders
            }
        }

        private void loadPAGPresetToolStripMenuItem_Click(object sender, EventArgs e)//loads preset drop down items to be selected
        {

        }

        private void createPresetWithNameToolStripMenuItem_Click(object sender, EventArgs e)//creates a preset with the name in the text box
        {
            string fileName = toolStripTextBoxCreatePreset.Text;//gets the name of the preset from the text box
            if (!string.IsNullOrEmpty(fileName) && fileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0)//checks if the name is valid (no empty, null or invalid file name chars)
            {
                string newDir = AppDomain.CurrentDomain.BaseDirectory + @"Presets\" + fileName + @"\";
                string oldDir = AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\";
                ad.DirectoryCopy(oldDir, newDir, true);//copies current files to preset folder
                MessageBox.Show(Convert.ToString("Preset \"" + toolStripTextBoxCreatePreset.Text + "\" Created"), "PAG Manager");
            }
            else
            {
                MessageBox.Show(Convert.ToString("Please enter a valid preset name"), "PAG Manager");// name entered was invalid
            }
        }

        private void toolStripTextBoxCreatePreset_TextChanged(object sender, EventArgs e)//preset text box name modified
        {
            createPresetWithNameToolStripMenuItem.Text = "Create Preset With Name: " + toolStripTextBoxCreatePreset.Text;
        }

        private void loadPAGPresetToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)//loads a selected pag preset
        {
            DialogResult result = MessageBox.Show("By loading a preset, any PAG's awarded to students will be removed. Do you want to proceed?\n\n" + e.ClickedItem, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)//asks the user if they are sure that they want to load a preset
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagAchievement.csv", "");//clears the pag achievement file
                string fileName = Convert.ToString(e.ClickedItem);
                string oldDir = AppDomain.CurrentDomain.BaseDirectory + @"Presets\" + fileName + @"\";
                string newDir = AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\";
                ad.DirectoryCopy(oldDir, newDir, true);//copys preset files across to main savedata
                MessageBox.Show(Convert.ToString("Load preset \"" + e.ClickedItem + "\""), "PAG Manager");
                ReloadAllData(true);
                tabControlMain.SelectedIndex = 0;
            }
        }

        private void deletePAGPresetToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)//this deletes a selected preset directory
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this preset?\n\n" + e.ClickedItem, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)//asks the user if they are sure they want to delete the preset
            {
                string fileName = Convert.ToString(e.ClickedItem);
                string dir = AppDomain.CurrentDomain.BaseDirectory + @"Presets\" + fileName + @"\";
                Directory.Delete(dir, true);//deletes the selected directory
            }
        }

        private void createPAGPresetToolStripMenuItem_DropDownOpened(object sender, EventArgs e)//create preset menu opened
        {
            toolStripTextBoxCreatePreset.Focus();//brings the text box into focus for immediate editing
            toolStripTextBoxCreatePreset.Text = System.DateTime.Today.ToString("dd-MM-yyyy");//fills in the textbox with the current date as a test name for the preset name
            toolStripTextBoxCreatePreset.SelectAll();//selects all text in the text box
        }

        private void buttonResetToDefault_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete all current data? Backups and Presets will be kept, and the program will close.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)//asks the user if they are sure they want to delete the preset
            {
                Directory.Delete(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\", true);//deletes current directory
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\");
                Application.Exit();
            }
        }

        private void button1_Click_2(object sender, EventArgs e)//-----------------------------THIS NEEDS TO BE DELETED AFTER USED
        {
            string lineRead;
            string[] seperatedLine;
            List<string> lines = new List<string>();
            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagAchievement.csv");
            lineRead = sr.ReadLine();
            while (lineRead != null)
            {
                seperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                if (seperatedLine[2] != "Absent")
                {
                    DateTime date = new DateTime();
                    DateTime.TryParse(seperatedLine[2], out date);
                    lines.Add(seperatedLine[0] + "," + seperatedLine[1] + "," + date.ToString("dd/MM/yyyy") + "," + seperatedLine[3]);
                }
                else
                {
                    lines.Add(lineRead);
                }
                lineRead = sr.ReadLine();
            }
            sr.Close();
            StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\PagAchievement.csv");
            for (int line = 0; line < lines.Count; line++)
            {
                sw.WriteLine(lines[line]);
            }
            sw.Close();

            MessageBox.Show(Convert.ToString("done"));
        }

        private void dataGridViewSkillRequirement_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)//checks if the numbers have been edited
            {
                string value = dataGridViewSkillRequirement.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                int number;
                try//try and turn it into an int
                {
                    number = Convert.ToInt32(value);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter a whole number", "PAG Manager");
                    number = 1;
                }
                if (number < 1)
                {
                    MessageBox.Show("Please enter a number greater than 0", "PAG Manager");
                    number = 1;
                }
                dataGridViewSkillRequirement.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Convert.ToString(number);
            }
        }

        private void buttonClearAllChanges_Click(object sender, EventArgs e)
        {
            ReloadAllData(true);
        }

        private void BackupRestoreToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            restoreDataToolStripMenuItem.DropDownItems.Clear();//items are cleared from the drop down item list
            deleteBackupToolStripMenuItem.DropDownItems.Clear();
            List<string> directories = new List<string>(Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\"));//gets a list of directories in the savedata folder
            for (int i = 0; i < directories.Count; i++)//loops through every directory
            {
                string backupName = directories[i].Replace(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\", "");//removes all but the last part of the directory from the list of directories
                if (backupName != "Current")//checks if the name of the backup is not called current - the main directory used for the program
                {
                    restoreDataToolStripMenuItem.DropDownItems.Add(backupName);//adds the list of backups to the lists of backups
                    deleteBackupToolStripMenuItem.DropDownItems.Add(backupName);
                }
            }
        }

        private void PAGPresetToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            loadPAGPresetToolStripMenuItem.DropDownItems.Clear();//clears any current preset items from drop down lists
            deletePAGPresetToolStripMenuItem.DropDownItems.Clear();
            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Presets\") == false)//check if preset directory exists
            {
                DirectoryInfo di = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"Presets");//creates new directory if one does not exist
            }
            List<string> directories = new List<string>(Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory + @"Presets\"));//gets list of directories
            for (int i = 0; i < directories.Count; i++)//loops through each directory
            {
                string backupName = directories[i].Replace(AppDomain.CurrentDomain.BaseDirectory + @"Presets\", "");
                loadPAGPresetToolStripMenuItem.DropDownItems.Add(backupName);//adds directory to both lists
                deletePAGPresetToolStripMenuItem.DropDownItems.Add(backupName);
            }
        }
    }
}