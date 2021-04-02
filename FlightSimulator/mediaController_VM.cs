using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FlightSimulator
{
    class mediaController_VM : INotifyPropertyChanged
    {
        private mediaController media;
        public event PropertyChangedEventHandler PropertyChanged;
        public mediaController_VM ()
        {
            this.media = mediaController.GetInstance;
            media.PropertyChanged += delegate (Object sender, System.ComponentModel.PropertyChangedEventArgs e) {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        public void VM_play()
        {
        //    if (media.isRunning == false)
         //   {
                media.play();
     //       }
        }
        public void VM_pause()
        {
            media.isRunning = false;
        }
        public void VM_goto(int precent)
        {
            double gotoLine = ((double)precent / 100) * media.numberOfLines;
            media.firstLine = (int)gotoLine;
            VM_play();
        }
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        }

        internal void VM_setSpeed(double newSpeed)
        {
            newSpeed = ((double)media.defaultSpeed / newSpeed);
            media.simulationSpeed = (int)newSpeed;
            VM_play();
        }

    public string VM_totalTime { get { return media.getTotalTime(); } }
           
        
   public string VM_currentTime { get { return media.getCurrentTime(); }}
      
   
    }
}
