using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorate
{
    class Person
    {
        public Person()
        {

        }
        private string name;
        public Person(string name)
        {
            this.name = name;
        }
        public virtual void show()
        {
            Console.WriteLine("裝扮{0}", this.name);
        }
    }
    class Finery : Person
    {
        protected Person component;

        public void Decorate(Person component)
        {
            this.component = component;
        }

        public override void show()
        {
            if(component != null)
            {
                component.show();
            }
        }
    }
    class TShirts:Finery
    {
        public override void show()
        {
            Console.Write("T Shirt");
            base.show();
        }
    }
    class BigTrouser : Finery
    {
        public override void show()
        {
            Console.Write("Pants collapse");
            base.show();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Kevin");
            BigTrouser bt = new BigTrouser();
            TShirts ts = new TShirts();


            bt.Decorate(person);
            ts.Decorate(bt);
            ts.show();
            Console.ReadLine();
        }
    }
}
