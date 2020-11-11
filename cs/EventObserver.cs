using System;
//public delegate void EventHandler(object? sender, EventArgs e);

namespace  cs
{
    interface IEventSubject
    {
        void Attach(IEventObserver observer);
        void Detach(IEventObserver observer);
        void Notify();
    }

    interface IEventObserver
    {
        void Update(object Sender, EventArgs e);
    }

    class MyEventArgs : EventArgs{
        public string message ="No Message";
        public MyEventArgs(string message){
            this.message = message;
        }
    }

    class EventSubject : IEventSubject{
        private int state = 0;
        public int State { 
            get {
                return this.state;
            } 
            set {
                this.state = value;
                this.Notify();
            }
        } 
        public event EventHandler eventHandler;

        public void Attach(IEventObserver observer){
            this.eventHandler += observer.Update;
        }
        public void Detach(IEventObserver observer){
            this.eventHandler -= observer.Update;
        }

        public void Notify(){
            if (eventHandler != null)  {
                eventHandler(this, new MyEventArgs(String.Format("New state is {0}", this.state))); 
            } 
        }
        
        public void RandomState()
        {
           this.State = new Random().Next(0, 10);
        } 
    }


    class EventLessFiveObserver : IEventObserver{
        public void Update(object Sender, EventArgs e){
            if ((Sender as EventSubject).State < 5)
            {
                Console.WriteLine("State < 5");
                Console.WriteLine((e as MyEventArgs).message);
            }
        }
    }

    class EventEvenObserver : IEventObserver
    {
        public void Update(object Sender, EventArgs e)
        {                   
            if ((Sender as EventSubject).State % 2 == 0)
            {
                Console.WriteLine("State is even");
                Console.WriteLine((e as MyEventArgs).message);
            }
        }
    }
}
