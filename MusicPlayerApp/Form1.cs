using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// @author Samul1
/// @version 31.01.2021
/// 
/// <summary>
/// Music Player
/// </summary>
namespace MusicPlayerApp
{
    public partial class MusicPlayerApp : Form
    {
        public MusicPlayerApp()
        {
            InitializeComponent();
        }

        // Create Global Variables of srting type array to save the titles or name of the tracks and paht of the track
        String[] paths, files;

        private void btnSelectSongs_Click(object sender, EventArgs e)
        {
            // Code to select song
            OpenFileDialog ofd = new OpenFileDialog();

            // Code to select multiple files
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = ofd.SafeFileNames; // Save the names of the track in files array
                paths = ofd.FileNames; // Save the paths of the tracks in path array
                
                // Display the music titles in listbox
                for(int i = 0; i<files.Length; i++)
                {
                    listBoxSongs.Items.Add(files[i]); // Display songs in listbox
                }
            }
        }

        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Write a code to play music
            axWindowsMediaPlayerMusic.URL = paths[listBoxSongs.SelectedIndex];
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Code to minimize the app
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Code to close the app
            this.Close();
        }

        #region "Dragging a Music Player Window"
        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            // Code to move the window by dragging top of the window
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        // Declare a variable for the lastpoint
        Point lastPoint;

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        #endregion
    }
}
