using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace MCItemChecker.Utils
{
    static class DataStream
    {
        /// <summary>
        /// Streamwrites the given class to a file
        /// </summary>
        /// <param name="T">The serializable class</param>
        /// <param name="filepath">The full directory of the file (including the file's name + its extention</param>
        /// <returns>Returns true when writing is succesfull</returns>
        public static bool SaveFile(object T, string filepath)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, T);
                stream.Close();
                return true;
            }
            catch (Exception ex)
            {
                ThrowErrorMessage(ex);
                return false;
            }
        }

        /// <summary>
        /// Returns the current working directory
        /// </summary>
        /// <returns></returns>
        public static string CurrentDir()
        { return Directory.GetCurrentDirectory(); }

        /// <summary>
        /// Checks if the file in the listed directory exists
        /// </summary>
        /// <param name="directory">Directory the file should be in</param>
        /// <returns>Returns true if the file does exist</returns>
        public static bool FileExists(string filepath)
        {
            if (File.Exists(filepath)) { return true; };
            return false;
        }

        /// <summary>
        /// Checks if the directory exists.
        /// </summary>
        /// <returns>Returns false if the directory doesn't exist</returns>
        public static bool DirectoryExists(string directory)
        {
            if (!Directory.Exists(directory)) { return false; }
            return true;
        }

        /// <summary>
        /// Creates a new directory
        /// </summary>
        /// <param name="directory">The directory path that needs to be created</param>
        /// <returns>returns true when the directory is created</returns>
        public static bool CreateDirectory(string directory)
        {
            try
            { Directory.CreateDirectory(directory); }
            catch (Exception ex)
            {
                ThrowErrorMessage(ex, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Loads a file specified by the filepath.
        /// </summary>
        /// <param name="filepath">The path of the file</param>
        /// <returns>Returns the loaded file as an object</returns>
        public static T OpenFile<T>(string filepath)
        {
            IFormatter formatter = new BinaryFormatter();
            try
            {
                using (Stream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    T file = (T)formatter.Deserialize(stream);
                    return file;
                }
            }
            catch (Exception ex)
            {
                ThrowErrorMessage(ex);
                return default(T);
            }
        }

        /// <summary>
        /// Opens a SaveFileDialog for saving a specified file
        /// </summary>
        /// <param name="o">The object that needs to be serialized</param>
        /// <param name="extension">The files extension (A "." followed by a string)</param>
        /// <param name="dialogfilter">The SaveFileDialog.Filter property (Name | *extention type) Example: "Picture | *png"</param>
        /// <param name="dialogtitle">The SaveFileDialog.Title property</param>
        /// <returns>Returns true if the object was saved</returns>
        public static bool Savefiledialog(object o, string dialogfilter = null, string dialogtitle = null)
        {
            string FilePath = CreateSaveFileDialog(dialogfilter, dialogtitle);

            if (FilePath == null) return false;
            if (!SaveFile(o, FilePath)) return false;

            return true;
        }

        /// <summary>
        /// Opens a OpenFileDialog for opening a file
        /// </summary>
        /// <param name="T">The object selected by the openfiledialog</param>
        /// <param name="extension">The files extension</param>
        /// <param name="dialogfilter">The OpenFileDialog.Filter property (Name | *extention type) Example: "Picture | *png"</param>
        /// <param name="dialogtitle">The OpenFileDialog.Title property</param>
        /// <returns>Returns the selected object</returns>
        public static T Openfiledialog<T>(string dialogfilter = null, string dialogtitle = null)
        {
            string filepath = CreateOpenFileDialog(dialogfilter, dialogtitle);

            if (filepath != null)
            {
                T file = OpenFile<T>(filepath);
                return file;
            }

            return default(T);
        }

        /// <summary>
        /// Opens a "Open File Dialog" for opening files.
        /// </summary>
        /// <param name="dialogfilter">This is a filter for which file types the dialog should list</param>
        /// <param name="dialogtitle">The title of the dialog</param>
        /// <returns>Returns the filepath of the selected file</returns>
        private static string CreateOpenFileDialog(string dialogfilter = null, string dialogtitle = null)
        {
            string filename = null;
            OpenFileDialog openfiledialog = new OpenFileDialog();
            //Sets the dialogs title (if available), else picks default
            if (dialogtitle == null)
            { openfiledialog.Title = "Open File"; }
            else
            { openfiledialog.Title = dialogtitle; }

            //Tries to set an item filter (if available and correct) else picks default
            if (dialogfilter == null)
            { openfiledialog.Filter = "All Files (*.*)|*.*"; }
            else
            {
                try
                { openfiledialog.Filter = dialogfilter; }
                catch
                { openfiledialog.Filter = "All Files (*.*)|*.*"; }
            }

            if (openfiledialog.ShowDialog() == DialogResult.OK)
            { filename = openfiledialog.FileName; }

            openfiledialog.Dispose();

            return filename;
        }

        /// <summary>
        /// Opens a "Save File Dialog" for saving files.
        /// </summary>
        /// <param name="dialogfilter">This is a filter for which file types the dialog should list</param>
        /// <param name="dialogtitle">The title of the dialog</param>
        /// <returns>Returns the filepath of the selected directory</returns>
        private static string CreateSaveFileDialog(string dialogfilter = null, string dialogtitle = null)
        {
            String FilePath = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //Sets the dialogs title (if available), else picks default
            if (dialogfilter == null)
            { saveFileDialog.Filter = "All Files (*.*)|*.*"; }
            else
            {
                try
                { saveFileDialog.Filter = dialogfilter; }
                catch
                { saveFileDialog.Filter = "All Files (*.*)|*.*"; }
            }
            //Tries to set an item filter (if available and correct) else picks default
            if (dialogtitle == null)
            { saveFileDialog.Title = "Save as..."; }
            else
            { saveFileDialog.Title = dialogtitle; }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = saveFileDialog.FileName;
            }
            saveFileDialog.Dispose();
            return FilePath;
        }

        /// <summary>
        /// Writes an array of string to a text file
        /// </summary>
        /// <param name="Text">The text to be serialized</param>
        /// <param name="filepath">The path of the file</param>
        /// <param name="append">Whether or not the text should be added to the already existing file</param>
        public static bool WriteTexttoFile(string[] Text, string filepath, bool append = false)
        {
            try
            {
                //Tries to create a new streamwriter and write the text array to file.
                StreamWriter sw = new StreamWriter(filepath, append);
                foreach (string s in Text)
                {
                    sw.WriteLine(s);
                }
                sw.Close(); sw.Dispose();
            }
            catch (Exception ex)
            {
                ThrowErrorMessage(ex);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Writes a single string to a text file
        /// </summary>
        /// <param name="Text">The text to be serialized</param>
        /// <param name="filepath">The path of the file</param>
        /// <param name="append">Whether or not the text should be added to the already existing file</param>
        public static Boolean WriteStringtoFile(string s, string filepath, bool append = false)
        {
            string[] sarray = new string[1];
            sarray[0] = s;
            return WriteTexttoFile(sarray, filepath, append);
        }

        /// <summary>
        /// Reads all the text from a text file and outputs it in a single string.
        /// </summary>
        /// <param name="filepath">The filepath of the file</param>
        /// <returns>Returns all the text from the file</returns>
        public static string ReadStringFromTextFile(string filepath)
        {
            string s = null;

            try
            {
                StreamReader sr = new StreamReader(filepath);
                s = sr.ReadToEnd();
                sr.Close(); sr.Dispose();
            }
            catch (Exception ex) { ThrowErrorMessage(ex); }

            return s;
        }

        /// <summary>
        /// Reads all the text from a text file and outputs it in an array.
        /// </summary>
        /// <param name="filepath">The filepath of the file</param>
        /// <returns>Returns all the text from the file</returns>
        public static string[] ReadArrayFromTextFile(string filepath)
        {
            List<string> slist = new List<string>();
            try
            {
                StreamReader sr = new StreamReader(filepath);
                while (sr.Peek() > 0)
                { slist.Add(sr.ReadLine()); }
                sr.Close(); sr.Dispose();
            }
            catch (Exception ex)
            { ThrowErrorMessage(ex, MessageBoxIcon.Warning); }
            return slist.ToArray();
        }

        /// <summary>
        /// Opens a "Save File Dialog" for saving a (text)file
        /// </summary>
        /// <param name="Text">The text that needs to be saved</param>
        /// <param name="append">Whether or not the new text should be added to an existing file</param>
        /// <param name="dialogfilter">This is a filter for which file types the dialog should list</param>
        /// <param name="dialogtitle">The title of the dialog</param>
        /// <returns>Returns true if the file was saved correcrly</returns>
        public static Boolean SaveTexttoFileDialog(string[] Text, bool append = false, string dialogfilter = "Text Documents (*.txt)|*.txt", string dialogtitle = null)
        {
            string FilePath = CreateSaveFileDialog(dialogfilter, dialogtitle);

            if (FilePath == null) return false;
            if (!WriteTexttoFile(Text, FilePath, append)) return false;

            return true;
        }

        /// <summary>
        /// Opens a "Save File Dialog" for saving a (text)file
        /// </summary>
        /// <param name="Text">The text that needs to be saved</param>
        /// <param name="append">Whether or not the new text should be added to an existing file</param>
        /// <param name="dialogfilter">This is a filter for which file types the dialog should list</param>
        /// <param name="dialogtitle">The title of the dialog</param>
        /// <returns>Returns true if the file was saved correcrly</returns>
        public static Boolean SaveStringtoFileDialog(string Text, bool append = false, string dialogfilter = "Text Documents (*.txt)|*.txt", string dialogtitle = null)
        {
            string FilePath = CreateSaveFileDialog(dialogfilter, dialogtitle);

            if (FilePath == null) return false;
            if (!WriteStringtoFile(Text, FilePath, append)) return false;

            return true;
        }

        /// <summary>
        /// Opens a "Open File Dialog" for opening a (text)file
        /// </summary>
        /// <param name="dialogfilter">This is a filter for which file types the dialog should list</param>
        /// <param name="dialogtitle">The title of the dialog</param>
        /// <returns>Returns the textfile in a single string</returns>
        public static string OpenStringfromFileDialog(string dialogfilter = "Text Documents (*.txt)|*.txt", string dialogtitle = null)
        {
            string filepath = CreateOpenFileDialog(dialogfilter, dialogtitle);

            if (filepath != null)
            { return ReadStringFromTextFile(filepath); }
            return null;
        }

        /// <summary>
        /// Opens a "Open File Dialog" for opening a (text)file
        /// </summary>
        /// <param name="dialogfilter">This is a filter for which file types the dialog should list</param>
        /// <param name="dialogtitle">The title of the dialog</param>
        /// <returns>Returns the textfile in a string array</returns>
        public static string[] OpenArrayfromFileDialog(string dialogfilter = "Text Documents (*.txt)|*.txt", string dialogtitle = null)
        {
            string filepath = CreateOpenFileDialog(dialogfilter, dialogtitle);

            if (filepath != null)
            { return ReadArrayFromTextFile(filepath); }
            return null;
        }

        /// <summary>
        /// Creates a messagebox with information about the error thrown.
        /// </summary>
        /// <param name="ErrorMessage">The error message</param>
        /// <param name="Icon">The icon shown on the dialog</param>
        private static void ThrowErrorMessage(Exception ex, MessageBoxIcon Icon = MessageBoxIcon.Error)
        {
            if (ex is SerializationException)
            {
                MessageBox.Show("Could not open file. \nThe selected file isn't the correct filetype", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ex is OutOfMemoryException)
            {
                MessageBox.Show("Could not open file. \nThe file was either too large or the incorrect filetype", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, Icon);
        }
    }
}
