using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;
using OpenTK;
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
        private Game() {
        }
        public void Initialize() {

        }
        public void Update(float dTime) {

        }
        public void Render() {

        }
        public void Shutdown() {

        }
    }
}
