using Microsoft.Xna.Framework;
using MonoGame.UI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class MyControls : ControlManager
    {
        public MyControls(Game game) : base(game)
        {
        }

        public override void InitializeComponent()
        {
            var btn1 = new Button()
            {
                Text = "EXIT GAME",
                Size = new Vector2(200, 50),
                BackgroundColor = Color.DarkGreen,
                Location = new Vector2(200, 200)
            };

            btn1.Clicked += Btn1_Clicked;
        }

        private void Btn1_Clicked(object sender, EventArgs e)
        {
           
        }
    }
}
