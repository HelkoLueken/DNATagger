using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DNATagger {
    class Bar {
        private int startPos = 0;
        private int length = 0;
        private int endPos = 0;
        private int topPos = 0;
        private int height = 0;
        private int bottomPos = 0;
        private Brush color;
        private static Pen marker = new Pen(Color.Yellow, 3);
        private bool hidden = false;





        public Bar(Brush color){
            this.color = color;
        }



        public void setPosition(int startPos, int top, int length, int height){
            this.startPos = startPos;
            this.length = length;
            this.endPos = startPos + length;
            this.topPos = top;
            this.height = height;
            this.bottomPos = top + height;
            this.hidden = false;
        }



        public void setColor(Brush color){
            this.color = color;
        }



        public int getStartPos(){
            return this.startPos;
        }



        public int getEndPos() {
            return this.endPos;
        }



        public int getTopPos() {
            return this.topPos;
        }



        public int getBottomPos() {
            return this.bottomPos;
        }



        public bool isOnBar(int x, int y){
            if (x < startPos || x > endPos || y < topPos || y > bottomPos) return false;
            return true;
        }



        public void draw(System.Windows.Forms.Panel canvas){
            if (this.hidden) return;
            Graphics cxt = canvas.CreateGraphics();
            if (this.startPos > canvas.Width) return;
            if (this.endPos < -4) return;
            int beginVisible = this.startPos;
            if (this.startPos < -4) beginVisible = -4;
            int endVisible = this.endPos;
            if (endVisible > canvas.Width) endVisible = canvas.Width + 4;
            int lengthVisible = endVisible - beginVisible;

            cxt.FillRectangle(this.color, beginVisible, this.topPos, lengthVisible, this.height);
            cxt.DrawRectangle(Pens.Black, beginVisible, this.topPos, lengthVisible, this.height);

            cxt.Dispose();
        }



        public void drawHighlighted(System.Windows.Forms.Panel canvas) {
            Graphics cxt = canvas.CreateGraphics();
            this.draw(canvas);
            cxt.DrawRectangle(marker, this.startPos, length, this.topPos, this.height);
            cxt.Dispose();
        }



        public void hide(){
            this.hidden = true;
        }



        public bool isHidden(){
            return hidden;
        }
    }
}
