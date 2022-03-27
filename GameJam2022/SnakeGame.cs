using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameJam2022
{
    public class SnakeGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont font;
        private PlayerSnake snake;

        
        private const int snakeSize = 10;
        private Food[] food;
        System.Random rand = new System.Random();

        public SnakeGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = Constants.GAME_WIDTH;
            _graphics.PreferredBackBufferHeight = Constants.GAME_HEIGHT;
        }

        protected override void Initialize()
        {
            
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferHeight = Constants.GAME_HEIGHT * snakeSize;
            _graphics.PreferredBackBufferWidth = Constants.GAME_WIDTH * snakeSize;
            food = new Food[]
            {
                new Food(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new Food(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new Food(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height))
            };
            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            snake = new PlayerSnake(this, GraphicsDevice, _spriteBatch, snakeSize);
            foreach (var f in food) f.LoadContent(Content);
            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("Pixel");
            this.Components.Add(snake);
        }

        public void checkSnakeFood()
        {
            int prevfood = 0;
            foreach(var f in food)
                {
                    
                    if (snake.posX == f.posX)
                    {
                    snake.score++;
                    snake.Addtail();
                    food[prevfood] = new Food(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height));
                    }
                prevfood++;
            }

            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                snake.dirX = 0;
                snake.dirY = -1;
            }
            else if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                snake.dirX = 0;
                snake.dirY = 1;
            }
            else if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                snake.dirX = -1;
                snake.dirY = 0;
            }
            else if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                snake.dirX = 1;
                snake.dirY = 0;
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGreen);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (var f in food) f.Draw(gameTime, _spriteBatch);
            _spriteBatch.DrawString(font, $"{"Score . . ."}", new Vector2(snakeSize), Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
