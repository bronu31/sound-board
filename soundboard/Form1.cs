using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace soundboard
{
    public partial class Form1 : Form
    {
        private SoundPlayer player;
        private FlowLayoutPanel flow_panel;
        private Panel panel;
        public Form1()
        {
            InitializeComponent();

        }

        private void folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // shows the path to the selected folder in the folder dialog
                string[] files =
        Directory.GetFiles(fbd.SelectedPath,
        "*.wav", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    add_files(file, Path.GetFileName(file));
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player = new SoundPlayer();
            flow_panel = flowLayout;
            flow_panel.HorizontalScroll.Enabled = false;
            flow_panel.AutoScroll = true;
        }
        private void add_files(string file, string file_name)
        {
            GroupBox box = new GroupBox();
            box.Size = new Size(500, 250);
            Button button = new Button();
            TextBox text = new TextBox();
            text.Text = file;
            text.Size = new Size(250, 25);
            text.Location = new Point(10, 10);

            TextBox text1 = new TextBox();
            text1.Text = file_name;
            text1.Size = new Size(250, 25);
            text1.Location = new Point(10, 40);

            button.Size = new Size(50, 50);
            button.Location = new Point(40, 60);
            //button.Image =new Bitmap("play.jpg");
            button.Text = "Play";
            button.Click += (sender, e) => button_click(sender, e, file, file_name);
            box.Controls.Add(text);
            box.Controls.Add(button);
            box.Controls.Add(text1);
            flow_panel.Controls.Add(box);


        }
        private void button_click(object sender, EventArgs e, string file, string file_name)
        {

            player.SoundLocation = file;
            player.Stream = System.IO.File.OpenRead(file);
            if (player.Stream.CanSeek)
            {
                player.Stream.Seek(0, SeekOrigin.Begin);
                player.Play();

            }

        }
        //public static Stream GetFileStream(string fileName) => System.IO.File.OpenRead(fileName);
    }
}
