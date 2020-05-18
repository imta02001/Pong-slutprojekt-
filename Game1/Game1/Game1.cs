using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D pixel;
        Rectangle boll = new Rectangle(100, 100, 20, 20);
        Rectangle spelare1 = new Rectangle(10, 150, 20, 150);
        Rectangle spelare2 = new Rectangle(770, 150, 20, 150);

        // Här skapar jag tre sprites: En boll och två paddlar
        SpriteFont scorefont;
        int score1 = 0;
        int score2 = 0;
        // poängsystem
    
        int x_speed = 5;
        int y_speed = 5;
        // Här bestämmer jag hastigheten/rörelsen på bollen
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }



        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            this.Components.Add(new MyControls(this));

            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            pixel = Content.Load<Texture2D>("pixel");
            scorefont = Content.Load<SpriteFont>("scorefont");
            //Laddar in pixel filen & textfilen för poänsystem från Monogame

        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)

        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState kstate = Keyboard.GetState();

            boll.X += x_speed;
            boll.Y += y_speed;

            if (kstate.IsKeyDown(Keys.W))
                spelare1.Y -= 5;
            if (kstate.IsKeyDown(Keys.S))
                spelare1.Y += 5;
            if (kstate.IsKeyDown(Keys.Up))
                spelare2.Y -= 5;
            if (kstate.IsKeyDown(Keys.Down))
                spelare2.Y += 5;

            if (spelare2.Y < 0)
                spelare2.Y = 0;
            if (spelare2.Y > Window.ClientBounds.Height - spelare2.Height)
                spelare2.Y = Window.ClientBounds.Height - spelare2.Height;
            if (spelare1.Y < 0)
                spelare1.Y = 0;
            if (spelare1.Y > Window.ClientBounds.Height - spelare1.Height)
                spelare1.Y = Window.ClientBounds.Height - spelare1.Height;

            if (boll.Y < 0 || boll.Y > Window.ClientBounds.Height - boll.Height)
                y_speed *= -1;

            if (boll.Intersects(spelare1) || boll.Intersects(spelare2))
                x_speed *= -1;


            if (boll.X > Window.ClientBounds.Width - boll.Width)
            {
                score1++;
                boll.X = 400;
                boll.Y = 200;
                x_speed *= -1;
            }

            if (boll.X < 0)
            {
                score2++;
                boll.X = 400;
                boll.Y = 200;
                x_speed *= -1;
            }


            //Här har jag skapat if-satser där jag läser av tangentbordet samt begränsar bollen så att den inte flyger ut från fönstret. har även gjort så att bollen studsar mot paddlarna och om den flyger ut så stängs spelet. har oxå skapat en if sats för poängsystemet så att varje gång bollen nuddar motsvarande sida ökar poänget med 1



            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(pixel, boll, Color.Black);
            spriteBatch.Draw(pixel, spelare1, Color.Black);
            spriteBatch.Draw(pixel, spelare2, Color.Black);
            spriteBatch.DrawString(scorefont, score1.ToString(), new Vector2(10, 10), Color.Black);
            spriteBatch.DrawString(scorefont, score2.ToString(), new Vector2(780, 10), Color.Black);
            spriteBatch.End();
            /// här har jag ritat upp: boll, paddlarna, valjt färg på objekten samt lagt in texten för poängsystem

            base.Draw(gameTime);
        }
    }
}
