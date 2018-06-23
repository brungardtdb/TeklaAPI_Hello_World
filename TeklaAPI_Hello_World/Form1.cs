// Date: 6/23/2018
// Author: David Brungardt
// This is a Hello World application using 
// the Tekla open API
// The application displays a message in a message
// box, as well as in the console, that says
// "Hello World!!! Your model is: " and then displays
// the name of the model the user is currently in.
// If the user is not connected to Tekla Structures, 
// A message box will show displaying an error message.

using System;
using System.Windows.Forms;
using Tekla.Structures.Model;
using Tekla.Structures.Model.Operations;

namespace TeklaAPI_Hello_World
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a model instance, check the connection status

            Model model = new Model();
            if (!model.GetConnectionStatus())
            {
                MessageBox.Show("Tekla Structures is not connected, please connect to Tekla Structures");
                return;
            }

            // Get model info and send "Hello World" message to the message box
            ModelInfo modelInfo = model.GetInfo();
            string modelName = modelInfo.ModelName;

            MessageBox.Show(string.Format("Hello world!!! Your current model is: {0}", modelName));

            // Send a hello world message to the Tekla Structures user command prompt
            Operation.DisplayPrompt(string.Format("Hello world!!! Your current model is: {0}", modelName));
        }

        
    }
}
