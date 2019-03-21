using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Globalization;
using System.Web;

namespace PAG_Manager
{
    public partial class FormMain : Form //This class manages everything related to interacting with the form or any of its elements. As there is a lot of interaction with the form, this class is very big.
    {
        protected string FILELOC = (AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\");
        //Setting up all class instances to be used throughout the program
        StudentLookup sl = new StudentLookup(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\");
        Admin ad = new Admin(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\");
        Admin contentSelection = new Admin(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\");
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
            //tabControlMain.TabPages.Remove(tabAdmin); //This line may be disabled while testing admin features, do not delete!
            ReloadAllSettings();
            // ACTIVITY/CONTENT SELECTION
            // LOAD ALL DATA
            ReloadAllData(false);
        }
        private void ReloadAllSettings()
        {
            string lineRead;
            string[] SeperatedLine;
            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"SaveData\Current\settings.dat");//opens the student record file to start reading names
            lineRead = sr.ReadLine();
            if (lineRead != "" && lineRead != null)
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                if (SeperatedLine[1] == "true")
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                sr.Close();
            }
        }
        private void ReloadAllData(bool admin)//Reloads all data into the program when big changes are made
        {//The parameter decides if the admin stuff will be reloaded. This saves processing power if the user does not need admin functions.
            ArrayList pagList = ad.LoadData("PagList.csv");//Admin stuff and pag relations
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
                for (int i = 0; i < pagList.Count; i++)//giving each entry a number
                {
                    listBoxPagList.Items.Add(pagList[i]);
                    listBoxPagRelation.Items.Add(pagList[i]);
                    checkedListBoxPagList.Items.Add(pagList[i]);
                }
                ArrayList skillList = ad.LoadData("SkillList.csv");
                for (int i = 0; i < skillList.Count; i++)//giving each entry a number
                {
                    listBoxSkillList.Items.Add(skillList[i]);
                    checkedListBoxSkillRelation.Items.Add(skillList[i]);
                    dataGridViewSkillRequirement.Rows.Add(skillList[i]);
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
                SortedList<int, Tuple<string, string, string, string>> studentInfo = new SortedList<int, Tuple<string, string, string, string>>(ad.GetStudentInformation());
                for (int i = 0; i < studentInfo.Count; i++)
                {
                    string fName = studentInfo.ElementAt(i).Value.Item1;
                    string lName = studentInfo.ElementAt(i).Value.Item2;
                    string theClass = studentInfo.ElementAt(i).Value.Item4;
                    listBoxStudentManagementList.Items.Add(fName + " " + lName + " - " + theClass);
                }
            }
            psr.ClearRelations();
            psr.LoadRelationFromFile();
            // STUDENT LOOKUP NAMES LIST
            listBoxStudentNames.Items.Clear();
            ArrayList studentNames = sl.LoadNames();
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

            ArrayList pagNames = contentSelection.LoadData("PagList.csv");
            for (int i = 0; i < pagNames.Count; i++)
            {
                checkedListBoxActivitySelectionPag.Items.Add(pagNames[i]);
                dataGridViewContentSelectionPag.Rows.Add(pagNames[i]);
            }
            ArrayList skillNames = contentSelection.LoadData("SkillList.csv");
            for (int i = 0; i < skillNames.Count; i++)
            {
                dataGridViewActivitySelectionSkills.Rows.Add(skillNames[i]);
                checkedListBoxContentSelectionSkill.Items.Add(skillNames[i]);
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
                dataGridViewSkills.Rows.Add(seperatedLine);
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
                dataGridViewPag.Rows.Add(seperatedLine);
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
            List<List<string>> pagTreeID = ap.GetPagTreeName();
            pagList = ap.GetPagList();
            for (int i = 0; i < pagTreeID.Count; i++)//adding class nodes
            {
                treeViewPagSelect.Nodes.Add(Convert.ToString(pagList[i]));
                for (int j = 0; j < pagTreeID[i].Count; j++)
                {
                    treeViewPagSelect.Nodes[i].Nodes.Add(Convert.ToString(pagTreeID[i][j]));
                }
            }
            for (int node = 0; node < treeViewYearSelect.Nodes.Count; node++)//expands all the year nodes for ease of use
            {
                treeViewYearSelect.Nodes[node].Expand();
            }
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

        private void button2_Click(object sender, EventArgs e)//leave this for testing purposes
        {

        }

        public int FindNextIndex(string fileName)
        {
            string lineRead;
            string[] SeperatedLine;
            int highestNumber;
            StreamReader sr = new StreamReader(fileName);
            lineRead = sr.ReadLine();
            while (lineRead != null)
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                highestNumber = Convert.ToInt32(SeperatedLine[0]) + 1;
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
            ReplaceCommas(sender, e);
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
            bool unsavedChanges = false;
            if (sl.GetUnsavedChanges() && listBoxStudentNames.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("You have unsaved changes, do you wish to proceed and lose these changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
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
                ArrayList missingGroups = sr.GetMissingGroups(currentStudentID, false);
                int numMissingGroups = missingGroups.Count;
                int totalGroups = sr.GetNumberOfGroups();
                int totalSkills = dataGridViewStudentLookup.RowCount - 1;
                ArrayList missingSkills = sr.GetMissingSkills(currentStudentID);
                int numMissingSkills = missingSkills.Count;
                dataGridViewStudentLookup.Columns[0].HeaderText = Convert.ToString(listBoxStudentNames.SelectedItem + "\n " + Convert.ToString(totalGroups - numMissingGroups) + "/" + Convert.ToString(totalGroups) +" Groups Completed \n " + Convert.ToString(totalSkills - numMissingSkills) + "/" + Convert.ToString(totalSkills) + " Skills Completed");
                //clears every cell
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
            //colouring cells
            for (int row = 1; row < dataGridViewStudentLookup.RowCount; row++)
            {
                for (int cell = 0; cell < dataGridViewStudentLookup.ColumnCount; cell++)
                {
                    if (Convert.ToString(dataGridViewStudentLookup.Rows[row].Cells[cell].Value) != "")
                    {
                        if (Convert.ToString(dataGridViewStudentLookup.Rows[row].Cells[cell].Value) == "Achieved")
                        {
                            dataGridViewStudentLookup.Rows[row].Cells[cell].Style.BackColor = Color.LawnGreen;
                        }
                        if (Convert.ToString(dataGridViewStudentLookup.Rows[row].Cells[cell].Value) == "Not Achieved")
                        {
                            dataGridViewStudentLookup.Rows[row].Cells[cell].Style.BackColor = Color.FromArgb(241,130,48);
                        }
                        if (Convert.ToString(dataGridViewStudentLookup.Rows[row].Cells[cell].Value) == "Absent")
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
                    if (Convert.ToString(dataGridViewStudentLookup.Rows[0].Cells[cell].Value) == "Absent")
                    {
                        dataGridViewStudentLookup.Rows[0].Cells[cell].Style.BackColor = Color.Yellow;
                    }
                    else
                    {
                        dataGridViewStudentLookup.Rows[0].Cells[cell].Style.BackColor = Color.SkyBlue;
                    }
                }
            }
            dataGridViewStudentLookup.Enabled = true;
            sl.LoadState = false;//allows auto colouring of cells
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
                DialogResult result = MessageBox.Show("You have unsaved changes, do you wish to proceed and lose these changes?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No)
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
                for (int row = 0; row < dataGridViewPag.RowCount; row++)
                {
                    for (int cell = 5; cell < dataGridViewPag.ColumnCount; cell++)
                    {
                        if (Convert.ToString(dataGridViewPag.Rows[row].Cells[cell].Value) == "Absent")
                        {
                            dataGridViewPag.Rows[row].Cells[cell].Style.BackColor = Color.OrangeRed;
                        }
                        else if (Convert.ToString(dataGridViewPag.Rows[row].Cells[cell].Value) != "")
                        {
                            dataGridViewPag.Rows[row].Cells[cell].Style.BackColor = Color.Gold;
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
                    for (int row = 0; row < dataGridViewStudentLookup.RowCount -1; row++)
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
            ReplaceCommas(sender, e);
            if (listBoxPagList.SelectedIndex != -1)
            {
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
            ReplaceCommas(sender, e);
            if (listBoxSkillList.SelectedIndex != -1)
            {
                listBoxSkillList.Items[listBoxSkillList.SelectedIndex] = skillListToolStripTextBox.Text;
            }
        }

        private void pagListToolStripButtonAddRecord_Click(object sender, EventArgs e)//ADMIN: creates a new pag and selects the text for instant renaming
        {
            listBoxPagList.Items.Add("New PAG");
            listBoxPagList.SelectedIndex = listBoxPagList.Items.Count-1;
            pagListToolStripTextBox.Focus();
            pagListToolStripTextBox.SelectAll();
        }

        private void skillListToolStripButtonAddRecord_Click(object sender, EventArgs e)//ADMIN: creates a new skill and selects the text for instant renaming
        {
            listBoxSkillList.Items.Add("New Skill");
            listBoxSkillList.SelectedIndex = listBoxSkillList.Items.Count - 1;
            skillListToolStripTextBox.Focus();
            skillListToolStripTextBox.SelectAll();
        }

        private void pagListToolStripButtonRemovePag_Click(object sender, EventArgs e)//ADMIN: removes the selected list box index
        {
            if (listBoxPagList.SelectedIndex != -1)
            {
                listBoxPagList.Items.RemoveAt(listBoxPagList.SelectedIndex);
            }
        }

        private void skillListToolStripButtonRemovePag_Click(object sender, EventArgs e)//ADMIN: removes the selected list box index
        {
            if (listBoxSkillList.SelectedIndex != -1)
            {
                listBoxSkillList.Items.RemoveAt(listBoxSkillList.SelectedIndex);
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
            ArrayList pagList = new ArrayList();
            for(int i = 0; i < listBoxPagList.Items.Count; i++)
            {
                pagList.Add(listBoxPagList.Items[i]);
            }
            ad.SaveData(pagList, "PagList.csv");
            ReloadAllData(true);
            MessageBox.Show("PAG names saved", "PAG Manager");
        }

        private void skillListToolStripButtonSave_Click(object sender, EventArgs e)//ADMIN: Saves all Skill Data
        {
            ArrayList skillList = new ArrayList();
            for (int i = 0; i < listBoxSkillList.Items.Count; i++)
            {
                skillList.Add(listBoxSkillList.Items[i]);
            }
            ad.SaveData(skillList, "SkillList.csv");
            ReloadAllData(true);
            MessageBox.Show("Skill names saved", "PAG Manager");
        }

        private void ClearTickBoxes()//ADMIN: Clears all check boxes from skill relations
        {
            for(int i = 0; i < checkedListBoxSkillRelation.Items.Count; i++)
            {
                checkedListBoxSkillRelation.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void listBoxPagRelation_SelectedIndexChanged(object sender, EventArgs e)//ADMIN: Clears all check boxes and reticks new boxes for the selected PAG
        {
            checkedListBoxSkillRelation.SelectedIndex = -1;
            ClearTickBoxes();
            List<int> boxesToTick = psr.GetRelations(listBoxPagRelation.SelectedIndex);
            if (boxesToTick != null)
            {
                for (int i = 0; i < boxesToTick.Count; i++)
                {
                    if (boxesToTick[i] != -1)
                    {
                        checkedListBoxSkillRelation.SetItemCheckState(boxesToTick[i], CheckState.Checked);
                    }
                }
            }
        }

        private void checkedListBoxSkillRelation_ItemCheck(object sender, ItemCheckEventArgs e)//ADMIN: Sets or removes a relation when the checked list box is modified
        {
            if (listBoxPagRelation.SelectedIndex != -1)
            {
                if (checkedListBoxSkillRelation.SelectedIndex != -1)
                {
                    if (checkedListBoxSkillRelation.GetItemChecked(checkedListBoxSkillRelation.SelectedIndex) == false) //Checking if the checked box is checked or unchecked
                    {
                        psr.SetRelation(listBoxPagRelation.SelectedIndex, checkedListBoxSkillRelation.SelectedIndex);
                    }
                    else
                    {
                        psr.RemoveRelation(listBoxPagRelation.SelectedIndex, checkedListBoxSkillRelation.SelectedIndex);
                    }
                }
            }
        }

        private void buttonBuildPagSkillRelation_Click(object sender, EventArgs e)//ADMIN: rewrites all relations to file
        {
            psr.BuildFromScratch();
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
                if ((checkedListBoxActivitySelectionPag.GetItemChecked(i)&& checkedListBoxActivitySelectionPag.SelectedIndex != i) || (checkedListBoxActivitySelectionPag.SelectedIndex == i && checkedListBoxActivitySelectionPag.GetItemChecked(checkedListBoxActivitySelectionPag.SelectedIndex)==false))//checks if the box is ticked
                {
                    List<int> skillsToHighlight = psr.GetRelations(i);//gets all related skills
                    if (skillsToHighlight != null)//checks if skills have been returned
                    {
                        for (int j = 0; j < skillsToHighlight.Count; j++)//loops colouring in all skills
                        {
                            dataGridViewActivitySelectionSkills.Rows[skillsToHighlight[j]].Cells[0].Style.BackColor = Color.Yellow;
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
        private void RecolourContentSelection()
        {
            ArrayList list = new ArrayList();
            list.Clear();
            for (int i = 0; i < checkedListBoxContentSelectionSkill.Items.Count; i++)//Step 1: build a list of all checked/about to be checked items
            {//Below if statement evals (A & B) | (¬A & c)
                if ((checkedListBoxContentSelectionSkill.SelectedIndex == i && checkedListBoxContentSelectionSkill.GetItemChecked(checkedListBoxContentSelectionSkill.SelectedIndex) == false) || (checkedListBoxContentSelectionSkill.SelectedIndex != i && checkedListBoxContentSelectionSkill.GetItemChecked(i)))
                {
                    list.Add(i);
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
                    dataGridViewContentSelectionPag.Rows[Convert.ToInt32(matchingPag[i])].Cells[0].Style.BackColor = Color.Yellow;
                }
            }
        }

        private void listBoxContentSelectionInclusion_SelectedIndexChanged(object sender, EventArgs e)
        {
            psr.SetInclusion(listBoxContentSelectionInclusion.SelectedIndex);
            checkedListBoxContentSelectionSkill.SelectedIndex = -1;
            RecolourContentSelection();
        }

        // Updates all child tree nodes recursively
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
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

        private void UpdateSelectedStudentLabel()
        {
            int selectedStudents = 0;
            int absentStudents = 0;
            for (int yearID = 0; yearID < treeViewYearSelect.Nodes.Count; yearID++)
            {
                for (int classID = 0; classID < treeViewYearSelect.Nodes[yearID].Nodes.Count; classID++)
                {
                    for (int studentID = 0; studentID < treeViewYearSelect.Nodes[yearID].Nodes[classID].Nodes.Count; studentID++)//searches every student box to check if it has been ticked or not
                    {
                        if (treeViewYearSelect.Nodes[yearID].Nodes[classID].Nodes[studentID].Checked)
                        {
                            selectedStudents++;
                        }
                        else if (treeViewYearSelect.Nodes[yearID].Nodes[classID].Checked)
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
        
        private void UpdateSelectedPagLabel()
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
            if (selectedPags == 1)
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

        private void dateTimePickerAwardPag_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerAwardPag.Value.Date > DateTime.Now)
            {
                MessageBox.Show("The selected date is in the future. Change the value if you did not mean to select a future date", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void treeViewYearSelect_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
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
                        if (treeViewYearSelect.Nodes[yearID].Nodes[classID].Nodes[studentID].Checked)
                        {
                            studentsToAwardPag.Add(studentIDList[yearID][classID][studentID]);
                        }
                        else if (treeViewYearSelect.Nodes[yearID].Nodes[classID].Checked)
                        {
                            absentStudents.Add(studentIDList[yearID][classID][studentID]);
                        }
                    }
                }
            }
            //Part 4 Preperation - Getting pag id tree list
            List<List<int>> pagTreeID = ap.GetPagTreeID();
            List<List<int>> skillsFailed = new List<List<int>>();
            //Part 2: ArrayList pagsCompleted
            ArrayList pagsCompletedByStudents = new ArrayList();
            for (int pag = 0; pag < treeViewPagSelect.Nodes.Count; pag++)//searches each pag to check if its ticked
            {
                skillsFailed.Add(new List<int> { });//Part 4 preperation, creating new blank entrys to be modified
                if(treeViewPagSelect.Nodes[pag].Checked)
                {
                    pagsCompletedByStudents.Add(pag);
                    for (int skill = 0; skill < treeViewPagSelect.Nodes[pag].Nodes.Count; skill++)//Part 4: searches through each skill within each checked pag to see if its not checked
                    {
                        if (treeViewPagSelect.Nodes[pag].Nodes[skill].Checked == false)
                        {
                            skillsFailed[pag].Add(pagTreeID[pag][skill]);
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

        private void buttonAwardPagClearSelection_Click(object sender, EventArgs e)
        {
            for (int yearID = 0; yearID < treeViewYearSelect.Nodes.Count; yearID++)
            {
                treeViewYearSelect.Nodes[yearID].Checked = false;
                for (int classID = 0; classID < treeViewYearSelect.Nodes[yearID].Nodes.Count; classID++)
                {
                    treeViewYearSelect.Nodes[yearID].Nodes[classID].Checked = false;
                    for (int studentID = 0; studentID < treeViewYearSelect.Nodes[yearID].Nodes[classID].Nodes.Count; studentID++)
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
                for (int skill = 0; skill < treeViewPagSelect.Nodes[pag].Nodes.Count; skill++)
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
            MessageBox.Show("Skill Requirements saved","PAG Manager");
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
            MessageBox.Show(Convert.ToString("Help Coming soon"));
        }

        private void Button1_Click_1(object sender, EventArgs e)
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
            for (int line = 0; line < orderedCSV.Count-1; line++)//writes every line to file
            {
                csvQuoteRemoved = Convert.ToString(orderedCSV[line]).Replace("\"","");//removes " if they exsist
                sw.WriteLine(Convert.ToString(index) + "," + csvQuoteRemoved);
                index++;
            }
            sw.Close();
            ReloadAllData(true);
            MessageBox.Show("Records added", "PAG Manager");
        }

        private void hidePagViewColumnsWithoutPAGDataToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            for (int column = 5; column < dataGridViewPag.Columns.Count; column++)
            {
                dataGridViewPag.Columns[column].Width = 100;
                if (hidePagViewColumnsWithoutPAGDataToolStripMenuItem.CheckState == CheckState.Checked)
                {
                    bool flag = false;
                    for (int row = 0; row < dataGridViewPag.Rows.Count; row++)
                    {
                        if (Convert.ToString(dataGridViewPag.Rows[row].Cells[column].Value) != "")
                        {
                            row = dataGridViewPag.Rows.Count;
                            flag = true;
                        }
                    }
                    if (flag == false)
                    {
                        dataGridViewPag.Columns[column].Width = 10;
                    }
                }
            }
        }

        private void checkBoxShowStudentID_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowStudentID.CheckState == CheckState.Checked)
            {
                dataGridViewPag.Columns[0].Visible = true;
                dataGridViewSkills.Columns[0].Visible = true;
                dataGridViewStudentReport.Columns[0].Visible = true;
            }
            else
            {
                dataGridViewPag.Columns[0].Visible = false;
                dataGridViewSkills.Columns[0].Visible = false;
                dataGridViewStudentReport.Columns[0].Visible = false;
            }
        }

        private void DataGridViewStudentLookup_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //This big case statment changes the value of what the user has typed to Achieved, Not achieved or absent, whichever is closest
            string contents;
            try
            {
                contents = dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
                contents = "";
            }
            if (contents == "" && e.RowIndex == 0)
            {
                List<int> skillIDs = new List<int>();
                skillIDs = psr.GetRelations(sl.ReversePagLookup(e.ColumnIndex));
                for (int skill = 0; skill < skillIDs.Count; skill++)
                {
                    int position = sl.LookupSkill(skillIDs[skill]);
                    dataGridViewStudentLookup.Rows[position + 1].Cells[e.ColumnIndex].Value = null;
                }
            }
            if (contents != "" && e.RowIndex != 0 && contents != null)
            {
                switch (dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value.ToString())
                {
                    case "":
                        break;
                    case "Achieved":
                        break;
                    case "Not Achieved":
                        break;
                    case "Absent":
                        break;
                    default:
                        List<int> bestFit = new List<int>();
                        string userInput = dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value.ToString();
                        bestFit.Add(sl.LevenshteinDistance(userInput, "Achieved"));
                        bestFit.Add(sl.LevenshteinDistance(userInput, "Not Achiev"));//reduced because otherwise its too long to ever be selected
                        bestFit.Add(sl.LevenshteinDistance(userInput, "Absent"));
                        int bestIndex = bestFit.IndexOf(bestFit.Min());
                        if (userInput.ToLower().Contains("yes") || userInput.ToLower().Contains("pass"))
                        {
                            bestIndex = 0;
                        }
                        if (userInput.ToLower().Contains("no") || userInput.ToLower().Contains("fail"))
                        {
                            bestIndex = 1;
                        }
                        switch (Convert.ToString(bestIndex))
                        {
                            case "0":
                                dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value = "Achieved";
                                if (dataGridViewStudentLookup[e.ColumnIndex,0].Value.ToString() == "Absent")
                                {
                                    dataGridViewStudentLookup[e.ColumnIndex, 0].Value = System.DateTime.Today.ToString("dd/MM/yyyy");
                                }
                                break;
                            case "1":
                                dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value = "Not Achieved";
                                if (dataGridViewStudentLookup[e.ColumnIndex, 0].Value.ToString() == "Absent")
                                {
                                    dataGridViewStudentLookup[e.ColumnIndex, 0].Value = System.DateTime.Today.ToString("dd/MM/yyyy");
                                }
                                break;
                            case "2":
                                dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value = "Absent";
                                break;
                            default:
                                dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value = "";
                                break;
                        }
                        break;
                }
            }
            else if (contents != "" && e.RowIndex == 0)
            {
                DateTime inputDate = new DateTime();
                if (dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value.ToString().ToLower().Contains("a"))
                {
                    dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value = "Absent";
                    List<int> skillIDs = new List<int>();
                    skillIDs = psr.GetRelations(sl.ReversePagLookup(e.ColumnIndex));
                    for (int skill = 0; skill < skillIDs.Count; skill++)
                    {
                        int position = sl.LookupSkill(skillIDs[skill]);
                        dataGridViewStudentLookup.Rows[position + 1].Cells[e.ColumnIndex].Value = "Absent";
                    }
                }
                else
                {
                    if (DateTime.TryParse(dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value.ToString(), out inputDate))//check for valid datetime
                    {
                        dataGridViewStudentLookup[e.ColumnIndex, 0].Value = inputDate.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        dataGridViewStudentLookup[e.ColumnIndex, 0].Value = System.DateTime.Today.ToString("dd/MM/yyyy");
                    }
                    List<int> skillIDs = new List<int>();
                    skillIDs = psr.GetRelations(sl.ReversePagLookup(e.ColumnIndex));
                    for (int skill = 0; skill < skillIDs.Count; skill++)
                    {
                        int position = sl.LookupSkill(skillIDs[skill]);
                        dataGridViewStudentLookup.Rows[position + 1].Cells[e.ColumnIndex].Value = "Achieved";
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

        private void dataGridViewStudentLookup_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try//recolouring modified cells
            {
                if (e.RowIndex == 0)
                {
                    if (Convert.ToString(dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value) != null && Convert.ToString(dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value) != "")
                    {
                        if (Convert.ToString(dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value) == "Absent")
                        {
                            dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Yellow;
                        }
                        else
                        {
                            dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.SkyBlue;
                        }
                    }
                    else
                    {
                        dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
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
                    if (Convert.ToString(dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value) == "Achieved")
                    {
                        dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LawnGreen;
                    }
                    else if (Convert.ToString(dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value) == "Not Achieved")
                    {
                        dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.FromArgb(241, 130, 48);
                    }
                    else if (Convert.ToString(dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Value) == "Absent")
                    {
                        dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Yellow;
                    }
                    else
                    {
                        dataGridViewStudentLookup[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
                    }
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                //This stops exceptions for when the program tries to colour cells that dont exist, when the table is being loaded
            }
        }

        private void dataGridViewStudentLookup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Delete)
            {
                if (dataGridViewStudentLookup.CurrentCell.ColumnIndex != 0)
                {
                    dataGridViewStudentLookup[dataGridViewStudentLookup.CurrentCell.ColumnIndex, dataGridViewStudentLookup.CurrentCell.RowIndex].Value = null;
                    sl.AddChange(dataGridViewStudentLookup.CurrentCell.ColumnIndex);
                }
            }
        }

        private void startMaximisedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (startMaximisedToolStripMenuItem.Checked)
            {

            }
        }

        private void buttonLookupSubmitModifications_Click(object sender, EventArgs e)
        {
            //first builds a new arraylist to store all the new data to be written to file
            Dictionary<int, string> newData = new Dictionary<int, string>();
            string dataString = "";
            ArrayList changes = new ArrayList(sl.GetChanges());
            List<int> skills = new List<int>();
            int studentID = sl.GetCurrentStudentID();
            for (int change = 0; change < changes.Count; change++)
            {
                int pagID = sl.ReversePagLookup(Convert.ToInt32(changes[change]));
                int column = Convert.ToInt32(changes[change]);
                dataString = studentID.ToString();
                dataString += ",";
                dataString += Convert.ToString(pagID);
                dataString += ",";
                dataString += dataGridViewStudentLookup[sl.LookupPag(Convert.ToInt32(changes[change]))-1,0].Value;
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
                        cellContents = "Not Achieved";
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
                newData.Add(column,dataString);
            }
            bool isSuccess = sl.UpdateStudentData(newData);//updates the student data and returns wether it succeded or not
            sl.ResetChanges();
            sl.SetUnsavedChanges(false);
            //changes tab if update fails so that fresh copy can be reloaded
            if (isSuccess == false)
            {
                tabControlMain.SelectedIndex = 0;
            }
            ReloadAllData(false);
        }

        private void checkBoxArchives_CheckedChanged(object sender, EventArgs e)
        {
            //check archives button clicked in student lookup
        }

        private void pagGroupToolStripButtonAdd_Click(object sender, EventArgs e)
        {//adds a new item, highlights it and adds an id for it in student report
            listBoxGroupList.Items.Add("New Group");
            sr.AddGroup();
            listBoxGroupList.SelectedIndex = listBoxGroupList.Items.Count - 1;
            pagGroupToolStripTextBox.Focus();
            pagGroupToolStripTextBox.SelectAll();
        }

        private void pagGroupToolStripRemove_Click(object sender, EventArgs e)
        {
            if (listBoxGroupList.SelectedIndex != -1)
            {
                sr.DeleteGroup(listBoxGroupList.SelectedIndex);
                listBoxGroupList.Items.RemoveAt(listBoxGroupList.SelectedIndex);
            }
        }

        private void pagGroupToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            ReplaceCommas(sender, e);
            if (listBoxGroupList.SelectedIndex != -1)
            {
                listBoxGroupList.Items[listBoxGroupList.SelectedIndex] = pagGroupToolStripTextBox.Text;
            }
            sr.RenameGroup(sr.GetGroupId(listBoxGroupList.SelectedIndex), pagGroupToolStripTextBox.Text);
        }

        private void listBoxGroupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxGroupList.SelectedIndex != -1)
            {
                //uncheck every box
                for (int item = 0; item < checkedListBoxPagList.Items.Count; item++)
                {
                    checkedListBoxPagList.SetItemCheckState(item, CheckState.Unchecked);
                }
                pagGroupToolStripTextBox.Text = (Convert.ToString(listBoxGroupList.SelectedItem));
                //gets list of pags for each group
                List<int> pagsInGroup = new List<int>();
                pagsInGroup = sr.GetGroupPagList(sr.GetGroupId(listBoxGroupList.SelectedIndex));
                for (int i = 0; i < pagsInGroup.Count; i++)
                {
                    checkedListBoxPagList.SetItemCheckState(sl.LookupPag(pagsInGroup[i])-1,CheckState.Checked);
                }
            }
        }

        private void checkedListBoxPagList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBoxPagList.SelectedIndex != -1)
            {
                int groupID = sr.GetGroupId(listBoxGroupList.SelectedIndex);
                if (e.NewValue == CheckState.Checked)
                {
                    sr.AddPagToGroup(groupID, sl.ReversePagLookup(checkedListBoxPagList.SelectedIndex + 1));
                }
                else
                {
                    sr.RemovePagFromGroup(groupID, sl.ReversePagLookup(checkedListBoxPagList.SelectedIndex + 1));
                }
                checkedListBoxPagList.SelectedIndex = -1;
            }
        }

        private void pagGroupToolStripSave_Click(object sender, EventArgs e)
        {
            sr.WritePagGroupInfo();
            ReloadAllData(true);
        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            dataGridViewStudentReport.Rows.Clear();
            sr.ClearStudentOrder();
            int studentAmount = sr.GetNumberOfStudents();
            progressBarStudentReport.Maximum = studentAmount;
            //pre individual student processing
            Dictionary<int, Tuple<string, string, string, string>> studentInfo = new Dictionary<int, Tuple<string, string, string, string>>();
            studentInfo = sr.GetAllStudentInformation();
            int index = -1;
            for (int student = 0; student < studentInfo.Count; student++)
            {
                index++;
                int currentStudentID = studentInfo.ElementAt(student).Key;
                sr.AddToStudentOrder(currentStudentID);
                string studentFName = studentInfo.ElementAt(student).Value.Item1;
                string studentSName = studentInfo.ElementAt(student).Value.Item2;
                string studentClass = studentInfo.ElementAt(student).Value.Item3;
                string studentYear = studentInfo.ElementAt(student).Value.Item4;
                //get missing skills for student
                ArrayList missingSkills = new ArrayList();
                missingSkills = sr.GetMissingSkills(currentStudentID);
                string missingSkillString = "";
                for (int i = 0; i < missingSkills.Count; i++)
                {
                    missingSkillString += missingSkills[i];
                    if (i + 1 != missingSkills.Count)
                    {
                        missingSkillString += ", ";
                    }
                }
                //get missing groups for student
                ArrayList missingGroups = new ArrayList();
                missingGroups = sr.GetMissingGroups(currentStudentID, true);
                string missingGroupString = "";
                for (int i = 0; i < missingGroups.Count; i++)
                {
                    missingGroupString += missingGroups[i];
                    if (i + 1 != missingGroups.Count)
                    {
                        missingGroupString += ", ";
                    }
                }
                if (missingGroupString == "")//adding column data, depending on result
                {
                    if (missingSkillString == "")
                    {
                        dataGridViewStudentReport.Rows.Add(index, studentFName, studentSName, studentClass, studentYear, "Student has passed");
                        dataGridViewStudentReport.Rows[dataGridViewStudentReport.Rows.Count - 1].Cells[5].Style.BackColor = Color.LawnGreen;
                    }
                    else
                    {
                        dataGridViewStudentReport.Rows.Add(index, studentFName, studentSName, studentClass, studentYear, "Missing Skills: " + missingSkillString);
                        dataGridViewStudentReport.Rows[dataGridViewStudentReport.Rows.Count - 1].Cells[5].Style.BackColor = Color.Yellow;
                    }
                }
                else
                {
                    dataGridViewStudentReport.Rows.Add(index, studentFName, studentSName, studentClass, studentYear, "Missing PAG's from: " + missingGroupString);
                    dataGridViewStudentReport.Rows[dataGridViewStudentReport.Rows.Count - 1].Cells[5].Style.BackColor = Color.Yellow;
                }
                //increment progress bar
                progressBarStudentReport.Value++;
            }
            //progressBarStudentReport.Value = 0;
            dataGridViewStudentReport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            radioButtonReportAll.Enabled = true;
            radioButtonReportComplete.Enabled = true;
            radioButtonReportNotComplete.Enabled = true;
            List<List<string>> table = new List<List<string>>();
            for (int row = 0; row < dataGridViewStudentReport.RowCount; row++)
            {
                table.Add(new List<string>());
                for (int column = 0; column < dataGridViewStudentReport.ColumnCount; column++)
                {
                    table[row].Add(Convert.ToString(dataGridViewStudentReport[column, row].Value));
                }
            }
            sr.SetReport(table);
        }

        private void dataGridViewStudentReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewStudentReport_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int studentIndex = Convert.ToInt32(dataGridViewStudentReport.Rows[e.RowIndex].Cells[0].Value);
                int studentID = sr.GetStudentOrder(studentIndex);
                HashSet<int> universe = new HashSet<int>();
                universe = sr.BuildUniverse(studentID);
                List<HashSet<int>> subsets = new List<HashSet<int>>();
                subsets = sr.GetSubsetList();
                List<int> requiredSubsets = new List<int>();
                requiredSubsets = sr.FindPagsToComplete(universe, subsets);
                string pagString = "";
                int index1 = 0;
                for (int i = 0; i < requiredSubsets.Count; i++)
                {
                    int pagID = sr.GetPagID(requiredSubsets.ElementAt(i));
                    string pagName = sr.GetPagName(pagID);
                    pagString += pagName;
                    if (i+1 != requiredSubsets.Count)
                    {
                        pagString += Environment.NewLine;
                    }
                    index1++;
                }
                if (pagString != "")
                {
                    MessageBox.Show("PAG's Required to complete all skills: " + Environment.NewLine + Environment.NewLine + Convert.ToString(pagString),"PAG Report for " + dataGridViewStudentReport[1,e.RowIndex].Value + " " + dataGridViewStudentReport[2, e.RowIndex].Value);
                }
            }
        }

        private void radioButtonReportComplete_CheckedChanged(object sender, EventArgs e)
        {
            List<List<string>> report = new List<List<string>>();
            report = sr.GetFilteredReport("passed");
            dataGridViewStudentReport.Rows.Clear();
            for (int i = 0; i < report.Count; i++)
            {
                string[] data = report[i].ToArray();
                dataGridViewStudentReport.Rows.Add(data);
                dataGridViewStudentReport.Rows[i].Cells[5].Style.BackColor = Color.LawnGreen;
            }
        }

        private void radioButtonReportNotComplete_CheckedChanged(object sender, EventArgs e)
        {
            List<List<string>> report = new List<List<string>>();
            report = sr.GetFilteredReport("Missing");
            dataGridViewStudentReport.Rows.Clear();
            for (int i = 0; i < report.Count; i++)
            {
                string[] data = report[i].ToArray();
                dataGridViewStudentReport.Rows.Add(data);
                dataGridViewStudentReport.Rows[i].Cells[5].Style.BackColor = Color.Yellow;
            }
        }

        private void radioButtonReportAll_CheckedChanged(object sender, EventArgs e)
        {
            List<List<string>> report = new List<List<string>>();
            report = sr.GetReport();
            dataGridViewStudentReport.Rows.Clear();
            for (int i = 0; i < report.Count; i++)
            {
                string[] data = report[i].ToArray();
                dataGridViewStudentReport.Rows.Add(data);
                if (Convert.ToString(dataGridViewStudentReport.Rows[i].Cells[5].Value).Contains("passed"))
                {
                    dataGridViewStudentReport.Rows[i].Cells[5].Style.BackColor = Color.LawnGreen;
                }
                else
                {
                    dataGridViewStudentReport.Rows[i].Cells[5].Style.BackColor = Color.Yellow;
                }
            }
        }

        private void buttonExportReport_Click(object sender, EventArgs e)
        {
            File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"EPPlus.dll", (PAG_Manager.Properties.Resources.EPPlusDll));
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"EPPlus.xml", (PAG_Manager.Properties.Resources.EPPlusXml));
            saveFileDialogExportReport.FileName = "PAG Manager Student Report " +  DateTime.Today.ToString("dd-MM-yyyy");
            saveFileDialogExportReport.ShowDialog();
        }

        private void saveFileDialogExportReport_FileOk(object sender, CancelEventArgs e)
        {
            string location = saveFileDialogExportReport.FileName;
            sr.ExcelExport(location);
        }

        private void listBoxStudentManagementList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxStudentManagementList.SelectedIndex != -1)
            {
                string fName = ad.GetInformation(listBoxStudentManagementList.SelectedIndex).Item1;
                string lName = ad.GetInformation(listBoxStudentManagementList.SelectedIndex).Item2;
                string year = ad.GetInformation(listBoxStudentManagementList.SelectedIndex).Item3;
                string theClass = ad.GetInformation(listBoxStudentManagementList.SelectedIndex).Item4;
                textBoxStudentFName.Text = fName;
                textBoxStudentLName.Text = lName;
                textBoxStudentYear.Text = year;
                textBoxStudentClass.Text = theClass;
            }
        }

        private void StudentDataModified()
        {
            if (listBoxStudentManagementList.SelectedIndex != -1)
            {
                ad.ModifyStudent(listBoxStudentManagementList.SelectedIndex, textBoxStudentFName.Text, textBoxStudentLName.Text, textBoxStudentYear.Text, textBoxStudentClass.Text);
                string fName = textBoxStudentFName.Text;
                string lName = textBoxStudentLName.Text;
                string theClass = textBoxStudentClass.Text;
                listBoxStudentManagementList.Items[listBoxStudentManagementList.SelectedIndex] = fName + " " + lName + " - " + theClass ;
            }
        }

        private void textBoxStudentFName_TextChanged(object sender, EventArgs e)
        {
            ReplaceCommas(sender, e);
            StudentDataModified();
        }

        private void textBoxStudentLName_TextChanged(object sender, EventArgs e)
        {
            ReplaceCommas(sender, e);
            StudentDataModified();
        }

        private void textBoxStudentYear_TextChanged(object sender, EventArgs e)
        {
            ReplaceCommas(sender, e);
            StudentDataModified();
        }

        private void textBoxStudentClass_TextChanged(object sender, EventArgs e)
        {
            ReplaceCommas(sender, e);
            StudentDataModified();
        }

        private void ReplaceCommas(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            int location;
            if (tb.Text.Contains(","))//filters out all commas and replaces them with semi-colons to avoid messing with the CSV files
            {
                location = tb.SelectionStart;
                tb.Text = tb.Text.Replace(",", ";");
                tb.SelectionStart = location;
            }
        }

        private void buttonStudentManagementDeleteStudent_Click(object sender, EventArgs e)
        {
            if (listBoxStudentManagementList.SelectedIndex != -1)
            {
                ad.DeleteStudent(listBoxStudentManagementList.SelectedIndex);
                listBoxStudentManagementList.Items.RemoveAt(listBoxStudentManagementList.SelectedIndex);
                textBoxStudentFName.Text = "";
                textBoxStudentLName.Text = "";
                textBoxStudentYear.Text = "";
                textBoxStudentClass.Text = "";
            }
        }

        private void buttonStudentManagementAddStudent_Click(object sender, EventArgs e)
        {
            ad.AddStudent();
            listBoxStudentManagementList.Items.Add("New Student - Class");
            listBoxStudentManagementList.SelectedIndex = listBoxStudentManagementList.Items.Count - 1;
            textBoxStudentFName.Focus();
        }

        private void buttonStudentManagementSaveChanges_Click(object sender, EventArgs e)
        {
            ad.SaveStudentData();
            ReloadAllData(true);
        }
    }
}