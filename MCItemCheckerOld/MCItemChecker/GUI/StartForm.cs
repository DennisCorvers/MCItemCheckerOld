using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using MCItemChecker.Utils;

namespace MCItemChecker
{
    public partial class StartForm : Form
    {
        /// <summary>
        /// ItemChecker Class (Contains all the game items)
        /// </summary>
        private ItemChecker ItemC;
        /// <summary>
        /// Form2 Class
        /// </summary>
        private MainMenu Mainform;
        /// <summary>
        /// Default directory where the programs data will be stored
        /// </summary>
        private string DefaultDirectory;
        /// <summary>
        /// The complete file path of the programs data file
        /// </summary>
        private string DefaultFilePath;


        /// <summary>
        /// Checks if the mainform was saved before exit.
        /// </summary>
        public StartForm()
        {
       
            InitializeComponent();

            DefaultDirectory = DataStream.CurrentDir() + "\\MCItemCheckerData";
            DefaultFilePath = DefaultDirectory + "\\Data.mci";

            if (Properties.Settings.Default.FilePath == null || Properties.Settings.Default.FilePath == "")
            { tbpath.Text = "No file selected!"; }
            else
            { tbpath.Text = Properties.Settings.Default.FilePath; }
        }

        /// <summary>
        /// Initialises the Form1 class.
        /// </summary>
        /// <param name="d">The Data Class</param>
        /// <param name="i">The ItemChecker Class</param>
        public void GoToMainForm(ItemChecker i)
        {
            if (i == null || i.Items == null)
            {
                MessageBox.Show("The .item file wasn''t loaded properly, try re-opening", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Mainform = new MainMenu(ItemC, this);
            this.Hide();
            Mainform.Show();
        }

        /// <summary>
        /// Tries to load the itemchecker class based on the information from the data class.
        /// Creates a new itemchecker class when the data class doesn't specify it's location.
        /// </summary>
        /// <returns>returns false when the itemchecker file couldn't be loaded or created</returns>
        private Boolean CheckItemCheckerFile()
        {
            //Checks if the Filename field is empty.
            if (Properties.Settings.Default.FilePath == null || Properties.Settings.Default.FilePath == "")
            {
                DialogResult dialogResult = MessageBox.Show("No .item file was found!" + Environment.NewLine + "Do tou want to create a new file?", "No File Found!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ItemC = new ItemChecker();
                    return CreateNeworRenameFile(ItemC);
                }
            }
            else
            {
                //Tries to load the itemchecker file into the itemchecker class.
                ItemChecker tempitemchecker = DataStream.OpenFile<ItemChecker>(Properties.Settings.Default.FilePath);
                if (tempitemchecker != null)
                {
                    ItemC = tempitemchecker;
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Method used to create, replace or rename an .item file.
        /// </summary>
        /// <param name="ic"></param>
        /// <returns></returns>
        private bool CreateNeworRenameFile(ItemChecker ic)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "ItemList File|*.item";
            saveFileDialog.Title = "Save an .Item File";
            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                UpdateFilePath(saveFileDialog.FileName);
                tbpath.Text = Properties.Settings.Default.FilePath;
            }
            if (result == DialogResult.Cancel)
            { return false; }

            //Tries to create a new Itemchecker file with the user specified filename.
            if (!DataStream.SaveFile(ic, Properties.Settings.Default.FilePath))
            { return false; }
            else
            { return true; }
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        private void ExitApplication()
        {
            Application.Exit();
        }

        /// <summary>
        /// Updates the filepath of the current ItemChecker file
        /// </summary>
        private void UpdateFilePath(string FilePath)
        {
            Properties.Settings.Default.FilePath = FilePath;
            Properties.Settings.Default.Save();
        }

        public void UpdateItemC(ItemChecker I)
        {
            this.ItemC = I;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void bresume_Click(object sender, EventArgs e)
        {
            if (CheckItemCheckerFile())
            { GoToMainForm(ItemC); }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemC = new ItemChecker();
            if (CreateNeworRenameFile(ItemC))
            { GoToMainForm(this.ItemC); }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }
        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ItemC == null)
            {
                if (CheckItemCheckerFile())
                { CreateNeworRenameFile(ItemC); }
            }
            else
            { CreateNeworRenameFile(ItemC); }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ItemC == null)
            { MessageBox.Show("You haven't made any changes yet." + Environment.NewLine + "If you want to rename or relocate, choose 'SaveAs'", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            { DataStream.SaveFile(ItemC, Properties.Settings.Default.FilePath); }
        }
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = "ItemList File|*.item";
            openfiledialog.Title = "Opening an .Item File...";
            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {
                ItemChecker tempitemchecker = DataStream.OpenFile<ItemChecker>(openfiledialog.FileName);
                if (tempitemchecker != null)
                {
                    ItemC = tempitemchecker;
                    UpdateFilePath(openfiledialog.FileName);
                    tbpath.Text = Properties.Settings.Default.FilePath;
                    GoToMainForm(ItemC);
                }
            }
            openfiledialog.Dispose();
        }
    }
}
