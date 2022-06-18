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
        public StartForm()
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Settings.Properties.FilePath))
                tbpath.Text = "No file selected!";
            else
                tbpath.Text = Settings.Properties.FilePath;
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

        private bool TryLoadItemCheckerDatabase(out ItemChecker file)
        {
            //Checks if the Filename field is empty.
            if (string.IsNullOrEmpty(Settings.Properties.FilePath))
            {
                DialogResult dialogResult = MessageBox.Show($"No .item file was found!{Environment.NewLine}Do you want to create a new file?",
                    "No File Found!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (dialogResult == DialogResult.Yes)
                {
                    file = new ItemChecker();
                    return TrySaveFile(file);
                }
            }
            else
            {
                return TryLoadFile(Settings.Properties.FilePath, out file);
            }

            file = null;
            return false;
        }

        private void ExitApplication()
        {
            Application.Exit();
        }

        private void UpdateFilePath(string FilePath)
        {
            Settings.Properties.FilePath = FilePath;
            Settings.Save();
        }

        private void BExit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void Bresume_Click(object sender, EventArgs e)
        {
            if (TryLoadItemCheckerDatabase(out ItemChecker file))
                GoToMainForm(file);
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
                    if (TryLoadFile(openfiledialog.FileName, out ItemChecker file))
                    {
                        UpdateFilePath(openfiledialog.FileName);
                        tbpath.Text = Settings.Properties.FilePath;

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
                tbpath.Text = Settings.Properties.FilePath;
            }
            if (result == DialogResult.Cancel)
                return false;

            try
            {
                DataStream.SaveFile(ic, Settings.Properties.FilePath);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool TryLoadFile(string path, out ItemChecker file)
        {
            try
            {
                file = DataStream.OpenFile<ItemChecker>(path);
                return true;
            }
            catch (Exception e)
            {
                // To be removed in future iterations...
                if (TryLoadDeprecated(path, out file))
                    return true;
                else
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        private bool TryLoadDeprecated(string path, out ItemChecker file)
        {
            file = null;

            try
            {
                file = DataStream.OpenFileOld<ItemChecker>(path);

                // We are still dealing with an old file format.
                // Rename the old file.
                var newDir = $"{Path.GetDirectoryName(path)}\\{Path.GetFileNameWithoutExtension(path)}Old{Path.GetExtension(path)}";

                File.Move(path, newDir);
                return true;
            }
            catch
            { }

            return false;
        }
    }
}
