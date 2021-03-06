﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;
using OpenTK;
using System.Drawing;

namespace RayCaster {
    class Program {
        public static OpenTK.GameWindow Window = null;
        public static void Initialize(object sender, EventArgs e) {
            GraphicsManager.Instance.Initialize(Window);
            TextureManager.Instance.Initialize(Window);
            InputManager.Instance.Initialize(Window);
            SoundManager.Instance.Initialize(Window);
            Game.Instance.Initialize();
        }
        public static void Update(object sender, FrameEventArgs e) {
            float dTime = (float)e.Time;
            if (dTime > 1 / 60.0f) {
                dTime = 1 / 60.0f;
            }
            InputManager.Instance.Update();
            Game.Instance.Update(dTime);
        }
        public static void Render(object sender, FrameEventArgs e) {
            GraphicsManager.Instance.ClearScreen(System.Drawing.Color.CadetBlue);
            int FPS = (int)(1 / e.Time);
            Game.Instance.Render();
            GraphicsManager.Instance.DrawString("FPS", new Point((Window.Width / 4) + 5, 6), Color.Black);
            GraphicsManager.Instance.DrawString("FPS", new Point((Window.Width / 4) + 4, 5), Color.White);
            GraphicsManager.Instance.DrawString(System.Convert.ToString(FPS), new Point((Window.Width / 4) + 10, 20), Color.Black);
            GraphicsManager.Instance.DrawString(System.Convert.ToString(FPS), new Point((Window.Width / 4) + 9, 19), Color.White);
            GraphicsManager.Instance.SwapBuffers();
        }
        public static void Shutdown(object sender, EventArgs e) {
            Game.Instance.Shutdown();
            SoundManager.Instance.Shutdown();
            InputManager.Instance.Shutdown();
            TextureManager.Instance.Shutdown();
            GraphicsManager.Instance.Shutdown();
        }
        [STAThread]
        static void Main(string[] args) {
            Window = new OpenTK.GameWindow();
            Window.Title = "RayCaster";
            Window.ClientSize = new System.Drawing.Size(800, 600);
            Window.Load += new EventHandler<EventArgs>(Initialize);
            Window.UpdateFrame += new EventHandler<FrameEventArgs>(Update);
            Window.RenderFrame += new EventHandler<FrameEventArgs>(Render);
            Window.Unload += new EventHandler<EventArgs>(Shutdown);
            Window.Run(60.0f);
            Window.Dispose();
#if DEBUG
            Console.WriteLine("\nFinished executing, press any key to exit...");
            Console.ReadKey();
#endif
        }
    }
}
