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
        int moveSpeed = 30;
        int[][] worldMap = null;
        Vector2 playerPos = new Vector2(22f,12f);
        Vector2 playerDir = new Vector2(-1f,0f);
        Vector2 playerCam = new Vector2(0f,0.66f); //always perpendicular to direction
        float w = 24.0f;//how many columns get rayed
        float h = 600;//height of screen in pixels
        float oldTime = 0.0f;//time of prev frame
        float time = 0.0f;//time of current frame

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
                //no collision check
                playerPos.X += playerDir.X * moveSpeed*dTime;
            }
            else if (InputManager.Instance.KeyDown(OpenTK.Input.Key.S) || InputManager.Instance.KeyDown(OpenTK.Input.Key.Down)) {
                playerPos.X -= playerDir.X * moveSpeed*dTime;
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
                float cameraX = 2 * x / w - 1;//x coordinate in camera space
                Vector2 rayPos = new Vector2(playerPos.X, playerPos.Y);
                Vector2 rayDir = new Vector2(playerDir.X + playerCam.X * cameraX, playerDir.Y + playerCam.Y * cameraX);
                //which box of the map it is in
                Vector2 mapPos = new Vector2(rayPos.X, rayPos.Y);
                //length of ray from current position to next x or y-side
                Vector2 sideDist = new Vector2();

                //length of ray from one x or y-side to the next x or Y-side
                Vector2 deltaDist = new Vector2((float)Math.Sqrt(1 + (rayDir.Y * rayDir.Y) / (rayDir.X * rayDir.X)), (float)Math.Sqrt(1 + (rayDir.X * rayDir.X) / (rayDir.Y * rayDir.Y)));
                float perpWallDist = 0.0f;

                //what direction to step in x or y(+1 or -1)
                Vector2 step = new Vector2();

                int hit = 0; //was there a wall hit
                int side = 0;//was a NS or EW wall hit

                //calculate step and initial sideDist
                if (rayDir.X < 0) {
                    step.X = -1;
                    sideDist.X = (rayPos.X - mapPos.X) * deltaDist.X;
                }
                else {
                    step.X = 1;
                    sideDist.X = (mapPos.X + 1.0f - rayPos.X) * deltaDist.X;
                }
                if (rayDir.Y < 0) {
                    step.Y = -1;
                    sideDist.Y = (rayPos.Y - mapPos.Y) * deltaDist.Y;
                }
                else {
                    step.Y = 1;
                    sideDist.Y = (mapPos.Y + 1.0f - rayPos.Y) * deltaDist.Y;
                }

                //perform dda
                while (hit == 0) {
                    //jump to next map squar in x or y dir
                    if (sideDist.X < sideDist.Y) {
                        sideDist.X += deltaDist.X;
                        mapPos.X += step.X;
                        side = 0;
                    }
                    else {
                        sideDist.Y += deltaDist.Y;
                        mapPos.Y += step.Y;
                        side = 1;
                    }
                    //check if ray has hit a wall
                    if (worldMap[(int)mapPos.X][(int)mapPos.Y] > 0) {
                        hit = 1;
                    }
                }//end hit
                //calculate distance project on camera direction
                if (side == 0) {
                    perpWallDist = Math.Abs((mapPos.X - rayPos.X + (1 - step.X) / 2) / rayDir.X);
                }
                else {
                    perpWallDist = Math.Abs((mapPos.Y - rayPos.Y + (1 - step.Y) / 2) / rayDir.Y);
                }

                //calculate height of line to draw on screen
                int lineHeight = (int)Math.Abs((h / perpWallDist));
                //calculate lowest and highest pixel to fill in current stripe
                int drawStart = -(int)((lineHeight / 2.0f) + (h / 2.0f));
                drawStart = drawStart < 0 ? 0 : drawStart;//cap start at 0
                int drawEnd = (int)(lineHeight / 2.0f + h / 2.0f);
                drawEnd = drawEnd >= h ? (int)(h - 1) : drawEnd; //cap end at h-1
                Color renderColor = Color.Yellow; ;
                //loop through map to set colors according to value
                for (int col = 0; col < 24; col++) {
                    for (int row = 0; row < 24; row++) {
                        if (worldMap[col][row] == 1) {
                            renderColor = Color.Red;
                            break;
                        }
                        else if (worldMap[col][row] == 2) {
                            renderColor = Color.Green;
                            break;
                        }
                        else if (worldMap[col][row] == 3) {
                            renderColor = Color.Blue;
                            break;
                        }
                        else if (worldMap[col][row] == 4) {
                            renderColor = Color.White;
                            break;
                        }
                    }
                }

                //draw pizels of the stripe as vertical line
                GraphicsManager.Instance.DrawLine(new Point(x, drawStart), new Point(x, drawEnd), renderColor);
            }
        }
        public void Shutdown() {

        }
    }
}
