using System;
using System.Collections.Generic;

namespace cs
{
    interface IObserver
    {
        void Update(ISubject subject);
    }

    interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    class Subject : ISubject
    {
        public int State { get; set; } = 0;
        private List<IObserver> _observers = new List<IObserver>();
        public void Attach(IObserver observer)
        {        
            this._observers.Add(observer);
        }
         public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void RandomState(){
            this.State = new Random().Next(0, 10);
            Console.WriteLine("New State {0}", this.State);
            this.Notify();
        }   

    }
    
    class LessFiveObserver : IObserver
    {
        public void Update(ISubject subject)
        {            
            if ((subject as Subject).State < 5)
            {
                Console.WriteLine("State < 5");
            }
        }
    }

    class EvenObserver : IObserver
    {
        public void Update(ISubject subject)
        {            
            if ((subject as Subject).State % 2 == 0)
            {
                Console.WriteLine("State is even");
            }
        }
    }
}