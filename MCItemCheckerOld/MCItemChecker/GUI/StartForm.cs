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
        private string m_defaultDirectory;
        private string m_defaultFilePath;

        public StartForm()
        {
            InitializeComponent();

            m_defaultDirectory = DataStream.CurrentDir() + "\\MCItemCheckerData";
            m_defaultFilePath = m_defaultDirectory + "\\Data.mci";

            if (Properties.Settings.Default.FilePath == null || Properties.Settings.Default.FilePath == "")
                tbpath.Text = "No file selected!";
            else
                tbpath.Text = Properties.Settings.Default.FilePath;
        }

        private void GoToMainForm(ItemChecker file)
        {
            if (file == null)
            {
                MessageBox.Show("The .item file wasn''t loaded properly, try re-opening", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var mainMenu = new MainMenu(file);
            Hide();

            mainMenu.ShowDialog();

            // Control will be returned here...
            Show();
        }

        private ItemChecker LoadItemCheckerDatabase()
        {
            //Checks if the Filename field is empty.
            if (Properties.Settings.Default.FilePath == null || Properties.Settings.Default.FilePath == "")
            {
                DialogResult dialogResult = MessageBox.Show("No .item file was found!" + Environment.NewLine + "Do tou want to create a new file?", "No File Found!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var file = new ItemChecker();
                    if (TrySaveFile(file))
                        return file;
                }
            }
            else
            {
                if (TryLoadDatabase(Properties.Settings.Default.FilePath, out ItemChecker file))
                    return file;
            }

            return null;
        }

        private void ExitApplication()
        {
            Application.Exit();
        }

        private void UpdateFilePath(string FilePath)
        {
            Properties.Settings.Default.FilePath = FilePath;
            Properties.Settings.Default.Save();
        }

        private void BExit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void Bresume_Click(object sender, EventArgs e)
        {
            GoToMainForm(LoadItemCheckerDatabase());
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemChecker file = new ItemChecker();
            if (TrySaveFile(file))
                GoToMainForm(file);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openfiledialog = new OpenFileDialog()
            {
                Filter = "ItemList File|*.item",
                Title = "Opening an .Item File..."
            })
            {
                if (openfiledialog.ShowDialog() == DialogResult.OK)
                {
                    if (TryLoadDatabase(openfiledialog.FileName, out ItemChecker file))
                    {
                        UpdateFilePath(openfiledialog.FileName);
                        tbpath.Text = Properties.Settings.Default.FilePath;

                        GoToMainForm(file);
                    }
                }
            }
        }

        private bool TrySaveFile(ItemChecker ic)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "ItemList File|*.item",
                Title = "Save an .Item File"
            };
            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                UpdateFilePath(saveFileDialog.FileName);
                tbpath.Text = Properties.Settings.Default.FilePath;
            }
            if (result == DialogResult.Cancel)
                return false;

            return DataStream.SaveFile(ic, Properties.Settings.Default.FilePath);
        }

        private bool TryLoadDatabase(string path, out ItemChecker file)
        {
            file = null;

            try
            {
                file = DataStream.OpenFile<ItemChecker>(path);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}
