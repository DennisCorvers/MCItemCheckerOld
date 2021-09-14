using System;
using System.Drawing;
using System.Windows.Forms;

namespace MCItemChecker.GUI
{
    public partial class InputBox : Form
    {
        public string Result
            => tbInput.Text;

        public InputBox(string title, string description)
        {
            InitializeComponent();

            Text = title;
            descriptionLabel.Text = description;
            ClientSize = new Size(Math.Max(300, descriptionLabel.Right + 10), ClientSize.Height);
        }
    }
}
