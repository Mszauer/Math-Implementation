using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;
using Math_Implementation;
using System.Drawing;

namespace RayCaster {
    class Game {
        private static Game instance = null;
        public static Game Instance {
            get {
                if (instance == null) {
                    instance = new Game();
                }
                return instance;
            }
        }
        float moveSpeed = 5.0f;
        int[][] worldMap = null;
        Vector2 playerPos = new Vector2(22f,12f);
        Vector2 playerDir = new Vector2(-1f,0f);
        Vector2 playerCam = new Vector2(0f,0.66f); //always perpendicular to direction
        float w = 800f;//how many columns get rayed
        float h = 600f;//how many pixels the lines come down

        private Game() {
        }
        public void Initialize() {
            //initialize array inline
            //possibly upgrade to textreader in future
            worldMap = new int[24][] {
                new int[]   {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                new int[]   {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,0,0,0,0,0,2,2,2,2,2,0,0,0,0,3,0,3,0,3,0,0,0,1},
                new int[]   {1,0,0,0,0,0,2,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,0,0,0,0,0,2,0,0,0,2,0,0,0,0,3,0,0,0,3,0,0,0,1},
                new int[]   {1,0,0,0,0,0,2,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,0,0,0,0,0,2,2,0,2,2,0,0,0,0,3,0,3,0,3,0,0,0,1},
                new int[]   {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,4,4,4,4,4,4,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,4,0,4,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,4,0,0,0,0,5,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,4,0,4,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,4,0,4,4,4,4,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,4,4,4,4,4,4,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                new int[]   {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
            };
           
        }
        public void Update(float dTime) {
            if (InputManager.Instance.KeyDown(OpenTK.Input.Key.W) || InputManager.Instance.KeyDown(OpenTK.Input.Key.Up)) {
                if (worldMap[(int)(playerPos.X+playerDir.X*moveSpeed)][(int)(playerPos.Y+playerDir.Y*moveSpeed)] == 0) {
                    playerPos += playerDir * moveSpeed * dTime;
                }
            }
            else if (InputManager.Instance.KeyDown(OpenTK.Input.Key.S) || InputManager.Instance.KeyDown(OpenTK.Input.Key.Down)) {
                if (worldMap[(int)(playerPos.X + playerDir.X * moveSpeed)][(int)(playerPos.Y + playerDir.Y * moveSpeed)] == 0) {
                    playerPos -= playerDir * moveSpeed * dTime;
                }
            }
            if (InputManager.Instance.KeyDown(OpenTK.Input.Key.A) || InputManager.Instance.KeyDown(OpenTK.Input.Key.Left)) {
                //rotate left
                playerDir = Matrix2.Rotation(90.0f * dTime) * playerDir;
                playerCam = Matrix2.Rotation(90.0f * dTime) * playerCam;
            }
            if (InputManager.Instance.KeyDown(OpenTK.Input.Key.D) || InputManager.Instance.KeyDown(OpenTK.Input.Key.Right)) {
                //rotate left
                playerDir = Matrix2.Rotation(-90.0f * dTime) * playerDir;
                playerCam = Matrix2.Rotation(-90.0f * dTime) * playerCam;
            }
        }
        public void Render() {
            for (int x = 0; x < w; x++) {//loop through each column
                //calculate ray position and direction
                float cameraX = 2 * (float)x / w - 1;//x coordinate in camera space
                Vector2 rayPos = new Vector2(playerPos.X, playerPos.Y);
                Vector2 rayDir = playerDir + playerCam *  cameraX;
                //which box of the map it is in
                int mapX = (int)rayPos.X;
                int mapY = (int)rayPos.Y;
                //length of ray from current position to next x or y-side
                Vector2 sideDist = new Vector2();

                //length of ray from one x or y-side to the next x or Y-side
                Vector2 deltaDist = new Vector2((float)Math.Sqrt(1 + (rayDir.Y * rayDir.Y) / (rayDir.X * rayDir.X)), (float)Math.Sqrt(1 + (rayDir.X * rayDir.X) / (rayDir.Y * rayDir.Y)));
                float perpWallDist = 0.0f;

                //what direction to step in x or y(+1 or -1)
                Vector2 step = new Vector2();

                float hit = 0f; //was there a wall hit
                float side = 0f;//was a NS or EW wall hit
                
                //calculate step and initial sideDist
                if (rayDir.X < 0f) {
                    step.X = -1f;
                    sideDist.X = (rayPos.X - mapX) * deltaDist.X;
                }
                else {
                    step.X = 1f;
                    sideDist.X = (mapX + 1.0f - rayPos.X) * deltaDist.X;
                }
                if (rayDir.Y < 0f) {
                    step.Y = -1f;
                    sideDist.Y = (rayPos.Y - mapY) * deltaDist.Y;
                }
                else {
                    step.Y = 1f;
                    sideDist.Y = (mapY + 1.0f - rayPos.Y) * deltaDist.Y;
                }
                
                //perform dda
                while (hit == 0) {
                    //jump to next map squar in x or y dir
                    if (sideDist.X < sideDist.Y) {
                        sideDist.X += deltaDist.X;
                        mapX += (int)step.X;
                        side = 0f;
                    }
                    else {
                        sideDist.Y += deltaDist.Y;
                        mapY += (int)step.Y;
                        side = 1f;
                    }
                    //check if ray has hit a wall
                    if (worldMap[mapX][mapY] > 0) {
                        hit = 1f;
                    }
                }//end hit
                //calculate distance project on camera direction
                if (side == 0) {
                    perpWallDist = (float)Math.Abs((mapX - rayPos.X + (1.0f - step.X) / 2.0f) / rayDir.X);
                }
                else {
                    perpWallDist = (float)Math.Abs((mapY - rayPos.Y + (1.0f - step.Y) / 2.0f) / rayDir.Y);
                }

                //calculate height of line to draw on screen
                float lineHeight = Math.Abs((h / perpWallDist));
                //calculate lowest and highest pixel to fill in current stripe
                float drawStart = (-(lineHeight / 2.0f) + (h / 2.0f));
                drawStart = drawStart < 0 ? 0 : drawStart;//cap start at 0
                float drawEnd = (lineHeight / 2.0f + h / 2.0f);
                drawEnd = drawEnd >= h ? (h - 1f) : drawEnd; //cap end at h-1
                Color renderColor = Color.Yellow; ;
                //set color according to value
                if (worldMap[mapX][mapY] == 1) {
                    renderColor = Color.Red;
                }
                else if (worldMap[mapX][mapY] == 2) {
                    renderColor = Color.Green;
                }
                else if (worldMap[mapX][mapY] == 3) {
                    renderColor = Color.Blue;
                }
                else if (worldMap[mapX][mapY] == 4) {
                    renderColor = Color.White;
                }
                //shading
                if (side == 1) {
                    renderColor = Color.FromArgb(255, renderColor.R / 2, renderColor.G / 2, renderColor.B / 2);
                }
                //draw pizels of the stripe as vertical line
                GraphicsManager.Instance.DrawLine(new Point(x, (int)drawStart), new Point(x, (int)drawEnd), renderColor);
            }
        }
        public void Shutdown() {

        }
    }
}
