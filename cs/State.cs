using System;
using System.Collections.Generic;
namespace cs
{
    class CashboxWithState
    {
        private Dictionary<string, Payment> payments= new Dictionary<string, Payment>();
        private string state;
       
        public CashboxWithState()
        {
            payments.Add("CASH", new CashPayment());
            payments.Add("CARD", new CardPayment());
            
        }

        public List<string> States
        {
            get
            {
                List<string> result = new List<string>();
                foreach (string state in this.payments.Keys)
                {
                    result.Add(state);
                }
                return result;
            }
        }    
        public string State {
            get {
                return this.state;
            }
            set{
                if (this.States.Contains(value))
                    this.state = value;
                else
                    throw new Exception("Unknown state");
            }
        }
        public bool TakePayment(double sum)
        {
            Payment payment;
            if (payments.TryGetValue(this.state, out payment))
            {
                return payment.Pay(sum);
            }
            return false;
        }

        
    }
}